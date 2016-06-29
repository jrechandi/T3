using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using T3.CLASES;
using T3.Clases;
using clslibraryconssa;
using T3.CONTROLES;

namespace T3
{
    public partial class Frm_MantenimientoMAAC : Form
    {
        #region Atributos

        _Cls_Varios_Metodos oVariosMetodos = new _Cls_Varios_Metodos(true);
        _Cls_Conexion oConexion = new _Cls_Conexion();
        _Cls_Formato oFormato = new _Cls_Formato("es-VE");
        
        private string sCodigoMotivo;

        #endregion

        #region Métodos

        /// <summary>
        /// Método nuevo invocado por la barra de herramientas del formulario padre.
        /// </summary>
        public void _Mtd_Nuevo()
        {
            txtDescripcion.Enabled = true;
            txtDescripcion.Text = "";
            txtDescripcion.Focus();
        }

        /// <summary>
        /// Método habilitar invocado por la barra de herramientas del formulario padre 
        /// cuando se pulsa el botón editar.
        /// </summary>
        public void _Mtd_Habilitar()
        {
            txtDescripcion.Enabled = true;
            txtDescripcion.Focus();
        }
        
        /// <summary>
        /// Método editar invocado por la barra de herramientas del formulario padre 
        /// cuando se pulsa el botón guardar para cuando está editando datos.
        /// </summary>
        /// <returns>Verdadero si guardo correctamente los cambios.</returns>
        public bool _Mtd_Editar()
        {
            try
            {
                string sSQL = "update TMOTIVO set cdescripcion = '" + txtDescripcion.Text.ToUpper() + "', cdateupd = getdate(), cuserupd = '" + Frm_Padre._Str_Use + "' where cidmotivo = '" + sCodigoMotivo + "' and cmotianulavicob='1';";
                oConexion._mtd_conexion._Mtd_EjecutarSentencia(sSQL);
                                
                _Mtd_CargarMotivos();

                txtDescripcion.Enabled = false;
            }
            catch (Exception e)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Método editar invocado por la barra de herramientas del formulario padre 
        /// cuando se pulsa el botón guardar para cuando está insertando nuevos datos.
        /// </summary>
        /// <returns>Verdadero si guardo correctamente los cambios.</returns>
        public bool _Mtd_Guardar()
        {
            try
            {
                string sSQL = "select cidmotivo from TMOTIVO where cdescripcion='" + txtDescripcion.Text.ToUpper() + "';";
                DataSet dsResultado = oConexion._mtd_conexion._Mtd_RetornarDataset(sSQL);

                if (dsResultado.Tables[0].Rows.Count == 1) {
                    sCodigoMotivo = dsResultado.Tables[0].Rows[0]["cidmotivo"].ToString();
                    sSQL = "update TMOTIVO set cdelete=0, cdateupd = getdate(), cuserupd = '" + Frm_Padre._Str_Use + "' where cidmotivo = '" + sCodigoMotivo + "' and cmotianulavicob='1';";
                } else {
                    sSQL = "select (count(cidmotivo) + 1) as cmaximo from TMOTIVO;";
                    dsResultado = oConexion._mtd_conexion._Mtd_RetornarDataset(sSQL);
                    if (dsResultado.Tables[0].Rows.Count == 1) {
                        string sMaximo = dsResultado.Tables[0].Rows[0]["cmaximo"].ToString();
                        sSQL = "insert into TMOTIVO (cidmotivo, cdescripcion, cmotianulavicob, cdelete, cdateadd, cuseradd) values ('" + sMaximo + "', '" + txtDescripcion.Text.ToUpper() + "', '1', 0, getdate(), '" + Frm_Padre._Str_Use + "');";
                    }
                }
                                
                oConexion._mtd_conexion._Mtd_EjecutarSentencia(sSQL);

                _Mtd_CargarMotivos();

                txtDescripcion.Enabled = false;
            }
            catch (Exception e)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Método que inicializar los controles del formulario cuando se inicializa la
        /// barra de herramientas del formulario padre.
        /// </summary>
        public void _Mtd_Ini()
        {
            txtDescripcion.Text = "";
            txtDescripcion.Enabled = false;
        }

        /// <summary>
        /// Método que cancela las operaciones del formulario cuando se pulsa el botón
        /// cancelar de la barra de herramientas del formulario padre.
        /// </summary>
        public void _Mtd_Cancelar()
        {
            txtDescripcion.Enabled = false;
        }

        /// <summary>
        /// Método eliminar invocado por la barra de herramientas del formulario padre 
        /// cuando se pulsa el botón eliminar.
        /// </summary>
        /// <returns></returns>
        public bool _Mtd_Eliminar()
        {
            try
            {
                string sSQL = "update TMOTIVO set cdelete = 1, cdatedel = getdate(), cuserdel = '" + Frm_Padre._Str_Use + "' where cidmotivo = '" + sCodigoMotivo + "' and cmotianulavicob='1';";
                oConexion._mtd_conexion._Mtd_EjecutarSentencia(sSQL);

                _Mtd_CargarMotivos();

                txtDescripcion.Enabled = false;
            }
            catch (Exception e)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Método para cargar los motivos de anulación para los avisos de cobros.
        /// </summary>
        private void _Mtd_CargarMotivos()
        {
            string sSQL = "select cidmotivo, cdescripcion from TMOTIVO where cmotianulavicob = '1' and cdelete = 0 order by cdescripcion asc;";
            
            dtgMotivos.DataSource = oConexion._mtd_conexion._Mtd_RetornarDataset(sSQL).Tables[0];
            dtgMotivos.Columns["colCodigo"].Visible = false;
            dtgMotivos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            txtDescripcion.Text = dtgMotivos.Rows[0].Cells["colDescripcion"].Value.ToString();
        }

        #endregion

        #region Eventos

        public Frm_MantenimientoMAAC()
        {
            InitializeComponent();

            _Mtd_CargarMotivos();
        }

        private void dtgMotivos_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            sCodigoMotivo = dtgMotivos.Rows[e.RowIndex].Cells["colCodigo"].Value.ToString();
            txtDescripcion.Text = dtgMotivos.Rows[e.RowIndex].Cells["colDescripcion"].Value.ToString();
        }

        private void dtgMotivos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            sCodigoMotivo = dtgMotivos.Rows[e.RowIndex].Cells["colCodigo"].Value.ToString();
            txtDescripcion.Text = dtgMotivos.Rows[e.RowIndex].Cells["colDescripcion"].Value.ToString();
        }

        private void Frm_MantenimientoMAAC_Activated(object sender, EventArgs e)
        {
            _Ctrl_Buscar._Bl_Especial = true;
            _Ctrl_Buscar._Bol_SoloNuevo = false;
            _Ctrl_Buscar._txt_ExistForm.Text = "";
            _Ctrl_Buscar._txt_ExistForm.Text = "Abierto";
            _Ctrl_Buscar._frm_Formulario = this;

            ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_nuevo2.Enabled = true;
            ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_editar2.Enabled = true;
            ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_guardar2.Enabled = false;
            ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_borrar2.Enabled = true;
        }

        private void Frm_MantenimientoMAAC_FormClosing(object sender, FormClosingEventArgs e)
        {
            _Ctrl_Buscar._Bl_Especial = false;
            _Ctrl_Buscar._Bol_SoloNuevo = false;
            _Ctrl_Buscar._txt_ExistForm.Text = "";
            _Ctrl_Buscar._txt_ExistForm.Text = "Cerrado";
        }

        #endregion        
    }
}
