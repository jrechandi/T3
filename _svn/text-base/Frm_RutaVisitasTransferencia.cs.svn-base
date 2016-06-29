using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace T3
{
    public partial class Frm_RutaVisitasTransferencia : Form
    {
        // color de la fila seleccionada
        string _Str_FilaSeleccionada = "ü";
        string _Str_FilaDeseleccionada = "û";
        string _G_Str_ClienteNoValido = "";
        string _G_Str_ZonaDestinoNoValida = "";
        public bool _G_ActivarBotonGuardar = false;

        public Frm_RutaVisitasTransferencia()
        {
            InitializeComponent();
            if (CLASES._Cls_Varios_Metodos._Mtd_GetUserIsGerArea(Frm_Padre._Str_Use))
            {
                _Mtd_Actualizar_Zonas(Frm_Padre._Str_Use);
            }
            else
            {
                _Mtd_Actualizar_Zonas();
            }
            _Mtd_Sorted();
        }
        public Frm_RutaVisitasTransferencia(string _P_Str_Zona, string _P_Str_Grupo)
        {
            InitializeComponent();
            if (CLASES._Cls_Varios_Metodos._Mtd_GetUserIsGerArea(Frm_Padre._Str_Use))
            {
                _Mtd_Actualizar_Zonas(Frm_Padre._Str_Use);
            }
            else
            {
                _Mtd_Actualizar_Zonas();
            }
            _Mtd_Sorted();
            int _Int_Row = 0;
            bool _Bol_Encontrado = false;
            foreach (DataGridViewRow _Dg_Row in _Dg_Zonas.Rows)
            {
                if (_Dg_Row.Cells[0].Value.ToString().Trim() == _P_Str_Zona.Trim() & _Dg_Row.Cells[3].Value.ToString().Trim() == _P_Str_Grupo.Trim())
                { _Bol_Encontrado = true; break; }
                _Int_Row++;
            }
            if (_Bol_Encontrado)
            {
                DataGridViewCell _Dg_Cel = _Dg_Zonas.Rows[_Int_Row].Cells[0];
                _Dg_Zonas.CurrentCell = _Dg_Cel;
                _Mtd_RowHeaderMouseClick();
            }
        }
        private void _Mtd_RowHeaderMouseClick()
        {
            _Tb_Tab.Enabled = true;
            _Dg_Zonas.Rows[_Int_Row].DefaultCellStyle.BackColor = Color.White;
            _Dg_Zonas.Rows[_Dg_Zonas.CurrentCell.RowIndex].DefaultCellStyle.BackColor = Color.Yellow;
            _Dg_Zonas.ClearSelection();

            _Int_Row = _Dg_Zonas.CurrentCell.RowIndex;
            _Str_Zona = _Dg_Zonas.Rows[_Dg_Zonas.CurrentCell.RowIndex].Cells[0].Value.ToString().Trim();
            int _Int_Dia = _Tb_Tab.SelectedIndex + 1;
            _Mtd_ActualizarDias(_Int_Dia);
        }
        private void _Mtd_Actualizar_Zonas()
        {
            string _Str_Cadena = "Select c_zona,cname,cgrupovta from VST_ZONAVENTA_VENDEDOR where ccompany='" + Frm_Padre._Str_Comp + "'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            object[] _Obj = new object[4];
            foreach (DataRow _Row in _Ds.Tables[0].Rows)
            {
                _Obj[0] = _Row[0].ToString();
                _Obj[1] = _Row[1].ToString();
                _Obj[2] = "";
                _Obj[3] = _Row[2].ToString();
                _Dg_Zonas.Rows.Add(_Obj);
            }
            _Dg_Zonas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
        }
        private void _Mtd_Actualizar_Zonas(string _Pr_Str_Gerente)
        {
            string _Str_Cadena = "Select c_zona,cname,cgrupovta from VST_ZONAVENTA_VENDEDOR where ccompany='" + Frm_Padre._Str_Comp + "' AND cgerarea='" + _Pr_Str_Gerente + "'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            object[] _Obj = new object[4];
            foreach (DataRow _Row in _Ds.Tables[0].Rows)
            {
                double _Dbl_Uni = 0;
                _Obj[0] = _Row[0].ToString();
                _Obj[1] = _Row[1].ToString();
                _Obj[2] = "";
                _Obj[3] = _Row[2].ToString();
                _Dg_Zonas.Rows.Add(_Obj);
            }
            _Dg_Zonas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
        }
        private void Frm_RutaVisitas_Load(object sender, EventArgs e)
        {
            //Limpio
            _txtCodigoZonaDeVentaDestino.Text = "";
            _txtDescripionZonaDeVentaDestino.Text = "";
        }

        private void _Dg_Zonas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (_Dg_Zonas.Rows.Count > 0)
            {
                if (e.ColumnIndex == 2)
                {
                    Frm_Zonadeventas _Frm = new Frm_Zonadeventas(_Dg_Zonas.Rows[e.RowIndex].Cells[0].Value.ToString().Trim(), _Dg_Zonas.Rows[e.RowIndex].Cells[1].Value.ToString().Trim(), _Dg_Zonas.Rows[e.RowIndex].Cells[3].Value.ToString().Trim());
                    _Frm.MdiParent = this.MdiParent;
                    _Frm.Show();
                }
            }
        }
        public void _Mtd_Sorted()
        {
            for (int _Int_i = 0; _Int_i < _Dg_Zonas.Columns.Count; _Int_i++)
            {
                _Dg_Zonas.Columns[_Int_i].SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }
        int _Int_Row = 0;
        string _Str_Zona = "";
        private void _Dg_Zonas_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (_Dg_Zonas.Rows.Count > 0)
            {
                _Tb_Tab.Enabled = true;
                Cursor = Cursors.WaitCursor;
                _Dg_Zonas.Rows[_Int_Row].DefaultCellStyle.BackColor = Color.White;
                _Dg_Zonas.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Yellow;
                _Dg_Zonas.ClearSelection();

                _Int_Row = e.RowIndex;
                _Str_Zona = _Dg_Zonas.Rows[e.RowIndex].Cells[0].Value.ToString().Trim();
                int _Int_Dia = _Tb_Tab.SelectedIndex + 1;
                //Cargo todo los dias de la semana
                _Mtd_ActualizarDias(1);
                _Mtd_ActualizarDias(2);
                _Mtd_ActualizarDias(3);
                _Mtd_ActualizarDias(4);
                _Mtd_ActualizarDias(5);
                _Mtd_ActualizarDias(6);
                _Mtd_ActualizarDias(7);
                //Devuelvo al Cursor Normal
                Cursor = Cursors.Default;
                //Activo el Boton de Guardar
                _Mtd_ActivarBotones();
            }
        }
        private void _Mtd_ActualizarDias(int _P_Int_Dia)
        {
            string _Str_Cadena = "Select char(251) as Selec, ccliente as Código, c_nomb_comer as Nombre, c_direcc_fiscal as Dirección, cpreferencia as Preferencia,choravisita as Hora from vst_rutavisita where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and ccompany='" + Frm_Padre._Str_Comp + "' and c_zona='" + _Str_Zona + "' and cdiasemana='" + _P_Int_Dia + "' AND c_activo='1'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_P_Int_Dia == 1)
            { 
                _Dg_Lunes.DataSource = _Ds.Tables[0]; 
                _Dg_Lunes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
                _Dg_Lunes.Columns["Selec"].DefaultCellStyle.Font = new Font("Wingdings", 9.25F);
                _Dg_Lunes.Columns["Selec"].Width = 20;
            }
            else if (_P_Int_Dia == 2)
            { 
                _Dg_Martes.DataSource = _Ds.Tables[0]; 
                _Dg_Martes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
                _Dg_Martes.Columns["Selec"].DefaultCellStyle.Font = new Font("Wingdings", 9.25F);
                _Dg_Martes.Columns["Selec"].Width = 20;
            }
            else if (_P_Int_Dia == 3)
            {
                _Dg_Miercoles.DataSource = _Ds.Tables[0]; 
                _Dg_Miercoles.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
                _Dg_Miercoles.Columns["Selec"].DefaultCellStyle.Font = new Font("Wingdings", 9.25F);
                _Dg_Miercoles.Columns["Selec"].Width = 20;
            }
            else if (_P_Int_Dia == 4)
            {
                _Dg_Jueves.DataSource = _Ds.Tables[0];
                _Dg_Jueves.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
                _Dg_Jueves.Columns["Selec"].DefaultCellStyle.Font = new Font("Wingdings", 9.25F);
                _Dg_Jueves.Columns["Selec"].Width = 20;
            }
            else if (_P_Int_Dia == 5)
            { 
                _Dg_Viernes.DataSource = _Ds.Tables[0]; 
                _Dg_Viernes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
                _Dg_Viernes.Columns["Selec"].DefaultCellStyle.Font = new Font("Wingdings", 9.25F);
                _Dg_Viernes.Columns["Selec"].Width = 20;
            }
            else if (_P_Int_Dia == 6)
            {
                _Dg_Sabado.DataSource = _Ds.Tables[0];
                _Dg_Sabado.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
                _Dg_Sabado.Columns["Selec"].DefaultCellStyle.Font = new Font("Wingdings", 9.25F);
                _Dg_Sabado.Columns["Selec"].Width = 20;
            }
            else if (_P_Int_Dia == 7)
            { 
                _Dg_Domingo.DataSource = _Ds.Tables[0]; 
                _Dg_Domingo.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
                _Dg_Domingo.Columns["Selec"].DefaultCellStyle.Font = new Font("Wingdings", 9.25F);
                _Dg_Domingo.Columns["Selec"].Width = 20;
            }
        }

        private void _Tb_Tab_SelectedIndexChanged(object sender, EventArgs e)
        {
            //int _Int_Dia = _Tb_Tab.SelectedIndex + 1;
            //_Mtd_ActualizarDias(_Int_Dia);
        }

        /// <summary>
        /// colorea de rosado el registro seleccionado
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void _Mtd_Seleccionar(object sender, DataGridViewCellMouseEventArgs e)
        {
            DataGridView Control = sender as DataGridView;
            if (Control.RowCount > 0)
            {
                // colorea de rosado el registro seleccionado
                using (DataGridViewRow _DR_Fila = Control.Rows[Control.CurrentCell.RowIndex])
                {
                    if (_DR_Fila.Cells["Selec"].Value.ToString() == _Str_FilaDeseleccionada)
                    {
                        _DR_Fila.Cells["Selec"].Value = _Str_FilaSeleccionada;               
                    }
                    else
                    {
                        _DR_Fila.Cells["Selec"].Value = _Str_FilaDeseleccionada;
                    }
                }
            }
            //Activo el Boton de Guardar
            _Mtd_ActivarBotones();
        }

        private void _Mtd_ActivarBotones()
        {
            int _Int_CantidadDeRutasSeleccionadas = 0;
            //Cuento las rutas seleccionadas
            _Int_CantidadDeRutasSeleccionadas += _Mtd_ContarRutasSeleccionadas(1);
            _Int_CantidadDeRutasSeleccionadas += _Mtd_ContarRutasSeleccionadas(2);
            _Int_CantidadDeRutasSeleccionadas += _Mtd_ContarRutasSeleccionadas(3);
            _Int_CantidadDeRutasSeleccionadas += _Mtd_ContarRutasSeleccionadas(4);
            _Int_CantidadDeRutasSeleccionadas += _Mtd_ContarRutasSeleccionadas(5);
            _Int_CantidadDeRutasSeleccionadas += _Mtd_ContarRutasSeleccionadas(6);
            _Int_CantidadDeRutasSeleccionadas += _Mtd_ContarRutasSeleccionadas(7);

            //Verifico y activo segun el caso
            if (_Int_CantidadDeRutasSeleccionadas > 0)
            {
                _G_ActivarBotonGuardar = true;
                ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_guardar2.Enabled = true;
            }
            else
            {
                _G_ActivarBotonGuardar = false;
                ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_guardar2.Enabled = false;
            }
        }

        public void _Mtd_Ini()
        {
            //Limpio los grid
            _Dg_Lunes.Rows.Clear();
            _Dg_Martes.Rows.Clear();
            _Dg_Miercoles.Rows.Clear();
            _Dg_Jueves.Rows.Clear();
            _Dg_Viernes.Rows.Clear();
            _Dg_Sabado.Rows.Clear();
            _Dg_Domingo.Rows.Clear();
        }

        private int _Mtd_ContarRutasSeleccionadas(int _P_Int_Dia)
        {
            DataGridView _Control = null;
            int _Int_CantidadDeRegistrosSeleccionados = 0;
            //En funcion al parametro asigno el grid correspondiente
            if (_P_Int_Dia == 1)
            { _Control = _Dg_Lunes; }
            else if (_P_Int_Dia == 2)
            { _Control = _Dg_Martes; }
            else if (_P_Int_Dia == 3)
            { _Control = _Dg_Miercoles; }
            else if (_P_Int_Dia == 4)
            { _Control = _Dg_Jueves; }
            else if (_P_Int_Dia == 5)
            { _Control = _Dg_Viernes; }
            else if (_P_Int_Dia == 6)
            { _Control = _Dg_Sabado; }
            else if (_P_Int_Dia == 7)
            { _Control = _Dg_Domingo; }

            // cicla los documentos seleccionados
            foreach (DataGridViewRow _DR_Fila in _Control.Rows)
            {
                // si el documento está seleccionado...
                if (_DR_Fila.Cells["Selec"].Value.ToString() == _Str_FilaSeleccionada)
                {
                    //Cuento
                    _Int_CantidadDeRegistrosSeleccionados++;
                }
            }
            //devuelvo
            return _Int_CantidadDeRegistrosSeleccionados;
        }

        public bool _Mtd_Guardar()
        {
            string _Str_Cadena = "";
            DataSet _Ds;
            string _Str_GrupoDeVentaOrigen = "";
            string _Str_GrupoDeVentaDestino = "";

            //Solicitamos la zona destino
            string _Str_ZonaDestino = _txtCodigoZonaDeVentaDestino.Text;

            //Validamos que se haya selecionado un destino
            if (_Str_ZonaDestino.Trim().Length == 0)
            {
                MessageBox.Show("Error en la operación. Verifique que haya seleccionado una Zona destino.\n", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                _G_ActivarBotonGuardar = true;
                return false;
            }

            //Obtengo el Grupo de Venta origen
            _Str_Cadena = "Select cgrupovta from TZONAVENTA where ccompany='" + Frm_Padre._Str_Comp + "' and c_zona='" + _Str_Zona + "'";
            _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                _Str_GrupoDeVentaOrigen = _Ds.Tables[0].Rows[0]["cgrupovta"].ToString().Trim();
            }
            //Obtengo el Grupo de Venta destino
            _Str_Cadena = "Select cgrupovta from TZONAVENTA where ccompany='" + Frm_Padre._Str_Comp + "' and c_zona='" + _Str_ZonaDestino + "'";
            _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                _Str_GrupoDeVentaDestino = _Ds.Tables[0].Rows[0]["cgrupovta"].ToString().Trim();
            }

            //Validamos que haya seleccionado alguna ruta
            if (!_Mtd_HayAlgunaRutaSeleccionada())
            {
                MessageBox.Show("Error en la operación. Debe Seleccionar alguna ruta para transferir.\n", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                _G_ActivarBotonGuardar = true;
                return false;
            }

            //Validamos cada dia
            if (!_Mtd_SonValidasRutasParaTransferirPorDia(1, _Str_Zona, _Str_GrupoDeVentaOrigen, _Str_ZonaDestino, _Str_GrupoDeVentaDestino))
            {
                MessageBox.Show("Error en la operación. El cliente " + _G_Str_ClienteNoValido + " no es valido para transferir a la Zona " + _G_Str_ZonaDestinoNoValida + ".\n", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                _G_ActivarBotonGuardar = true;
                return false;
            }
            if (!_Mtd_SonValidasRutasParaTransferirPorDia(2, _Str_Zona, _Str_GrupoDeVentaOrigen, _Str_ZonaDestino, _Str_GrupoDeVentaDestino))
            {
                MessageBox.Show("Error en la operación. El cliente " + _G_Str_ClienteNoValido + " no es valido para transferir a la Zona " + _G_Str_ZonaDestinoNoValida + ".\n", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                _G_ActivarBotonGuardar = true;
                return false;
            }
            if (!_Mtd_SonValidasRutasParaTransferirPorDia(3, _Str_Zona, _Str_GrupoDeVentaOrigen, _Str_ZonaDestino, _Str_GrupoDeVentaDestino))
            {
                MessageBox.Show("Error en la operación. El cliente " + _G_Str_ClienteNoValido + " no es valido para transferir a la Zona " + _G_Str_ZonaDestinoNoValida + ".\n", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                _G_ActivarBotonGuardar = true;
                return false;
            }
            if (!_Mtd_SonValidasRutasParaTransferirPorDia(4, _Str_Zona, _Str_GrupoDeVentaOrigen, _Str_ZonaDestino, _Str_GrupoDeVentaDestino))
            {
                MessageBox.Show("Error en la operación. El cliente " + _G_Str_ClienteNoValido + " no es valido para transferir a la Zona " + _G_Str_ZonaDestinoNoValida + ".\n", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                _G_ActivarBotonGuardar = true;
                return false;
            }
            if (!_Mtd_SonValidasRutasParaTransferirPorDia(5, _Str_Zona, _Str_GrupoDeVentaOrigen, _Str_ZonaDestino, _Str_GrupoDeVentaDestino))
            {
                MessageBox.Show("Error en la operación. El cliente " + _G_Str_ClienteNoValido + " no es valido para transferir a la Zona " + _G_Str_ZonaDestinoNoValida + ".\n", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                _G_ActivarBotonGuardar = true;
                return false;
            }
            if (!_Mtd_SonValidasRutasParaTransferirPorDia(6, _Str_Zona, _Str_GrupoDeVentaOrigen, _Str_ZonaDestino, _Str_GrupoDeVentaDestino))
            {
                MessageBox.Show("Error en la operación. El cliente " + _G_Str_ClienteNoValido + " no es valido para transferir a la Zona " + _G_Str_ZonaDestinoNoValida + ".\n", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                _G_ActivarBotonGuardar = true;
                return false;
            }
            if (!_Mtd_SonValidasRutasParaTransferirPorDia(7, _Str_Zona, _Str_GrupoDeVentaOrigen, _Str_ZonaDestino, _Str_GrupoDeVentaDestino))
            {
                MessageBox.Show("Error en la operación. El cliente " + _G_Str_ClienteNoValido + " no es valido para transferir a la Zona " + _G_Str_ZonaDestinoNoValida + ".\n", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                _G_ActivarBotonGuardar = true;
                return false;
            }

            //Guardamos los cambios de la Ruta
            _Mtd_GuardarDias(1, _Str_ZonaDestino, _Str_GrupoDeVentaOrigen, _Str_GrupoDeVentaDestino);
            _Mtd_GuardarDias(2, _Str_ZonaDestino, _Str_GrupoDeVentaOrigen, _Str_GrupoDeVentaDestino);
            _Mtd_GuardarDias(3, _Str_ZonaDestino, _Str_GrupoDeVentaOrigen, _Str_GrupoDeVentaDestino);
            _Mtd_GuardarDias(4, _Str_ZonaDestino, _Str_GrupoDeVentaOrigen, _Str_GrupoDeVentaDestino);
            _Mtd_GuardarDias(5, _Str_ZonaDestino, _Str_GrupoDeVentaOrigen, _Str_GrupoDeVentaDestino);
            _Mtd_GuardarDias(6, _Str_ZonaDestino, _Str_GrupoDeVentaOrigen, _Str_GrupoDeVentaDestino);
            _Mtd_GuardarDias(7, _Str_ZonaDestino, _Str_GrupoDeVentaOrigen, _Str_GrupoDeVentaDestino);

            MessageBox.Show("La operación ha sido realizada correctamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);

            //Volver  cargar todos los dias
            _Mtd_ActualizarDias(1);
            _Mtd_ActualizarDias(2);
            _Mtd_ActualizarDias(3);
            _Mtd_ActualizarDias(4);
            _Mtd_ActualizarDias(5);
            _Mtd_ActualizarDias(6);
            _Mtd_ActualizarDias(7);

            _G_ActivarBotonGuardar = false;
            return true;
        }

        /// <summary>
        /// Guarda la Transferecia de la Ruta
        /// </summary>
        /// <param name="_P_Int_Dia"></param>
        /// <param name="_P_Str_ZonaDestino"></param>
        /// <param name="_P_Str_GrupoDeVentaOrigen"></param>
        /// <param name="_P_Str_GrupoDeVentaDestino"></param>
        private void _Mtd_GuardarDias(int _P_Int_Dia, string _P_Str_ZonaDestino, string _P_Str_GrupoDeVentaOrigen, string _P_Str_GrupoDeVentaDestino)
        {
            DataGridView _Control = null;
            string _Str_Cadena;
            //En funcion al parametro asigno el grid correspondiente
            if (_P_Int_Dia == 1)
            { _Control = _Dg_Lunes; }
            else if (_P_Int_Dia == 2)
            { _Control = _Dg_Martes; }
            else if (_P_Int_Dia == 3)
            { _Control = _Dg_Miercoles; }
            else if (_P_Int_Dia == 4)
            { _Control = _Dg_Jueves; }
            else if (_P_Int_Dia == 5)
            { _Control = _Dg_Viernes; }
            else if (_P_Int_Dia == 6)
            { _Control = _Dg_Sabado; }
            else if (_P_Int_Dia == 7)
            { _Control = _Dg_Domingo; }

            // cicla los documentos seleccionados
            foreach (DataGridViewRow _DR_Fila in _Control.Rows)
            {
                // si el documento está seleccionado...
                if (_DR_Fila.Cells["Selec"].Value.ToString() == _Str_FilaSeleccionada)
                {
                    //Obtenemos lo valores necesarios
                    string _Str_ZonaOrigen = _Str_Zona;
                    string _Str_ccliente = _DR_Fila.Cells["Código"].Value.ToString().Trim();
                    string _Str_cpreferencia = "";
                    string _Str_choravisita = "";
                    string _Str_cincidencia = "";
                    DateTime _Dt_cfechainicio = DateTime.MinValue;

                    //Consultamos los otros datos necesarios
                    _Str_Cadena = "Select * from TRUTAVISITAD where ccompany='" + Frm_Padre._Str_Comp + "' and c_zona='" + _Str_ZonaOrigen + "' and cdiasemana='" + _P_Int_Dia + "' and ccliente='" + _Str_ccliente + "'";
                    DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                    if (_Ds.Tables[0].Rows.Count > 0)
                    {
                        _Str_cpreferencia = _Ds.Tables[0].Rows[0]["cpreferencia"].ToString().Trim();
                        if (_Ds.Tables[0].Rows[0]["choravisita"] != System.DBNull.Value)
                        {
                            _Str_choravisita = _Ds.Tables[0].Rows[0]["choravisita"].ToString().Trim();
                        }
                        _Str_cincidencia = _Ds.Tables[0].Rows[0]["cinsidencia"].ToString().Trim();
                        _Dt_cfechainicio = Convert.ToDateTime(_Ds.Tables[0].Rows[0]["cfechainicio"].ToString().Trim());
                    }

                    // - - - - - - - - - - - - Actualizo la Tabla de Movimientos  - - - - - - - - - - - - (Solo al agregar, mas no existe rutina que guarde si se modifica o elimina)
                    _Str_Cadena = "Select * from TRUTAVISITAM where ccompany='" + Frm_Padre._Str_Comp + "' and c_zona='" + _P_Str_ZonaDestino + "' and cdiasemana='" + _P_Int_Dia + "'";
                    _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                    if (_Ds.Tables[0].Rows.Count == 0)
                    {
                        _Str_Cadena = "Insert into TRUTAVISITAM (ccompany,c_zona,cdiasemana,cdateadd,cuseradd,cdelete) values ('" + Frm_Padre._Str_Comp + "','" + _P_Str_ZonaDestino + "','" + _P_Int_Dia + "',GETDATE(),'" + Frm_Padre._Str_Use + "','0')";
                        Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                    }

                    // - - - - - - - - - - - - MARCAMOS EL DETALLE ACTUAL COMO BORRADO - - - - - - - - - - - -
                    _Str_Cadena = "Update TRUTAVISITAD Set cdatedel=GETDATE(),cuserdel='" + Frm_Padre._Str_Use + "',cdelete='1' where ccompany='" + Frm_Padre._Str_Comp + "' and c_zona='" + _Str_ZonaOrigen + "' and cdiasemana='" + _P_Int_Dia + "' and ccliente='" + _Str_ccliente + "'";
                    Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);

                    // - - - - - - - - - - - - BUSCAMOS SI EXISTE DETALLE EN LA NUEVA ZONA - - - - - - - - - - - -
                    _Str_Cadena = "Select cdelete from TRUTAVISITAD where ccompany='" + Frm_Padre._Str_Comp + "' and c_zona='" + _P_Str_ZonaDestino + "' and cdiasemana='" + _P_Int_Dia + "' and ccliente='" + _Str_ccliente + "'";
                    _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                    if (_Ds.Tables[0].Rows.Count > 0)
                    {
                        //si el registro existe en la zona destino como borrado
                        if (_Ds.Tables[0].Rows[0][0].ToString().Trim() == "1")
                        {
                            //Lo activamos de nuevo
                            _Str_Cadena = "Update TRUTAVISITAD Set cpreferencia='" + _Str_cpreferencia + "',choravisita='" + Convert.ToDateTime(_Str_choravisita).ToShortTimeString() + "',cfechainicio='" + new clslibraryconssa._Cls_Formato("es-VE")._Mtd_fecha(_Dt_cfechainicio) + "',cinsidencia='" + _Str_cincidencia + "',cdateupd=GETDATE(),cuserupd='" + Frm_Padre._Str_Use + "',cdelete='0' where ccompany='" + Frm_Padre._Str_Comp + "' and c_zona='" + _P_Str_ZonaDestino + "' and cdiasemana='" + _P_Int_Dia + "' and ccliente='" + _Str_ccliente + "'";
                            Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                        }
                        else
                        {
                            //Actualizamos su detalle
                            _Str_Cadena = "Update TRUTAVISITAD Set cpreferencia='" + _Str_cpreferencia + "',choravisita='" + Convert.ToDateTime(_Str_choravisita).ToShortTimeString() + "',cfechainicio='" + new clslibraryconssa._Cls_Formato("es-VE")._Mtd_fecha(_Dt_cfechainicio) + "',cinsidencia='" + _Str_cincidencia + "',cdateupd=GETDATE(),cuserupd='" + Frm_Padre._Str_Use + "' where ccompany='" + Frm_Padre._Str_Comp + "' and c_zona='" + _Str_Zona + "' and cdiasemana='" + _P_Int_Dia + "' and ccliente='" + _Str_ccliente + "'";
                            Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                        }
                    }
                    else
                    {
                        //Como no existe, lo insertamos
                        _Str_Cadena = "Insert into TRUTAVISITAD (ccompany,c_zona,cdiasemana,ccliente,cpreferencia,choravisita,cinsidencia,cfechainicio,cdateadd,cuseradd,cdelete) values ('" + Frm_Padre._Str_Comp + "','" + _P_Str_ZonaDestino + "','" + _P_Int_Dia + "','" + _Str_ccliente + "','" + _Str_cpreferencia + "','" + Convert.ToDateTime(_Str_choravisita).ToShortTimeString() + "','" + _Str_cincidencia + "','" + new clslibraryconssa._Cls_Formato("es-VE")._Mtd_fecha(_Dt_cfechainicio) + "',GETDATE(),'" + Frm_Padre._Str_Use + "','0')";
                        Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                    }

                    //Actualizo la Zona del Cliente
                    _Mtd_CambiarZonaCliente(_Str_ccliente, _Str_ZonaOrigen, _P_Str_ZonaDestino, _P_Str_GrupoDeVentaOrigen, _P_Str_GrupoDeVentaDestino);

                }
            }
        }
        /// <summary>
        /// Cambia la Zona del Cliente
        /// </summary>
        /// <param name="_P_Str_ccliente"></param>
        /// <param name="_P_Str_ZonaOrigen"></param>
        /// <param name="_P_Str_ZonaDestino"></param>
        private void _Mtd_CambiarZonaCliente(string _P_Str_ccliente, string _P_Str_ZonaOrigen, string _P_Str_ZonaDestino, string _P_Str_GrupoDeVentaOrigen, string _P_Str_GrupoDeVentaDestino)
        {
            string _Str_Cadena = "";
            DataSet _Ds;
            string _Str_c_rif = "";


            //Obtengo el Rif del cliente
            _Str_Cadena = "Select c_rif from TCLIENTE where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and ccliente='" + _P_Str_ccliente + "'";
            _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                _Str_c_rif = _Ds.Tables[0].Rows[0]["c_rif"].ToString().Trim();
            }

            //Elimino el Registro de la zona anterior
            _Str_Cadena = "DELETE FROM TZONACLIENTE where ccompany='" + Frm_Padre._Str_Comp + "' and c_zona='" + _P_Str_ZonaOrigen + "' and cgrupovta='" + _P_Str_GrupoDeVentaOrigen + "' and ccliente='" + _P_Str_ccliente + "'";
            Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);

            //Busco si esta en  la Zona del cliente existe en el destino
            _Str_Cadena = "Select cdelete from TZONACLIENTE where ccompany='" + Frm_Padre._Str_Comp + "' and c_zona='" + _P_Str_ZonaDestino + "' and ccliente='" + _P_Str_ccliente + "'";
            _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            //Si no existe
            if (_Ds.Tables[0].Rows.Count == 0)
            {
                //Añado
                _Str_Cadena = "'" + Frm_Padre._Str_Comp + "','" + _P_Str_ZonaDestino + "','" + _P_Str_ccliente + "',GETDATE(),'" + Frm_Padre._Str_Use + "','0','" + _P_Str_GrupoDeVentaDestino + "'";
                Program._MyClsCnn._mtd_conexion._Mtd_Insertar("TZONACLIENTE", "ccompany,c_zona,ccliente,cdateadd,cuseradd,cdelete,cgrupovta", _Str_Cadena);
                Program._MyClsCnn._mtd_conexion._Mtd_modificar("TCLIENTE", "c_zonificado='1',cdateupd=GETDATE(),cuserupd='" + Frm_Padre._Str_Use + "'", "cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and ccliente='" + _P_Str_ccliente + "' and c_rif='" + _Str_c_rif + "'");
            }
            else //Si existe el cliente
            {
                //Si esta como borrado
                if (_Ds.Tables[0].Rows[0][0].ToString() == "1")
                {
                    //Elimino el Registro de la zona destino
                    _Str_Cadena = "DELETE FROM TZONACLIENTE where ccompany='" + Frm_Padre._Str_Comp + "' and c_zona='" + _P_Str_ZonaDestino + "' and cgrupovta='" + _P_Str_GrupoDeVentaDestino + "' and ccliente='" + _P_Str_ccliente + "'";
                    Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                    //Agrego el registro en la nueva zona
                    _Str_Cadena = "'" + Frm_Padre._Str_Comp + "','" + _P_Str_ZonaDestino + "','" + _P_Str_ccliente + "',GETDATE(),'" + Frm_Padre._Str_Use + "','0','" + _P_Str_GrupoDeVentaDestino + "'";
                    Program._MyClsCnn._mtd_conexion._Mtd_Insertar("TZONACLIENTE", "ccompany,c_zona,ccliente,cdateadd,cuseradd,cdelete,cgrupovta", _Str_Cadena);
                }
                else
                {
                    MessageBox.Show("Error en la operación. Por aqui nunca debería pasar, falta validacion.\n", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        /// Valida si la Ruta puede ser tranferida
        /// </summary>
        /// <param name="_P_Int_Dia"></param>
        /// <returns></returns>
        private bool _Mtd_SonValidasRutasParaTransferirPorDia(int _P_Int_Dia, string _P_Str_ZonaOrigen, string _P_Str_GrupoDeVentaOrigen, string _P_Str_ZonaDestino, string _P_Str_GrupoDeVentaDestino)
        {
            DataGridView _Control = null;
            string _Str_Cadena;
            DataSet _Ds;
            //En funcion al parametro asigno el grid correspondiente
            if (_P_Int_Dia == 1)
            { _Control = _Dg_Lunes; }
            else if (_P_Int_Dia == 2)
            { _Control = _Dg_Martes; }
            else if (_P_Int_Dia == 3)
            { _Control = _Dg_Miercoles; }
            else if (_P_Int_Dia == 4)
            { _Control = _Dg_Jueves; }
            else if (_P_Int_Dia == 5)
            { _Control = _Dg_Viernes; }
            else if (_P_Int_Dia == 6)
            { _Control = _Dg_Sabado; }
            else if (_P_Int_Dia == 7)
            { _Control = _Dg_Domingo; }

            // cicla los documentos seleccionados
            foreach (DataGridViewRow _DR_Fila in _Control.Rows)
            {
                // si el documento está seleccionado...
                if (_DR_Fila.Cells["Selec"].Value.ToString() == _Str_FilaSeleccionada)
                {
                    //Obtengo los Valores para validar
                    string _Str_ccliente = _DR_Fila.Cells["Código"].Value.ToString().Trim();
                    string _Str_Descripcion = _DR_Fila.Cells["Nombre"].Value.ToString().Trim();

                    //Validamos
                    //Busco si el cliente existe en la Zona Destino (excepto  el grupo actual)
                    _Str_Cadena = "Select cdelete from TZONACLIENTE where ccompany='" + Frm_Padre._Str_Comp + "' and cgrupovta='" + _P_Str_GrupoDeVentaDestino + "' and ccliente='" + _Str_ccliente + "' and cgrupovta<>'" + _P_Str_GrupoDeVentaOrigen + "'";
                    _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                    //Si existe
                    if (_Ds.Tables[0].Rows.Count > 0)
                    {
                        //si el registro existe en la zona destino como activo, no permitimos la transferencia
                        if (_Ds.Tables[0].Rows[0][0].ToString().Trim() != "1")
                        {
                            //Guardamos la Variables Globales
                            _G_Str_ClienteNoValido = _Str_ccliente + "-" + _Str_Descripcion;
                            _G_Str_ZonaDestinoNoValida = _P_Str_GrupoDeVentaDestino;

                            //Devolvemos
                            return false;
                        }
                    }
                }
            }

            //Si pasamos por aqui, todas las rutas son validas para transferir
            return true;
        }

        /// <summary>
        /// Indica si existe alguna ruta seleccionada
        /// </summary>
        /// <returns></returns>
        private bool _Mtd_HayAlgunaRutaSeleccionada()
        {
            DataGridView _Control = null;
            int _Int_Dia;

            //Recorro todos los dias
            for (_Int_Dia = 1; _Int_Dia < 8; _Int_Dia++)
            {
                //En funcion al parametro asigno el grid correspondiente
                if (_Int_Dia == 1)
                { _Control = _Dg_Lunes; }
                else if (_Int_Dia == 2)
                { _Control = _Dg_Martes; }
                else if (_Int_Dia == 3)
                { _Control = _Dg_Miercoles; }
                else if (_Int_Dia == 4)
                { _Control = _Dg_Jueves; }
                else if (_Int_Dia == 5)
                { _Control = _Dg_Viernes; }
                else if (_Int_Dia == 6)
                { _Control = _Dg_Sabado; }
                else if (_Int_Dia == 7)
                { _Control = _Dg_Domingo; }

                // Recorro los documentos seleccionados
                foreach (DataGridViewRow _DR_Fila in _Control.Rows)
                {
                    // si el documento está seleccionado...
                    if (_DR_Fila.Cells["Selec"].Value.ToString() == _Str_FilaSeleccionada)
                    {
                        //devolvemos
                        return true;
                    }
                }
            }

            //Si pasamos por aqui, no hay rutas seleccionadas
            return false;
        }

        /// <summary>
        /// Selecciona todas las rutas de todos los dias
        /// </summary>
        private void _Mtd_SeleccionarTodasLasRutasDeTodosLosDias(bool _P_Bool_Seleccionar)
        {
            DataGridView _Control = null;
            int _Int_Dia;

            //Recorro todos los dias
            for (_Int_Dia = 1; _Int_Dia < 8; _Int_Dia++)
            {
                //En funcion al parametro asigno el grid correspondiente
                if (_Int_Dia == 1)
                { _Control = _Dg_Lunes; }
                else if (_Int_Dia == 2)
                { _Control = _Dg_Martes; }
                else if (_Int_Dia == 3)
                { _Control = _Dg_Miercoles; }
                else if (_Int_Dia == 4)
                { _Control = _Dg_Jueves; }
                else if (_Int_Dia == 5)
                { _Control = _Dg_Viernes; }
                else if (_Int_Dia == 6)
                { _Control = _Dg_Sabado; }
                else if (_Int_Dia == 7)
                { _Control = _Dg_Domingo; }

                // Recorro los documentos seleccionados
                foreach (DataGridViewRow _DR_Fila in _Control.Rows)
                {
                    //Selecciono 
                    if (_P_Bool_Seleccionar)
                    {
                        _DR_Fila.Cells["Selec"].Value = _Str_FilaSeleccionada;
                    }
                    else
                    {
                        _DR_Fila.Cells["Selec"].Value = _Str_FilaDeseleccionada;
                    }
                }
            }

        }

        private void _Dg_Lunes_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            _Mtd_Seleccionar(sender, e);
        }

        private void _Dg_Martes_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            _Mtd_Seleccionar(sender, e);
        }

        private void _Dg_Miercoles_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            _Mtd_Seleccionar(sender, e);
        }

        private void _Dg_Jueves_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            _Mtd_Seleccionar(sender, e);
        }

        private void _Dg_Viernes_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            _Mtd_Seleccionar(sender, e);
        }

        private void _Dg_Sabado_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            _Mtd_Seleccionar(sender, e);
        }

        private void _Dg_Domingo_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            _Mtd_Seleccionar(sender, e);
        }

        private DateTime _Mtd_Buscar_Dia(int _P_Int_Dia)
        {
            DateTime _Date = new DateTime(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate().Year, CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate().Month, CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate().Day);
            DayOfWeek _DayOf = new DayOfWeek();
            if (_P_Int_Dia == 1)
            { _DayOf = DayOfWeek.Monday; }
            else if (_P_Int_Dia == 2)
            { _DayOf = DayOfWeek.Tuesday; }
            else if (_P_Int_Dia == 3)
            { _DayOf = DayOfWeek.Wednesday; }
            else if (_P_Int_Dia == 4)
            { _DayOf = DayOfWeek.Thursday; }
            else if (_P_Int_Dia == 5)
            { _DayOf = DayOfWeek.Friday; }
            else if (_P_Int_Dia == 6)
            { _DayOf = DayOfWeek.Saturday; }
            else if (_P_Int_Dia == 7)
            { _DayOf = DayOfWeek.Sunday; }
            if (DateTime.Now.DayOfWeek.Equals(_DayOf))
            { return CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate(); }
            else
            {
                TimeSpan _Tim = new TimeSpan(1, 0, 0, 0);
                while (true)
                {
                    _Date += _Tim;
                    if (_Date.DayOfWeek == _DayOf)
                    {
                        return _Date.Date;
                    }
                }
            }
        }

        private void Frm_RutaVisitas_Activated(object sender, EventArgs e)
        {
            CONTROLES._Ctrl_Buscar._frm_Formulario = this;
            CONTROLES._Ctrl_Buscar._Bl_Especial = true;
            CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "";
            CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "Cerrado";
            ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_guardar2.Enabled = _G_ActivarBotonGuardar;

        }

        private void _Dg_Zonas_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
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

        private void _Dg_Lunes_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == -1 && e.RowIndex > -1)
            {
                _Lbl_DgLunesInfo.Visible = true;
            }
            else
            {
                _Lbl_DgLunesInfo.Visible = false;
            }
        }

        private void _Dg_Martes_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == -1 && e.RowIndex > -1)
            {
                _Lbl_DgMartesInfo.Visible = true;
            }
            else
            {
                _Lbl_DgMartesInfo.Visible = false;
            }
        }

        private void _Dg_Miercoles_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == -1 && e.RowIndex > -1)
            {
                _Lbl_DgMiercolesInfo.Visible = true;
            }
            else
            {
                _Lbl_DgMiercolesInfo.Visible = false;
            }
        }

        private void _Dg_Jueves_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == -1 && e.RowIndex > -1)
            {
                _Lbl_DgJuevesInfo.Visible = true;
            }
            else
            {
                _Lbl_DgJuevesInfo.Visible = false;
            }
        }

        private void _Dg_Viernes_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == -1 && e.RowIndex > -1)
            {
                _Lbl_DgViernesInfo.Visible = true;
            }
            else
            {
                _Lbl_DgViernesInfo.Visible = false;
            }
        }

        private void _Dg_Sabado_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == -1 && e.RowIndex > -1)
            {
                _Lbl_DgSabadoInfo.Visible = true;
            }
            else
            {
                _Lbl_DgSabadoInfo.Visible = false;
            }
        }

        private void _Dg_Domingo_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == -1 && e.RowIndex > -1)
            {
                _Lbl_DgDomingoInfo.Visible = true;
            }
            else
            {
                _Lbl_DgDomingoInfo.Visible = false;
            }
        }

        private void _Dg_Zonas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private DayOfWeek _Mtd_Retornar_Dia(int _P_Int_Dia)
        {
            DayOfWeek _DayOf = new DayOfWeek();
            if (_P_Int_Dia == 1)
            { _DayOf = DayOfWeek.Monday; }
            else if (_P_Int_Dia == 2)
            { _DayOf = DayOfWeek.Tuesday; }
            else if (_P_Int_Dia == 3)
            { _DayOf = DayOfWeek.Wednesday; }
            else if (_P_Int_Dia == 4)
            { _DayOf = DayOfWeek.Thursday; }
            else if (_P_Int_Dia == 5)
            { _DayOf = DayOfWeek.Friday; }
            else if (_P_Int_Dia == 6)
            { _DayOf = DayOfWeek.Saturday; }
            else if (_P_Int_Dia == 7)
            { _DayOf = DayOfWeek.Sunday; }
            return _DayOf;
        }

        private void _Bt_SeleccionarZonaDeVentaDestino_Click(object sender, EventArgs e)
        {
            {
                Cursor = Cursors.WaitCursor;
                TextBox _Txt_Codigo = new TextBox();
                TextBox _Txt_Cliente2 = new TextBox();
                ToolStripMenuItem[] _Tsm_Menu = new ToolStripMenuItem[3];
                _Tsm_Menu[0] = new ToolStripMenuItem("Código");
                _Tsm_Menu[1] = new ToolStripMenuItem("Descripción");
                _Tsm_Menu[2] = new ToolStripMenuItem("Grupo de Vta.");
                string[] _Str_Campos = new string[3];
                _Str_Campos[0] = "c_zona";
                _Str_Campos[1] = "c_zona_name";
                _Str_Campos[2] = "cgrupovta_name";
                string _Str_Cadena = "SELECT c_zona AS Código, RTRIM(c_zona_name) AS Descripción, RTRIM(cgrupovta_name) AS [Grupo de Vta.], cgrupovta " +
                                     "FROM VST_GRUPOVTA_ZONAVTA " +
                                     "WHERE c_zona_cdelete = 0 AND cgrupovta_cdelete=0 AND ccompany='" + Frm_Padre._Str_Comp + "'";
                Frm_Busqueda _Frm = new Frm_Busqueda(_Txt_Codigo, _Txt_Cliente2, _Str_Cadena, _Str_Campos, "Zonas", _Tsm_Menu, 0, 1);
                _Frm.ShowDialog(this);
                if (_Txt_Codigo.Text.Trim().Length > 0)
                {
                    _txtCodigoZonaDeVentaDestino.Text = _Txt_Codigo.Text;
                    _txtDescripionZonaDeVentaDestino.Text = _Txt_Cliente2.Text;
                }
                else
                {
                    _txtCodigoZonaDeVentaDestino.Text = _Txt_Codigo.Text;
                    _txtDescripionZonaDeVentaDestino.Text = _Txt_Cliente2.Text;
                }
                Cursor = Cursors.Default;

                //Vuelvo a asignar el formulario inicial al control
                CONTROLES._Ctrl_Buscar._frm_Formulario = this;
                CONTROLES._Ctrl_Buscar._Bl_Especial = true;
                CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "";
                CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "Cerrado";
                ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_guardar2.Enabled = _G_ActivarBotonGuardar;
            }
        }

        /// <summary>
        /// Selecciona todas las rutas de todos los dias de la semana
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void _Btn_SeleccionarTodosLasRutasTodosLosDias_Click(object sender, EventArgs e)
        {
            _Mtd_SeleccionarTodasLasRutasDeTodosLosDias(true);
            _Dg_Martes.Refresh();
            //Activo el Boton de Guardar
            _Mtd_ActivarBotones();
        }

        /// <summary>
        /// Deselecciona todas las rutas de todos los dias de la semana
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void _Btn_DeseleccionarTodosLasRutasTodosLosDias_Click(object sender, EventArgs e)
        {
            _Mtd_SeleccionarTodasLasRutasDeTodosLosDias(false);
            _Dg_Martes.Refresh();
            //Activo el Boton de Guardar
            _Mtd_ActivarBotones();
        }

        private void _Tol_Seleccionar_Click(object sender, EventArgs e)
        {
            // Try to cast the sender to a MenuItem
            ToolStripItem _menuItem = sender as ToolStripItem;
            if (_menuItem != null)
            {
                // Retrieve the ContextMenuStrip that contains this MenuItem
                ContextMenuStrip owner = _menuItem.Owner as ContextMenuStrip;

                if (owner != null)
                {
                    // Get the control that is displaying this context menu
                    Control _sourceControl = owner.SourceControl;
                    //Detecto las filas seleccionadas
                    DataGridView _Control = _sourceControl as DataGridView;
                    //Si hay filas selecionadas
                    if (_Control.SelectedRows.Count > 0)
                    {
                        //Recorro las Filas Seleccionadas
                        foreach (DataGridViewRow _DR_Fila in _Control.SelectedRows)
                        {
                            // Selecciono 
                            _DR_Fila.Cells["Selec"].Value = _Str_FilaSeleccionada;
                        }
                    }
                    //Activo el Boton de Guardar
                    _Mtd_ActivarBotones();
                }
            }
        }
        private void _Tol_Desseleccionar_Click(object sender, EventArgs e)
        {
            // Try to cast the sender to a MenuItem
            ToolStripItem _menuItem = sender as ToolStripItem;
            if (_menuItem != null)
            {
                // Retrieve the ContextMenuStrip that contains this MenuItem
                ContextMenuStrip owner = _menuItem.Owner as ContextMenuStrip;

                if (owner != null)
                {
                    // Get the control that is displaying this context menu
                    Control _sourceControl = owner.SourceControl;
                    //Detecto las filas seleccionadas
                    DataGridView _Control = _sourceControl as DataGridView;
                    //Si hay filas selecionadas
                    if (_Control.SelectedRows.Count > 0)
                    {
                        //Recorro las Filas Seleccionadas
                        foreach (DataGridViewRow _DR_Fila in _Control.SelectedRows)
                        {
                            // Deselecciono 
                            _DR_Fila.Cells["Selec"].Value = _Str_FilaDeseleccionada;
                        }
                    }
                    //Activo el Boton de Guardar
                    _Mtd_ActivarBotones();
                }
            }
        }

    }
}