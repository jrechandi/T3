using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace T3
{
    public partial class Frm_RutaVisitas : Form
    {
        public Frm_RutaVisitas()
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
        public Frm_RutaVisitas(string _P_Str_Zona,string _P_Str_Grupo)
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
        DateTime _Dtm_Temp;
        private void _Mtd_Mostrar_Informacion(string _P_Str_Cliente,int _P_Int_Dia)
        {
            _Txt_Cliente.Text = "";
            _Txt_Des_Cliente.Text = "";
            _Txt_Direccion.Text = "";
            _Txt_Preferencia.Text = "";
            //_Dtp_Fecha_Inicio.MaxDate = new DateTime(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate().Year, CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate().Month, CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate().Day);
            _Dtp_Fecha_Inicio.Value = new DateTime(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate().Year, CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate().Month, CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate().Day); 
            _Dtp_Hora.Value = CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate();
            string _Str_Cadena = "Select cinsidencia,cfechainicio,choravisita,cpreferencia from TRUTAVISITAD where ccompany='" + Frm_Padre._Str_Comp + "' and c_zona='" + _Str_Zona + "' and ccliente='" + _P_Str_Cliente + "' and cdiasemana='" + _P_Int_Dia.ToString() + "'";
            DataSet _Ds2=Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            bool _Bol_cinsidencia = false;
            bool _Bol_cfechainicio = false;
            if (_Ds2.Tables[0].Rows.Count > 0)
            {
                if (_Ds2.Tables[0].Rows[0][0] != System.DBNull.Value)
                { _Bol_cinsidencia = true; }
                if (_Ds2.Tables[0].Rows[0][1] != System.DBNull.Value)
                { _Bol_cfechainicio = true; }
                _Txt_Preferencia.Text = _Ds2.Tables[0].Rows[0]["cpreferencia"].ToString().Trim();
                if (_Ds2.Tables[0].Rows[0]["choravisita"] != System.DBNull.Value)
                {
                    _Dtp_Hora.Value = Convert.ToDateTime(_Ds2.Tables[0].Rows[0]["choravisita"].ToString().Trim());
                }
            }
            _Str_Cadena = "Select ccliente,c_fechainical,c_tipvisita,c_direcc_fiscal,c_nomb_comer from TCLIENTE where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and ccliente='" + _P_Str_Cliente + "'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count > 0)
            {

                _Txt_Cliente.Text = _P_Str_Cliente;
                _Txt_Des_Cliente.Text = _Ds.Tables[0].Rows[0]["c_nomb_comer"].ToString();
                _Txt_Direccion.Text = _Ds.Tables[0].Rows[0]["c_direcc_fiscal"].ToString();
                if (_Bol_cinsidencia)
                {
                    if (_Ds2.Tables[0].Rows[0]["cinsidencia"].ToString().Trim() == "0")
                    { _Cmb_Tipo.SelectedIndex = 0; }
                    else if (_Ds2.Tables[0].Rows[0]["cinsidencia"].ToString().Trim() == "1")
                    { _Cmb_Tipo.SelectedIndex = 1; }
                    else if (_Ds2.Tables[0].Rows[0]["cinsidencia"].ToString().Trim() == "2")
                    { _Cmb_Tipo.SelectedIndex = 2; }
                }
                else
                {
                    if (_Ds.Tables[0].Rows[0]["c_tipvisita"].ToString().Trim() == "0")
                    { _Cmb_Tipo.SelectedIndex = 0; }
                    else if (_Ds.Tables[0].Rows[0]["c_tipvisita"].ToString().Trim() == "1")
                    { _Cmb_Tipo.SelectedIndex = 1; }
                    else if (_Ds.Tables[0].Rows[0]["c_tipvisita"].ToString().Trim() == "2")
                    { _Cmb_Tipo.SelectedIndex = 2; }
                }
                if (_Bol_cfechainicio)
                {
                    if (_Ds2.Tables[0].Rows[0]["cfechainicio"] != System.DBNull.Value)
                    {
                        //_Dtp_Fecha_Inicio.MaxDate = Convert.ToDateTime(_Ds2.Tables[0].Rows[0]["cfechainicio"].ToString().Trim());
                        _Dtp_Fecha_Inicio.Value = Convert.ToDateTime(_Ds2.Tables[0].Rows[0]["cfechainicio"].ToString().Trim());
                    }
                }
                else
                {
                    if (_Ds.Tables[0].Rows[0]["c_fechainical"] != System.DBNull.Value)
                    {
                        //_Dtp_Fecha_Inicio.MaxDate = _Mtd_Buscar_Dia(_P_Int_Dia);
                        _Dtp_Fecha_Inicio.Value = _Mtd_Buscar_Dia(_P_Int_Dia);
                    }
                }
            }
        }

        private void _Pnl_Direccion_VisibleChanged(object sender, EventArgs e)
        {
            if (_Pnl_Direccion.Visible)
            {
                _Tb_Tab.Enabled = false; _Grb_Zonas.Enabled = false; 
            }
            else
            { _Tb_Tab.Enabled = true; _Grb_Zonas.Enabled = true; }
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
            string _Str_Cadena = "Select c_zona,cname,cgrupovta from VST_ZONAVENTA_VENDEDOR where ccompany='" + Frm_Padre._Str_Comp + "' AND cgerarea='"+ _Pr_Str_Gerente +"'";
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
        string _Str_Zona="";
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
                _Mtd_ActualizarDias(_Int_Dia);
                Cursor = Cursors.Default;
            }
        }
        private void _Mtd_ActualizarDias(int _P_Int_Dia)
        {
            string _Str_Cadena = "Select ccliente as Código, c_nomb_comer as Nombre, c_direcc_fiscal as Dirección, cpreferencia as Preferencia,choravisita as Hora from vst_rutavisita where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and ccompany='" + Frm_Padre._Str_Comp + "' and c_zona='" + _Str_Zona + "' and cdiasemana='" + _P_Int_Dia + "' AND c_activo='1'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_P_Int_Dia == 1)
            { _Dg_Lunes.DataSource = _Ds.Tables[0]; _Dg_Lunes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells; }
            else if (_P_Int_Dia == 2)
            { _Dg_Martes.DataSource = _Ds.Tables[0]; _Dg_Martes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells; }
            else if (_P_Int_Dia == 3)
            { _Dg_Miercoles.DataSource = _Ds.Tables[0]; _Dg_Miercoles.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells; }
            else if (_P_Int_Dia == 4)
            { _Dg_Jueves.DataSource = _Ds.Tables[0]; _Dg_Jueves.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells; }
            else if (_P_Int_Dia == 5)
            { _Dg_Viernes.DataSource = _Ds.Tables[0]; _Dg_Viernes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells; }
            else if (_P_Int_Dia == 6)
            { _Dg_Sabado.DataSource = _Ds.Tables[0]; _Dg_Sabado.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells; }
            else if (_P_Int_Dia == 7)
            { _Dg_Domingo.DataSource = _Ds.Tables[0]; _Dg_Domingo.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells; }
        }

        private void _Tb_Tab_SelectedIndexChanged(object sender, EventArgs e)
        {
            int _Int_Dia = _Tb_Tab.SelectedIndex + 1;
            _Mtd_ActualizarDias(_Int_Dia);
        }
        private void _Mtd_Agregar(int _P_Int_Dia)
        {
            int _Int_Index=0;
            if(_Cmb_Tipo.SelectedIndex==0)
            {_Int_Index=0;}
            else if(_Cmb_Tipo.SelectedIndex==1)
            {_Int_Index=1;}
            else if(_Cmb_Tipo.SelectedIndex==2)
            {_Int_Index=2;}
            if (_Mtd_Retornar_Dia(_P_Int_Dia) == _Dtp_Fecha_Inicio.Value.DayOfWeek)
            {
                string _Str_Cadena = "Select * from TRUTAVISITAM where ccompany='" + Frm_Padre._Str_Comp + "' and c_zona='" + _Str_Zona + "' and cdiasemana='" + _P_Int_Dia + "'";
                DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                if (_Ds.Tables[0].Rows.Count == 0)
                {
                    _Str_Cadena = "Insert into TRUTAVISITAM (ccompany,c_zona,cdiasemana,cdateadd,cuseradd,cdelete) values ('" + Frm_Padre._Str_Comp + "','" + _Str_Zona + "','" + _P_Int_Dia + "',GETDATE(),'" + Frm_Padre._Str_Use + "','0')";
                    Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                }
                _Str_Cadena = "Select cdelete from TRUTAVISITAD where ccompany='" + Frm_Padre._Str_Comp + "' and c_zona='" + _Str_Zona + "' and cdiasemana='" + _P_Int_Dia + "' and ccliente='" + _Txt_Cliente.Text.Trim() + "'";
                _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                if (_Ds.Tables[0].Rows.Count > 0)
                {
                    if (_Ds.Tables[0].Rows[0][0].ToString().Trim() == "1")
                    {
                        if (MessageBox.Show("Este registro ha sido eliminado de la zona " + _Str_Zona.Trim() + ". ¿Desea activarlo nuevamente?", "Información", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            _Str_Cadena = "Update TRUTAVISITAD Set cpreferencia='" + _Txt_Preferencia.Text.Trim() + "',choravisita='" + _Dtp_Hora.Value.ToShortTimeString() + "',cfechainicio='" + new clslibraryconssa._Cls_Formato("es-VE")._Mtd_fecha(_Dtp_Fecha_Inicio.Value) + "',cinsidencia='" + _Int_Index.ToString() + "',cdateupd=GETDATE(),cuserupd='" + Frm_Padre._Str_Use + "',cdelete='0' where ccompany='" + Frm_Padre._Str_Comp + "' and c_zona='" + _Str_Zona + "' and cdiasemana='" + _P_Int_Dia + "' and ccliente='" + _Txt_Cliente.Text.Trim() + "'";
                            Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                            MessageBox.Show("La operación ha sido realizada correctamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        _Str_Cadena = "Update TRUTAVISITAD Set cpreferencia='" + _Txt_Preferencia.Text.Trim() + "',choravisita='" + _Dtp_Hora.Value.ToShortTimeString() + "',cfechainicio='" + new clslibraryconssa._Cls_Formato("es-VE")._Mtd_fecha(_Dtp_Fecha_Inicio.Value) + "',cinsidencia='" + _Int_Index.ToString() + "',cdateupd=GETDATE(),cuserupd='" + Frm_Padre._Str_Use + "' where ccompany='" + Frm_Padre._Str_Comp + "' and c_zona='" + _Str_Zona + "' and cdiasemana='" + _P_Int_Dia + "' and ccliente='" + _Txt_Cliente.Text.Trim() + "'";
                        Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                        MessageBox.Show("La operación ha sido realizada correctamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    _Str_Cadena = "Select cdelete from TRUTAVISITAD where ccompany='" + Frm_Padre._Str_Comp + "' and c_zona='" + _Str_Zona + "' and ccliente='" + _Txt_Cliente.Text.Trim() + "' and cdelete='0'";
                    _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                    if (_Ds.Tables[0].Rows.Count == 0)
                    {
                        _Str_Cadena = "Insert into TRUTAVISITAD (ccompany,c_zona,cdiasemana,ccliente,cpreferencia,choravisita,cinsidencia,cfechainicio,cdateadd,cuseradd,cdelete) values ('" + Frm_Padre._Str_Comp + "','" + _Str_Zona + "','" + _P_Int_Dia + "','" + _Txt_Cliente.Text.Trim() + "','" + _Txt_Preferencia.Text.Trim() + "','" + _Dtp_Hora.Value.ToShortTimeString() + "','" + _Int_Index.ToString() + "','" + new clslibraryconssa._Cls_Formato("es-VE")._Mtd_fecha(_Dtp_Fecha_Inicio.Value) + "',GETDATE(),'" + Frm_Padre._Str_Use + "','0')";
                        Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                        MessageBox.Show("La operación ha sido realizada correctamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Disculpe, ya el cliente se encuentra registrado para esta zona en otro día", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                _Mtd_ActualizarDias(_P_Int_Dia);
                _Pnl_Direccion.Visible = false;
            }
            else
            {
                MessageBox.Show("Debe seleccionar una fecha que corresponda al día seleccionado", "Información", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void _Mtd_CrearGridExportar()
        {
            _Mtd_ActualizarDias(1);
            _Mtd_ActualizarDias(2);
            _Mtd_ActualizarDias(3);
            _Mtd_ActualizarDias(4);
            _Mtd_ActualizarDias(5);
            _Mtd_ActualizarDias(6);
            _Mtd_ActualizarDias(7);
            if (_Sfd_1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    DataGridView _Dtg_Grid = new DataGridView();
                    DataGridViewTextBoxColumn _Dtg_Columna = new DataGridViewTextBoxColumn();
                    DataGridViewTextBoxColumn _Dtg_Columna1 = new DataGridViewTextBoxColumn();
                    DataGridViewTextBoxColumn _Dtg_Columna2 = new DataGridViewTextBoxColumn();
                    DataGridViewTextBoxColumn _Dtg_Columna3 = new DataGridViewTextBoxColumn();
                    DataGridViewTextBoxColumn _Dtg_Columna4 = new DataGridViewTextBoxColumn();
                    DataGridViewTextBoxColumn _Dtg_Columna5 = new DataGridViewTextBoxColumn();
                    _Dtg_Grid.Columns.Add(_Dtg_Columna);
                    _Dtg_Grid.Columns.Add(_Dtg_Columna1);
                    _Dtg_Grid.Columns.Add(_Dtg_Columna2);
                    _Dtg_Grid.Columns.Add(_Dtg_Columna3);
                    _Dtg_Grid.Columns.Add(_Dtg_Columna4);
                    _Dtg_Grid.Columns.Add(_Dtg_Columna5);
                    _Dtg_Grid.Columns[0].HeaderText = "Día";
                    _Dtg_Grid.Columns[1].HeaderText = "Código";
                    _Dtg_Grid.Columns[2].HeaderText = "Nombre";
                    _Dtg_Grid.Columns[3].HeaderText = "Dirección";
                    _Dtg_Grid.Columns[4].HeaderText = "Preferencia";
                    _Dtg_Grid.Columns[5].HeaderText = "Hora";
                    foreach (DataGridViewRow _Dtg_Row in _Dg_Lunes.Rows)
                    {
                        _Dtg_Grid.Rows.Add(new object[] { "Lunes", _Dtg_Row.Cells[0].Value.ToString(), _Dtg_Row.Cells[1].Value.ToString(), _Dtg_Row.Cells[2].Value.ToString(), _Dtg_Row.Cells[3].Value.ToString(), _Dtg_Row.Cells[4].Value.ToString() });
                    }
                    foreach (DataGridViewRow _Dtg_Row in _Dg_Martes.Rows)
                    {
                        _Dtg_Grid.Rows.Add(new object[] { "Martes", _Dtg_Row.Cells[0].Value.ToString(), _Dtg_Row.Cells[1].Value.ToString(), _Dtg_Row.Cells[2].Value.ToString(), _Dtg_Row.Cells[3].Value.ToString(), _Dtg_Row.Cells[4].Value.ToString() });
                    }
                    foreach (DataGridViewRow _Dtg_Row in _Dg_Miercoles.Rows)
                    {
                        _Dtg_Grid.Rows.Add(new object[] { "Miércoles", _Dtg_Row.Cells[0].Value.ToString(), _Dtg_Row.Cells[1].Value.ToString(), _Dtg_Row.Cells[2].Value.ToString(), _Dtg_Row.Cells[3].Value.ToString(), _Dtg_Row.Cells[4].Value.ToString() });
                    }
                    foreach (DataGridViewRow _Dtg_Row in _Dg_Jueves.Rows)
                    {
                        _Dtg_Grid.Rows.Add(new object[] { "Jueves", _Dtg_Row.Cells[0].Value.ToString(), _Dtg_Row.Cells[1].Value.ToString(), _Dtg_Row.Cells[2].Value.ToString(), _Dtg_Row.Cells[3].Value.ToString(), _Dtg_Row.Cells[4].Value.ToString() });
                    }
                    foreach (DataGridViewRow _Dtg_Row in _Dg_Viernes.Rows)
                    {
                        _Dtg_Grid.Rows.Add(new object[] { "Viernes", _Dtg_Row.Cells[0].Value.ToString(), _Dtg_Row.Cells[1].Value.ToString(), _Dtg_Row.Cells[2].Value.ToString(), _Dtg_Row.Cells[3].Value.ToString(), _Dtg_Row.Cells[4].Value.ToString() });
                    }
                    foreach (DataGridViewRow _Dtg_Row in _Dg_Sabado.Rows)
                    {
                        _Dtg_Grid.Rows.Add(new object[] { "Sábado", _Dtg_Row.Cells[0].Value.ToString(), _Dtg_Row.Cells[1].Value.ToString(), _Dtg_Row.Cells[2].Value.ToString(), _Dtg_Row.Cells[3].Value.ToString(), _Dtg_Row.Cells[4].Value.ToString() });
                    }
                    foreach (DataGridViewRow _Dtg_Row in _Dg_Domingo.Rows)
                    {
                        _Dtg_Grid.Rows.Add(new object[] { "Domingo", _Dtg_Row.Cells[0].Value.ToString(), _Dtg_Row.Cells[1].Value.ToString(), _Dtg_Row.Cells[2].Value.ToString(), _Dtg_Row.Cells[3].Value.ToString(), _Dtg_Row.Cells[4].Value.ToString() });
                    }
                    if (_Dtg_Grid.Rows.Count > 0)
                    {
                        Clases._Cls_ExcelUtilidades _Cls_Excel = new T3.Clases._Cls_ExcelUtilidades();
                        _Cls_Excel._Mtd_DgViewToExcel(_Dtg_Grid, _Sfd_1.FileName, "Rutas_"+_Dg_Zonas[0,_Dg_Zonas.CurrentCell.RowIndex].Value.ToString());
                    }
                }
                catch
                {
                }
            }
        }

        private void _Mtd_Bt_Agregar(int _P_Int_Dia)
        {
            Cursor = Cursors.WaitCursor;
            TextBox _Txt_Codigo = new TextBox();
            TextBox _Txt_Cliente2 = new TextBox();
            ToolStripMenuItem[] _Tsm_Menu = new ToolStripMenuItem[2];
            _Tsm_Menu[0] = new ToolStripMenuItem("Codigo");
            _Tsm_Menu[1] = new ToolStripMenuItem("Descripción");
            string[] _Str_Campos = new string[2];
            _Str_Campos[0] = "ccliente";
            _Str_Campos[1] = "c_nomb_comer";
            string _Str_Cadena = "SELECT TCLIENTE.ccliente, dbo.TCLIENTE.c_nomb_comer " +
"FROM  TZONACLIENTE INNER JOIN " +
"TCLIENTE ON TZONACLIENTE.ccliente = TCLIENTE.ccliente AND TZONACLIENTE.cdelete = dbo.TCLIENTE.cdelete " +
"WHERE (TZONACLIENTE.c_zona = '" + _Str_Zona + "') AND TZONACLIENTE.ccompany='" + Frm_Padre._Str_Comp + "' AND (TCLIENTE.c_activo='1') AND (TCLIENTE.cgroupcomp = '" + Frm_Padre._Str_GroupComp + "') AND (TZONACLIENTE.cdelete = 0) and not exists(Select * from TRUTAVISITAD where TRUTAVISITAD.ccompany=TZONACLIENTE.ccompany and TRUTAVISITAD.c_zona=TZONACLIENTE.c_zona and TRUTAVISITAD.cdelete='0' and TRUTAVISITAD.ccliente=TZONACLIENTE.ccliente)";
            Frm_Busqueda _Frm = new Frm_Busqueda(_Txt_Codigo, _Txt_Cliente2, _Str_Cadena, _Str_Campos, "Clientes", _Tsm_Menu, 0, 1);
            _Frm.ShowDialog(this);
            if (_Txt_Codigo.Text.Trim().Length > 0)
            {
                _Str_Cadena = "Select ccliente,c_lun_visita,c_mar_visita,c_mie_visita,c_jue_visita,c_vie_visita,c_sab_visita,c_dom_visita,c_fechainical,c_tipvisita,c_direcc_fiscal from TCLIENTE where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and ccliente='"+_Txt_Codigo.Text.Trim()+"'";
                DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                if (_Ds.Tables[0].Rows.Count > 0)
                {
                    if (_Ds.Tables[0].Rows[0][_P_Int_Dia].ToString().Trim().Length > 1)
                    {
                        _Mtd_Mostrar_Informacion(_Txt_Codigo.Text.Trim(),_P_Int_Dia);
                        _Pnl_Direccion.Visible=true;
                    }
                    else
                    {
                        if((MessageBox.Show("¿Esta seguro de crear esta ruta?", "Información", MessageBoxButtons.YesNo, MessageBoxIcon.Question)==DialogResult.Yes))
                        {
                            _Mtd_Mostrar_Informacion(_Txt_Codigo.Text.Trim(), _P_Int_Dia);
                            _Pnl_Direccion.Visible = true;
                        }

                    }
                }
                else
                {
                    MessageBox.Show("No se puede realizar la operación","Información",MessageBoxButtons.OK,MessageBoxIcon.Information);
                }
            }
            Cursor = Cursors.Default;
        }
        private void _Bt_Lunes_A_Click(object sender, EventArgs e)
        {
            _Mtd_Bt_Agregar(1);
        }

        private void _Bt_Guardar_Click(object sender, EventArgs e)
        {
            int _Int_Dia = _Tb_Tab.SelectedIndex + 1;
            Cursor = Cursors.WaitCursor;
            _Mtd_Agregar(_Int_Dia);
            System.Threading.ThreadPool.QueueUserWorkItem(((Frm_Padre)this.MdiParent)._Frm_Contenedor._async_Default);
            Cursor = Cursors.Default;
        }

        private void _Bt_Martes_A_Click(object sender, EventArgs e)
        {
            _Mtd_Bt_Agregar(2);
        }

        private void _Bt_Miercoles_A_Click(object sender, EventArgs e)
        {
            _Mtd_Bt_Agregar(3);
        }

        private void _Bt_Jueves_A_Click(object sender, EventArgs e)
        {
            _Mtd_Bt_Agregar(4);
        }

        private void _Bt_Viernes_A_Click(object sender, EventArgs e)
        {
            _Mtd_Bt_Agregar(5);
        }

        private void _Bt_Sabado_A_Click(object sender, EventArgs e)
        {
            _Mtd_Bt_Agregar(6);
        }

        private void _Bt_Domingo_A_Click(object sender, EventArgs e)
        {
            _Mtd_Bt_Agregar(7);
        }
        private void _Dg_Lunes_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (_Dg_Lunes.Rows.Count > 0)
            {
                Cursor = Cursors.WaitCursor;
                _Mtd_Mostrar_Informacion(_Dg_Lunes.Rows[e.RowIndex].Cells[0].Value.ToString(),1);
                _Pnl_Direccion.Visible = true;
                Cursor = Cursors.Default;
            }
        }
        private void _Dg_Martes_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (_Dg_Martes.Rows.Count > 0)
            {
                Cursor = Cursors.WaitCursor;
                _Mtd_Mostrar_Informacion(_Dg_Martes.Rows[e.RowIndex].Cells[0].Value.ToString(),2);
                _Pnl_Direccion.Visible = true;
                Cursor = Cursors.Default;
            }
        }

        private void _Dg_Miercoles_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (_Dg_Miercoles.Rows.Count > 0)
            {
                Cursor = Cursors.WaitCursor;
                _Mtd_Mostrar_Informacion(_Dg_Miercoles.Rows[e.RowIndex].Cells[0].Value.ToString(),3);
                _Pnl_Direccion.Visible = true;
                Cursor = Cursors.Default;
            }
        }

        private void _Dg_Jueves_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (_Dg_Jueves.Rows.Count > 0)
            {
                Cursor = Cursors.WaitCursor;
                _Mtd_Mostrar_Informacion(_Dg_Jueves.Rows[e.RowIndex].Cells[0].Value.ToString(),4);
                _Pnl_Direccion.Visible = true;
                Cursor = Cursors.Default;
            }
        }

        private void _Dg_Viernes_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (_Dg_Viernes.Rows.Count > 0)
            {
                Cursor = Cursors.WaitCursor;
                _Mtd_Mostrar_Informacion(_Dg_Viernes.Rows[e.RowIndex].Cells[0].Value.ToString(),5);
                _Pnl_Direccion.Visible = true;
                Cursor = Cursors.Default;
            }
        }

        private void _Dg_Sabado_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (_Dg_Sabado.Rows.Count > 0)
            {
                Cursor = Cursors.WaitCursor;
                _Mtd_Mostrar_Informacion(_Dg_Sabado.Rows[e.RowIndex].Cells[0].Value.ToString(),6);
                _Pnl_Direccion.Visible = true;
                Cursor = Cursors.Default;
            }
        }

        private void _Dg_Domingo_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (_Dg_Domingo.Rows.Count > 0)
            {
                Cursor = Cursors.WaitCursor;
                _Mtd_Mostrar_Informacion(_Dg_Domingo.Rows[e.RowIndex].Cells[0].Value.ToString(),7);
                _Pnl_Direccion.Visible = true;
                Cursor = Cursors.Default;
            }
        }

        private void _Bt_Salir_Click(object sender, EventArgs e)
        {
            _Pnl_Direccion.Visible = false;
        }

        private void _Bt_Lunes_E_Click(object sender, EventArgs e)
        {
            if (_Dg_Lunes.Rows.Count > 0)
            {
                if (MessageBox.Show("¿Esta seguro de eliminar el registro?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    string _Str_Cadena = "Update TRUTAVISITAD Set cdatedel=GETDATE(),cuserdel='" + Frm_Padre._Str_Use + "',cdelete='1' where ccompany='" + Frm_Padre._Str_Comp + "' and c_zona='" + _Str_Zona + "' and cdiasemana='1' and ccliente='" + _Dg_Lunes.Rows[_Dg_Lunes.CurrentCell.RowIndex].Cells[0].Value.ToString().Trim() + "'";
                    Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                    MessageBox.Show("El registro ha sido eliminado correctamente","Información",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    _Mtd_ActualizarDias(1);
                }
            }
        }

        private void _Bt_Martes_E_Click(object sender, EventArgs e)
        {
            if (_Dg_Martes.Rows.Count > 0)
            {
                if (MessageBox.Show("¿Esta seguro de eliminar el registro?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    string _Str_Cadena = "Update TRUTAVISITAD Set cdatedel=GETDATE(),cuserdel='" + Frm_Padre._Str_Use + "',cdelete='1' where ccompany='" + Frm_Padre._Str_Comp + "' and c_zona='" + _Str_Zona + "' and cdiasemana='2' and ccliente='" + _Dg_Martes.Rows[_Dg_Martes.CurrentCell.RowIndex].Cells[0].Value.ToString().Trim() + "'";
                    Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                    MessageBox.Show("El registro ha sido eliminado correctamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _Mtd_ActualizarDias(2);
                }
            }
        }

        private void _Bt_Miercoles_E_Click(object sender, EventArgs e)
        {
            if (_Dg_Miercoles.Rows.Count > 0)
            {
                if (MessageBox.Show("¿Esta seguro de eliminar el registro?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    string _Str_Cadena = "Update TRUTAVISITAD Set cdatedel=GETDATE(),cuserdel='" + Frm_Padre._Str_Use + "',cdelete='1' where ccompany='" + Frm_Padre._Str_Comp + "' and c_zona='" + _Str_Zona + "' and cdiasemana='3' and ccliente='" + _Dg_Miercoles.Rows[_Dg_Miercoles.CurrentCell.RowIndex].Cells[0].Value.ToString().Trim() + "'";
                    Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                    MessageBox.Show("El registro ha sido eliminado correctamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _Mtd_ActualizarDias(3);
                }
            }
        }

        private void _Bt_Jueves_E_Click(object sender, EventArgs e)
        {
            if (_Dg_Jueves.Rows.Count > 0)
            {
                if (MessageBox.Show("¿Esta seguro de eliminar el registro?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    string _Str_Cadena = "Update TRUTAVISITAD Set cdatedel=GETDATE(),cuserdel='" + Frm_Padre._Str_Use + "',cdelete='1' where ccompany='" + Frm_Padre._Str_Comp + "' and c_zona='" + _Str_Zona + "' and cdiasemana='4' and ccliente='" + _Dg_Jueves.Rows[_Dg_Jueves.CurrentCell.RowIndex].Cells[0].Value.ToString().Trim() + "'";
                    Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                    MessageBox.Show("El registro ha sido eliminado correctamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _Mtd_ActualizarDias(4);
                }
            }
        }

        private void _Bt_Viernes_E_Click(object sender, EventArgs e)
        {
            if (_Dg_Viernes.Rows.Count > 0)
            {
                if (MessageBox.Show("¿Esta seguro de eliminar el registro?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    string _Str_Cadena = "Update TRUTAVISITAD Set cdatedel=GETDATE(),cuserdel='" + Frm_Padre._Str_Use + "',cdelete='1' where ccompany='" + Frm_Padre._Str_Comp + "' and c_zona='" + _Str_Zona + "' and cdiasemana='5' and ccliente='" + _Dg_Viernes.Rows[_Dg_Viernes.CurrentCell.RowIndex].Cells[0].Value.ToString().Trim() + "'";
                    Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                    MessageBox.Show("El registro ha sido eliminado correctamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _Mtd_ActualizarDias(5);
                }
            }
        }

        private void _Bt_Sabado_E_Click(object sender, EventArgs e)
        {
            if (_Dg_Sabado.Rows.Count > 0)
            {
                if (MessageBox.Show("¿Esta seguro de eliminar el registro?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    string _Str_Cadena = "Update TRUTAVISITAD Set cdatedel=GETDATE(),cuserdel='" + Frm_Padre._Str_Use + "',cdelete='1' where ccompany='" + Frm_Padre._Str_Comp + "' and c_zona='" + _Str_Zona + "' and cdiasemana='6' and ccliente='" + _Dg_Sabado.Rows[_Dg_Sabado.CurrentCell.RowIndex].Cells[0].Value.ToString().Trim() + "'";
                    Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                    MessageBox.Show("El registro ha sido eliminado correctamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _Mtd_ActualizarDias(6);
                }
            }
        }

        private void _Bt_Domingo_E_Click(object sender, EventArgs e)
        {
            if (_Dg_Domingo.Rows.Count > 0)
            {
                if (MessageBox.Show("¿Esta seguro de eliminar el registro?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    string _Str_Cadena = "Update TRUTAVISITAD Set cdatedel=GETDATE(),cuserdel='" + Frm_Padre._Str_Use + "',cdelete='1' where ccompany='" + Frm_Padre._Str_Comp + "' and c_zona='" + _Str_Zona + "' and cdiasemana='7' and ccliente='" + _Dg_Domingo.Rows[_Dg_Domingo.CurrentCell.RowIndex].Cells[0].Value.ToString().Trim() + "'";
                    Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                    MessageBox.Show("El registro ha sido eliminado correctamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _Mtd_ActualizarDias(7);
                }
            }
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

        private void button1_Click(object sender, EventArgs e)
        {
            _Mtd_CrearGridExportar();
        }
   
        private DayOfWeek _Mtd_Retornar_Dia(int _P_Int_Dia)
        {
            DayOfWeek _DayOf=new DayOfWeek();
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

        private void label46_Click(object sender, EventArgs e)
        {

        }
    }
}