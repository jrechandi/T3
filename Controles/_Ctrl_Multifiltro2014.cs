using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using System.Linq;
using System.Threading;
using clslibraryconssa;
using T3.Clases;
using Microsoft.Reporting.WinForms;

namespace T3.Controles
{
    #region Tipos enumerados

    /// <summary>Tipos de consultas del multifiltro.</summary>
    public enum _Enu_MultifiltroTipos
    {
        MultifiltroTipoCombo = 0,
        MultifiltroTipoCompuesto,
        MultifiltroTipoBuscar,
        MultifiltroTipoCaja,
        MultifiltroTipoFecha,
        MultifiltroTipoAñoMes        
    }

    #endregion

    #region Delegados

    /// <summary>Delegado de los eventos SelectionChangeCommitted.</summary>
    /// <param name="pFiltro">Filtro seleccionado en el combo.</param>
    /// <param name="pFiltrosGrid">Filtros agregados en el grid.</param>
    public delegate void DelegadoDespuesSeleccionar(FiltroCombo pFiltro, List<FiltroGrid> pFiltrosGrid);

    /// <summary>Delegado de los eventos SelectionChangeCommitted del combo Estado.</summary>
    /// <param name="pTexto">Estado seleccionado.</param>
    /// <param name="pValor">Valor seleccionado.</param>
    public delegate void DelegadoDespuesSeleccionarEstado(string pTexto, string pValor);

    /// <summary>Delegado de los eventos SelectionChangeCommitted del combo año.</summary>
    /// <param name="pAño">Año seleccionado.</param>
    public delegate void DelegadoDespuesSeleccionarAño(string pAño);

    /// <summary>Delegado de los eventos Click.</summary>
    /// <param name="pNombreFiltro">Nombre del filtro seleccionado.</param>
    /// <param name="pCajaTexto">Caja de texto.</param>
    public delegate void DelegadoClick(string pNombreFiltro, TextBox pControl);

    /// <summary>Delegado para el evento cuando se ejecuta la consulta.</summary>
    /// <param name="pFiltros">Filtros utilizados.</param>
    public delegate void DelegadoEjecutada(List<FiltroGrid> pFiltros);

    /// <summary>Delegado para el evento cuando se valida la consulta antes de ejecutar.</summary>
    /// <param name="pFiltro">Filtro seleccionado.</param>
    /// <param name="pCajaTexto">Caja de texto.</param>
    public delegate void DelegadoValidar(List<FiltroGrid> pFiltros, ref bool pCancelar);

    /// <summary>Delegado para el evento cerrar.</summary>
    public delegate void DelegadoCerrar();

    #endregion

    public partial class _Ctrl_Multifiltro2014 : UserControl
    {
        #region Atributos

        /// <summary>Visor de Reporting Services.</summary>
        private ReportViewer gVisorReportes;

        /// <summary>Lista de filtros para el Grid.</summary>
        private List<FiltroGrid> gListaFiltrosGrid = new List<FiltroGrid>();

        /// <summary>Lista de filtros para el combo "Filtrar por".</summary>
        private ArrayList gListaFiltros = new ArrayList();

        /// <summary>Lista de filtros para el combo "Estados".</summary>
        private ArrayList gListaEstados = new ArrayList();

        /// <summary>Bandera para agregar a los filtros compuesto la opción de seleccionarlos todos.</summary>
        private bool gSeleccionarTodos = false;

        #endregion

        #region Propiedades

        /// <summary>Obtiene los filtros seleccionados por el usuario.</summary>
        public List<FiltroGrid> Filtros
        {
            get { return gListaFiltrosGrid; } 
        }

        /// <summary>Para los filtros compuesto, permite agregar un filtro que selecciona todo los filtros del combo.</summary>
        public bool SeleccionarTodos
        {
            set { gSeleccionarTodos = value; }
        }

        /// <summary>Año seleccionado en el combo.</summary>
        public string Año
        {
            get { return _Cmb_Año.SelectedValue.ToString(); }
        }

        /// <summary>Habilita el combo filtrar por.</summary>
        public bool HabilitarFiltrarPor
        {
            set { _Cmb_FiltrarPor.Enabled = value; }
        }

        /// <summary>Establece el visor de Reporting Services utilizado en el formulario.</summary>
        public ReportViewer Visor
        {
            set { gVisorReportes = value; }
        }

        #endregion

        #region Metodos

        /// <summary>Constructor de la clase.</summary>
        public _Ctrl_Multifiltro2014()
        {
            InitializeComponent();
        }

        /// <summary>Agregar una fila al Grid.</summary>
        /// <param name="pFiltroSeleccionado">Datos del filtro seleccionado en el combo filtrar por.</param>
        /// <param name="pDescripcion">Descripción del filtro.</param>
        /// <param name="pValor">Valor del filtro.</param>
        private void agregarFiltroGrid(FiltroCombo pFiltroSeleccionado, string pDescripcion, string pValor)
        {
            _Dtg_Filtros.DataSource = null;

            /*
             *  Aqui se hace lo siguiente:
             * 
             *  1. Buscamos el filtro, y si existe en el grid, lo actualizamos y nos salimos de la rutina.
             *  2. De lo contrario, un filtro nuevo se agrega al grid.
             *  3. Finalmente se muestra el encabezado si es el primer filtro en el grid.
             */

            for (int iIndice = 0; iIndice < gListaFiltrosGrid.Count; iIndice++)
            {
                if (gListaFiltrosGrid[iIndice].Nombre == pFiltroSeleccionado.Nombre)
                {
                    gListaFiltrosGrid[iIndice].Descripcion = pDescripcion;
                    gListaFiltrosGrid[iIndice].Valor = pValor;

                    _Dtg_Filtros.DataSource = gListaFiltrosGrid;

                    return;
                }
            }

            gListaFiltrosGrid.Add(new FiltroGrid
            {
                Tipo = pFiltroSeleccionado.Tipo,
                Titulo = pFiltroSeleccionado.TituloGrid,
                Nombre = pFiltroSeleccionado.Nombre,
                Valor = pValor,
                Descripcion = pDescripcion
            });

            _Dtg_Filtros.DataSource = gListaFiltrosGrid;

            if (_Dtg_Filtros.Rows.Count > 0)
            {
                _Dtg_Filtros.ColumnHeadersVisible = true;
            }            
        }

        /// <summary>Agrega un filtro al combo de filtrar por.</summary>
        /// <param name="pElemento">Objeto con los datos del combo.</param>
        public void agregarFiltrarPor(FiltroCombo pElemento)
        {
            gListaFiltros.Add(pElemento);

            _Cmb_FiltrarPor.DataSource = null;
            _Cmb_FiltrarPor.DataSource = gListaFiltros;
            _Cmb_FiltrarPor.DisplayMember = "TituloFiltrarPor";
            _Cmb_FiltrarPor.ValueMember = "Nombre";
        }

        /// <summary>Agrega un estado al combo de estados.</summary>
        /// <param name="pTexto">Texto que debe aparecer en el combo.</param>
        /// <param name="pValor">Valor del estado.</param>
        public void agregarEstado(string pTexto, string pValor)
        {
            if (gListaEstados.Count == 0)
            {
                gListaEstados.Add(new Clases._Cls_ArrayList("Seleccionar...", "SEL"));
            }

            gListaEstados.Add(new Clases._Cls_ArrayList(pTexto, pValor));

            _Cmb_Estado.DataSource = null;
            _Cmb_Estado.DataSource = gListaEstados;
            _Cmb_Estado.DisplayMember = "Display";
            _Cmb_Estado.ValueMember = "Value";
            _Cmb_Estado.SelectedIndex = 0;
        }

        /// <summary>Modifica el aspecto del Grid.</summary>
        private void cambiarAspectoGrid()
        {
            _Dtg_Filtros.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
            _Dtg_Filtros.AllowUserToResizeRows = false;
            _Dtg_Filtros.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            _Dtg_Filtros.AllowUserToResizeColumns = false;
            _Dtg_Filtros.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            _Dtg_Filtros.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            _Dtg_Filtros.Columns[0].HeaderText = "";
            _Dtg_Filtros.Columns[0].Width = 30;
            _Dtg_Filtros.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _Dtg_Filtros.Columns[1].HeaderText = "Filtro";
            _Dtg_Filtros.Columns[1].Width = 130;
            _Dtg_Filtros.Columns[1].ReadOnly = true;
            _Dtg_Filtros.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            _Dtg_Filtros.Columns[2].HeaderText = "Valor";
            _Dtg_Filtros.Columns[2].Width = 460;
            _Dtg_Filtros.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            _Dtg_Filtros.Columns[2].ReadOnly = true;
            _Dtg_Filtros.Columns[3].Visible = false;
            _Dtg_Filtros.Columns[4].Visible = false;
            _Dtg_Filtros.Columns[5].Visible = false;
        }

        /// <summary>Agrega los datos al combo de estados.</summary>
        /// <param name="pDatos">Conjunto de resultado con los datos.</param>
        public void cargarEstados(DataSet pDatos)
        {
            ArrayList oListado = new ArrayList();

            _Cmb_Estado.DataSource = null;

            oListado.Add(new Clases._Cls_ArrayList("Seleccionar...", "SEL"));

            foreach (DataRow oFila in pDatos.Tables[0].Rows)
            {
                oListado.Add(new Clases._Cls_ArrayList(oFila[1].ToString(), oFila[0].ToString()));
            }

            _Cmb_Estado.DataSource = oListado;
            _Cmb_Estado.DisplayMember = "Display";
            _Cmb_Estado.ValueMember = "Value";
        }

        /// <summary>Agrega los datos al combo compuesto.</summary>
        /// <param name="pDatos">Conjunto de resultado con los datos.</param>
        public void cargarCompuesto(DataSet pDatos)
        {
            ArrayList oListado = new ArrayList();

            _Cmb_Compuesto.DataSource = null;

            oListado.Add(new Clases._Cls_ArrayList("Seleccionar...", "SEL"));

            if (gSeleccionarTodos)
            {
                oListado.Add(new Clases._Cls_ArrayList("Todos", "SELT"));
            }

            foreach (DataRow oFila in pDatos.Tables[0].Rows)
            {
                oListado.Add(new Clases._Cls_ArrayList(oFila[1].ToString(), oFila[0].ToString()));
            }

            _Cmb_Compuesto.DataSource = oListado;
            _Cmb_Compuesto.DisplayMember = "Display";
            _Cmb_Compuesto.ValueMember = "Value";
        }

        /// <summary>Agrega los años al combo.</summary>
        /// <param name="pAños">Conjunto de resultado con los años.</param>
        public void cargarAñosCombo(DataSet pAños)
        {
            ArrayList oListado = new ArrayList();

            _Cmb_Año.DataSource = null;

            foreach (DataRow oFila in pAños.Tables[0].Rows)
            {
                oListado.Add(new Clases._Cls_ArrayList(oFila[1].ToString(), oFila[0].ToString()));
            }

            _Cmb_Año.DataSource = oListado;
            _Cmb_Año.DisplayMember = "Display";
            _Cmb_Año.ValueMember = "Value";
            _Cmb_Año.SelectedIndex = 0;
        }

        /// <summary>Agrega los meses al combo.</summary>
        /// <param name="pAños">Conjunto de resultado con los meses.</param>
        public void cargarMesesCombo(DataSet pMeses)
        {
            ArrayList oListado = new ArrayList();

            _Cmb_Mes.DataSource = null;

            foreach (DataRow oFila in pMeses.Tables[0].Rows)
            {
                oListado.Add(new Clases._Cls_ArrayList(oFila[1].ToString(), oFila[0].ToString()));
            }

            _Cmb_Mes.DataSource = oListado;
            _Cmb_Mes.DisplayMember = "Display";
            _Cmb_Mes.ValueMember = "Value";
            _Cmb_Mes.SelectedIndex = 0;
        }

        /// <summary>Elimina los estados.</summary>
        public void eliminarEstados()
        {
            gListaEstados.Clear();

            _Cmb_Estado.DataSource = null;
        }

        /// <summary>Muestra el filtro.</summary>
        /// <param name="pTipo">Tipo de control que debe mostrarse.</param>
        public void mostrarFiltro(_Enu_MultifiltroTipos pTipo)
        {
            ocultar();

            FiltroCombo oArregloFiltro = (FiltroCombo)_Cmb_FiltrarPor.SelectedItem;

            IEnumerable<FiltroGrid> oFiltros;

            switch (pTipo)
            {
                case _Enu_MultifiltroTipos.MultifiltroTipoCombo:

                    _Lbl_Estado.Text = oArregloFiltro.TituloEtiqueta;
                    _Lbl_Estado.Visible = true;
                    _Cmb_Estado.Visible = true;

                    break;

                case _Enu_MultifiltroTipos.MultifiltroTipoBuscar:

                    _Lbl_Estado.Text = oArregloFiltro.TituloEtiqueta;
                    _Lbl_Estado.Visible = true;
                    _Txt_Buscar.Text = "";
                    _Txt_Buscar.Visible = true;
                    _Btn_Buscar.Visible = true;

                    break;

                case _Enu_MultifiltroTipos.MultifiltroTipoCaja:

                    _Lbl_Estado.Text = oArregloFiltro.TituloEtiqueta;
                    _Lbl_Estado.Visible = true;
                    _Txt_Texto.Visible = true;
                    _Txt_Texto.Focus();

                    break;

                case _Enu_MultifiltroTipos.MultifiltroTipoAñoMes:

                    oFiltros = from oFiltro in gListaFiltrosGrid
                                where (oFiltro.Tipo == _Enu_MultifiltroTipos.MultifiltroTipoAñoMes)
                                select oFiltro;

                    if (oFiltros.ToList().Count == 0)
                    {
                        _Cls_ArrayList oAño = (_Cls_ArrayList)_Cmb_Año.SelectedItem;
                        _Cls_ArrayList oMes = (_Cls_ArrayList)_Cmb_Mes.SelectedItem;

                        if (oMes == null) return;

                        gListaFiltrosGrid.Add(new FiltroGrid
                        {
                            Tipo = _Enu_MultifiltroTipos.MultifiltroTipoAñoMes,
                            Titulo = "Año:",
                            Nombre = "cano",
                            Valor = oAño.Value,
                            Descripcion = oAño.Display
                        });

                        gListaFiltrosGrid.Add(new FiltroGrid
                        {
                            Tipo = _Enu_MultifiltroTipos.MultifiltroTipoAñoMes,
                            Titulo = "Mes:",
                            Nombre = "cmes",
                            Valor = oMes.Value,
                            Descripcion = oMes.Display
                        });
                    }

                    _Dtg_Filtros.DataSource = null;

                    // Aqui se elimina el filtro de fecha (Desde - Hasta) en el caso de que esté en el grid.

                    oFiltros = from oFiltro in gListaFiltrosGrid
                                where (oFiltro.Tipo != _Enu_MultifiltroTipos.MultifiltroTipoFecha)
                                select oFiltro;

                    gListaFiltrosGrid = oFiltros.ToList();

                    _Dtg_Filtros.DataSource = gListaFiltrosGrid;

                    if (_Dtg_Filtros.Rows.Count > 0)
                    {
                        _Dtg_Filtros.ColumnHeadersVisible = true;
                    }

                    cambiarAspectoGrid();

                    _Lbl_Año.Visible = true;
                    _Cmb_Año.Visible = true;
                    _Lbl_Mes.Visible = true;
                    _Cmb_Mes.Visible = true;

                    break;

                case _Enu_MultifiltroTipos.MultifiltroTipoFecha:

                    _Dtp_Desde.Value = DateTime.Now;
                    _Dtp_Hasta.Value = DateTime.Now;

                    oFiltros = from oFiltro in gListaFiltrosGrid
                                where (oFiltro.Tipo == _Enu_MultifiltroTipos.MultifiltroTipoFecha)
                                select oFiltro;

                    if (oFiltros.ToList().Count == 0)
                    {
                        gListaFiltrosGrid.Add(new FiltroGrid
                        {
                            Tipo = _Enu_MultifiltroTipos.MultifiltroTipoFecha,
                            Titulo = "Desde:",
                            Nombre = "cdesde",
                            Valor = _Dtp_Desde.Value.ToShortDateString(),
                            Descripcion = _Dtp_Desde.Value.ToShortDateString()
                        });

                        gListaFiltrosGrid.Add(new FiltroGrid
                        {
                            Tipo = _Enu_MultifiltroTipos.MultifiltroTipoFecha,
                            Titulo = "Hasta:",
                            Nombre = "chasta",
                            Valor = _Dtp_Hasta.Value.ToShortDateString(),
                            Descripcion = _Dtp_Hasta.Value.ToShortDateString()
                        });
                    }

                    _Dtg_Filtros.DataSource = null;

                    // Aqui se elimina el filtro de año y mes en el caso de que esté en el grid.

                    oFiltros = from oFiltro in gListaFiltrosGrid
                                where (oFiltro.Tipo != _Enu_MultifiltroTipos.MultifiltroTipoAñoMes)
                                select oFiltro;

                    gListaFiltrosGrid = oFiltros.ToList();

                    _Dtg_Filtros.DataSource = gListaFiltrosGrid;

                    if (_Dtg_Filtros.Rows.Count > 0)
                    {
                        _Dtg_Filtros.ColumnHeadersVisible = true;
                    }

                    cambiarAspectoGrid();

                    _Lbl_Desde.Visible = true;
                    _Dtp_Desde.Visible = true;
                    _Lbl_Hasta.Visible = true;
                    _Dtp_Hasta.Visible = true;

                    break;

                case _Enu_MultifiltroTipos.MultifiltroTipoCompuesto:

                    _Lbl_Estado.Text = oArregloFiltro.TituloEtiqueta;
                    _Lbl_Estado.Visible = true;
                    _Cmb_Compuesto.Visible = true;
                    _Btn_Agregar.Visible = true;

                    break;
            }
        }

        /// <summary>Muestra el filtro.</summary>
        /// <param name="pNombre">Nombre del filtro a mostrarse.</param>
        public void mostrarFiltro(string pNombre)
        {
            ArrayList oFiltros = (ArrayList)_Cmb_FiltrarPor.DataSource;

            IEnumerable<FiltroCombo> oFiltro = from FiltroCombo p in oFiltros
                                               where (p.Nombre == pNombre)
                                               select p;

            _Cmb_FiltrarPor.SelectedItem = oFiltro.ToList()[0];

            if (FiltroSeleccionado != null)
            {
                FiltroSeleccionado((FiltroCombo)_Cmb_FiltrarPor.SelectedItem, gListaFiltrosGrid);
            }
        }

        /// <summary>Limpia y oculta los controles del multifiltro.</summary>
        private void ocultar()
        {
            foreach (Control oControl in _Pnl_Filtro.Controls)
            {
                if ((oControl is TextBox) || ((oControl is Button) || (oControl is DateTimePicker)))
                {
                    oControl.Visible = false;
                }

                if ((oControl is Label) && (oControl.Name != "_Lbl_Titulo") && (oControl.Name != "_Lbl_FiltrarPor"))
                {
                    oControl.Visible = false;
                }

                if ((oControl is ComboBox) && (oControl.Name != "_Cmb_FiltrarPor"))
                {
                    ComboBox oCombo = oControl as ComboBox;

                    oCombo.Visible = false;
                }
            }
        }

        /// <summary>Ordena los filtros en el grid.</summary>
        private void ordenarFiltros()
        {
            _Dtg_Filtros.DataSource = null;

            IEnumerable<FiltroGrid> oFiltros = from oFiltro in gListaFiltrosGrid
                                               orderby oFiltro.Tipo
                                               select oFiltro;

            gListaFiltrosGrid = oFiltros.ToList();

            _Dtg_Filtros.DataSource = gListaFiltrosGrid;
        }

        /// <summary>Este método organiza los títulos del los filtros cuando se elimina uno intermedio.</summary>
        private void organizarTituloFiltro()
        {
            FiltroCombo oFiltroCombo;

            for (int iIndice = 0; iIndice < _Cmb_FiltrarPor.Items.Count; iIndice++)
            {
                oFiltroCombo = (FiltroCombo)_Cmb_FiltrarPor.Items[iIndice];

                if ((oFiltroCombo.Tipo != _Enu_MultifiltroTipos.MultifiltroTipoFecha) && (oFiltroCombo.Tipo != _Enu_MultifiltroTipos.MultifiltroTipoAñoMes))
                {
                    int iContador = 1;

                    for (int iFila = 0; iFila < _Dtg_Filtros.Rows.Count; iFila++)
                    {
                        if (_Dtg_Filtros.Rows[iFila].Cells[4].Value == oFiltroCombo.Nombre)
                        {
                            _Dtg_Filtros.Rows[iFila].Cells[1].Value = oFiltroCombo.TituloGrid.Replace(":", " #" + iContador + ":");

                            iContador += 1;
                        }
                    }
                }
            }
        }

        /// <summary>Refresca el visor de los reportes cuando tienes que alternar entre reportes distintos.</summary>
        /// <param name="pPadre">Formulario donde se encuentra agregar el visor de reportes.</param>
        /// <param name="pNombreVisor">Nombre que utiliza el visor de reportes del formulario.</param>
        public void refrescarVisorReporte(ref Form pPadre, string pNombreVisor)
        {
            gVisorReportes = new Microsoft.Reporting.WinForms.ReportViewer();
            gVisorReportes.Dock = System.Windows.Forms.DockStyle.Fill;
            gVisorReportes.DocumentMapCollapsed = true;
            gVisorReportes.Location = new System.Drawing.Point(0, 39);
            gVisorReportes.Name = pNombreVisor;
            gVisorReportes.ProcessingMode = Microsoft.Reporting.WinForms.ProcessingMode.Remote;
            gVisorReportes.ServerReport.ReportServerUrl = new System.Uri("", System.UriKind.Relative);
            gVisorReportes.ShowParameterPrompts = false;
            gVisorReportes.Size = new System.Drawing.Size(1087, 450);
            gVisorReportes.TabIndex = 172;
            gVisorReportes.ProcessingMode = ProcessingMode.Local;

            pPadre.Controls.RemoveByKey(pNombreVisor);
            pPadre.Controls.Add(gVisorReportes);
        }

        /// <summary>Carga el reporte en el visor de reportes.</summary>
        /// <param name="sNombreReporte">Nombre del reporte.</param>
        /// <param name="pParametros">Arreglo con los parámetros del reporte.</param>
        public void cargarReporte(string sNombreReporte, ReportParameter[] pParametros)
        {
            gVisorReportes.Enabled = true;
            gVisorReportes.ServerReport.ReportServerUrl = new Uri(CLASES._Cls_Conexion._Str_ReportServerUrl);
            gVisorReportes.ServerReport.ReportPath = (CLASES._Cls_Conexion._Str_ReportPath + sNombreReporte);
            gVisorReportes.ServerReport.SetParameters(pParametros);
            gVisorReportes.ServerReport.Refresh();
            gVisorReportes.RefreshReport();
        }

        #endregion

        #region Eventos

        /*
         * Eventos públicos personalizados.
         */

        public event DelegadoDespuesSeleccionar FiltroSeleccionado;
        public event DelegadoDespuesSeleccionarAño AñoSeleccionado;
        public event DelegadoDespuesSeleccionarEstado EstadoSeleccionado;
        public event DelegadoEjecutada BotonConsultarClick;
        public event DelegadoClick BotonBuscarClick;
        public event DelegadoValidar Validando;
        public event DelegadoCerrar Cerrando;

        /*
         * Eventos de los controles del multifiltro.
         */

        private void _Ctrl_Multifiltro2014_Load(object sender, EventArgs e)
        {
            _Dtg_Filtros.AutoGenerateColumns = true;

            _Dtp_Desde.Value = DateTime.Now;
            _Dtp_Hasta.Value = DateTime.Now;

            /*
             * Esto es necesario para nivelar el resto de los controles
             * a la altura del combo Filtrar por.
             */

            _Txt_Texto.Location = new Point(_Txt_Texto.Location.X, (_Cmb_Estado.Location.Y + 1));
            _Txt_Buscar.Location = new Point(_Txt_Buscar.Location.X, (_Cmb_Estado.Location.Y + 1));
            _Btn_Buscar.Location = new Point(_Btn_Buscar.Location.X, (_Cmb_Estado.Location.Y - 2));

            _Lbl_Año.Location = new Point(_Lbl_Año.Location.X, _Lbl_Estado.Location.Y);
            _Cmb_Año.Location = new Point(_Cmb_Año.Location.X, _Cmb_Estado.Location.Y);
            _Lbl_Mes.Location = new Point(_Lbl_Mes.Location.X, _Lbl_Estado.Location.Y);
            _Cmb_Mes.Location = new Point(_Cmb_Mes.Location.X, _Cmb_Estado.Location.Y);

            _Lbl_Desde.Location = new Point(_Lbl_Desde.Location.X, _Lbl_Estado.Location.Y);
            _Dtp_Desde.Location = new Point(_Dtp_Desde.Location.X, _Cmb_Estado.Location.Y);
            _Lbl_Hasta.Location = new Point(_Lbl_Hasta.Location.X, _Lbl_Estado.Location.Y);
            _Dtp_Hasta.Location = new Point(_Dtp_Hasta.Location.X, _Cmb_Estado.Location.Y);

            _Cmb_Compuesto.Location = new Point(_Cmb_Compuesto.Location.X, _Cmb_Estado.Location.Y);
            _Btn_Agregar.Location = new Point(_Btn_Agregar.Location.X, _Cmb_Estado.Location.Y - 2);
        }

        private void _Cmb_FiltrarPor_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (FiltroSeleccionado != null)
            {
                FiltroSeleccionado((FiltroCombo)_Cmb_FiltrarPor.SelectedItem, gListaFiltrosGrid);
            }
        }

        private void _Cmb_Estado_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (_Cmb_Estado.SelectedItem != null)
            {
                _Cls_ArrayList oArregloEstado = (_Cls_ArrayList)_Cmb_Estado.SelectedItem;

                // Aqui se evita que se agregue el texto "Seleccionar..." en el grid.

                if (oArregloEstado.Value == "SEL")
                {
                    return;
                }

                agregarFiltroGrid((FiltroCombo)_Cmb_FiltrarPor.SelectedItem, oArregloEstado.Display, oArregloEstado.Value);

                ordenarFiltros();

                cambiarAspectoGrid();

                if (EstadoSeleccionado != null)
                {
                    EstadoSeleccionado(oArregloEstado.Display, oArregloEstado.Value);
                }
            }
        }

        private void _Btn_Consultar_Click(object sender, EventArgs e)
        {
            if (BotonConsultarClick != null)
            {
                bool bCancelar = false;

                if (_Dtg_Filtros.Rows.Count == 0)
                {
                    MessageBox.Show("Debe selecionar un filtro por lo menos.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    return;
                }

                if (Validando != null)
                {
                    Validando(gListaFiltrosGrid, ref bCancelar);
                }

                // Si no existe problema con las validaciones, se ejecuta el método consultar.

                if (!bCancelar)
                {
                    Cursor = Cursors.WaitCursor;

                    BotonConsultarClick(gListaFiltrosGrid);

                    Cursor = Cursors.Default;

                    Hide();
                }
            }
        }

        private void _Btn_Buscar_Click(object sender, EventArgs e)
        {
            if (BotonBuscarClick != null)
            {
                Cursor = Cursors.WaitCursor;

                FiltroCombo oArregloFiltro = (FiltroCombo)_Cmb_FiltrarPor.SelectedItem;

                BotonBuscarClick(oArregloFiltro.Nombre, _Txt_Buscar);

                agregarFiltroGrid(oArregloFiltro, _Txt_Buscar.Text, _Txt_Buscar.Tag.ToString());

                if ((_Txt_Buscar.Text != "") && (_Txt_Buscar.Tag != ""))
                {
                    _Txt_Buscar.Text = "";
                    _Txt_Buscar.Tag = "";
                }

                Cursor = Cursors.Default;

                ordenarFiltros();

                cambiarAspectoGrid();
            }
        }

        private void _Ctrl_MultifiltroCompra_Resize(object sender, EventArgs e)
        {
            if ((Width != 698) || (Height != 343))
            {
                Width = 698;
                Height = 343;
            }
        }

        private void _Txt_Texto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 && e.KeyChar != 13)
            {
                e.Handled = true;                
            }

            if (e.KeyChar == (char)27)
            {
                if (Cerrando != null)
                {
                    Cerrando();
                }

                Hide();
            }
        }

        private void _Txt_Texto_TextChanged(object sender, EventArgs e)
        {
            if (_Txt_Texto.Text != "")
            {
                agregarFiltroGrid((FiltroCombo)_Cmb_FiltrarPor.SelectedItem, _Txt_Texto.Text, _Txt_Texto.Text);

                cambiarAspectoGrid();
            }
            else
            {
                // Si el TextBox queda vacío, se remueve el filtro del DataGridView.

                FiltroCombo oArregloFiltro = (FiltroCombo)_Cmb_FiltrarPor.SelectedItem;

                IEnumerable<FiltroGrid> oDatos = from oFiltro in gListaFiltrosGrid 
                                                 where (oFiltro.Tipo != oArregloFiltro.Tipo)
                                                 select oFiltro;

                gListaFiltrosGrid = oDatos.ToList();

                _Dtg_Filtros.DataSource = null;

                if (gListaFiltrosGrid.Count == 0)
                {
                    _Dtg_Filtros.ColumnHeadersVisible = false;
                }
                else
                {
                    _Dtg_Filtros.DataSource = gListaFiltrosGrid;

                    ordenarFiltros();

                    cambiarAspectoGrid();
                }
            }
        }

        private void _Dtp_Desde_CloseUp(object sender, EventArgs e)
        {
            if ((_Cmb_FiltrarPor.SelectedItem != null) && (_Dtp_Desde.Visible))
            {
                for (int iIndice = 0; iIndice < gListaFiltrosGrid.Count; iIndice++)
                {
                    if (gListaFiltrosGrid[iIndice].Nombre == "cdesde")
                    {
                        gListaFiltrosGrid[iIndice].Descripcion = _Dtp_Desde.Value.ToShortDateString();
                        gListaFiltrosGrid[iIndice].Valor = _Dtp_Desde.Value.ToShortDateString();

                        _Dtg_Filtros.DataSource = gListaFiltrosGrid;
                        _Dtg_Filtros.Refresh();

                        return;
                    }
                }
            }
        }

        private void _Dtp_Hasta_CloseUp(object sender, EventArgs e)
        {
            if ((_Cmb_FiltrarPor.SelectedItem != null) && (_Dtp_Hasta.Visible))
            {
                for (int iIndice = 0; iIndice < gListaFiltrosGrid.Count; iIndice++)
                {
                    if (gListaFiltrosGrid[iIndice].Nombre == "chasta")
                    {
                        gListaFiltrosGrid[iIndice].Descripcion = _Dtp_Hasta.Value.ToShortDateString();
                        gListaFiltrosGrid[iIndice].Valor = _Dtp_Hasta.Value.ToShortDateString();

                        _Dtg_Filtros.DataSource = gListaFiltrosGrid;
                        _Dtg_Filtros.Refresh();

                        return;
                    }
                }
            }
        }

        private void _Btn_Remover_Click(object sender, EventArgs e)
        {
            FiltroCombo oArregloFiltro = (FiltroCombo)_Cmb_FiltrarPor.SelectedItem;

            IEnumerable<FiltroGrid> oFiltros = null, oFiltrosSeleccionados = null, oFiltrosNoSeleccionados = null, oFiltrosFechasAño = null;

            /*
             *  Aqui se hace lo siguiente:
             * 
             *  1. Se extraen los filtros que no están seleccionados en el grid.
             *  2. Se verifica si en los filtros seleccionados exista alguno por fechas o mes y se eliminan ambos (Desde - Hasta) o (Año - Mes).
             *  3. Se actualiza el grid de los filtros.
             */

            oFiltrosNoSeleccionados = from oFiltro in gListaFiltrosGrid 
                                      where (oFiltro.Seleccionar == false) 
                                      select oFiltro;

            //  Aquí se comprueba si los filtros son de fecha o mes para eliminar el par, para la fecha (Desde - Hasta) y para el año (Año - Mes).

            oFiltrosFechasAño = from oFiltro in oFiltrosNoSeleccionados.ToList() where 
                                (
                                    (oFiltro.Tipo == _Enu_MultifiltroTipos.MultifiltroTipoFecha) || 
                                    (oFiltro.Tipo == _Enu_MultifiltroTipos.MultifiltroTipoAñoMes)
                                )
                                select oFiltro;

            if (oFiltrosFechasAño.ToList().Count == 1)
            {
                oFiltros = from oFiltro in oFiltrosNoSeleccionados.ToList() where 
                           (
                                (oFiltro.Tipo != _Enu_MultifiltroTipos.MultifiltroTipoFecha) &&
                                (oFiltro.Tipo != _Enu_MultifiltroTipos.MultifiltroTipoAñoMes)
                           )
                           select oFiltro;
            }
            else
            {
                oFiltros = oFiltrosNoSeleccionados.ToList();
            }

            // Se actualizan los datos.

            gListaFiltrosGrid = oFiltros.ToList();

            _Dtg_Filtros.DataSource = null;

            if (gListaFiltrosGrid.Count == 0)
            {
                _Dtg_Filtros.ColumnHeadersVisible = false;
            }
            else
            {
                _Dtg_Filtros.DataSource = gListaFiltrosGrid;

                ordenarFiltros();

                cambiarAspectoGrid();

                organizarTituloFiltro();

                // Las siguientes líneas son para inicializar los combos.

                if (_Cmb_FiltrarPor.Items.Count > 0)
                {
                    _Cmb_FiltrarPor.SelectedIndex = 0;

                    if (FiltroSeleccionado != null)
                    {
                        FiltroSeleccionado((FiltroCombo)_Cmb_FiltrarPor.SelectedItem, gListaFiltrosGrid);
                    }
                }

                if (_Cmb_Estado.Items.Count > 0)
                {
                    _Cmb_Estado.SelectedIndex = 0;
                }

                if (_Cmb_Compuesto.Items.Count > 0)
                {
                    _Cmb_Compuesto.SelectedIndex = 0;
                }
            }

            if (FiltroSeleccionado != null)
            {
                FiltroSeleccionado((FiltroCombo)_Cmb_FiltrarPor.SelectedItem, gListaFiltrosGrid);
            }
        }

        private void _Btn_Agregar_Click(object sender, EventArgs e)
        {
            IEnumerable<FiltroGrid> oIndice, oExiste;

            FiltroCombo oFiltroCombo = (FiltroCombo)_Cmb_FiltrarPor.SelectedItem;

            _Cls_ArrayList oArreglo = (_Cls_ArrayList)_Cmb_Compuesto.SelectedItem;

            /*
             *  Aqui se hace lo siguiente:
             * 
             *  1. Aqui se evita que se agregue el texto "Seleccionar..." en el grid.
             *  2. Verificamos que el filtro existe en el grid, si existe manda una advertencia.
             *  3. De lo contrario, se agrega al grid el filtro.
             */

            if (oArreglo.Value == "SEL")
            {
                return;
            }

            oExiste = from oFiltro in gListaFiltrosGrid where 
                      (
                        (oFiltro.Valor == oArreglo.Value) && 
                        (oFiltro.Tipo == _Enu_MultifiltroTipos.MultifiltroTipoCompuesto)
                      )
                      select oFiltro;

            if (oExiste.ToList().Count == 1)
            {
                MessageBox.Show("Ya existe un filtro con ese valor.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);

                return;
            }

            Cursor = Cursors.WaitCursor;
            
            _Dtg_Filtros.DataSource = null;

            if ((gSeleccionarTodos) && (oArreglo.Value == "SELT"))
            {
                _Cls_ArrayList oDatos;

                for (int iIndice = 2; iIndice < _Cmb_Compuesto.Items.Count; iIndice++)
                {
                    /*
                     *  Por cada valor en el combo _Cmb_Compuesto:
                     * 
                     *  1. Se genera un índice para el filtro, ejemplo: Proveedor #1, Proveedor #2, Proveedor #3, etc.
                     *  2. Se agregan los datos del combo al grid.
                     */

                    oDatos = (_Cls_ArrayList)_Cmb_Compuesto.Items[iIndice];

                    oIndice = from oFiltro in gListaFiltrosGrid
                              where 
                              (
                                (oFiltro.Tipo == _Enu_MultifiltroTipos.MultifiltroTipoCompuesto) && 
                                (oFiltro.Nombre == oFiltroCombo.Nombre)
                              )
                              select oFiltro;

                    oExiste = from oFiltro in gListaFiltrosGrid
                              where 
                              (
                                (oFiltro.Valor == oDatos.Value) && 
                                (oFiltro.Tipo == _Enu_MultifiltroTipos.MultifiltroTipoCompuesto)
                              )
                              select oFiltro;

                    if (oExiste.ToList().Count == 0)
                    {
                        gListaFiltrosGrid.Add(new FiltroGrid
                        {
                            Tipo = oFiltroCombo.Tipo,
                            Titulo = oFiltroCombo.TituloGrid.Replace(":", " #" + (oIndice.ToList().Count + 1) + ":"),
                            Nombre = oFiltroCombo.Nombre,
                            Valor = oDatos.Value,
                            Descripcion = oDatos.Display
                        });
                    }
                }
            }
            else
            {
                /*
                 *  Por cada valor en el combo _Cmb_Compuesto:
                 * 
                 *  1. Se genera un índice para el filtro, ejemplo: Proveedor #1, Proveedor #2, Proveedor #3, etc.
                 *  2. Se agregan los datos del combo al grid.
                 */

                oIndice = from oFiltro in gListaFiltrosGrid where
                          (
                            (oFiltro.Tipo == _Enu_MultifiltroTipos.MultifiltroTipoCompuesto) && 
                            (oFiltro.Nombre == oFiltroCombo.Nombre)
                          )
                          select oFiltro;

                oExiste = from oFiltro in gListaFiltrosGrid where 
                          (
                            (oFiltro.Valor == oArreglo.Value) && 
                            (oFiltro.Tipo == _Enu_MultifiltroTipos.MultifiltroTipoCompuesto)
                          )
                          select oFiltro;

                if (oExiste.ToList().Count == 0)
                {
                    gListaFiltrosGrid.Add(new FiltroGrid
                    {
                        Tipo = oFiltroCombo.Tipo,
                        Titulo = oFiltroCombo.TituloGrid.Replace(":", " #" + (oIndice.ToList().Count + 1) + ":"),
                        Nombre = oFiltroCombo.Nombre,
                        Valor = oArreglo.Value,
                        Descripcion = oArreglo.Display
                    });
                }
            }

            _Dtg_Filtros.DataSource = gListaFiltrosGrid;

            if (_Dtg_Filtros.Rows.Count > 0)
            {
                _Dtg_Filtros.ColumnHeadersVisible = true;
            }

            ordenarFiltros();

            cambiarAspectoGrid();

            Cursor = Cursors.Default;
        }

        private void _Cmb_FiltrarPor_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)27)
            {
                if (Cerrando != null)
                {
                    Cerrando();
                }

                Hide();
            }
        }

        private void _Cmb_Estado_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)27)
            {
                if (Cerrando != null)
                {
                    Cerrando();
                }

                Hide();
            }
        }

        private void _Btn_Remover_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)27)
            {
                if (Cerrando != null)
                {
                    Cerrando();
                }

                Hide();
            }
        }

        private void _Btn_Consultar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)27)
            {
                if (Cerrando != null)
                {
                    Cerrando();
                }

                Hide();
            }
        }

        private void _Cmb_Año_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)27)
            {
                if (Cerrando != null)
                {
                    Cerrando();
                }

                Hide();
            }
        }

        private void _Cmb_Mes_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)27)
            {
                if (Cerrando != null)
                {
                    Cerrando();
                }

                Hide();
            }
        }

        private void _Cmb_Compuesto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)27)
            {
                if (Cerrando != null)
                {
                    Cerrando();
                }

                Hide();
            }
        }

        private void _Dtp_Desde_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)27)
            {
                if (Cerrando != null)
                {
                    Cerrando();
                }

                Hide();
            }
        }

        private void _Dtp_Hasta_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)27)
            {
                if (Cerrando != null)
                {
                    Cerrando();
                }

                Hide();
            }
        }

        private void _Btn_Buscar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)27)
            {
                if (Cerrando != null)
                {
                    Cerrando();
                }

                Hide();
            }
        }

        private void _Txt_Buscar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)27)
            {
                if (Cerrando != null)
                {
                    Cerrando();
                }

                Hide();
            }
        }

        private void _Ctrl_Multifiltro2014_VisibleChanged(object sender, EventArgs e)
        {
            if (Visible)
            {
                _Cmb_FiltrarPor.Focus();
            }
        }

        private void _Cmb_Año_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (AñoSeleccionado != null)
            {
                _Cls_ArrayList oArreglo = (_Cls_ArrayList)_Cmb_Año.SelectedItem;

                if (AñoSeleccionado != null)
                {
                    Cursor = Cursors.WaitCursor;
                    
                    AñoSeleccionado(oArreglo.Value);

                    Cursor = Cursors.Default;
                }

                for (int iIndice = 0; iIndice < gListaFiltrosGrid.Count; iIndice++)
                {
                    if (gListaFiltrosGrid[iIndice].Nombre == "cano")
                    {
                        gListaFiltrosGrid[iIndice].Descripcion = oArreglo.Display;
                        gListaFiltrosGrid[iIndice].Valor = oArreglo.Value;

                        _Dtg_Filtros.DataSource = gListaFiltrosGrid;
                        _Dtg_Filtros.Refresh();

                        return;
                    }
                }
            }
        }

        private void _Cmb_Mes_SelectedIndexChanged(object sender, EventArgs e)
        {
            _Cls_ArrayList oArreglo = (_Cls_ArrayList)_Cmb_Mes.SelectedItem;

            if (oArreglo != null)
            {
                for (int iIndice = 0; iIndice < gListaFiltrosGrid.Count; iIndice++)
                {
                    if (gListaFiltrosGrid[iIndice].Nombre == "cmes")
                    {
                        gListaFiltrosGrid[iIndice].Descripcion = oArreglo.Display;
                        gListaFiltrosGrid[iIndice].Valor = oArreglo.Value;

                        _Dtg_Filtros.DataSource = gListaFiltrosGrid;
                        _Dtg_Filtros.Refresh();

                        return;
                    }
                }
            }
        }

        #endregion
    }

    #region Clases

    /// <summary>Esta clase se utiliza para capturar los filtros que el usuario ingresa.</summary>
    public class FiltroGrid
    {
        /// <summary>Propiedad para el checkbox de la fila.</summary>
        public bool Seleccionar { get; set; }

        /// <summary>Título del filtro.</summary>
        public string Titulo { get; set; }

        /// <summary>Descripción del filtro.</summary>
        public string Descripcion { get; set; }

        /// <summary>Tipo de filtro a utilizar.</summary>
        public _Enu_MultifiltroTipos Tipo { get; set; }

        /// <summary>Nombre del filtro.</summary>
        public string Nombre { get; set; }

        /// <summary>Valor del filtro.</summary>
        public string Valor { get; set; }
    }

    /// <summary>Esta clase se utiliza en el combo filtrar por para guardar el aspecto de cada filtro.</summary>
    public class FiltroCombo
    {
        /// <summary>Tipo de filtro a utilizar.</summary>
        public _Enu_MultifiltroTipos Tipo { get; set; }

        /// <summary>Nombre del filtro.</summary>
        public string Nombre { get; set; }

        /// <summary>Texto del filtrar por.</summary>
        public string TituloFiltrarPor { get; set; }

        /// <summary>Texto del etiqueta.</summary>
        public string TituloEtiqueta { get; set; }

        /// <summary>Título del filtro.</summary>
        public string TituloGrid { get; set; }
    }

    #endregion
}