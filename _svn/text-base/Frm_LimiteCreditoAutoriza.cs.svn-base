using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace T3
{
    public partial class Frm_LimiteCreditoAutoriza : Form
    {
        public Frm_LimiteCreditoAutoriza()
        {
            InitializeComponent();
            _Mtd_Actualizar();
        }
        private void _Mtd_Actualizar()
        {
            DataSet _Ds2 = new DataSet();
            string _Str_Cadena = "Select ccodlimite,dbo.Fnc_Formatear(climtehasta) as climtehasta from TLIMITCREDITO";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            object[] _Ob = new object[6];
            foreach (DataRow _Row in _Ds.Tables[0].Rows)
            {
                _Ob[0] = _Row[0].ToString();
                _Ob[1] = _Row[1].ToString();
                _Ob[2] = "";
                _Str_Cadena = "Select cusereditor,cuseraprobador from TLIMITCREDITOP where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and ccompany='" + Frm_Padre._Str_Comp + "' and ccodlimite='" + _Row[0].ToString() + "'";
                _Ds2 = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                if (_Ds2.Tables[0].Rows.Count > 0)
                {
                    _Ob[3] = _Ds2.Tables[0].Rows[0][0].ToString();
                    _Ob[5] = _Ds2.Tables[0].Rows[0][1].ToString();
                }
                else
                {
                    _Ob[3] = "";
                    _Ob[5] = "";
                }
                _Ob[4] = "";
                _Dg_Grid.Rows.Add(_Ob);
            }
        }
        public bool _Mtd_Guardar()
        {
            string _Str_Cadena = "";
            DataSet _Ds = new DataSet();
            foreach (DataGridViewRow _Dg_Row in _Dg_Grid.Rows)
            {
                _Str_Cadena = "Select * from TLIMITCREDITOP where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccodlimite='" + _Dg_Row.Cells[0].Value + "'";
                _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                if (_Ds.Tables[0].Rows.Count == 0)
                {
                    if (_Dg_Row.Cells["cuser_Editor"].Value.ToString() != "0" | _Dg_Row.Cells["cuser_Aprobador"].Value.ToString() != "0")
                    _Str_Cadena = "Insert into TLIMITCREDITOP (cgroupcomp,ccodlimite,cusereditor,cuseraprobador,cdateadd,cuseradd,cdelete) values ('" + Frm_Padre._Str_GroupComp + "','" + _Dg_Row.Cells[0].Value + "','" + _Dg_Row.Cells["cuser_Editor"].Value + "','" + _Dg_Row.Cells["cuser_Aprobador"].Value + "',GETDATE(),'" + Frm_Padre._Str_Use + "','0')"; 
                }
                else
                { _Str_Cadena = "Update TLIMITCREDITOP set cusereditor='" + _Dg_Row.Cells["cuser_Editor"].Value + "',cuseraprobador='" + _Dg_Row.Cells["cuser_Aprobador"].Value + "',cdateupd=GETDATE(),cuserupd='" + Frm_Padre._Str_Use + "',cdelete='0' where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccodlimite='" + _Dg_Row.Cells[0].Value + "'"; }
                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
            }
            MessageBox.Show("La operación fue realizada correctamente","Información",MessageBoxButtons.OK,MessageBoxIcon.Information);
            return false;
        }
        private void Frm_LimiteCreditoAutoriza_Load(object sender, EventArgs e)
        {

        }

        private void _Dg_Grid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (_Dg_Grid.CurrentCell != null)
            {
                if (e.ColumnIndex == 2)
                {
                    TextBox _Txt_TemporalCod = new TextBox();
                    TextBox _Txt_TemporalDes = new TextBox();
                    Frm_Busqueda2 _Frm = new Frm_Busqueda2(12, _Txt_TemporalCod, _Txt_TemporalDes, 0, 1, "");
                    _Frm.ShowDialog(this);
                    //-----------------------------
                    if (_Txt_TemporalCod.Text.Trim().Length > 0)
                    {
                        _Dg_Grid.Rows[e.RowIndex].Cells[3].Value = _Txt_TemporalCod.Text.Trim();
                    }
                }
                else if (e.ColumnIndex == 4)
                {
                    TextBox _Txt_TemporalCod = new TextBox();
                    TextBox _Txt_TemporalDes = new TextBox();
                    Frm_Busqueda2 _Frm = new Frm_Busqueda2(12, _Txt_TemporalCod, _Txt_TemporalDes, 0, 1, "");
                    _Frm.ShowDialog(this);
                    //-----------------------------
                    if (_Txt_TemporalCod.Text.Trim().Length > 0)
                    {
                        _Dg_Grid.Rows[e.RowIndex].Cells[5].Value = _Txt_TemporalCod.Text.Trim();
                    }
                }
            }
        }

        private void Frm_LimiteCreditoAutoriza_Activated(object sender, EventArgs e)
        {
            CONTROLES._Ctrl_Buscar._Txt_TpoFind.Text = "PA";
            CONTROLES._Ctrl_Buscar._Bl_Modifi = false;
            CONTROLES._Ctrl_Buscar._Bl_Especial = true;
            CONTROLES._Ctrl_Buscar._Bol_SoloNuevo = false;
            CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "";
            CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "Abierto";
            CONTROLES._Ctrl_Buscar._frm_Formulario = this;
            ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_guardar2.Enabled = true;
            ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_borrar2.Enabled = false;
            ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_editar2.Enabled = false;
            ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_nuevo2.Enabled = false;
            ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_cancelar2.Enabled = false;
        }

        private void Frm_LimiteCreditoAutoriza_FormClosing(object sender, FormClosingEventArgs e)
        {
            CONTROLES._Ctrl_Buscar._Bl_Especial = false;
            CONTROLES._Ctrl_Buscar._Bol_SoloNuevo = false;
            CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "";
            CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "Cerrado";
        }
    }
}