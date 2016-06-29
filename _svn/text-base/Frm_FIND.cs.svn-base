using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace T3
{
    public partial class Frm_FIND : Form
    {
        public Frm_FIND(string[] _Pr_Str_CamposFiltro, string[] _Pr_Str_CamposFiltroName, string[] _Pr_Str_CamposFiltroType, string[] _Pr_Str_CamposFiltroStyle, string _Pr_Str_SqlLista)
        {
            InitializeComponent();
            _Str_CamposFiltro = _Pr_Str_CamposFiltro;
            _Str_CamposFiltroName = _Pr_Str_CamposFiltroName;
            _Str_CamposFiltroType = _Pr_Str_CamposFiltroType;
            _Str_CamposFiltroStyle = _Pr_Str_CamposFiltroStyle;
            _Str_SqlLista = _Pr_Str_SqlLista;
        }

        public string _Str_Result="";
        public string _Str_SqlLista = "";
        public static string[] _Str_CamposFiltro;
        public static string[] _Str_CamposFiltroName;
        public static string[] _Str_CamposFiltroType;
        public static string[] _Str_CamposFiltroStyle;
        Control[] _Ctrl_Controles = new Control[3];

        private void Frm_FIND_Load(object sender, EventArgs e)
        {
            _Cb_Opt.Items.AddRange(_Str_CamposFiltroName);
            _Dt_Desde.Value = CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate();
            _Dt_Fecha.Value = CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate();
            _Dt_Hasta.Value = CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate();
            _Dt_Hasta.MinDate = CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate();
            _Ctrl_Controles[0] = _Txt_Valor;
            _Ctrl_Controles[1] = _Txt_Desde;
            _Ctrl_Controles[2] = _Txt_Hasta;
            CLASES._Cls_Varios_Metodos _Cls_CL = new CLASES._Cls_Varios_Metodos(_Ctrl_Controles);
            _Cls_CL._Mtd_Foco();
        }

        private void _Cb_Opt_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_Cb_Opt.SelectedItem != null)
            {
                if (Convert.ToString(_Cb_Opt.SelectedItem) == "Todos")
                { _Bt_Ok.PerformClick(); }
                else
                {
                    switch (_Str_CamposFiltroType[_Cb_Opt.SelectedIndex])
                    {
                        case "text":
                            _Pn_Fecha.Visible = false;
                            _Pn_FechaRango.Visible = false;
                            _Pn_Bool.Visible = false;
                            if (_Str_CamposFiltroStyle[_Cb_Opt.SelectedIndex] == "F")
                            {
                                _Txt_Valor.Text = "";
                                _Pn_TextRango.Visible = false;
                                _Txt_Valor.Visible = true;
                                _Txt_Valor.Enabled = true;
                                _Cb_Lista.Visible = false;
                            }
                            else
                            {
                                _Txt_Desde.Text = "";
                                _Txt_Hasta.Text = "";
                                _Pn_TextRango.Visible = true;
                                _Txt_Valor.Visible = false;
                                _Txt_Desde.Enabled = true;
                                _Txt_Hasta.Enabled = true;
                                _Cb_Lista.Visible = false;
                            }
                            break;
                        case "varchar":
                            _Pn_Fecha.Visible = false;
                            _Pn_FechaRango.Visible = false;
                            _Pn_Bool.Visible = false;
                            if (_Str_CamposFiltroStyle[_Cb_Opt.SelectedIndex] == "F")
                            {
                                _Txt_Valor.Text = "";
                                _Pn_TextRango.Visible = false;
                                _Txt_Valor.Visible = true;
                                _Txt_Valor.Enabled = true;
                                _Cb_Lista.Visible = false;
                            }
                            else
                            {
                                if (_Str_CamposFiltroStyle[_Cb_Opt.SelectedIndex] == "R")
                                {
                                    _Txt_Desde.Text = "";
                                    _Txt_Hasta.Text = "";
                                    _Pn_TextRango.Visible = true;
                                    _Txt_Valor.Visible = false;
                                    _Txt_Desde.Enabled = true;
                                    _Txt_Hasta.Enabled = true;
                                    _Cb_Lista.Visible = false;
                                }
                                else
                                {
                                    if (_Str_CamposFiltroStyle[_Cb_Opt.SelectedIndex] == "L")
                                    {
                                        DataSet _Ds;
                                        _Cb_Lista.DataSource = null;
                                        _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_SqlLista);
                                        _Cb_Lista.DataSource = _Ds.Tables[0];
                                        _Cb_Lista.DisplayMember = _Ds.Tables[0].Columns[1].ColumnName;
                                        _Cb_Lista.ValueMember = _Ds.Tables[0].Columns[0].ColumnName;
                                        _Cb_Lista.Visible = true;
                                        _Pn_TextRango.Visible = false;
                                        _Txt_Valor.Visible = false;
                                    }
                                }
                            }
                            break;
                        case "datetime":
                            _Dt_Desde.Value = CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate();
                            _Dt_Fecha.Value = CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate();
                            _Dt_Hasta.Value = CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate();
                            _Pn_Bool.Visible = false;
                            _Pn_TextRango.Visible = false;
                            _Txt_Valor.Visible = false;
                            if (_Str_CamposFiltroStyle[_Cb_Opt.SelectedIndex] == "F")
                            {
                                _Pn_Fecha.Visible = true;
                                _Pn_FechaRango.Visible = false;
                                _Cb_Lista.Visible = false;
                            }
                            else
                            {
                                _Pn_Fecha.Visible = false;
                                _Pn_FechaRango.Visible = true;
                                _Dt_Desde.Enabled = true;
                                _Dt_Hasta.Enabled = true;
                                _Cb_Lista.Visible = false;
                            }
                            break;
                        case "bool":
                            _Rb_No.Checked = false;
                            _Rb_Si.Checked = false;
                            _Pn_Fecha.Visible = true;
                            _Pn_FechaRango.Visible = false;
                            _Pn_TextRango.Visible = false;
                            _Txt_Valor.Visible = false;
                            _Cb_Lista.Visible = false;
                            if (_Str_CamposFiltroStyle[_Cb_Opt.SelectedIndex] == "F")
                            {
                                _Pn_Bool.Visible = true;
                            }
                            break;
                        case "todos":
                            _Bt_Ok.PerformClick();
                            break;
                        case "numero":

                            break;
                        default:
                            break;
                    }
                }
            }
        }

        private void _Bt_Ok_Click(object sender, EventArgs e)
        {
            if (_Cb_Opt.SelectedItem != null)
            {
                if (Convert.ToString(_Cb_Opt.SelectedItem) == "Todos")
                { _Str_Result = ""; }
                else
                {
                    switch (_Str_CamposFiltroType[_Cb_Opt.SelectedIndex])
                    {
                        case "text":
                            if (_Str_CamposFiltroStyle[_Cb_Opt.SelectedIndex] == "F")
                            {
                                _Str_Result = _Str_CamposFiltro[_Cb_Opt.SelectedIndex] + " LIKE '%" + _Txt_Valor.Text.ToUpper() + "%'";
                            }
                            else
                            {
                                _Str_Result = _Str_CamposFiltro[_Cb_Opt.SelectedIndex] + " BETWEEN '" + _Txt_Desde.Text.ToUpper() + "' AND '" + _Txt_Hasta.Text.ToUpper() + "'";
                            }
                            break;
                        case "varchar":
                            if (_Str_CamposFiltroStyle[_Cb_Opt.SelectedIndex] == "F")
                            {
                                _Str_Result = _Str_CamposFiltro[_Cb_Opt.SelectedIndex] + "='" + _Txt_Valor.Text.ToUpper() + "'";
                            }
                            else
                            {
                                if (_Str_CamposFiltroStyle[_Cb_Opt.SelectedIndex] == "R")
                                {
                                    _Str_Result = _Str_CamposFiltro[_Cb_Opt.SelectedIndex] + " BETWEEN '" + _Txt_Desde.Text.ToUpper() + "' AND '" + _Txt_Hasta.Text.ToUpper() + "'";
                                }
                                else
                                {
                                    if (_Str_CamposFiltroStyle[_Cb_Opt.SelectedIndex] == "L")
                                    {
                                        _Str_Result = _Str_CamposFiltro[_Cb_Opt.SelectedIndex] + "='" + Convert.ToString(_Cb_Lista.SelectedItem) + "'";
                                    }
                                }
                            }
                            break;
                        case "datetime":
                            if (_Str_CamposFiltroStyle[_Cb_Opt.SelectedIndex] == "F")
                            {
                                _Pn_Fecha.Visible = true;
                                _Str_Result = _Str_CamposFiltro[_Cb_Opt.SelectedIndex] + "='" + _Dt_Fecha.Value.ToShortDateString() + "'";
                            }
                            else
                            {
                                _Str_Result = _Str_CamposFiltro[_Cb_Opt.SelectedIndex] + " BETWEEN '" + _Dt_Desde.Value.ToShortDateString() + "' AND '" + _Dt_Hasta.Value.ToShortDateString() + "'";
                            }
                            break;
                        case "bool":
                            if (_Str_CamposFiltroStyle[_Cb_Opt.SelectedIndex] == "F")
                            {
                                if (_Rb_Si.Checked)
                                {
                                    _Str_Result = _Str_CamposFiltro[_Cb_Opt.SelectedIndex] + "=1";
                                }
                                else
                                {
                                    _Str_Result = _Str_CamposFiltro[_Cb_Opt.SelectedIndex] + "=0";
                                }
                            }
                            break;
                        case "todos":
                            _Str_Result = "";
                            break;
                        case "numero":

                            break;
                        default:
                            break;
                    }
                }
                
                if (_Str_Result != "")
                {
                    _Str_Result = " AND " + _Str_Result + " Order By " + _Str_CamposFiltro[_Cb_Opt.SelectedIndex];
                }
                else
                {
                    _Str_Result = _Str_Result + " Order By " + _Str_CamposFiltro[0];
                }
            }
            this.Hide();
        }

        private void _Bt_Cancel_Click(object sender, EventArgs e)
        {
            _Str_Result = "";
            this.Hide();
        }

        private void _Dt_Desde_ValueChanged(object sender, EventArgs e)
        {
            if (_Dt_Desde.Value > _Dt_Hasta.Value)
            {
                _Dt_Hasta.Value = _Dt_Desde.Value;
                _Dt_Hasta.MinDate = _Dt_Desde.Value;
            }
        }
    }
}