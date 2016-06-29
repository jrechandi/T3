using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using T3.Clases;

namespace T3
{
    public partial class Frm_IC_RelaProvCli : Form
    {
        CLASES._Cls_Varios_Metodos _Cls_VariosMetodos = new CLASES._Cls_Varios_Metodos(true);

        clslibraryconssa._Cls_Formato _Cls_Formato = new clslibraryconssa._Cls_Formato("es-VE");

        enum _Enu_EstadosFormulario { ConsultandoMaestra, ConsultandoDetalle, Agregando, Modificando };

        private _Enu_EstadosFormulario _G_Bol_EstadoActualFormulario = _Enu_EstadosFormulario.ConsultandoMaestra;

        private bool _G_Bol_PermitirClicTabDetalle = false;
        private string _G_Str_cidrelaprocli;
        private string _G_Str_CodigoProveedorAnterior;
        private string _G_Str_CodigoClienteAnterior;

        /// <summary>
        /// Érase una vez un constructor...
        /// </summary>
        public Frm_IC_RelaProvCli()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Se ejecuta una vez, cuando carga el formulario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Frm_IC_RelaProvCli_Load(object sender, EventArgs e)
        {
            _Tb_Tab.SelectedIndex = 0;

            _Mtd_LlenarGridPrincipal();

            _Mtd_LlenarComboProveedor();

            // desactiva los controles en la pestaña detalle
            _Mtd_HabilitarInhabilitarDetalle(false);
        }

        /// <summary>
        /// Llena el grid principal e inicializa el control busqueda1
        /// </summary>
        private void _Mtd_LlenarGridPrincipal()
        {

            // este menú se pasa como parámetro en la inicializacion de busqueda1
            ToolStripMenuItem[] _Tsm_Menu = new ToolStripMenuItem[4];
            _Tsm_Menu[0] = new ToolStripMenuItem("Código proveedor");
            _Tsm_Menu[1] = new ToolStripMenuItem("Nombre proveedor");
            _Tsm_Menu[2] = new ToolStripMenuItem("Código cliente");
            _Tsm_Menu[3] = new ToolStripMenuItem("Nombre cliente");

            // los nombres de los campos deben ser completos (nombre y apellido) para SQLs con joins
            // este arreglo se para como parámetro en la inicialización de busqueda1
            string[] _Str_Campos = new string[4];
            _Str_Campos[0] = "TICRELAPROCLI.cproveedor";
            _Str_Campos[1] = "TPROVEEDOR.c_nomb_comer";
            _Str_Campos[2] = "TICRELAPROCLI.ccliente";
            _Str_Campos[3] = "TCLIENTE.c_nomb_comer";

            // muestra los proveedores que hay en la tabla de relaciones
            string _Str_Sql = "";
            _Str_Sql += "SELECT TOP 100 PERCENT dbo.TICRELAPROCLI.cidrelaprocli, dbo.TICRELAPROCLI.cproveedor, dbo.TPROVEEDOR.c_nomb_comer AS cproveedor_desc, CASE WHEN dbo.TICRELAPROCLI.ccliente = 0 THEN NULL ELSE TICRELAPROCLI.ccliente END AS ccliente,  "; // si ccliente es 0, entonces lo convierte en NULL, para que no aparezca en el grid
            _Str_Sql += "   dbo.TCLIENTE.c_nomb_comer AS ccliente_desc ";
            _Str_Sql += "FROM dbo.TICRELAPROCLI INNER JOIN ";
            _Str_Sql += "   dbo.TPROVEEDOR ON dbo.TICRELAPROCLI.cproveedor = dbo.TPROVEEDOR.cproveedor LEFT JOIN";
            _Str_Sql += "   dbo.TCLIENTE ON dbo.TICRELAPROCLI.ccliente = dbo.TCLIENTE.ccliente ";
            _Str_Sql += " WHERE (dbo.TPROVEEDOR.ccompany = '" + Frm_Padre._Str_Comp + "') ";


            // finalmente inicializa busqueda1
            _Ctrl_Busqueda1._Mtd_Inicializar(_Str_Sql, _Str_Campos, "Proveedores IC", _Tsm_Menu, _Dtg_Principal, true, "");

            //Oculto las columnas que no se deben mostrar
            _Dtg_Principal.Columns["cidrelaprocli"].Visible = false;

            // hace que las columnas del grid se ajusten de tamaño automáticamente
            _Dtg_Principal.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

        }

        /// <summary>
        /// muestra y oculta el tooltip del grid
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// limpia la pestaña de detalle en caso de que el usuario vuelva a la pestaña de consulta
        /// evita que el usuario abra la pestaña de detalle directamente
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void _Tb_Tab_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if (e.TabPageIndex == 0)
            {
                _Mtd_LimpiarDetalle();
                _Mtd_HabilitarInhabilitarDetalle(false);

                _G_Bol_PermitirClicTabDetalle = false;

                _G_Bol_EstadoActualFormulario = _Enu_EstadosFormulario.ConsultandoMaestra;

                _Mtd_ActualizarEstadoBotonera();

            }


            if (e.TabPageIndex == 1 && !_G_Bol_PermitirClicTabDetalle)
            {
                e.Cancel = true;
            }
        }

        /// <summary>
        /// muestra el detalle y utiliza un cursor de espera
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void _Dg_Grid_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (_Dtg_Principal.Rows.Count > 0)
            {
                _G_Bol_EstadoActualFormulario = _Enu_EstadosFormulario.ConsultandoDetalle;
                _Mtd_ActualizarEstadoBotonera();

                Cursor = Cursors.WaitCursor;
                // --------------------------------------------------------------------------------------------------------------------------
                _G_Str_cidrelaprocli = _Ctrl_Busqueda1._Mtd_RetornarStringCelda(0, e.RowIndex).Trim();
                _G_Str_CodigoProveedorAnterior = _Ctrl_Busqueda1._Mtd_RetornarStringCelda(1, e.RowIndex).Trim();
                _G_Str_CodigoClienteAnterior = _Ctrl_Busqueda1._Mtd_RetornarStringCelda(3, e.RowIndex).Trim();
                _Mtd_MostrarDetalle(_G_Str_cidrelaprocli);

                //---------------------------------------------------------------------------------------------------------------------------
                _Mtd_MostrarPestanaDetalle();

                Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// Muestra al usuario la pestaña de detalle
        /// </summary>
        private void _Mtd_MostrarPestanaDetalle()
        {
            _G_Bol_PermitirClicTabDetalle = true;
            _Tb_Tab.SelectedIndex = 1;
            _G_Bol_PermitirClicTabDetalle = false;
        }

        /// <summary>
        /// Vacia los campos de la pestaña de detalle
        /// </summary>
        private void _Mtd_LimpiarDetalle()
        {
            if (_Cmb_Proveedor.Items.Count > 0)
            {
                _Cmb_Proveedor.SelectedIndex = 0;
            }

            _Lbl_CodigoCliente.Text = "";
            _Lbl_NombreCliente.Text = "";
        }

        /// <summary>
        /// llena/actualiza el combo de proveedores
        /// </summary>
        private void _Mtd_LlenarComboProveedor()
        {
            string _Str_SQL = "";
            _Str_SQL += " SELECT dbo.VST_COMPANIASRELACIONADAS.cproveedor, dbo.VST_COMPANIASRELACIONADAS.cproveedor + ' - ' + dbo.VST_COMPANIASRELACIONADAS.c_nomb_comer AS cnombreproveedor, dbo.TICRELAPROCLI.ccliente, dbo.TCLIENTE.c_nomb_comer AS cnombrecliente ";
            _Str_SQL += " FROM dbo.TCLIENTE INNER JOIN dbo.TICRELAPROCLI ON dbo.TCLIENTE.ccliente = dbo.TICRELAPROCLI.ccliente  ";
            _Str_SQL += " RIGHT OUTER JOIN dbo.VST_COMPANIASRELACIONADAS ON dbo.TICRELAPROCLI.cproveedor = dbo.VST_COMPANIASRELACIONADAS.cproveedor ";
            _Str_SQL += " WHERE (dbo.VST_COMPANIASRELACIONADAS.ccompany = '" + Frm_Padre._Str_Comp + "') ";

            //_Mtd_CargarComboSinPuntos(_Cmb_Proveedor, _Str_SQL);
            _Cls_VariosMetodos._Mtd_CargarCombo(_Cmb_Proveedor, _Str_SQL);
        }

        /// <summary>
        /// actualiza el estado de los botones en la botonera según el modo en el que esté el formulario
        /// </summary>
        private void _Mtd_ActualizarEstadoBotonera()
        {
            CONTROLES._Ctrl_Buscar._Bl_Especial = true;
            CONTROLES._Ctrl_Buscar._Bol_SoloNuevo = false;
            CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "";
            CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "Abierto";
            CONTROLES._Ctrl_Buscar._frm_Formulario = this;


            if (_G_Bol_EstadoActualFormulario == _Enu_EstadosFormulario.ConsultandoMaestra)
            {
                ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_nuevo2.Enabled = true;
                ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_editar2.Enabled = false;
                ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_guardar2.Enabled = false;
                ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_cancelar2.Enabled = false;
            }

            if (_G_Bol_EstadoActualFormulario == _Enu_EstadosFormulario.ConsultandoDetalle)
            {
                ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_nuevo2.Enabled = true;
                ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_editar2.Enabled = true;
                ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_guardar2.Enabled = false;
                ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_cancelar2.Enabled = false;
            }

            if (_G_Bol_EstadoActualFormulario == _Enu_EstadosFormulario.Agregando || _G_Bol_EstadoActualFormulario == _Enu_EstadosFormulario.Modificando)
            {
                ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_nuevo2.Enabled = false;
                ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_editar2.Enabled = false;
                ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_guardar2.Enabled = true;
                ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_cancelar2.Enabled = true;
            }

            this.Text = "Relación intercompañía proveedor-cliente";
        }

        /// <summary>
        /// actualiza el estado de los botones en la botonera según el modo en el que esté el formulario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Frm_IC_RelaProvCli_Activated(object sender, EventArgs e)
        {
            _Mtd_ActualizarEstadoBotonera();
        }

        /// <summary>
        /// Pasa el formulario a modo 'agregando', es decir, muestra la pestaña de detalle con los campos limpios y habilita los controles
        /// Este método tiene que llamarse así por compatibilidad con la botonera
        /// </summary>
        public void _Mtd_Nuevo()
        {
            _G_Str_CodigoProveedorAnterior = "";
            _G_Str_CodigoClienteAnterior = "";
            _G_Bol_EstadoActualFormulario = _Enu_EstadosFormulario.Agregando;

            _Mtd_ActualizarEstadoBotonera();

            _Mtd_MostrarPestanaDetalle();
            _Mtd_LimpiarDetalle();
            _Mtd_HabilitarInhabilitarDetalle(true);
        }

        /// <summary>
        /// Este método deberia llamarse _Mtd_Cancelar pero se llama _Mtd_Ini para que funcione correctamente la botonera (efecto BOTÓN ROJO)
        /// Lo que hace es 'cancelar' el proceso de 'agregar', vuelve a la consulta
        /// </summary>
        /// <returns></returns>
        public void _Mtd_Ini()
        {
            _G_Bol_EstadoActualFormulario = _Enu_EstadosFormulario.ConsultandoMaestra;

            _Mtd_ActualizarEstadoBotonera();

            _Tb_Tab.SelectedIndex = 0;
            _Mtd_LimpiarDetalle();
            _Mtd_HabilitarInhabilitarDetalle(false);
        }

        /// <summary>
        /// Este método deberia llamarse _Mtd_Modificar pero se llama _Mtd_Habilitar para que funcione correctamente la botonera
        /// Lo que hace es habilitar los controles para el usuario pueda modificar un reigstro
        /// </summary>
        /// <returns></returns>
        public void _Mtd_Habilitar()
        {
            _G_Bol_EstadoActualFormulario = _Enu_EstadosFormulario.Modificando;
            _Mtd_HabilitarInhabilitarDetalle(true);
            _Mtd_ActualizarEstadoBotonera();
        }

        /// <summary>
        /// Este método deberia llamarse _Mtd_GuardarAlModificar, o algo asi, pero se llama _Mtd_Editar para que funcione correctamente la botonera
        /// Lo que hace es guardar.
        /// </summary>
        /// <returns></returns>
        public bool _Mtd_Editar()
        {
            return _Mtd_Guardar();
        }

        /// <summary>
        /// Activa/inactiva los controles del detalle para que el usuario pueda modificar
        /// </summary>
        private void _Mtd_HabilitarInhabilitarDetalle(bool _P_Bol_Habilitar)
        {
            _Cmb_Proveedor.Enabled = _P_Bol_Habilitar;

            _Lbl_CodigoCliente.Enabled = _P_Bol_Habilitar;
            _Lbl_NombreCliente.Enabled = _P_Bol_Habilitar;
            _Btn_BuscarCliente.Enabled = _P_Bol_Habilitar;
        }

        /// <summary>
        /// Vuelve la botonera al estado 'neutral' al salir del fomrulario
        /// Es importante para que esos botones no queden activados a lo loco...
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Frm_IC_RelaProvCli_FormClosing(object sender, FormClosingEventArgs e)
        {
            CONTROLES._Ctrl_Buscar._Bl_Especial = false;
            CONTROLES._Ctrl_Buscar._Bol_SoloNuevo = false;
            CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "";
            CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "Cerrado";
        }

        /// <summary>
        /// Muestra los detalles de una relación en la pestaña de detalle
        /// </summary>
        /// <param name="_P_Str_cidrelaprocli">codigo del la relacion que se desea mostrar</param>
        private void _Mtd_MostrarDetalle(string _P_Str_cidrelaprocli)
        {
            string _Str_SQL = "";
            _Str_SQL += "SELECT TOP 100 PERCENT dbo.TICRELAPROCLI.cproveedor, dbo.TPROVEEDOR.c_nomb_comer AS cproveedor_desc, CASE WHEN dbo.TICRELAPROCLI.ccliente = 0 THEN '' ELSE CONVERT(VARCHAR, TICRELAPROCLI.ccliente) END AS ccliente, ISNULL(dbo.TCLIENTE.c_nomb_comer, '') AS ccliente_desc ";
            _Str_SQL += "FROM dbo.TICRELAPROCLI LEFT OUTER JOIN dbo.TCLIENTE ON dbo.TICRELAPROCLI.ccliente = dbo.TCLIENTE.ccliente LEFT OUTER JOIN dbo.TPROVEEDOR ON dbo.TICRELAPROCLI.cproveedor = dbo.TPROVEEDOR.cproveedor ";
            _Str_SQL += "WHERE (dbo.TICRELAPROCLI.cidrelaprocli = '" + _P_Str_cidrelaprocli + "') ";

            DataSet _Ds_DataSet = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_SQL);

            if (_Ds_DataSet.Tables[0].Rows.Count > 0)
            {
                _Cmb_Proveedor.SelectedValue = Convert.ToString(_Ds_DataSet.Tables[0].Rows[0]["cproveedor"]);
                _Lbl_CodigoCliente.Text = Convert.ToString(_Ds_DataSet.Tables[0].Rows[0]["ccliente"]);
                _Lbl_NombreCliente.Text = Convert.ToString(_Ds_DataSet.Tables[0].Rows[0]["ccliente_desc"]);
            }
        }

        /// <summary>
        /// limpia los campos del detalle si se elige un nuevo proveedor
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void _Cmb_Proveedor_SelectedIndexChanged(object sender, EventArgs e)
        {
            //_Lbl_CodigoCliente.Text = "";
            //_Lbl_NombreCliente.Text = "";
        }

        /// <summary>
        /// Ejecuta el método _Mtd_NuevoRegistroEsValido y guarda la relación en caso de ser válida
        /// </summary>
        /// <returns></returns>
        public bool _Mtd_Guardar()
        {
            string _Str_CodigoProveedor = _Cmb_Proveedor.SelectedValue.ToString().Trim();
            string _Str_CodigoCliente = _Lbl_CodigoCliente.Text.Trim();

            // si el usuario no selecciono un cliente, se guarda codigo cero
            if (_Str_CodigoCliente == "") _Str_CodigoCliente = "0";

            if (_G_Bol_EstadoActualFormulario == _Enu_EstadosFormulario.Agregando)
            {
                if (_Mtd_Validar())
                {
                    string _Str_SQL = "INSERT INTO TICRELAPROCLI (cproveedor,ccliente,cgroupcomp,cdateadd,cuseradd) VALUES ('" + _Str_CodigoProveedor + "','" + _Str_CodigoCliente + "','" + Frm_Padre._Str_GroupComp + "', GETDATE(),'" + Frm_Padre._Str_Use + "')";
                    Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_SQL);

                    _G_Bol_EstadoActualFormulario = _Enu_EstadosFormulario.ConsultandoMaestra;

                    _Mtd_ActualizarEstadoBotonera();

                    MessageBox.Show("El registro se ha agregado satisfactoriamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // actualiza el grid ppal
                    _Mtd_LlenarGridPrincipal();

                    // vuelve a la primera pestaña
                    _Tb_Tab.SelectedIndex = 0;

                    return true;
                }
                else
                {
                    return false;
                }
            }

            if (_G_Bol_EstadoActualFormulario == _Enu_EstadosFormulario.Modificando)
            {
                if (_Mtd_Validar())
                {
                    string _Str_SQL = "UPDATE TICRELAPROCLI SET ccliente = '" + _Str_CodigoCliente + "', cproveedor = '" + _Str_CodigoProveedor + "', cdateupd = GETDATE(), cuserupd = '" + Frm_Padre._Str_Use + "' WHERE cidrelaprocli = '" + _G_Str_cidrelaprocli + "'";
                    Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_SQL);

                    _G_Bol_EstadoActualFormulario = _Enu_EstadosFormulario.ConsultandoMaestra;

                    _Mtd_ActualizarEstadoBotonera();

                    MessageBox.Show("El registro se ha modificado satisfactoriamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // actualiza el grid ppal
                    _Mtd_LlenarGridPrincipal();

                    // vuelve a la primera pestaña
                    _Tb_Tab.SelectedIndex = 0;

                    return true;
                }
                else
                {
                    return false;
                }
            }

            MessageBox.Show("Ha ocurrido un error inesperado. Por favor contacte al desarrollador.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return false;
        }

        /*
        /dNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNd/
        NMy::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::yMM
        NMo                                                                                              oMM
        NMo                                                                                              oMM
        NMo                                                                                              oMM
        NMo                                                                                              oMM
        NMo                                     -y-                                                      oMM
        NMo                                     +NN/                                                     oMM
        NMo                                      -hN+                                                    oMM
        NMo                                       `+Ms                                                   oMM
        NMo                                      `/hy:                                                   oMM
        NMo                             `...`  `+yo-                                                     oMM
        NMo                          `/ydmmmd: yo-                                    `..---             oMM
        NMo                         -dMMMMMNy/ymmmy:                      ``..--/+oshhdmmmdy             oMM
        NMo                    `:ss`mMMMMMMy/NMMMMMN/         ``..--:+osyhhhhhdhyyhdNmds/--:+            oMM
        NMo                  `odMs`/MMMMMMMNNMMMMMMMm `-:++syyhhhhdhyso/:--.--/shdho:-.-ohmMM            oMM
        NMo                  hMMs  +MMMMMMMMMMMMMMMMN :mNNys+:-..`      .-+yhdy+:..:ohmMMMMMM            oMM
        NMo               ```oMMs  `mMMMMMMMMMMMMMMMs   :NMNm:     `.:oydds/-`.:ohmMMMMMMMMMM            oMM
        NMo           -osyyhh.oNM.  :dNMMMMMMMMMMNmo   `oMMmo` `./shdds/.`.:ohNMMMMMMMMMMMMMM            oMM
        NMo           yMN+:-.  -hs  oy+shmmmmmdy+:`  `odms/.-+yhmy+:```:shNMMMMMMMMMMMMMMNNdo            oMM
        NMo           yMdms-`    :  `ymo````.:/      /+::oydmy/- ``:ohNMMMMMMMMMMMMMMMNds/.              oMM
        NMo           yM.:smdy/-``    +NNddNms-   `./shmho/. ``:shNMMMMMMMMMMMMMMMNdo/.  ``-+            oMM
        NMo           yM.   -+ydNdhyso++yhy+:::/+ydNho:` ``:sdMMMMMMMMMMMMMMMMNdo:`  ``-ohNMM            oMM
        NMo           yM.        .-:/+osssyyyssss+-   `/sdMMMMMMMMMMMMMMMMNdo:`  ``-ohNMMMMMM            oMM
        NMo           yM.                         `/sdMMMMMMMMMMMMMMMMMdo:`    -ohNMMMMMMMMMM            oMM
        NMo           yM.                        dMMMMMMMMMMMMMMMMNho:`    :ohNMMMMMMMMMMMMMM            oMM
        NMo           yM.                        MMMMMMMMMMMMMNho-    `:odMMMMMMMMMMMMMMMMMds            oMM
        NMo           yM.                        MMMMMMMMMNho-`   `:odNMMMMMMMMMMMMMMMMds/``             oMM
        NMo           yM.                        MMMMMNho-`   `:odNMMMMMMMMMMMMMMMMds:`` -/ym            oMM
        NMo           yM.                        Mmho-`   .:odNNMMMMMMMMMMMMMMNho:`` -/ymNMMM            oMM
        NMo           yM.                        .``  ./sdNMMMMMMMMMMMMMMMNhs:```-+ymNMMMMMMM            oMM
        NMo           yM.                         ./sdNNMMMMMMMMMMMMMMNhs:```-+ymNMMMMMMMMMMM            oMM
        NMo           yM.                        hNMMMMMMMMMMMMMMMNho:.``-+ymNMMMMMMMMMMMMMMN            oMM
        NMo           yM.                        MMMMMMMMMMMMMmho:.``-+ymNMMMMMMMMMMMMMMNdy+.            oMM
        NMo           yM.                        MMMMMMMMMmho:.``-+ymNMMMMMMMMMMMMMMNdy+.`               oMM
        NMo           yM.                        MMMMMmho:.`.:+hmNMMMMMMMMMMMMMMNdy/.`                   oMM
        NMo           yM.                        Mmho:. .-ohmNMMMMMMMMMMMMMMNdy/-`                       oMM
        NMo           yM.                        -. .-ohmNMMMMMMMMMMMMMMNdy/-`                           oMM
        NMo           yM.                        -+hmMMMMMMMMMMMMMMMNds/-`                               oMM
        NMo           oM+                        NMMMMMMMMMMMMMMNds/-`                                   oMM
        NMo           `sNs.                      MMMMMMMMMMMNds/-`                                       oMM
        NMo             :hms/.`                  MMMMMMMNds/-`                                           oMM
        NMo               -ohdhyo+:-....``````...MMMNds/.                                                oMM
        NMo                  `-/+syhdmddddhhdddddds:.                                                    oMM
        NMo                            ````````                                                          oMM
        NMo                                                                                              oMM
        NMo                                                                                              oMM
        NMo                                                                                              oMM
        NMo                                                                                              oMM
        mMy::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::yMM
        /mMNMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMmo
                                       t h e   c a k e   i s   a   l i e
        */

        /// <summary>
        /// indica si los rifs son iguales
        /// </summary>
        /// <param name="_Str_cproveedor"></param>
        /// <param name="_Str_ccliente"></param>
        /// <returns></returns>
        private bool _Mtd_LosRifSonIguales(string _Str_cproveedor, string _Str_ccliente)
        {
            string _Str_SQL;
            DataSet _Ds_DataSet;
            string _Str_RIFProveedor = "";
            string _Str_RIFCliente = "";

            // Obtengo el Rif del Proveedor
            _Str_SQL = "SELECT cproveedor,c_rif FROM TPROVEEDOR where cproveedor = '" + _Str_cproveedor + "'";
            _Ds_DataSet = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_SQL);
            if (_Ds_DataSet.Tables[0].Rows.Count > 0)
            {
                _Str_RIFProveedor = _Ds_DataSet.Tables[0].Rows[0]["c_rif"].ToString();
            }

            // Obtengo el Rif del Cliente
            _Str_SQL = "SELECT ccliente,c_rif FROM TCLIENTE where ccliente = '" + _Str_ccliente + "'";
            _Ds_DataSet = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_SQL);
            if (_Ds_DataSet.Tables[0].Rows.Count > 0)
            {
                _Str_RIFCliente = _Ds_DataSet.Tables[0].Rows[0]["c_rif"].ToString();
            }

            //Normalizo
            _Str_RIFProveedor = _Str_RIFProveedor.Trim().ToUpper();
            _Str_RIFCliente = _Str_RIFCliente.Trim().ToUpper();

            //Verifico
            return _Str_RIFProveedor == _Str_RIFCliente;

        }

        /// <summary>
        /// valida que los valores que especifico el usuario son válidos para guardar
        /// </summary>
        /// <returns></returns>
        private bool _Mtd_Validar()
        {
            string _Str_CodigoProveedor = _Cmb_Proveedor.SelectedValue.ToString().Trim();
            string _Str_CodigoCliente = _Lbl_CodigoCliente.Text;

            //Valido las seleccion de los controles
            if (_Str_CodigoProveedor == "nulo")
            {
                MessageBox.Show("Debe seleccionar un Proveedor. Por favor verifique.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            string _Str_SQL;
            DataSet _Ds_DataSet;

            if (_G_Bol_EstadoActualFormulario == _Enu_EstadosFormulario.Agregando)
            {
                // verifica que el proveedor no esté guardado previamente
                _Str_SQL = "SELECT cproveedor FROM TICRELAPROCLI where cproveedor = '" + _Str_CodigoProveedor + "'";
                _Ds_DataSet = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_SQL);

                if (_Ds_DataSet.Tables[0].Rows.Count > 0)
                {
                    MessageBox.Show("El proveedor que ha seleccionado ya tiene un cliente asignado. Por favor verifique.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }

                // verifica que el cliente no esté guardado previamente, en caso de que el usuario haya seleccionado uno
                // pues es posible guardar el proveedor sin cliente asignado
                if (_Str_CodigoCliente != "")
                {
                    _Str_SQL = "SELECT cproveedor FROM TICRELAPROCLI where ccliente = '" + _Str_CodigoCliente + "'";
                    _Ds_DataSet = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_SQL);

                    if (_Ds_DataSet.Tables[0].Rows.Count > 0)
                    {
                        MessageBox.Show("El cliente que ha seleccionado ya está asignado a un proveedor. Por favor verifique.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                }

                //Solo si hay seleccionado un proveeor i un cliente
                if (_Str_CodigoProveedor.Length > 0 && _Str_CodigoCliente.Length > 0)
                {
                    //Verifica que los Rif de proveedor y cliente no sean los mismos
                    if (!_Mtd_LosRifSonIguales(_Str_CodigoProveedor, _Str_CodigoCliente))
                    {
                        MessageBox.Show("El proveedor seleccionado no tiene el mismo RIF que el cliente seleccionado. Por favor verifique.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                }

            }

            if (_G_Bol_EstadoActualFormulario == _Enu_EstadosFormulario.Modificando)
            {
                // verifica que el proveedor no esté guardado previamente
                _Str_SQL = "SELECT cproveedor FROM TICRELAPROCLI where cproveedor = '" + _Str_CodigoProveedor + "' and cidrelaprocli <> '" + _G_Str_cidrelaprocli + "'";
                _Ds_DataSet = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_SQL);
                if (_Ds_DataSet.Tables[0].Rows.Count > 0)
                {
                    MessageBox.Show("El proveedor que ha seleccionado ya tiene un cliente asignado. Por favor verifique.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }

                //Si hay cambio de proveedor
                if (_G_Str_CodigoProveedorAnterior != _Str_CodigoProveedor)
                {
                    //Verifico que el proveedor no este en una cobranza
                    string _Str_CodigoCobranzaIC = _Cls_RutinasIc._Mtd_ProveedorSeEncuentraCobranza(_G_Str_CodigoProveedorAnterior);
                    if (_Str_CodigoCobranzaIC != "")
                    {
                        Cursor = Cursors.Default;
                        MessageBox.Show("El Proveedor " + _G_Str_CodigoProveedorAnterior + " se encuentra en la cobranza intercompañía No. " + _Str_CodigoCobranzaIC + ". No se puede modificar.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return false;
                    }
                    //Verifico que el proveedor no este en una orden de pago
                    string _Str_CodigoOrdenPago = _Cls_RutinasIc._Mtd_ProveedorSeEncuentraEnOrdenPagoNoAnulada(_G_Str_CodigoProveedorAnterior);
                    if (_Str_CodigoOrdenPago != "")
                    {
                        Cursor = Cursors.Default;
                        MessageBox.Show("El Proveedor " + _G_Str_CodigoProveedorAnterior + " se encuentra en la orden de pago No. " + _Str_CodigoOrdenPago + ". No se puede modificar.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return false;
                    }
                }

                // verifica que el cliente no esté guardado previamente PARA OTRO PROVEEDOR, en caso de que el usuario haya seleccionado uno
                // pues es posible guardar el proveedor sin cliente asignado
                if (_Str_CodigoCliente != "")
                {
                    _Str_SQL = "SELECT cproveedor FROM TICRELAPROCLI where ccliente = '" + _Str_CodigoCliente + "' and cproveedor <> '" + _Str_CodigoProveedor + "' and cidrelaprocli <> '" + _G_Str_cidrelaprocli + "'";
                    _Ds_DataSet = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_SQL);
                    if (_Ds_DataSet.Tables[0].Rows.Count > 0)
                    {
                        MessageBox.Show("El cliente que ha seleccionado ya está asignado a un proveedor. Por favor verifique.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                }


                //Si hay cambio de cliente
                if (_G_Str_CodigoClienteAnterior != _Str_CodigoCliente)
                {
                    //Verifico si el Cliente ya fue asignado
                    if (_G_Str_CodigoClienteAnterior != "")
                    {
                        //Verifico que el cliente no este en un detalle de una cobranza
                        string _Str_CodigoCobranzaIC2 = _Cls_RutinasIc._Mtd_ClienteSeEncuentraCobranza(_G_Str_CodigoClienteAnterior);
                        if (_Str_CodigoCobranzaIC2 != "")
                        {
                            Cursor = Cursors.Default;
                            MessageBox.Show("El Cliente " + _G_Str_CodigoClienteAnterior + " se encuentra en la cobranza intercompañía No. " + _Str_CodigoCobranzaIC2 + ". No se puede modificar.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            return false;
                        }
                        //Verifico que el cliente no este en un detalle de orden de pago 
                        string _Str_CodigoOrdenPago2 = _Cls_RutinasIc._Mtd_ClienteSeEncuentraEnOrdenPagoNoAnulada(_G_Str_CodigoClienteAnterior);
                        if (_Str_CodigoOrdenPago2 != "")
                        {
                            Cursor = Cursors.Default;
                            MessageBox.Show("El Cliente " + _G_Str_CodigoClienteAnterior + " se encuentra en la orden de pago No. " + _Str_CodigoOrdenPago2 + ". No se puede modificar.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            return false;
                        }
                    }
                }

                //Solo si hay seleccionado un proveeor i un cliente
                if (_Str_CodigoProveedor.Length > 0 && _Str_CodigoCliente.Length > 0)
                {
                    //Verifica que los Rif de proveedor y cliente no sean los mismos
                    if (!_Mtd_LosRifSonIguales(_Str_CodigoProveedor, _Str_CodigoCliente))
                    {
                        MessageBox.Show("El proveedor seleccionado no tiene el mismo RIF que el cliente seleccionado. Por favor verifique.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                }

            }

            // si no se está guardando, ni modificando, entonces, ¿qué demonios se está haciendo? retorna falso para revisión...
            if (_G_Bol_EstadoActualFormulario != _Enu_EstadosFormulario.Agregando && _G_Bol_EstadoActualFormulario != _Enu_EstadosFormulario.Modificando)
            {
                MessageBox.Show("Ha ocurrido un error inesperado. Por favor contacte al desarrollador.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        /// <summary>
        /// Invoca Busqueda2: consulta de clientes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void _Btn_BuscarCliente_Click(object sender, EventArgs e)
        {
            _Lbl_CodigoCliente.Text = "";
            _Lbl_NombreCliente.Text = "";

            // Caso 32: clientes de la sucursal activos
            Frm_Busqueda2 _Frm_Busqueda2 = new Frm_Busqueda2(94);
            _Frm_Busqueda2.ShowDialog();
            if (_Frm_Busqueda2._Str_FrmResult == "1") // si el usuario seleccionó un cliente
            {
                string _Str_CodigoClienteSeleccionado = _Frm_Busqueda2._Dg_Grid[0, _Frm_Busqueda2._Dg_Grid.CurrentCell.RowIndex].Value.ToString().ToUpper();
                _Mtd_MostrarClienteSeleccionado(_Str_CodigoClienteSeleccionado);
            }

        }

        /// <summary>
        /// muestra el codigo y el nombre de cliente en los labes del detalle correspondientes
        /// </summary>
        /// <param name="_P_Str_CodigoCliente">codigo del cliente que se desea mostrar</param>
        private void _Mtd_MostrarClienteSeleccionado(string _P_Str_CodigoCliente)
        {
            string _Str_SQL = "SELECT c_nomb_comer FROM TCLIENTE where ccliente = '" + _P_Str_CodigoCliente + "'";
            DataSet _Ds_DataSet = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_SQL);

            if (_Ds_DataSet.Tables[0].Rows.Count > 0)
            {
                _Lbl_NombreCliente.Text = Convert.ToString(_Ds_DataSet.Tables[0].Rows[0]["c_nomb_comer"]); ;
                _Lbl_CodigoCliente.Text = _P_Str_CodigoCliente;
            }
        }

        /// <summary>
        /// llena un combo, pero a diferencia del que está en MetodoVarios, este no tiene una opción '...'
        /// </summary>
        /// <param name="_P_Cmb_Combo">combo que se va a llenar</param>
        /// <param name="_Str_Sql">sentencia sql que devuelve los resultados para llenar el combo</param>
        private void _Mtd_CargarComboSinPuntos(ComboBox _P_Cmb_Combo, string _P_Str_SQL)
        {
            DataSet _Ds;
            System.Collections.ArrayList _myArrayList = new System.Collections.ArrayList();
            _P_Cmb_Combo.DataSource = null;
            _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_P_Str_SQL);
            foreach (DataRow _DRow in _Ds.Tables[0].Rows)
            {
                _myArrayList.Add(new T3.Clases._Cls_ArrayList(_DRow[1].ToString().Trim(), _DRow[0].ToString().Trim()));
            }
            _P_Cmb_Combo.DataSource = _myArrayList;
            _P_Cmb_Combo.DisplayMember = "Display";
            _P_Cmb_Combo.ValueMember = "Value";
            _P_Cmb_Combo.SelectedValue = "nulo";
        }

    } // formulario
} // namespace
