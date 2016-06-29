using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace T3
{
    public partial class Frm_LimiteCreditoAutorizaN : Form
    {
        public Frm_LimiteCreditoAutorizaN()
        {
            InitializeComponent();
        }
        CLASES._Cls_Varios_Metodos myUtilidad = new CLASES._Cls_Varios_Metodos(true);
        clslibraryconssa._Cls_Formato _Cls_Formato = new clslibraryconssa._Cls_Formato("es-VE");
        string _Str_FrmUsuCod = "";
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
        
        private void _Mtd_CargarLimites()
        {
            string _Str_Sql = "SELECT ccodlimite,cdescripcion FROM TLIMITCREDITO WHERE cdelete=0";
            myUtilidad._Mtd_CargarCombo(_Cb_LimCredito, _Str_Sql);
        }
        public void _Mtd_Ini()
        {
            _Str_FrmUsuCod = "";
            _Txt_Usuario.Text = "";
            _Txt_MaxPorcSobre.Text = "";
            _Cb_LimCredito.SelectedIndex = -1;
        }
        private void _Mtd_CargarData(string _Pr_Str_User, string _Pr_Str_IdLimite)
        {
            double _Dbl_PorcSobreGiro = 0;
            string _Str_Sql = "SELECT * FROM VST_LIMITEUSER WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND cuser='" + _Pr_Str_User + "' AND ccodlimite='" + _Pr_Str_IdLimite + "'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                _Str_FrmUsuCod = _Pr_Str_User;
                _Txt_Usuario.Text = _Ds.Tables[0].Rows[0]["cusername"].ToString();
                _Cb_LimCredito.SelectedValue = _Ds.Tables[0].Rows[0]["ccodlimite"].ToString();
                if (Convert.ToString(_Ds.Tables[0].Rows[0]["caprobasobregiro"]) != "")
                {
                    _Dbl_PorcSobreGiro = Convert.ToDouble(_Ds.Tables[0].Rows[0]["caprobasobregiro"]);
                }
                _Txt_MaxPorcSobre.Text = _Dbl_PorcSobreGiro.ToString("#,##0.00");
            }
        }
        private void _Mtd_Actualizar()
        {
            string _Str_Sql = "SELECT ccodlimite,cuser,(cuser+'-'+CONVERT(VARCHAR,cname)) as Usuario,cdescripcion as Límite,caprobasobregiro as [S. Giro] FROM VST_LIMITEUSER WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
            _Dg_Grid.DataSource = _Ds.Tables[0];
            _Dg_Grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            _Dg_Grid.Columns[0].Visible = false;
            _Dg_Grid.Columns[1].Visible = false;
        }
        private void Frm_LimiteCreditoAutorizaN_Load(object sender, EventArgs e)
        {
            _Mtd_Color_Estandar(this);
            _Mtd_Ini();
            _Mtd_Actualizar();
        }

        private void Frm_LimiteCreditoAutorizaN_FormClosing(object sender, FormClosingEventArgs e)
        {
            CONTROLES._Ctrl_Buscar._txt_text.Text = "";
            CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "Cerrado";
        }

        private void Frm_LimiteCreditoAutorizaN_Activated(object sender, EventArgs e)
        {
            CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "";
            CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "Cerrado";
        }

        private void _Btn_FindUsuario_Click(object sender, EventArgs e)
        {
            TextBox _Txt_TemporalCod = new TextBox();
            TextBox _Txt_TemporalDes = new TextBox();
            Frm_Busqueda2 _Frm = new Frm_Busqueda2(12, _Txt_TemporalCod, _Txt_TemporalDes, 0, 1, "");
            _Frm.ShowDialog(this);
            //-----------------------------
            if (_Txt_TemporalCod.Text.Trim().Length > 0)
            {
                _Str_FrmUsuCod = _Txt_TemporalCod.Text.Trim();
                _Txt_Usuario.Text = _Txt_TemporalDes.Text;
                _Cb_LimCredito.Enabled = true;
                _Txt_MaxPorcSobre.Enabled = true;
                _Mtd_CargarLimites();
                _Txt_MaxPorcSobre.Text = "0";
                string _Str_Cadena = "Select ccodlimite,caprobasobregiro from TLIMITCREDITOP where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND cuser='" + _Str_FrmUsuCod + "'";
                DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                if (_Ds.Tables[0].Rows.Count > 0)
                {
                    if (_Ds.Tables[0].Rows[0][0] != System.DBNull.Value)
                    {
                        _Cb_LimCredito.SelectedValue = _Ds.Tables[0].Rows[0][0];
                    }
                    if (_Ds.Tables[0].Rows[0][1] != System.DBNull.Value)
                    {
                        _Txt_MaxPorcSobre.Text = Convert.ToDouble(_Ds.Tables[0].Rows[0][1].ToString()).ToString("#,##0.00");
                    }
                }
            }
        }

        private void _Txt_MaxPorcSobre_KeyPress(object sender, KeyPressEventArgs e)
        {
            myUtilidad._Mtd_Valida_Numeros(_Txt_MaxPorcSobre, e, 3, 2);
        }

        private void _Txt_MaxPorcSobre_TextChanged(object sender, EventArgs e)
        {
            if (_Txt_MaxPorcSobre.Text != "")
            {
                double _Dbl_Monto = Convert.ToDouble(_Txt_MaxPorcSobre.Text);
                if (_Dbl_Monto > 100)
                {
                    _Txt_MaxPorcSobre.Text = "100";
                }
            }
        }
        private bool _Mtd_ExisteUsuarioLimite(string _Pr_Str_IdUser, string _Pr_Str_IdLimite)
        {
            bool _Bol_R = false;
            string _Str_Sql = "SELECT * FROM TLIMITCREDITOP WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND cuser='" + _Pr_Str_IdUser + "' AND ccodlimite='" + _Pr_Str_IdLimite + "'";
            if (Program._MyClsCnn._mtd_conexion._Mtd_ExistenRegistros(_Str_Sql))
            {
                _Bol_R = true;
            }
            return _Bol_R;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _Er_Error.Dispose();
            string _Str_Lim = "";
            if (_Txt_MaxPorcSobre.Text.Trim().Length == 0)
            { _Txt_MaxPorcSobre.Text = "0"; }
            if (_Cb_LimCredito.SelectedIndex > 0)
            { _Str_Lim = _Cb_LimCredito.SelectedValue.ToString(); }
            if (_Txt_Usuario.Text.Trim().Length > 0 & _Str_Lim.Trim().Length > 0 & Convert.ToDouble(_Txt_MaxPorcSobre.Text.Trim())>0)
            {
                _Mtd_GuardarEditar(_Str_FrmUsuCod, _Str_Lim);
            }
            else
            {
                if (_Txt_Usuario.Text.Trim().Length == 0) { _Er_Error.SetError(_Txt_Usuario, "Información requerida!!!"); }
                if (_Str_Lim.Trim().Length == 0) { _Er_Error.SetError(_Cb_LimCredito, "Información requerida!!!"); }
                if (Convert.ToDouble(_Txt_MaxPorcSobre.Text.Trim()) == 0) { _Er_Error.SetError(_Txt_MaxPorcSobre, "Información requerida!!!"); }
            }
        }
        private void _Mtd_GuardarEditar(string _P_Str_User,string _P_Str_Lim)
        {
            string _Str_Cadena = "Select * from TLIMITCREDITOP where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND cuser='" + _P_Str_User + "'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                _Str_Cadena = "Update TLIMITCREDITOP Set ccodlimite='" + _P_Str_Lim + "',caprobasobregiro='" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_Txt_MaxPorcSobre.Text)) + "',cdateupd=GETDATE(),cuserupd='" + Frm_Padre._Str_Use + "',cdelete='0' where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND cuser='" + _P_Str_User + "'";
                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                MessageBox.Show("El registro fue actualizado correctamente");
            }
            else
            {
                _Str_Cadena = "Insert into TLIMITCREDITOP (cgroupcomp,cuser,ccodlimite,caprobasobregiro,cdateadd,cuseradd,cdelete) values('" + Frm_Padre._Str_GroupComp + "','" + _P_Str_User + "','" + _P_Str_Lim + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_Txt_MaxPorcSobre.Text)) + "',GETDATE(),'" + Frm_Padre._Str_Use + "','0')";
                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                MessageBox.Show("El registro fue agregado correctamente");
            }
            _Mtd_Actualizar();
        }
        private void _Mtd_Eliminar()
        {
            if (_Str_FrmUsuCod.Trim().Length > 0)
            {
                string _Str_Cadena = "Select * from TLIMITCREDITOP where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND cuser='" + _Str_FrmUsuCod + "'";
                DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                if (_Ds.Tables[0].Rows.Count > 0)
                {
                    DialogResult eli = MessageBox.Show("Esta seguro de Eliminar el registro?", "Información", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (eli == DialogResult.Yes)
                    {
                        _Str_Cadena = "Delete from TLIMITCREDITOP where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND cuser='" + _Str_FrmUsuCod + "'";
                        Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                        MessageBox.Show("El registro fue eliminado correctamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        _Cb_LimCredito.Enabled = false;
                        _Txt_MaxPorcSobre.Enabled = false;
                        _Mtd_Ini();
                        _Mtd_Actualizar();
                    }
                }
                else
                {
                    MessageBox.Show("El registro aún no existe", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information); ;
                }
            }
            else
            {
                MessageBox.Show("Faltan Datos para realizar esta operación", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information); ;
            }
        }
        private void _Cb_LimCredito_DropDown(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            _Mtd_CargarLimites();
            this.Cursor = Cursors.Default;
        }

        private void dataGridView1_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (_Dg_Grid.CurrentCell != null)
            {
                _Er_Error.Dispose();
                Cursor = Cursors.WaitCursor;
                _Mtd_Ini();
                _Mtd_CargarLimites();
                _Cb_LimCredito.Enabled = true;
                _Txt_MaxPorcSobre.Enabled = true;
                string _Str_Cadena = "Select cname from TUSER where cuser='" + _Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells[1].Value.ToString() + "' and cdelete='0'";
                DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                if (_Ds.Tables[0].Rows.Count > 0)
                {
                    _Txt_Usuario.Text = _Ds.Tables[0].Rows[0][0].ToString().Trim();
                }
                _Cb_LimCredito.SelectedValue = _Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells[0].Value.ToString();
                _Str_FrmUsuCod = _Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells[1].Value.ToString();
                if (_Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells[4].Value.ToString().Trim() == "")
                {
                    _Txt_MaxPorcSobre.Text = "0";
                }
                else
                {
                    _Txt_MaxPorcSobre.Text = Convert.ToDouble(_Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells[4].Value.ToString()).ToString("#,##0.00");
                }
                Cursor = Cursors.Default;
            }
        }

        private void _Bt_Elim_Click(object sender, EventArgs e)
        {
            _Mtd_Eliminar();
        }
    }
}