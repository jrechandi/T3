using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace T3
{
    public partial class Frm_EstatusBackOrder : Form
    {
        public int _Int_Fecha = 0;
        string _Str_ThisText = "";
        DateTime _Dtm_FechaInicial = new DateTime(); // El valor de esta variable es cambiado por los metodos de fecha
        DateTime _Dtm_FechaFinal = new DateTime(); // El valor de esta variable es cambiado por los metodos de fecha
        public Frm_EstatusBackOrder()
        {
            InitializeComponent();
            _Str_ThisText = this.Text;
            _Mtd_Color_Estandar(this);
            _Mtd_Actualizar(_Int_Fecha);
        }
        private void _Mtd_Color_Estandar(Control _P_Ctrl_Control)
        {
            foreach (Control _Ctrl in _P_Ctrl_Control.Controls)
            {
                if (_Ctrl.Controls.Count > 0)
                {
                    _Mtd_Color_Estandar(_Ctrl);
                }
                else
                {
                    new CLASES._Cls_Varios_Metodos(new Control[] { _Ctrl })._Mtd_Foco();
                }
            }
        }
        private DateTime _Mtd_FechaUltimaSemana()
        {
            DateTime _Dtm_FechaActual = new DateTime(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate().Year, CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate().Month, CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate().Day);
            for (int _Int_I = 0; _Int_I <= 31; _Int_I++)
            {
                if (_Dtm_FechaActual.AddDays(-_Int_I).DayOfWeek == DayOfWeek.Monday)
                { return _Dtm_FechaActual.AddDays(-_Int_I); }
            }
            return _Dtm_FechaActual;
        }
        private void _Mtd_MesActual()
        {
            _Int_Fecha = 1;
            string _Str_Cadena = "";
            _Str_Cadena = "select convert(varchar,cdiafecha,103) as cdiafecha from TCALENDVTA WHERE " + _Mtd_Exists() + " and canocalend='" + CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate().Year.ToString() + "' and cmesubicado ='" + CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate().Month.ToString() + "' order by convert(datetime,cdiafecha) asc";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            string _Str_DiaI = "";
            string _Str_DiaF = "";
            if (_Ds.Tables[0].Rows.Count > 0)
            { _Str_DiaI = _Ds.Tables[0].Rows[0]["cdiafecha"].ToString(); _Dtm_FechaInicial = Convert.ToDateTime(_Str_DiaI); }
            if (_Ds.Tables[0].Rows.Count > 0)
            { _Str_DiaF = _Ds.Tables[0].Rows[_Ds.Tables[0].Rows.Count - 1]["cdiafecha"].ToString(); _Dtm_FechaFinal = Convert.ToDateTime(_Str_DiaF).AddDays(1); }
            if (_Str_DiaI.Trim().Length == 0)
            { _Int_Fecha = 0; }
        }
        private void _Mtd_SemanaActual()
        {
            _Int_Fecha = 2;
            string _Str_Cadena = "";
            _Str_Cadena = "select convert(varchar,cdiafecha,103) as cdiafecha from TCALENDVTA WHERE " + _Mtd_Exists() + " and canocalend='" + CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate().Year.ToString() + "' and cmesubicado ='" + CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate().Month.ToString() + "' and cdiafecha>'" + new clslibraryconssa._Cls_Formato("es-VE")._Mtd_fecha(_Mtd_FechaUltimaSemana()) + "' order by convert(datetime,cdiafecha) asc";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            string _Str_DiaI = "";
            string _Str_DiaF = "";
            if (_Ds.Tables[0].Rows.Count > 0)
            { _Str_DiaI = _Ds.Tables[0].Rows[0]["cdiafecha"].ToString(); _Dtm_FechaInicial = Convert.ToDateTime(_Str_DiaI); }
            if (_Ds.Tables[0].Rows.Count > 0)
            { _Str_DiaF = _Ds.Tables[0].Rows[_Ds.Tables[0].Rows.Count - 1]["cdiafecha"].ToString(); _Dtm_FechaFinal = Convert.ToDateTime(_Str_DiaF).AddDays(1); }
            if (_Str_DiaI.Trim().Length == 0)
            { _Int_Fecha = 0; }
        }
        private void _Mtd_Hoy()
        {
            _Int_Fecha = 3;
            _Dtm_FechaInicial = CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate();
            _Dtm_FechaFinal = _Dtm_FechaInicial;
        }
        private void _Mtd_Rango(DateTime _P_Dtm_FechaDesde, DateTime _P_Dtm_FechaHasta)
        {
            _Int_Fecha = 4;
            string _Str_Cadena = "";
            _Str_Cadena = "select convert(varchar,cdiafecha,103) as cdiafecha from TCALENDVTA WHERE " + _Mtd_Exists() + " and cdiafecha between '" + new clslibraryconssa._Cls_Formato("es-VE")._Mtd_fecha(_P_Dtm_FechaDesde) + "' and +'" + new clslibraryconssa._Cls_Formato("es-VE")._Mtd_fecha(_P_Dtm_FechaHasta) + "' order by convert(datetime,cdiafecha) asc";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            string _Str_DiaI = "";
            string _Str_DiaF = "";
            if (_Ds.Tables[0].Rows.Count > 0)
            { _Str_DiaI = _Ds.Tables[0].Rows[0]["cdiafecha"].ToString(); _Dtm_FechaInicial = Convert.ToDateTime(_Str_DiaI); }
            if (_Ds.Tables[0].Rows.Count > 0)
            { _Str_DiaF = _Ds.Tables[0].Rows[_Ds.Tables[0].Rows.Count - 1]["cdiafecha"].ToString(); _Dtm_FechaFinal = Convert.ToDateTime(_Str_DiaF).AddDays(1); }
            if (_Str_DiaI.Trim().Length == 0)
            { _Int_Fecha = 0; }
        }
        private string _Mtd_Exists()
        {
            return "(NOT EXISTS  (SELECT * FROM TCALENDVTAEX WHERE CONVERT(varchar, TCALENDVTAEX.cdia, 103) = CONVERT(varchar, TCALENDVTA.cdiafecha, 103) AND TCALENDVTAEX.ccompany='" + Frm_Padre._Str_Comp + "'))";
        }
        private void Frm_EstatusBackOrder_Load(object sender, EventArgs e)
        {
            this.Dock = DockStyle.Fill;
            _Pnl_Rango.Left = (this.Width / 2) - (_Pnl_Rango.Width / 2);
            _Pnl_Rango.Top = (this.Height / 2) - (_Pnl_Rango.Height / 2);
            _Dtp_FechDesde.Value = CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate();
            _Dtp_FechHasta.Value = CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate().AddDays(1);
            _Dg_Grid.ClearSelection();
        }
        public void _Mtd_Actualizar(int _P_Int_Fecha)
        {
            string _Str_Cadena = "";
            if (_P_Int_Fecha != 0)
            {
                if (_Dtm_FechaInicial == _Dtm_FechaFinal)
                {
                    _Str_Cadena = "Select convert(varchar, c_fecha_pedido,103) as c_fecha_pedido,datediff(dd,c_fecha_pedido,getdate()) as Dias,cpedido,convert(varchar,ccliente)+' - '+ c_nomb_comer as c_nomb_comer,cempaques,ccliente,cvendedor,cname,cunidades from VST_CONSULTABACKORDER where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and ccompany='" + Frm_Padre._Str_Comp + "' AND convert(varchar, c_fecha_pedido,103)='" + new clslibraryconssa._Cls_Formato("es-VE")._Mtd_fecha(_Dtm_FechaInicial) + "' order by cpedido,c_fecha_pedido DESC";
                }
                else
                {
                    _Str_Cadena = "Select convert(varchar, c_fecha_pedido,103) as c_fecha_pedido,datediff(dd,c_fecha_pedido,getdate()) as Dias,cpedido,convert(varchar,ccliente)+' - '+ c_nomb_comer as c_nomb_comer,cempaques,ccliente,cvendedor,cname,cunidades from VST_CONSULTABACKORDER where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and ccompany='" + Frm_Padre._Str_Comp + "' AND c_fecha_pedido between '" + new clslibraryconssa._Cls_Formato("es-VE")._Mtd_fecha(_Dtm_FechaInicial) + "' and '" + new clslibraryconssa._Cls_Formato("es-VE")._Mtd_fecha(_Dtm_FechaFinal) + "' order by cpedido,c_fecha_pedido DESC";
                }
            }
            else
            {
                _Str_Cadena = "Select convert(varchar, c_fecha_pedido,103) as c_fecha_pedido,datediff(dd,c_fecha_pedido,getdate()) as Dias,cpedido,convert(varchar,ccliente)+' - '+ c_nomb_comer as c_nomb_comer,cempaques,ccliente,cvendedor,cname,cunidades from VST_CONSULTABACKORDER where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and ccompany='" + Frm_Padre._Str_Comp + "' order by cpedido,c_fecha_pedido DESC";
            }
            Cursor = Cursors.WaitCursor;
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            _Dg_Grid.DataSource = _Ds.Tables[0];
            _Dg_Grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            Cursor = Cursors.Default;
            _Dg_Grid.ClearSelection();
            //--------------------------------------------------------------------
            string _Str_FechaSeleccion = "";
            if (_P_Int_Fecha == 0)
            { _Str_FechaSeleccion = " (Todos)"; }
            else if (_P_Int_Fecha == 1)
            { _Str_FechaSeleccion = " (Mes actual)"; }
            else if (_P_Int_Fecha == 2)
            { _Str_FechaSeleccion = " (Semana actual)"; }
            else if (_P_Int_Fecha == 3)
            { _Str_FechaSeleccion = " (Hoy)"; }
            else if (_P_Int_Fecha == 4)
            { _Str_FechaSeleccion = " (Del período " + new clslibraryconssa._Cls_Formato("es-VE")._Mtd_fecha(_Dtm_FechaInicial) + " - " + new clslibraryconssa._Cls_Formato("es-VE")._Mtd_fecha(_Dtm_FechaFinal) + ")"; }
            this.Text = _Str_ThisText + _Str_FechaSeleccion; 
        }

        private void _Dg_Grid_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            //TimeSpan _Tsm = new TimeSpan();
            //if (_Dg_Grid.Rows[e.RowIndex].Cells["c_fecha_pedido"].Value.ToString().Trim().Length > 0)
            //{
              //  _Tsm = CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate() - Convert.ToDateTime(_Dg_Grid.Rows[e.RowIndex].Cells["c_fecha_pedido"].Value);
                //_Dg_Grid.Rows[e.RowIndex].Cells["Dias"].Value = _Tsm.Days;
            //}
        }

        private void _Tool_Todos_Click(object sender, EventArgs e)
        {
            _Int_Fecha = 0;
            Cursor = Cursors.WaitCursor;
            _Mtd_Actualizar(_Int_Fecha);
            Cursor = Cursors.Default;
        }

        private void _Tool_Mes_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            _Mtd_MesActual();
            _Mtd_Actualizar(_Int_Fecha);
            Cursor = Cursors.Default;
        }

        private void _Tool_Semana_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            _Mtd_SemanaActual();
            _Mtd_Actualizar(_Int_Fecha);
            Cursor = Cursors.Default;
        }

        private void _Tool_Hoy_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            _Mtd_Hoy();
            _Mtd_Actualizar(_Int_Fecha);
            Cursor = Cursors.Default;
        }

        private void _Tool_Periodo_Click(object sender, EventArgs e)
        {
            _Pnl_Rango.Visible = true;
        }

        private void _Pnl_Rango_VisibleChanged(object sender, EventArgs e)
        {
            if (_Pnl_Rango.Visible)
            { _Tool_Principal.Enabled = false; _Dg_Grid.Enabled = false; _Dtp_FechDesde.Focus(); }
            else
            { _Tool_Principal.Enabled = true; _Dg_Grid.Enabled = true; }
        }

        private void _Dtp_FechDesde_ValueChanged(object sender, EventArgs e)
        {
            if (_Dtp_FechDesde.Value >= _Dtp_FechHasta.Value)
            {
                _Dtp_FechHasta.Value = _Dtp_FechDesde.Value.AddDays(1);
            }
        }

        private void _Bt_Cancelar_Click(object sender, EventArgs e)
        {
            _Pnl_Rango.Visible = false;
        }

        private void _Bt_Aceptar_Click(object sender, EventArgs e)
        {
            _Mtd_Rango(_Dtp_FechDesde.Value, _Dtp_FechHasta.Value);
            _Pnl_Rango.Visible = false;
            _Mtd_Actualizar(_Int_Fecha);
        }

        private void _Cntx_Menu_Opening(object sender, CancelEventArgs e)
        {
            if (_Dg_Grid.CurrentCell == null)
            { e.Cancel = true; }
        }

        private void verDetalleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frm_EstatusBackOrderDetalle _Frm = new Frm_EstatusBackOrderDetalle(_Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells["cpedido"].Value.ToString().Trim(), _Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells["ccliente"].Value.ToString().Trim(),
                                                                             _Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells["c_nomb_comer"].Value.ToString().Trim(), _Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells["cvendedor"].Value.ToString().Trim(),
                                                                             _Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells["cname"].Value.ToString().Trim(), Convert.ToDouble(_Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells["cempaques"].Value.ToString().Trim()),
                                                                             Convert.ToDouble(_Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells["cunidades"].Value.ToString().Trim()), _Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells["c_fecha_pedido"].Value.ToString().Trim());
            _Frm.ShowDialog(this);
        }

        private void Frm_EstatusBackOrder_Activated(object sender, EventArgs e)
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
    }
}