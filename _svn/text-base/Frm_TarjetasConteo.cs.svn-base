using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace T3
{
    public partial class Frm_TarjetasConteo : Form
    {
        public Frm_TarjetasConteo()
        {
            InitializeComponent();
        }
        public Frm_TarjetasConteo(string _P_Str_Conteo)
        {
            InitializeComponent();
            _Mtd_TipoTarjetas(_P_Str_Conteo);
        }
        TextBox _Txt_Tarjeta = new TextBox();
        public Frm_TarjetasConteo(string _P_Str_Conteo,TextBox _P_Txt_Tarjeta)
        {
            InitializeComponent();
            _Txt_Tarjeta = _P_Txt_Tarjeta;
            _Mtd_TipoTarjetas(_P_Str_Conteo);
        }
        string _Str_SentenciaSQL;
        DataSet _Ds_DataSet = new DataSet();
        private void _Mtd_TipoTarjetas(string _Str_Conteo)
        {
            switch (_Str_Conteo)
            {
                case "1":
                    _Lbl_TipoTarjetas.Text += " sin usar 1er Conteo";
                    _Str_SentenciaSQL = "select id_tarjetainv as [N° Tarjeta],cproducto as [Código Producto],cnamef as [Descripción],cidproductod AS [Lote],dbo.Fnc_Formatear(cprecioventamax) AS PMV from VST_INVENTARIOFISICO WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND (cnousada = '0') and cconteo1=0";
                    break;
                case "2":
                    _Lbl_TipoTarjetas.Text += " sin usar 2do Conteo";
                    _Str_SentenciaSQL = "select id_tarjetainv as [N° Tarjeta],cproducto as [Código Producto],cnamef as [Descripción],cidproductod AS [Lote],dbo.Fnc_Formatear(cprecioventamax) AS PMV from VST_INVENTARIOFISICO WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND (cnousada = '0') and cconteo2=0";
                    break;
                case "3":
                    _Lbl_TipoTarjetas.Text += " sin usar 3er Conteo";
                    _Str_SentenciaSQL = "select id_tarjetainv as [N° Tarjeta],cproducto as [Código Producto],cnamef as [Descripción],cidproductod AS [Lote],dbo.Fnc_Formatear(cprecioventamax) AS PMV from VST_INVENTARIOFISICO WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND (cnousada = '0') and cconteo3=0 and (cdiferencaj>0 or cdiferenunid>0)";
                    break;
            }
            _Ds_DataSet = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_SentenciaSQL);
            _Dtg_Tarjetas.DataSource = _Ds_DataSet.Tables[0].DefaultView;
            _Dtg_Tarjetas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            _Dtg_Tarjetas.Columns["PMV"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            _Dtg_Tarjetas.Columns["Descripción"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        private void _Dtg_Tarjetas_MouseEnter(object sender, EventArgs e)
        {
            _Lbl_DgInfo.Visible = true;
        }

        private void _Dtg_Tarjetas_MouseLeave(object sender, EventArgs e)
        {
            _Lbl_DgInfo.Visible = false;
        }

        private void _Dtg_Tarjetas_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (_Dtg_Tarjetas.CurrentCell != null)
            {
                if (e.RowIndex != -1)
                {
                    _Txt_Tarjeta.Text = Convert.ToString(_Dtg_Tarjetas.Rows[e.RowIndex].Cells[0].Value);
                    this.Close();
                }
            }
        }

        private void Frm_TarjetasConteo_Load(object sender, EventArgs e)
        {

        }
    }
}