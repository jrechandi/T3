using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Security.Cryptography;
using CrystalDecisions.CrystalReports.Engine;
namespace T3
{
    public partial class Frm_ImpresionLote : Form
    {
        int _Int_Sw = 0;
        string _Str_ThisText = "";
        int _Int_Seleccion = 0;
        string _Str_Factura = "";
        string _G_Str_ccaja = "";
        CLASES._Cls_Varios_Metodos _MyUtilidad = new CLASES._Cls_Varios_Metodos(true);
        clslibraryconssa._Cls_Formato _Cls_Formato = new clslibraryconssa._Cls_Formato("es-VE");
        public Frm_ImpresionLote()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Contrustructor para impresión de documantos por lote
        /// </summary>
        /// <param name="_P_Int_Sw">Valor de tipo int que indica los documentos que se han de mostrar. (NC='1'),(ND='2'),(FAC='3')</param>
        public Frm_ImpresionLote(int _P_Int_Sw)
        {
            InitializeComponent();
            _Str_ThisText = this.Text;
            _Mtd_Color_Estandar(this);
            _Int_Sw = _P_Int_Sw;
            if (_Int_Sw == 1)
            {
                DataGridViewTextBoxColumn _Dg_Column = new DataGridViewTextBoxColumn();
                _Dg_Column.Name = "Cliente";
                _Dg_Column.DataPropertyName = "Cliente";
                _Dg_Column.HeaderText = "Cliente";
                _Dg_Column.ReadOnly = true;
                _Dg_Column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                _Dg_Grid.Columns.Insert(2, _Dg_Column);
                _Dg_Column = new DataGridViewTextBoxColumn();
                _Dg_Column.Name = "DesCliente";
                _Dg_Column.DataPropertyName = "DesCliente";
                _Dg_Column.HeaderText = "Des. Cliente";
                _Dg_Column.ReadOnly = true;
                _Dg_Grid.Columns.Insert(3, _Dg_Column);
                _Dg_Column = new DataGridViewTextBoxColumn();
                _Dg_Column.Name = "Monto";
                _Dg_Column.DataPropertyName = "Monto";
                _Dg_Column.HeaderText = "Monto";
                _Dg_Column.ReadOnly = true;
                _Dg_Column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                _Dg_Grid.Columns.Insert(5, _Dg_Column);
            }
            else if (_Int_Sw == 2)
            {
                DataGridViewTextBoxColumn _Dg_Column = new DataGridViewTextBoxColumn();
                _Dg_Column.Name = "Cliente";
                _Dg_Column.DataPropertyName = "Cliente";
                _Dg_Column.HeaderText = "Cliente";
                _Dg_Column.ReadOnly = true;
                _Dg_Column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                _Dg_Grid.Columns.Insert(2, _Dg_Column);
                _Dg_Column = new DataGridViewTextBoxColumn();
                _Dg_Column.Name = "DesCliente";
                _Dg_Column.DataPropertyName = "DesCliente";
                _Dg_Column.HeaderText = "Des. Cliente";
                _Dg_Column.ReadOnly = true;
                _Dg_Grid.Columns.Insert(3, _Dg_Column);
                _Dg_Column = new DataGridViewTextBoxColumn();
                _Dg_Column.Name = "Monto";
                _Dg_Column.DataPropertyName = "Monto";
                _Dg_Column.HeaderText = "Monto";
                _Dg_Column.ReadOnly = true;
                _Dg_Column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                _Dg_Grid.Columns.Insert(5, _Dg_Column);
            }
            else if (_Int_Sw == 3)
            { 
                _Bt_Imprimir.Enabled = false; 
                _Int_Seleccion = 1;
                _Dg_Grid.Columns["Imprimir"].HeaderText = "Seleccionar"; 
                _Tool_NumeroControl.Visible = true; 
            }
            else if (_Int_Sw == 4)
            {
                _Dg_Grid.ContextMenuStrip = _Cntx_Menu;
                _Bt_Imprimir.Enabled = false;
                _Bt_Actualizar.Enabled = true;
                _Bt_Actualizar.Text = "Aprobar NC";
                _Dg_Grid.Columns["Imprimir"].HeaderText = "Aprobar";
                DataGridViewTextBoxColumn _Dg_Column = new DataGridViewTextBoxColumn();
                _Dg_Column.Name = "Cliente";
                _Dg_Column.DataPropertyName = "Cliente";
                _Dg_Column.HeaderText = "Cliente";
                _Dg_Column.ReadOnly = true;
                _Dg_Column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                _Dg_Grid.Columns.Insert(2, _Dg_Column);
                _Dg_Column = new DataGridViewTextBoxColumn();
                _Dg_Column.Name = "DesCliente";
                _Dg_Column.DataPropertyName = "DesCliente";
                _Dg_Column.HeaderText = "Des. Cliente";
                _Dg_Column.ReadOnly = true;
                _Dg_Grid.Columns.Insert(3, _Dg_Column);
                _Dg_Column = new DataGridViewTextBoxColumn();
                _Dg_Column.Name = "Vendedor";
                _Dg_Column.DataPropertyName = "cvendedor";
                _Dg_Column.HeaderText = "Vendedor";
                _Dg_Column.ReadOnly = true;
                _Dg_Column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                _Dg_Grid.Columns.Insert(5, _Dg_Column);
                _Dg_Column = new DataGridViewTextBoxColumn();
                _Dg_Column.Name = "Monto";
                _Dg_Column.DataPropertyName = "Monto";
                _Dg_Column.HeaderText = "Monto";
                _Dg_Column.ReadOnly = true;
                _Dg_Column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                _Dg_Grid.Columns.Insert(5, _Dg_Column);
                _Bt_Exportar.Visible = true;
            }
            else if (_Int_Sw == 5)
            {
                _Bt_Imprimir.Enabled = false;
                _Int_Seleccion = 1;
                _Dg_Grid.Columns["Imprimir"].HeaderText = "Seleccionar";
                _Tool_NumeroControl.Visible = true;
                _Bt_Exportar.Visible = true;
            }
            else if (_Int_Sw == 6)
            {
                _Dg_Grid.ContextMenuStrip = _Cntx_Menu;
                _Bt_Imprimir.Enabled = false;
                _Bt_Actualizar.Enabled = true;
                _Bt_Actualizar.Text = "Aprobar ND";
                _Dg_Grid.Columns["Imprimir"].HeaderText = "Aprobar";
                DataGridViewTextBoxColumn _Dg_Column = new DataGridViewTextBoxColumn();
                _Dg_Column.Name = "Cliente";
                _Dg_Column.DataPropertyName = "Cliente";
                _Dg_Column.HeaderText = "Cliente";
                _Dg_Column.ReadOnly = true;
                _Dg_Column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                _Dg_Grid.Columns.Insert(2, _Dg_Column);
                _Dg_Column = new DataGridViewTextBoxColumn();
                _Dg_Column.Name = "DesCliente";
                _Dg_Column.DataPropertyName = "DesCliente";
                _Dg_Column.HeaderText = "Des. Cliente";
                _Dg_Column.ReadOnly = true;
                _Dg_Grid.Columns.Insert(3, _Dg_Column);
                _Dg_Column = new DataGridViewTextBoxColumn();
                _Dg_Column.Name = "Vendedor";
                _Dg_Column.DataPropertyName = "cvendedor";
                _Dg_Column.HeaderText = "Vendedor";
                _Dg_Column.ReadOnly = true;
                _Dg_Column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                _Dg_Grid.Columns.Insert(5, _Dg_Column);
                _Dg_Column = new DataGridViewTextBoxColumn();
                _Dg_Column.Name = "Monto";
                _Dg_Column.DataPropertyName = "Monto";
                _Dg_Column.HeaderText = "Monto";
                _Dg_Column.ReadOnly = true;
                _Dg_Column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                _Dg_Grid.Columns.Insert(5, _Dg_Column);
                _Bt_Exportar.Visible = true;
            }
            else if (_Int_Sw == 7)
            {
                _Bt_Imprimir.Enabled = false;
                _Int_Seleccion = 1;
                _Dg_Grid.Columns["Imprimir"].HeaderText = "Seleccionar";
                _Tool_NumeroControl.Visible = true;
                _Bt_Exportar.Visible = true;
            }
            else if (_Int_Sw == 8)
            {//NC APLICADAS EN CAJA POR IMPRIMIR
                //_Bt_Imprimir.Enabled = false;
                //_Bt_Actualizar.Enabled = true;
            }
            else if (_Int_Sw == 9)
            {
                _Bt_Imprimir.Enabled = true;
                _Bt_Actualizar.Enabled = false;
            }
            else if (_Int_Sw == 10)
            {
                _Dg_Grid.ContextMenuStrip = _Cntx_Menu;
                _Bt_Imprimir.Enabled = false;
                _Bt_Actualizar.Enabled = true;
                _Bt_Actualizar.Text = "Aprobar ND";
                _Dg_Grid.Columns["Imprimir"].HeaderText = "Aprobar";
                DataGridViewTextBoxColumn _Dg_Column = new DataGridViewTextBoxColumn();
                _Dg_Column.Name = "Monto";
                _Dg_Column.DataPropertyName = "Monto";
                _Dg_Column.HeaderText = "Monto";
                _Dg_Column.ReadOnly = true;
                _Dg_Column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                _Dg_Grid.Columns.Insert(3, _Dg_Column);
            }
            else if (_Int_Sw == 11)
            {
                _Dg_Grid.ContextMenuStrip = _Cntx_Menu;
                _Bt_Imprimir.Enabled = false;
                _Bt_Actualizar.Enabled = true;
                _Bt_Actualizar.Text = "Aprobar NC";
                _Dg_Grid.Columns["Imprimir"].HeaderText = "Aprobar";
                DataGridViewTextBoxColumn _Dg_Column = new DataGridViewTextBoxColumn();
                _Dg_Column.Name = "Monto";
                _Dg_Column.DataPropertyName = "Monto";
                _Dg_Column.HeaderText = "Monto";
                _Dg_Column.ReadOnly = true;
                _Dg_Column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                _Dg_Grid.Columns.Insert(3, _Dg_Column);
            }
            else if (_Int_Sw == 12)
            {
                _Bt_Imprimir.Enabled = true;
                _Bt_Actualizar.Enabled = false;
                _Bt_Imprimir.Size = new Size(224, 30);
                _Bt_Imprimir.Left = _Bt_Actualizar.Left - (_Bt_Imprimir.Width + 8);
                _Bt_Exportar.Left = _Bt_Imprimir.Left - (_Bt_Exportar.Width + 8);
                _Bt_Imprimir.Text = "Generar Comprobante";
                _Dg_Grid.Columns["Descripcion"].HeaderText = "Cliente";
                _Dg_Grid.Columns["Imprimir"].HeaderText = "Generar";
                _Dg_Grid.Columns["Documento"].HeaderText = "ID CheqDev";
                DataGridViewTextBoxColumn _Dg_Column = new DataGridViewTextBoxColumn();
                _Dg_Column.Name = "Monto";
                _Dg_Column.DataPropertyName = "Monto";
                _Dg_Column.HeaderText = "Monto";
                _Dg_Column.ReadOnly = true;
                _Dg_Column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                _Dg_Grid.Columns.Insert(3, _Dg_Column);
                //--------------------------------------
                _Dg_Column = new DataGridViewTextBoxColumn();
                _Dg_Column.Name = "cnumcheque";
                _Dg_Column.DataPropertyName = "cnumcheque";
                _Dg_Column.HeaderText = "cnumcheque";
                _Dg_Column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                _Dg_Grid.Columns.Add(_Dg_Column);
                //--------------------------------------
                _Dg_Column = new DataGridViewTextBoxColumn();
                _Dg_Column.Name = "ccliente";
                _Dg_Column.DataPropertyName = "ccliente";
                _Dg_Column.HeaderText = "ccliente";
                _Dg_Column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                _Dg_Grid.Columns.Add(_Dg_Column);
                //--------------------------------------
                _Dg_Grid.Columns["Numero"].Visible = false;
                _Dg_Grid.Columns["cidcomprob"].Visible = true;
                _Dg_Grid.Columns["cnumcheque"].Visible = false;
                _Dg_Grid.Columns["ccliente"].Visible = false;
            }
            else if (_Int_Sw == 13)
            {
                _Dg_Grid.ContextMenuStrip = _Cntx_Menu;
                _Dg_Grid.Columns["Imprimir"].HeaderText = "Aprobar";
                DataGridViewTextBoxColumn _Dg_Column = new DataGridViewTextBoxColumn();
                _Dg_Column.Name = "Monto";
                _Dg_Column.DataPropertyName = "Monto";
                _Dg_Column.HeaderText = "Monto";
                _Dg_Column.ReadOnly = true;
                _Dg_Column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                _Dg_Grid.Columns.Insert(3, _Dg_Column);
                _Dg_Grid.Columns["Numero"].Visible = false;
            }
            else if (_Int_Sw == 14)
            {
                _Bt_Imprimir.Enabled = true;
                _Bt_Actualizar.Enabled = false;
                _Bt_Imprimir.Size = new Size(224, 30);
                _Bt_Imprimir.Left = _Bt_Actualizar.Left - (_Bt_Imprimir.Width + 8);
                _Bt_Exportar.Left = _Bt_Imprimir.Left - (_Bt_Exportar.Width + 8);
                _Bt_Imprimir.Text = "Generar Comprobante";
                _Dg_Grid.Columns["Tipo"].HeaderText = "Num. Cheque";
                _Dg_Grid.Columns["Tipo"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                _Dg_Grid.Columns["Descripcion"].HeaderText = "Cliente";
                _Dg_Grid.Columns["Imprimir"].HeaderText = "Generar";
                _Dg_Grid.Columns["Documento"].HeaderText = "ID EgreCheq";
                DataGridViewTextBoxColumn _Dg_Column = new DataGridViewTextBoxColumn();
                _Dg_Column.Name = "Monto";
                _Dg_Column.DataPropertyName = "Monto";
                _Dg_Column.HeaderText = "Monto";
                _Dg_Column.ReadOnly = true;
                _Dg_Column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                _Dg_Grid.Columns.Insert(3, _Dg_Column);
                //--------------------------------------
                _Dg_Column = new DataGridViewTextBoxColumn();
                _Dg_Column.Name = "cnumdepo";
                _Dg_Column.DataPropertyName = "cnumdepo";
                _Dg_Column.HeaderText = "Depósito";
                _Dg_Column.ReadOnly = true;
                _Dg_Column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                _Dg_Grid.Columns.Add(_Dg_Column);
                //--------------------------------------
                _Dg_Column = new DataGridViewTextBoxColumn();
                _Dg_Column.Name = "ccliente";
                _Dg_Column.DataPropertyName = "ccliente";
                _Dg_Column.HeaderText = "ccliente";
                _Dg_Column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                _Dg_Grid.Columns.Add(_Dg_Column);
                //--------------------------------------
                _Dg_Grid.Columns["Numero"].Visible = false;
                _Dg_Grid.Columns["cidcomprob"].Visible = true;
                _Dg_Grid.Columns["ccliente"].Visible = false;
            }
            _Mtd_Actualizar(_Int_Sw, _Tool_Consulta.Text, _Int_Seleccion, _Str_Factura);
        }
        string _Str_CompFact = "";
        public Frm_ImpresionLote(string _P_Str_Factura, bool _P_Bol_VariasComp, string _P_Str_Comp)
        {
            InitializeComponent();
            _Str_CompFact = _P_Str_Comp;
            _Str_ThisText = this.Text;
            _Mtd_Color_Estandar(this);
            _Int_Sw = 3;
            _Str_Factura = _P_Str_Factura;
            _Tool_NumeroControl.Visible = true;
            _Bt_Imprimir.Enabled = false; _Int_Seleccion = 1;
            _Mtd_Actualizar(_Int_Sw, _Tool_Consulta.Text, _Int_Seleccion, _Str_Factura);
        }
        public Frm_ImpresionLote(int _P_Int_Sw, string _P_Str_Caja)
        {
            InitializeComponent();
            _Str_ThisText = this.Text;
            _Mtd_Color_Estandar(this);
            _Int_Sw = _P_Int_Sw;
            _G_Str_ccaja = _P_Str_Caja;
            _Mtd_Actualizar(_Int_Sw, _Tool_Consulta.Text, _Int_Seleccion, _Str_Factura);
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
        public bool _Mtd_IsNumeric(object Expression)
        {
            bool isNum;
            double retNum;
            isNum = Double.TryParse(Convert.ToString(Expression), System.Globalization.NumberStyles.Any, System.Globalization.NumberFormatInfo.InvariantInfo, out retNum);
            return isNum;
        }
        public void _Mtd_Sorted(DataGridView _Dg_My)
        {
            for (int _Int_i = 0; _Int_i < _Dg_My.Columns.Count; _Int_i++)
            {
                _Dg_My.Columns[_Int_i].SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }
        private void _Mtd_Actualizar(int _P_Int_Sw, string _P_Str_Ducumento, int _Int_Seleccion,string _P_Str_Factura)
        {
            string _Str_Cadena = "";
            if (_P_Int_Sw == 1)
            {//NC POR IMPRIMIR
                if (_P_Str_Ducumento.Trim().Length == 0)
                {
                    _Str_Cadena = "SELECT  TDOCUMENT.cname as Tipo, TNOTACREDICC.cidnotcredicc as Documento, TNOTACREDICC.ccliente AS Cliente, RTRIM(TCLIENTE.c_nomb_comer) AS DesCliente, TNOTACREDICC.cdescripcion as Descripcion,TNOTACREDICC.cmontototsi + ISNULL(TNOTACREDICC.cexento,0) + ISNULL(TNOTACREDICC.cimpuesto,0) as Monto,'" + _Int_Seleccion + "' as Imprimir, TNOTACREDICC.cidcomprob " +
                    "FROM TNOTACREDICC INNER JOIN " +
                    "TCLIENTE ON TNOTACREDICC.ccliente=TCLIENTE.ccliente AND TNOTACREDICC.cgroupcomp=TCLIENTE.cgroupcomp INNER JOIN " +
                    "TCONFIGCXC ON TNOTACREDICC.ccompany = TCONFIGCXC.ccompany INNER JOIN " +
                    "TDOCUMENT ON TCONFIGCXC.ctipdocnotcred = TDOCUMENT.ctdocument " +
                    "WHERE (TNOTACREDICC.cgroupcomp = '" + Frm_Padre._Str_GroupComp + "') AND (cexedentecobro<>'1') AND (TNOTACREDICC.cimpresa = '0') AND (TNOTACREDICC.cactivo = '0') AND (TNOTACREDICC.cestatusfirma=2) AND (TNOTACREDICC.ccompany = '" + Frm_Padre._Str_Comp + "') AND (cidnotrecepc IS NULL OR cidnotrecepc=0) AND NOT EXISTS(SELECT ccliente FROM TICRELAPROCLI WHERE TICRELAPROCLI.ccliente=TNOTACREDICC.ccliente AND ISNULL(TICRELAPROCLI.cdelete,0)=0)";
                    _Str_Cadena = _Str_Cadena + " UNION ";
                    _Str_Cadena = _Str_Cadena + "SELECT  TDOCUMENT.cname as Tipo, TNOTACREDICC.cidnotcredicc as Documento, TNOTACREDICC.ccliente AS Cliente, RTRIM(TCLIENTE.c_nomb_comer) AS DesCliente, TNOTACREDICC.cdescripcion as Descripcion,TNOTACREDICC.cmontototsi + ISNULL(TNOTACREDICC.cexento,0) as Monto,'" + _Int_Seleccion + "' as Imprimir, TNOTACREDICC.cidcomprob " +
                    "FROM TNOTACREDICC INNER JOIN "+
                    "TCLIENTE ON TNOTACREDICC.ccliente=TCLIENTE.ccliente AND TNOTACREDICC.cgroupcomp=TCLIENTE.cgroupcomp INNER JOIN " +
                    "TCONFIGCXC ON TNOTACREDICC.ccompany = TCONFIGCXC.ccompany INNER JOIN "+
                    "TDOCUMENT ON TCONFIGCXC.ctipdocnotcred = TDOCUMENT.ctdocument INNER JOIN "+
                    "TNOTARECEPC ON TNOTACREDICC.cidnotrecepc = TNOTARECEPC.cidnotrecepc AND "+
                    "TNOTACREDICC.cgroupcomp = TNOTARECEPC.cgroupcomp AND TNOTACREDICC.ccompany = TNOTARECEPC.ccompany "+
                    "WHERE (TNOTACREDICC.cgroupcomp = '" + Frm_Padre._Str_GroupComp + "') AND (TNOTACREDICC.cimpresa = '0') AND (TNOTACREDICC.cactivo = '0') AND (TNOTACREDICC.ccompany = '" + Frm_Padre._Str_Comp + "') AND (TNOTARECEPC.cimpreso = 1) AND NOT EXISTS(SELECT ccliente FROM TICRELAPROCLI WHERE TICRELAPROCLI.ccliente=TNOTACREDICC.ccliente AND ISNULL(TICRELAPROCLI.cdelete,0)=0) ORDER BY TNOTACREDICC.cidnotcredicc";
                }
                else
                {
                    _Str_Cadena = "SELECT  TDOCUMENT.cname as Tipo, TNOTACREDICC.cidnotcredicc as Documento, TNOTACREDICC.ccliente AS Cliente, RTRIM(TCLIENTE.c_nomb_comer) AS DesCliente, TNOTACREDICC.cdescripcion as Descripcion,TNOTACREDICC.cmontototsi + ISNULL(TNOTACREDICC.cexento,0) + ISNULL(TNOTACREDICC.cimpuesto,0) as Monto,'" + _Int_Seleccion + "' as Imprimir, TNOTACREDICC.cidcomprob " +
                    "FROM TNOTACREDICC INNER JOIN " +
                    "TCLIENTE ON TNOTACREDICC.ccliente=TCLIENTE.ccliente AND TNOTACREDICC.cgroupcomp=TCLIENTE.cgroupcomp INNER JOIN " +
                    "TCONFIGCXC ON TNOTACREDICC.ccompany = TCONFIGCXC.ccompany INNER JOIN " +
                    "TDOCUMENT ON TCONFIGCXC.ctipdocnotcred = TDOCUMENT.ctdocument " +
                    "WHERE (TNOTACREDICC.cgroupcomp = '" + Frm_Padre._Str_GroupComp + "') AND (cexedentecobro<>'1') AND (TNOTACREDICC.cimpresa = '0') AND (TNOTACREDICC.cactivo = '0') AND (TNOTACREDICC.cestatusfirma=2) AND (TNOTACREDICC.ccompany = '" + Frm_Padre._Str_Comp + "') AND (TNOTACREDICC.cidnotcredicc LIKE '" + _P_Str_Ducumento + "%')  AND (cidnotrecepc IS NULL OR cidnotrecepc=0) AND NOT EXISTS(SELECT ccliente FROM TICRELAPROCLI WHERE TICRELAPROCLI.ccliente=TNOTACREDICC.ccliente AND ISNULL(TICRELAPROCLI.cdelete,0)=0)";
                    _Str_Cadena = _Str_Cadena + " UNION ";
                    _Str_Cadena = _Str_Cadena + "SELECT  TDOCUMENT.cname as Tipo, TNOTACREDICC.cidnotcredicc as Documento, TNOTACREDICC.ccliente AS Cliente, RTRIM(TCLIENTE.c_nomb_comer) AS DesCliente, TNOTACREDICC.cdescripcion as Descripcion,TNOTACREDICC.cmontototsi + ISNULL(TNOTACREDICC.cexento,0) as Monto,'" + _Int_Seleccion + "' as Imprimir, TNOTACREDICC.cidcomprob " +
                    "FROM TNOTACREDICC INNER JOIN " +
                    "TCLIENTE ON TNOTACREDICC.ccliente=TCLIENTE.ccliente AND TNOTACREDICC.cgroupcomp=TCLIENTE.cgroupcomp INNER JOIN " +
                    "TCONFIGCXC ON TNOTACREDICC.ccompany = TCONFIGCXC.ccompany INNER JOIN " +
                    "TDOCUMENT ON TCONFIGCXC.ctipdocnotcred = TDOCUMENT.ctdocument INNER JOIN " +
                    "TNOTARECEPC ON TNOTACREDICC.cidnotrecepc = TNOTARECEPC.cidnotrecepc AND " +
                    "TNOTACREDICC.cgroupcomp = TNOTARECEPC.cgroupcomp AND TNOTACREDICC.ccompany = TNOTARECEPC.ccompany " +
                    "WHERE (TNOTACREDICC.cgroupcomp = '" + Frm_Padre._Str_GroupComp + "') AND (TNOTACREDICC.cimpresa = '0') AND (TNOTACREDICC.cactivo = '0') AND (TNOTACREDICC.ccompany = '" + Frm_Padre._Str_Comp + "') AND (TNOTACREDICC.cidnotcredicc LIKE '" + _P_Str_Ducumento + "%')  AND (TNOTARECEPC.cimpreso = 1) AND NOT EXISTS(SELECT ccliente FROM TICRELAPROCLI WHERE TICRELAPROCLI.ccliente=TNOTACREDICC.ccliente AND ISNULL(TICRELAPROCLI.cdelete,0)=0) ORDER BY TNOTACREDICC.cidnotcredicc";
                }

            }
            else if (_P_Int_Sw == 2)
            {//ND POR IMPRIMIR
                if (_P_Str_Ducumento.Trim().Length == 0)
                {
                    _Str_Cadena = "SELECT TDOCUMENT.cname as Tipo, TNOTADEBICC.cidnotadebitocc as Documento, TNOTADEBICC.ccliente AS Cliente, RTRIM(TCLIENTE.c_nomb_comer) AS DesCliente, TNOTADEBICC.cdescripcion as Descripcion, TNOTADEBICC.cmontototsi + ISNULL(TNOTADEBICC.cexento,0) + ISNULL(TNOTADEBICC.cimpuesto,0) as Monto,'" + _Int_Seleccion + "' as Imprimir, TNOTADEBICC.cidcomprob " +
                    "FROM TNOTADEBICC INNER JOIN " +
                    "TCLIENTE ON TNOTADEBICC.ccliente=TCLIENTE.ccliente AND TNOTADEBICC.cgroupcomp=TCLIENTE.cgroupcomp INNER JOIN " +
                    "TCONFIGCXC ON TNOTADEBICC.ccompany = TCONFIGCXC.ccompany INNER JOIN " +
                    "TDOCUMENT ON TCONFIGCXC.ctipdocnotdeb = TDOCUMENT.ctdocument " +
                    "WHERE (TNOTADEBICC.cgroupcomp = '" + Frm_Padre._Str_GroupComp + "') AND (TNOTADEBICC.cimpresa = '0') AND (TNOTADEBICC.cactivo = '0') AND (TNOTADEBICC.cestatusfirma=2) AND (TNOTADEBICC.ccompany = '" + Frm_Padre._Str_Comp + "') AND NOT EXISTS(SELECT ccliente FROM TICRELAPROCLI WHERE TICRELAPROCLI.ccliente=TNOTADEBICC.ccliente AND ISNULL(TICRELAPROCLI.cdelete,0)=0) ORDER BY TNOTADEBICC.cidnotadebitocc";
                }
                else
                {
                    _Str_Cadena = "SELECT TDOCUMENT.cname as Tipo, TNOTADEBICC.cidnotadebitocc as Documento, TNOTADEBICC.ccliente AS Cliente, RTRIM(TCLIENTE.c_nomb_comer) AS DesCliente, TNOTADEBICC.cdescripcion as Descripcion, TNOTADEBICC.cmontototsi + ISNULL(TNOTADEBICC.cexento,0) + ISNULL(TNOTADEBICC.cimpuesto,0) as Monto,'" + _Int_Seleccion + "' as Imprimir, TNOTADEBICC.cidcomprob " +
                    "FROM TNOTADEBICC INNER JOIN " +
                    "TCLIENTE ON TNOTADEBICC.ccliente=TCLIENTE.ccliente AND TNOTADEBICC.cgroupcomp=TCLIENTE.cgroupcomp INNER JOIN " +
                    "TCONFIGCXC ON TNOTADEBICC.ccompany = TCONFIGCXC.ccompany INNER JOIN " +
                    "TDOCUMENT ON TCONFIGCXC.ctipdocnotdeb = TDOCUMENT.ctdocument " +
                    "WHERE (TNOTADEBICC.cgroupcomp = '" + Frm_Padre._Str_GroupComp + "') AND (TNOTADEBICC.cimpresa = '0') AND (TNOTADEBICC.cactivo = '0')  AND (TNOTADEBICC.cestatusfirma=2) AND (TNOTADEBICC.ccompany = '" + Frm_Padre._Str_Comp + "') AND (TNOTADEBICC.cidnotadebitocc LIKE '" + _P_Str_Ducumento + "%') AND NOT EXISTS(SELECT ccliente FROM TICRELAPROCLI WHERE TICRELAPROCLI.ccliente=TNOTADEBICC.ccliente AND ISNULL(TICRELAPROCLI.cdelete,0)=0) ORDER BY TNOTADEBICC.cidnotadebitocc";
                }
            }
            else if (_P_Int_Sw == 3)
            {
                if (_P_Str_Factura.Trim().Length == 0)
                {
                    if (_P_Str_Ducumento.Trim().Length == 0)
                    {
                        _Str_Cadena = "SELECT TDOCUMENT.cname as Tipo, TFACTURAM.cfactura as Documento, CONVERT(varchar, TFACTURAM.cfactura) + ' - ' + TCLIENTE.c_nomb_comer AS Descripcion,'" + _Int_Seleccion + "' as Imprimir " +
                        "FROM TCONFIGCXC INNER JOIN " +
                        "TFACTURAM ON TCONFIGCXC.ccompany = TFACTURAM.ccompany INNER JOIN " +
                        "TDOCUMENT ON TCONFIGCXC.ctipdocfact = TDOCUMENT.ctdocument INNER JOIN " +
                        "TCLIENTE ON TFACTURAM.cgroupcomp = TCLIENTE.cgroupcomp AND TFACTURAM.ccliente = TCLIENTE.ccliente " +
                        "WHERE (TFACTURAM.cgroupcomp = '" + Frm_Padre._Str_GroupComp + "') AND (TFACTURAM.ccompany = '" + _Str_CompFact + "') AND (TFACTURAM.c_impresa = '1') AND (TFACTURAM.c_numerocontrol='0') ORDER BY TFACTURAM.cfactura";
                    }
                    else
                    {
                        _Str_Cadena = "SELECT TDOCUMENT.cname as Tipo, TFACTURAM.cfactura as Documento, CONVERT(varchar, TFACTURAM.cfactura) + ' - ' + TCLIENTE.c_nomb_comer AS Descripcion,'" + _Int_Seleccion + "' as Imprimir " +
                        "FROM TCONFIGCXC INNER JOIN " +
                        "TFACTURAM ON TCONFIGCXC.ccompany = TFACTURAM.ccompany INNER JOIN " +
                        "TDOCUMENT ON TCONFIGCXC.ctipdocfact = TDOCUMENT.ctdocument INNER JOIN " +
                        "TCLIENTE ON TFACTURAM.cgroupcomp = TCLIENTE.cgroupcomp AND TFACTURAM.ccliente = TCLIENTE.ccliente " +
                        "WHERE (TFACTURAM.cgroupcomp = '" + Frm_Padre._Str_GroupComp + "') AND (TFACTURAM.ccompany = '" + _Str_CompFact + "') AND (TFACTURAM.c_impresa = '1') AND (TFACTURAM.c_numerocontrol='0') AND (TFACTURAM.cfactura LIKE '" + _P_Str_Ducumento + "%') ORDER BY TFACTURAM.cfactura";
                    }
                }
                else
                {
                    if (_P_Str_Ducumento.Trim().Length == 0)
                    {
                        _Str_Cadena = "SELECT TDOCUMENT.cname as Tipo, TFACTURAM.cfactura as Documento, CONVERT(varchar, TFACTURAM.cfactura) + ' - ' + TCLIENTE.c_nomb_comer AS Descripcion,'" + _Int_Seleccion + "' as Imprimir " +
                        "FROM TCONFIGCXC INNER JOIN " +
                        "TFACTURAM ON TCONFIGCXC.ccompany = TFACTURAM.ccompany INNER JOIN " +
                        "TDOCUMENT ON TCONFIGCXC.ctipdocfact = TDOCUMENT.ctdocument INNER JOIN " +
                        "TCLIENTE ON TFACTURAM.cgroupcomp = TCLIENTE.cgroupcomp AND TFACTURAM.ccliente = TCLIENTE.ccliente " +
                        "WHERE (TFACTURAM.cgroupcomp = '" + Frm_Padre._Str_GroupComp + "') AND (TFACTURAM.ccompany = '" + _Str_CompFact + "') AND (TFACTURAM.c_impresa = '1') AND (TFACTURAM.c_numerocontrol='0') ORDER BY TFACTURAM.cfactura";
                    }
                    else
                    {
                        _Str_Cadena = "SELECT TDOCUMENT.cname as Tipo, TFACTURAM.cfactura as Documento, CONVERT(varchar, TFACTURAM.cfactura) + ' - ' + TCLIENTE.c_nomb_comer AS Descripcion,'" + _Int_Seleccion + "' as Imprimir " +
                        "FROM TCONFIGCXC INNER JOIN " +
                        "TFACTURAM ON TCONFIGCXC.ccompany = TFACTURAM.ccompany INNER JOIN " +
                        "TDOCUMENT ON TCONFIGCXC.ctipdocfact = TDOCUMENT.ctdocument INNER JOIN " +
                        "TCLIENTE ON TFACTURAM.cgroupcomp = TCLIENTE.cgroupcomp AND TFACTURAM.ccliente = TCLIENTE.ccliente " +
                        "WHERE (TFACTURAM.cgroupcomp = '" + Frm_Padre._Str_GroupComp + "') AND (TFACTURAM.ccompany = '" + _Str_CompFact + "') AND (TFACTURAM.c_impresa = '1') AND (TFACTURAM.c_numerocontrol='0') AND (TFACTURAM.cfactura LIKE '" + _P_Str_Ducumento + "%')" + _P_Str_Factura + ") ORDER BY TFACTURAM.cfactura";
                    }
                }
            }
            else if (_P_Int_Sw == 4)
            {//NC POR APROBAR
                if (_P_Str_Ducumento.Trim().Length == 0)
                {
                    _Str_Cadena = "SELECT  TDOCUMENT.cname as Tipo, TNOTACREDICCTEMP.cidnotcredicctemp as Documento, TNOTACREDICCTEMP.ccliente AS Cliente, RTRIM(TCLIENTE.c_nomb_comer) AS DesCliente, TNOTACREDICCTEMP.cdescripcion as Descripcion ,TNOTACREDICCTEMP.cmontototsi + ISNULL(TNOTACREDICCTEMP.cexento,0) as Monto, TNOTACREDICCTEMP.cvendedor,'" + _Int_Seleccion + "' as Imprimir " +
                    "FROM TNOTACREDICCTEMP INNER JOIN " +
                    "TCLIENTE ON TNOTACREDICCTEMP.ccliente=TCLIENTE.ccliente AND TNOTACREDICCTEMP.cgroupcomp=TCLIENTE.cgroupcomp INNER JOIN " +
                    "TCONFIGCXC ON TNOTACREDICCTEMP.ccompany = TCONFIGCXC.ccompany INNER JOIN " +
                    "TDOCUMENT ON TCONFIGCXC.ctipdocnotcred = TDOCUMENT.ctdocument " +
                    "WHERE (TNOTACREDICCTEMP.cgroupcomp = '" + Frm_Padre._Str_GroupComp + "') AND (TNOTACREDICCTEMP.ccompany = '" + Frm_Padre._Str_Comp + "') AND (cestatusfirma=1) ORDER BY TNOTACREDICCTEMP.cidnotcredicctemp";
                }
                else
                {
                    _Str_Cadena = "SELECT  TDOCUMENT.cname as Tipo, TNOTACREDICCTEMP.cidnotcredicctemp as Documento, TNOTACREDICCTEMP.ccliente AS Cliente, RTRIM(TCLIENTE.c_nomb_comer) AS DesCliente, TNOTACREDICCTEMP.cdescripcion as Descripcion ,TNOTACREDICCTEMP.cmontototsi + ISNULL(TNOTACREDICCTEMP.cexento,0) as Monto,TNOTACREDICCTEMP.cvendedor,'" + _Int_Seleccion + "' as Imprimir " +
                    "FROM TNOTACREDICCTEMP INNER JOIN " +
                    "TCLIENTE ON TNOTACREDICCTEMP.ccliente=TCLIENTE.ccliente AND TNOTACREDICCTEMP.cgroupcomp=TCLIENTE.cgroupcomp INNER JOIN " +
                    "TCONFIGCXC ON TNOTACREDICCTEMP.ccompany = TCONFIGCXC.ccompany INNER JOIN " +
                    "TDOCUMENT ON TCONFIGCXC.ctipdocnotcred = TDOCUMENT.ctdocument " +
                    "WHERE (TNOTACREDICCTEMP.cgroupcomp = '" + Frm_Padre._Str_GroupComp + "') AND (TNOTACREDICCTEMP.ccompany = '" + Frm_Padre._Str_Comp + "') AND (TNOTACREDICCTEMP.cidnotcredicctemp LIKE '" + _P_Str_Ducumento + "%') AND (cestatusfirma=1) ORDER BY TNOTACREDICCTEMP.cidnotcredicctemp";
                }
            }
            else if (_P_Int_Sw == 5)
            {//NC SIN NUMERO DE CONTROL
                if (_P_Str_Ducumento.Trim().Length == 0)
                {
                    _Str_Cadena = "SELECT  TDOCUMENT.cname as Tipo, TNOTACREDICC.cidnotcredicc as Documento, TNOTACREDICC.cdescripcion as Descripcion,'" + _Int_Seleccion + "' as Imprimir " +
                    "FROM TNOTACREDICC INNER JOIN " +
                    "TCONFIGCXC ON TNOTACREDICC.ccompany = TCONFIGCXC.ccompany INNER JOIN " +
                    "TDOCUMENT ON TCONFIGCXC.ctipdocnotcred = TDOCUMENT.ctdocument " +
                    "WHERE (TNOTACREDICC.cgroupcomp = '" + Frm_Padre._Str_GroupComp + "') AND (TNOTACREDICC.cdelete='0') AND (TNOTACREDICC.cimpresa = 1) AND (TNOTACREDICC.cactivo = 1) AND (TNOTACREDICC.canulado=0) AND (TNOTACREDICC.cnumcontrolnc=0 OR TNOTACREDICC.cnumcontrolnc IS NULL) AND (TNOTACREDICC.ccompany = '" + Frm_Padre._Str_Comp + "') ORDER BY TNOTACREDICC.cidnotcredicc";
                }
                else
                {
                    _Str_Cadena = "SELECT  TDOCUMENT.cname as Tipo, TNOTACREDICC.cidnotcredicc as Documento, TNOTACREDICC.cdescripcion as Descripcion,'" + _Int_Seleccion + "' as Imprimir " +
                    "FROM TNOTACREDICC INNER JOIN " +
                    "TCONFIGCXC ON TNOTACREDICC.ccompany = TCONFIGCXC.ccompany INNER JOIN " +
                    "TDOCUMENT ON TCONFIGCXC.ctipdocnotcred = TDOCUMENT.ctdocument " +
                    "WHERE (TNOTACREDICC.cgroupcomp = '" + Frm_Padre._Str_GroupComp + "') AND (TNOTACREDICC.cdelete='0') AND (TNOTACREDICC.cimpresa = 1) AND (TNOTACREDICC.cactivo = 1) AND (TNOTACREDICC.canulado=0) AND (TNOTACREDICC.cnumcontrolnc=0 OR TNOTACREDICC.cnumcontrolnc IS NULL) AND (TNOTACREDICC.ccompany = '" + Frm_Padre._Str_Comp + "') AND (TNOTACREDICC.cidnotcredicc LIKE '" + _P_Str_Ducumento + "%') ORDER BY TNOTACREDICC.cidnotcredicc";
                }
            }
            else if (_P_Int_Sw == 6)
            {//ND POR APROBAR
                if (_P_Str_Ducumento.Trim().Length == 0)
                {
                    _Str_Cadena = "SELECT  TDOCUMENT.cname as Tipo, TNOTADEBICCTEMP.cidnotadebitocctemp as Documento, TNOTADEBICCTEMP.ccliente AS Cliente, RTRIM(TCLIENTE.c_nomb_comer) AS DesCliente, TNOTADEBICCTEMP.cdescripcion as Descripcion, TNOTADEBICCTEMP.cmontototsi + ISNULL(TNOTADEBICCTEMP.cexento,0) as Monto,TNOTADEBICCTEMP.cvendedor,'" + _Int_Seleccion + "' as Imprimir " +
                    "FROM TNOTADEBICCTEMP INNER JOIN " +
                    "TCLIENTE ON TNOTADEBICCTEMP.ccliente=TCLIENTE.ccliente AND TNOTADEBICCTEMP.cgroupcomp=TCLIENTE.cgroupcomp INNER JOIN " +
                    "TCONFIGCXC ON TNOTADEBICCTEMP.ccompany = TCONFIGCXC.ccompany INNER JOIN " +
                    "TDOCUMENT ON TCONFIGCXC.ctipdocnotdeb = TDOCUMENT.ctdocument " +
                    "WHERE (TNOTADEBICCTEMP.cgroupcomp = '" + Frm_Padre._Str_GroupComp + "') AND (TNOTADEBICCTEMP.ccompany = '" + Frm_Padre._Str_Comp + "') AND (cestatusfirma=1) ORDER BY TNOTADEBICCTEMP.cidnotadebitocctemp";
                }
                else
                {
                    _Str_Cadena = "SELECT  TDOCUMENT.cname as Tipo, TNOTADEBICCTEMP.cidnotadebitocctemp as Documento, TNOTADEBICCTEMP.ccliente AS Cliente, RTRIM(TCLIENTE.c_nomb_comer) AS DesCliente, TNOTADEBICCTEMP.cdescripcion as Descripcion, TNOTADEBICCTEMP.cmontototsi + ISNULL(TNOTADEBICCTEMP.cexento,0) as Monto,TNOTADEBICCTEMP.cvendedor,'" + _Int_Seleccion + "' as Imprimir " +
                    "FROM TNOTADEBICCTEMP INNER JOIN " +
                    "TCLIENTE ON TNOTADEBICCTEMP.ccliente=TCLIENTE.ccliente AND TNOTADEBICCTEMP.cgroupcomp=TCLIENTE.cgroupcomp INNER JOIN " +
                    "TCONFIGCXC ON TNOTADEBICCTEMP.ccompany = TCONFIGCXC.ccompany INNER JOIN " +
                    "TDOCUMENT ON TCONFIGCXC.ctipdocnotdeb = TDOCUMENT.ctdocument " +
                    "WHERE (TNOTADEBICCTEMP.cgroupcomp = '" + Frm_Padre._Str_GroupComp + "') AND (TNOTADEBICCTEMP.ccompany = '" + Frm_Padre._Str_Comp + "') AND (TNOTADEBICCTEMP.cidnotadebitocctemp LIKE '" + _P_Str_Ducumento + "%')  AND (cestatusfirma=1) ORDER BY TNOTADEBICCTEMP.cidnotadebitocctemp";
                }
            }
            else if (_P_Int_Sw == 7)
            {//ND SIN NUMERO DE CONTROL
                if (_P_Str_Ducumento.Trim().Length == 0)
                {
                    _Str_Cadena = "SELECT  TDOCUMENT.cname as Tipo, TNOTADEBICC.cidnotadebitocc as Documento, TNOTADEBICC.cdescripcion as Descripcion,'" + _Int_Seleccion + "' as Imprimir " +
                    "FROM TNOTADEBICC INNER JOIN " +
                    "TCONFIGCXC ON TNOTADEBICC.ccompany = TCONFIGCXC.ccompany INNER JOIN " +
                    "TDOCUMENT ON TCONFIGCXC.ctipdocnotdeb = TDOCUMENT.ctdocument " +
                    "WHERE (TNOTADEBICC.cgroupcomp = '" + Frm_Padre._Str_GroupComp + "') AND (TNOTADEBICC.cdelete = '0') AND (TNOTADEBICC.cimpresa = 1) AND (TNOTADEBICC.cactivo = 1) AND (TNOTADEBICC.canulado=0) AND (TNOTADEBICC.cnumcontrolnd=0 OR TNOTADEBICC.cnumcontrolnd IS NULL) AND (TNOTADEBICC.ccompany = '" + Frm_Padre._Str_Comp + "') ORDER BY TNOTADEBICC.cidnotadebitocc";
                }
                else
                {
                    _Str_Cadena = "SELECT  TDOCUMENT.cname as Tipo, TNOTADEBICC.cidnotadebitocc as Documento, TNOTADEBICC.cdescripcion as Descripcion,'" + _Int_Seleccion + "' as Imprimir " +
                    "FROM TNOTADEBICC INNER JOIN " +
                    "TCONFIGCXC ON TNOTADEBICC.ccompany = TCONFIGCXC.ccompany INNER JOIN " +
                    "TDOCUMENT ON TCONFIGCXC.ctipdocnotdeb = TDOCUMENT.ctdocument " +
                    "WHERE (TNOTADEBICC.cgroupcomp = '" + Frm_Padre._Str_GroupComp + "') AND (TNOTADEBICC.cdelete = '0') AND (TNOTADEBICC.cimpresa = 1) AND (TNOTADEBICC.cactivo = 1) AND (TNOTADEBICC.canulado=0) AND (TNOTADEBICC.cnumcontrolnd=0 OR TNOTADEBICC.cnumcontrolnd IS NULL) AND (TNOTADEBICC.ccompany = '" + Frm_Padre._Str_Comp + "') AND (TNOTADEBICC.cidnotadebitocc LIKE '" + _P_Str_Ducumento + "%') ORDER BY TNOTADEBICC.cidnotadebitocc";
                }
            }
            else if (_P_Int_Sw == 8)
            {//NC APLICADAS EN CAJA POR IMPRIMIR
                if (_P_Str_Ducumento.Trim().Length == 0)
                {
                    _Str_Cadena = "SELECT  TDOCUMENT.cname as Tipo, TNOTACREDICC.cidnotcredicc as Documento, TNOTACREDICC.cdescripcion as Descripcion,'" + _Int_Seleccion + "' as Imprimir, TNOTACREDICC.cidcomprob " +
                    "FROM TNOTACREDICC INNER JOIN " +
                    "TCONFIGCXC ON TNOTACREDICC.ccompany = TCONFIGCXC.ccompany INNER JOIN " +
                    "TDOCUMENT ON TCONFIGCXC.ctipdocnotcred = TDOCUMENT.ctdocument " +
                    "WHERE (TNOTACREDICC.cgroupcomp = '" + Frm_Padre._Str_GroupComp + "') AND (TNOTACREDICC.cimpresa = '0') AND (TNOTACREDICC.cactivo = '0') AND (TNOTACREDICC.cestatusfirma=3) AND (TNOTACREDICC.ccompany = '" + Frm_Padre._Str_Comp + "') AND (TNOTACREDICC.cdescuenpp=1)";
                    if (_G_Str_ccaja.Length > 0)
                    {
                        _Str_Cadena = _Str_Cadena + " AND (TNOTACREDICC.ccaja='" + _G_Str_ccaja + "')";
                    }
                    _Str_Cadena = _Str_Cadena + "  ORDER BY TNOTACREDICC.cidnotcredicc";
                }
                else
                {
                    _Str_Cadena = "SELECT  TDOCUMENT.cname as Tipo, TNOTACREDICC.cidnotcredicc as Documento, TNOTACREDICC.cdescripcion as Descripcion,'" + _Int_Seleccion + "' as Imprimir, TNOTACREDICC.cidcomprob " +
                    "FROM TNOTACREDICC INNER JOIN " +
                    "TCONFIGCXC ON TNOTACREDICC.ccompany = TCONFIGCXC.ccompany INNER JOIN " +
                    "TDOCUMENT ON TCONFIGCXC.ctipdocnotcred = TDOCUMENT.ctdocument " +
                    "WHERE (TNOTACREDICC.cgroupcomp = '" + Frm_Padre._Str_GroupComp + "') AND (TNOTACREDICC.cimpresa = '0') AND (TNOTACREDICC.cactivo = '0') AND (TNOTACREDICC.cestatusfirma=3) AND (TNOTACREDICC.ccompany = '" + Frm_Padre._Str_Comp + "') AND (TNOTACREDICC.cidnotcredicc LIKE '" + _P_Str_Ducumento + "%')  AND (TNOTACREDICC.cdescuenpp=1)";
                    if (_G_Str_ccaja.Length > 0)
                    {
                        _Str_Cadena = _Str_Cadena + " AND (TNOTACREDICC.ccaja='" + _G_Str_ccaja + "')";
                    }
                    _Str_Cadena = _Str_Cadena + "  ORDER BY TNOTACREDICC.cidnotcredicc";
                }
            }
            else if (_P_Int_Sw == 9)
            {//NOTA DE RECEPCION POR DEVOLUCIONES EN VENTA POR IMPRIMIR
                _Str_Cadena = "SELECT cidnotrecepc AS [N.R.],ccliente AS Cliente,c_nomb_comer AS Descripción,ctipodocument_name AS [T.Documento],cnumdocu AS Documento,dbo.Fnc_Formatear(cmontosi) AS Monto,dbo.Fnc_Formatear(cmontoimp) AS Impuesto,dbo.Fnc_Formatear((cmontosi)+cmontoimp) AS Total,'" + _Int_Seleccion + "' AS Imprimir FROM VST_NOTARECEPC_DEVOL WHERE cdelete='0' AND cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cimpreso='0' ORDER BY cidnotrecepc";
                _Dg_Grid.Columns.Clear();
                DataGridViewCheckBoxColumn _Dg_Column = new DataGridViewCheckBoxColumn();
                _Dg_Column.Name = "Imprimir";
                _Dg_Column.DataPropertyName = "Imprimir";
                _Dg_Column.HeaderText = "Imprimir";
                _Dg_Column.ReadOnly = false;
                _Dg_Column.FalseValue = "0";
                _Dg_Column.TrueValue = "1";
                _Dg_Grid.Columns.Add(_Dg_Column);
            }
            else if (_P_Int_Sw == 10)
            {//ND POR APROBAR A PROVEEDORES
                if (_P_Str_Ducumento.Trim().Length == 0)
                {
                    _Str_Cadena = "SELECT  TDOCUMENT.cname as Tipo, TNOTADEBITOCPTEMP.cidnotadebitocxptemp as Documento, TNOTADEBITOCPTEMP.cdescripcion as Descripcion,ISNULL(TNOTADEBITOCPTEMP.cmontototsi,0)+ISNULL(cbaseexcenta,0) as Monto,'" + _Int_Seleccion + "' as Imprimir " +
                    "FROM TNOTADEBITOCPTEMP INNER JOIN " +
                    "TCONFIGCXP ON TNOTADEBITOCPTEMP.ccompany = TCONFIGCXP.ccompany INNER JOIN " +
                    "TDOCUMENT ON TCONFIGCXP.ctipodocnd = TDOCUMENT.ctdocument " +
                    "WHERE (TNOTADEBITOCPTEMP.cgroupcomp = '" + Frm_Padre._Str_GroupComp + "') AND (TNOTADEBITOCPTEMP.ccompany = '" + Frm_Padre._Str_Comp + "') AND (cestatusfirma=1) ORDER BY TNOTADEBITOCPTEMP.cidnotadebitocxptemp";
                }
                else
                {
                    _Str_Cadena = "SELECT  TDOCUMENT.cname as Tipo, TNOTADEBITOCPTEMP.cidnotadebitocxptemp as Documento, TNOTADEBITOCPTEMP.cdescripcion as Descripcion,ISNULL(TNOTADEBITOCPTEMP.cmontototsi,0)+ISNULL(cbaseexcenta,0) as Monto,'" + _Int_Seleccion + "' as Imprimir " +
                    "FROM TNOTADEBITOCPTEMP INNER JOIN " +
                    "TCONFIGCXP ON TNOTADEBITOCPTEMP.ccompany = TCONFIGCXP.ccompany INNER JOIN " +
                    "TDOCUMENT ON TCONFIGCXP.ctipodocnd = TDOCUMENT.ctdocument " +
                    "WHERE (TNOTADEBITOCPTEMP.cgroupcomp = '" + Frm_Padre._Str_GroupComp + "') AND (TNOTADEBITOCPTEMP.ccompany = '" + Frm_Padre._Str_Comp + "') AND (TNOTADEBITOCPTEMP.cidnotadebitocxptemp LIKE '" + _P_Str_Ducumento + "%') AND (cestatusfirma=1) ORDER BY TNOTADEBITOCPTEMP.cidnotadebitocxptemp";
                }
            }
            else if (_P_Int_Sw == 11)
            {//NC POR APROBAR A PROVEEDORES
                if (_P_Str_Ducumento.Trim().Length == 0)
                {
                    _Str_Cadena = "SELECT  TDOCUMENT.cname as Tipo, TNOTACREDICPTEMP.cidnotacreditocxptemp as Documento, TNOTACREDICPTEMP.cdescripcion as Descripcion,ISNULL(TNOTACREDICPTEMP.cmontototsi,0)+ISNULL(cbaseexcenta,0) as Monto,'" + _Int_Seleccion + "' as Imprimir " +
                    "FROM TNOTACREDICPTEMP INNER JOIN " +
                    "TCONFIGCXP ON TNOTACREDICPTEMP.ccompany = TCONFIGCXP.ccompany INNER JOIN " +
                    "TDOCUMENT ON TCONFIGCXP.ctipodocnc = TDOCUMENT.ctdocument " +
                    "WHERE (TNOTACREDICPTEMP.cgroupcomp = '" + Frm_Padre._Str_GroupComp + "') AND (TNOTACREDICPTEMP.ccompany = '" + Frm_Padre._Str_Comp + "') AND (cestatusfirma=1) ORDER BY TNOTACREDICPTEMP.cidnotacreditocxptemp";
                }
                else
                {
                    _Str_Cadena = "SELECT  TDOCUMENT.cname as Tipo, TNOTACREDICPTEMP.cidnotacreditocxptemp as Documento, TNOTACREDICPTEMP.cdescripcion as Descripcion,ISNULL(TNOTACREDICPTEMP.cmontototsi,0)+ISNULL(cbaseexcenta,0) as Monto,'" + _Int_Seleccion + "' as Imprimir " +
                    "FROM TNOTACREDICPTEMP INNER JOIN " +
                    "TCONFIGCXP ON TNOTACREDICPTEMP.ccompany = TCONFIGCXP.ccompany INNER JOIN " +
                    "TDOCUMENT ON TCONFIGCXP.ctipodocnc = TDOCUMENT.ctdocument " +
                    "WHERE (TNOTACREDICPTEMP.cgroupcomp = '" + Frm_Padre._Str_GroupComp + "') AND (TNOTACREDICPTEMP.ccompany = '" + Frm_Padre._Str_Comp + "') AND (TNOTACREDICPTEMP.cidnotacreditocxptemp LIKE '" + _P_Str_Ducumento + "%') AND (cestatusfirma=1) ORDER BY TNOTACREDICPTEMP.cidnotacreditocxptemp";
                }
            }
            else if (_P_Int_Sw == 12)
            {//COMPROBANTE DE CHEQUES DEVUELTOS POR GENERAR
                if (_P_Str_Ducumento.Trim().Length == 0)
                {
                    _Str_Cadena = "SELECT TDOCUMENT.cname AS Tipo, TCHEQDEVUELT.cidcheqdevuelt AS Documento, CONVERT(VARCHAR, TCLIENTE.ccliente) + ' - ' + TCLIENTE.c_nomb_comer AS Descripcion, dbo.Fnc_Formatear(TCHEQDEVUELT.cmontocheq) AS Monto,'" + _Int_Seleccion + "' as Imprimir, TCHEQDEVUELT.cidcomprob, TCHEQDEVUELT.cnumcheque, TCHEQDEVUELT.ccliente " +
                      "FROM TCHEQDEVUELT INNER JOIN " +
                      "TCONFIGCXC ON TCHEQDEVUELT.ccompany = TCONFIGCXC.ccompany INNER JOIN " +
                      "TDOCUMENT ON TCONFIGCXC.ctipdoccheqdev = TDOCUMENT.ctdocument INNER JOIN " +
                      "TCLIENTE ON TCHEQDEVUELT.cgroupcomp = TCLIENTE.cgroupcomp AND TCHEQDEVUELT.ccliente = TCLIENTE.ccliente " +
                      "WHERE (TCHEQDEVUELT.cgroupcomp = '" + Frm_Padre._Str_GroupComp + "') AND (TCHEQDEVUELT.ccompany = '" + Frm_Padre._Str_Comp + "') AND (TCHEQDEVUELT.cidcomprob='0' OR (TCHEQDEVUELT.cidcomprob>0 AND EXISTS(SELECT cidcomprob FROM TCOMPROBANC WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cidcomprob=TCHEQDEVUELT.cidcomprob AND clvalidado='0'))) ORDER BY TCHEQDEVUELT.cidcheqdevuelt";
                }
                else
                {
                    _Str_Cadena = "SELECT TDOCUMENT.cname AS Tipo, TCHEQDEVUELT.cidcheqdevuelt AS Documento, CONVERT(VARCHAR, TCLIENTE.ccliente) + ' - ' + TCLIENTE.c_nomb_comer AS Descripcion, dbo.Fnc_Formatear(TCHEQDEVUELT.cmontocheq) AS Monto,'" + _Int_Seleccion + "' as Imprimir, TCHEQDEVUELT.cidcomprob, TCHEQDEVUELT.cnumcheque, TCHEQDEVUELT.ccliente " +
                      "FROM TCHEQDEVUELT INNER JOIN " +
                      "TCONFIGCXC ON TCHEQDEVUELT.ccompany = TCONFIGCXC.ccompany INNER JOIN " +
                      "TDOCUMENT ON TCONFIGCXC.ctipdoccheqdev = TDOCUMENT.ctdocument INNER JOIN " +
                      "TCLIENTE ON TCHEQDEVUELT.cgroupcomp = TCLIENTE.cgroupcomp AND TCHEQDEVUELT.ccliente = TCLIENTE.ccliente " +
                      "WHERE (TCHEQDEVUELT.cgroupcomp = '" + Frm_Padre._Str_GroupComp + "') AND (TCHEQDEVUELT.ccompany = '" + Frm_Padre._Str_Comp + "') AND (TCHEQDEVUELT.cidcheqdevuelt LIKE '" + _P_Str_Ducumento + "%') AND (TCHEQDEVUELT.cidcomprob='0' OR (TCHEQDEVUELT.cidcomprob>0 AND EXISTS(SELECT cidcomprob FROM TCOMPROBANC WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cidcomprob=TCHEQDEVUELT.cidcomprob AND clvalidado='0'))) ORDER BY TCHEQDEVUELT.cidcheqdevuelt";
                }
            }
            else if (_P_Int_Sw == 13)
            {// ANULACIÓN DE NC POR APROBAR
                if (_P_Str_Ducumento.Trim().Length == 0)
                {
                    _Str_Cadena = "SELECT  TDOCUMENT.cname as Tipo, VST_NC_ANUL.cidnotcredicc as Documento, VST_NC_ANUL.cdescripcion as Descripcion,VST_NC_ANUL.cmontototsi + ISNULL(VST_NC_ANUL.cexento,0) as Monto,'" + _Int_Seleccion + "' as Imprimir, VST_NC_ANUL.cidcomprobanul AS cidcomprob " +
                    "FROM VST_NC_ANUL INNER JOIN " +
                    "TCONFIGCXC ON VST_NC_ANUL.ccompany = TCONFIGCXC.ccompany INNER JOIN " +
                    "TDOCUMENT ON TCONFIGCXC.ctipdocnotcred = TDOCUMENT.ctdocument " +
                    "WHERE VST_NC_ANUL.cdelete=0 AND VST_NC_ANUL.cgroupcomp = '" + Frm_Padre._Str_GroupComp + "' AND VST_NC_ANUL.ccompany='" + Frm_Padre._Str_Comp + "' AND VST_NC_ANUL.cactivo_anul=0 AND VST_NC_ANUL.cestatusfirma_anul=1 ORDER BY VST_NC_ANUL.cidnotcredicc";
                }
                else
                {
                    _Str_Cadena = "SELECT  TDOCUMENT.cname as Tipo, VST_NC_ANUL.cidnotcredicc as Documento, VST_NC_ANUL.cdescripcion as Descripcion,VST_NC_ANUL.cmontototsi + ISNULL(VST_NC_ANUL.cexento,0) as Monto,'" + _Int_Seleccion + "' as Imprimir, VST_NC_ANUL.cidcomprobanul AS cidcomprob " +
                     "FROM VST_NC_ANUL INNER JOIN " +
                     "TCONFIGCXC ON VST_NC_ANUL.ccompany = TCONFIGCXC.ccompany INNER JOIN " +
                     "TDOCUMENT ON TCONFIGCXC.ctipdocnotcred = TDOCUMENT.ctdocument " +
                     "WHERE VST_NC_ANUL.cdelete=0 AND VST_NC_ANUL.cgroupcomp = '" + Frm_Padre._Str_GroupComp + "' AND VST_NC_ANUL.ccompany='" + Frm_Padre._Str_Comp + "' AND VST_NC_ANUL.cactivo_anul=0 AND VST_NC_ANUL.cestatusfirma_anul=1 AND (VST_NC_ANUL.cidnotcredicc LIKE '" + _P_Str_Ducumento + "%') ORDER BY VST_NC_ANUL.cidnotcredicc";
                }
            }
            else if (_P_Int_Sw == 14)
            {//COMPROBANTE DE EGRESO DE CHEQUES POR GENERAR
                if (_P_Str_Ducumento.Trim().Length == 0)
                {
                    _Str_Cadena = "SELECT TOP 100 PERCENT dbo.TEGRECHEQTRAN.cnumcheque AS Tipo, dbo.TEGRECHEQTRAN.cidegrecheqtran AS Documento, CONVERT(VARCHAR, dbo.TCLIENTE.ccliente) + ' - ' + dbo.TCLIENTE.c_nomb_comer AS Descripcion, dbo.Fnc_Formatear(dbo.TEGRECHEQTRAN.cmontocheq) AS Monto,  '" + _Int_Seleccion + "' AS Imprimir, dbo.TEGRECHEQTRAN.cidcomprob, dbo.TEGRECHEQTRAN.cnumdepo, dbo.TEGRECHEQTRAN.ccliente, dbo.TBANCO.cname AS [Banco deposito] " +
                    "FROM dbo.TEGRECHEQTRAN INNER JOIN dbo.TCLIENTE ON dbo.TEGRECHEQTRAN.cgroupcomp = dbo.TCLIENTE.cgroupcomp AND dbo.TEGRECHEQTRAN.ccliente = dbo.TCLIENTE.ccliente INNER JOIN dbo.TBANCO ON dbo.TEGRECHEQTRAN.ccompany = dbo.TBANCO.ccompany AND dbo.TEGRECHEQTRAN.cbancodepo = dbo.TBANCO.cbanco " +
                    "WHERE (TEGRECHEQTRAN.cgroupcomp = '" + Frm_Padre._Str_GroupComp + "') AND (TEGRECHEQTRAN.ccompany = '" + Frm_Padre._Str_Comp + "') AND (TEGRECHEQTRAN.cidcomprob='0' OR (TEGRECHEQTRAN.cidcomprob>0 AND EXISTS(SELECT cidcomprob FROM TCOMPROBANC WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cidcomprob=TEGRECHEQTRAN.cidcomprob AND clvalidado='0'))) ORDER BY TEGRECHEQTRAN.cidegrecheqtran";
                }
                else
                {
                    _Str_Cadena = "SELECT TOP 100 PERCENT dbo.TEGRECHEQTRAN.cnumcheque AS Tipo, dbo.TEGRECHEQTRAN.cidegrecheqtran AS Documento, CONVERT(VARCHAR, dbo.TCLIENTE.ccliente) + ' - ' + dbo.TCLIENTE.c_nomb_comer AS Descripcion, dbo.Fnc_Formatear(dbo.TEGRECHEQTRAN.cmontocheq) AS Monto,  '" + _Int_Seleccion + "' AS Imprimir, dbo.TEGRECHEQTRAN.cidcomprob, dbo.TEGRECHEQTRAN.cnumdepo, dbo.TEGRECHEQTRAN.ccliente, dbo.TBANCO.cname AS [Banco deposito] " +
                    "FROM dbo.TEGRECHEQTRAN INNER JOIN dbo.TCLIENTE ON dbo.TEGRECHEQTRAN.cgroupcomp = dbo.TCLIENTE.cgroupcomp AND dbo.TEGRECHEQTRAN.ccliente = dbo.TCLIENTE.ccliente INNER JOIN dbo.TBANCO ON dbo.TEGRECHEQTRAN.ccompany = dbo.TBANCO.ccompany AND dbo.TEGRECHEQTRAN.cbancodepo = dbo.TBANCO.cbanco " +
                    "WHERE (TEGRECHEQTRAN.cgroupcomp = '" + Frm_Padre._Str_GroupComp + "') AND (TEGRECHEQTRAN.ccompany = '" + Frm_Padre._Str_Comp + "') AND (TEGRECHEQTRAN.cidegrecheqtran LIKE '" + _P_Str_Ducumento + "%') AND (TEGRECHEQTRAN.cidcomprob='0' OR (TEGRECHEQTRAN.cidcomprob>0 AND EXISTS(SELECT cidcomprob FROM TCOMPROBANC WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cidcomprob=TEGRECHEQTRAN.cidcomprob AND clvalidado='0'))) ORDER BY TEGRECHEQTRAN.cidegrecheqtran";
                }
            }
            Cursor = Cursors.WaitCursor;
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            _Dg_Grid.DataSource = _Ds.Tables[0];
            _Dg_Grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            Cursor = Cursors.Default;
            _Dg_Grid.ClearSelection();
            //--------------------------------------------------------------------
            if (_P_Int_Sw == 1)
            { this.Text = _Str_ThisText + " (Todas las Notas de Crédito sin imprimir)"; _Dg_Grid.Columns["cidcomprob"].Visible = true; }
            else if (_P_Int_Sw == 2)
            { this.Text = _Str_ThisText + " (Todas las Notas de Débito sin imprimir)"; _Dg_Grid.Columns["cidcomprob"].Visible = true; }
            else if (_P_Int_Sw == 3)
            { this.Text = _Str_ThisText + " (Todas las Facturas sin número de control)"; }
            else if (_P_Int_Sw == 4)
            { this.Text = _Str_ThisText + " (Todas las NC por aprobar)"; }
            else if (_P_Int_Sw == 5)
            { this.Text = _Str_ThisText + " (Todas las NC sin número de control)"; }
            else if (_P_Int_Sw == 8)
            { this.Text = _Str_ThisText + " (Todas las NC generadas en el cierre de Caja " + _G_Str_ccaja + ")"; _Dg_Grid.Columns["cidcomprob"].Visible = true; }
            else if (_P_Int_Sw == 9)
            {
                this.Text = _Str_ThisText + " (Todas las NR por Devoluciones en Ventas por imprimir)";
                _Dg_Grid.Columns["Imprimir"].DisplayIndex = 8;
                _Dg_Grid.Columns[0].Name = "Documento";
                foreach (DataGridViewColumn _Dg in _Dg_Grid.Columns)
                {
                    if (_Dg.GetType() != typeof(DataGridViewCheckBoxColumn))
                    {
                        _Dg.ReadOnly = true;
                        if (_Dg.Index == 5 | _Dg.Index == 6 | _Dg.Index == 7)
                        { _Dg.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight; }
                    }
                }
            }
            else if (_P_Int_Sw == 10)
            { this.Text = _Str_ThisText + " (Todas las ND por aprobar)"; }
            else if (_P_Int_Sw == 11)
            { this.Text = _Str_ThisText + " (Todas las NC por aprobar)"; }
            else if (_P_Int_Sw == 12)
            { this.Text = _Str_ThisText + " (Cheques Devueltos sin comprobante)"; }
            else if (_P_Int_Sw == 13)
            { this.Text = _Str_ThisText + " (Todas las Notas de Crédito anuladas por aprobar)"; _Dg_Grid.Columns["cidcomprob"].Visible = true; }
            else if (_P_Int_Sw == 14)
            { this.Text = _Str_ThisText + " (Egresos de Cheque sin comprobante)"; }
        }

        private void Frm_ImpresionLote_Load(object sender, EventArgs e)
        {
            _Mtd_Sorted(_Dg_Grid);
            this.Dock = DockStyle.Fill;
            _Pnl_Numero.Left = (this.Width / 2) - (_Pnl_Numero.Width / 2);
            _Pnl_Numero.Top = (this.Height / 2) - (_Pnl_Numero.Height / 2);
            _Pnl_Clave.Left = (this.Width / 2) - (_Pnl_Clave.Width / 2);
            _Pnl_Clave.Top = (this.Height / 2) - (_Pnl_Clave.Height / 2);
            _Pnl_ReImpresion.Parent = this;
            _Pnl_ReImpresion.Left = (this.Width / 2) - (_Pnl_ReImpresion.Width / 2);
            _Pnl_ReImpresion.Top = (this.Height / 2) - (_Pnl_ReImpresion.Height / 2);
            _Dg_Grid.ClearSelection();
        }

        private void _Tool_Actualizar_Click(object sender, EventArgs e)
        {
            _Tool_Consulta.Text = "";
            Cursor = Cursors.WaitCursor;
            _Mtd_Actualizar(_Int_Sw, _Tool_Consulta.Text, _Int_Seleccion, _Str_Factura);
            Cursor = Cursors.Default;
        }

        private void _Tool_Consulta_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 && e.KeyChar != 13)
            {
                e.Handled = true;
            }
            else
            {
                if (e.KeyChar == (char)13)
                {
                    _Mtd_Actualizar(_Int_Sw, _Tool_Consulta.Text, _Int_Seleccion, _Str_Factura);
                }
            }
        }

        private void _Tool_Consulta_TextChanged(object sender, EventArgs e)
        {
            if (!_Mtd_IsNumeric(_Tool_Consulta.Text))
            {
                _Tool_Consulta.Text = "";
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (!_Mtd_IsNumeric(_Txt_Numero.Text))
            {
                _Txt_Numero.Text = "";
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }

        private void _Pnl_Numero_VisibleChanged(object sender, EventArgs e)
        {
            if (_Pnl_Numero.Visible)
            { _Tool_Principal.Enabled = false; _Dg_Grid.Enabled = false; _Pnl_Inferior.Enabled = false; _Txt_Numero.Text = ""; _Txt_Numero.Focus(); }
            else
            { _Tool_Principal.Enabled = true; _Dg_Grid.Enabled = true; _Pnl_Inferior.Enabled = true; }
        }

        private void _Pnl_Clave_VisibleChanged(object sender, EventArgs e)
        {
            if (_Pnl_Clave.Visible)
            { _Bol_Rechazar = false; _Tool_Principal.Enabled = false; _Dg_Grid.Enabled = false; _Pnl_Inferior.Enabled = false; _Txt_Clave.Text = ""; _Txt_Clave.Focus(); }
            else
            { _Tool_Principal.Enabled = true; _Dg_Grid.Enabled = true; _Pnl_Inferior.Enabled = true; _Bt_Actualizar.Focus(); }
        }

        private void _Bt_CancelarNumero_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Esta seguro de cancelar la operación?", "Precausión", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                if (_Int_Sw == 3 & _Str_Factura.Trim().Length>0)
                { this.Close(); }
                else
                { _Pnl_Numero.Visible = false; }
            }
        }
        private bool _Mtd_Seleccionar()
        {
            Cursor = Cursors.WaitCursor;
            foreach (DataGridViewRow _Dg_Row in _Dg_Grid.Rows)
            {
                if (_Dg_Row.Cells["Imprimir"].Value != null)
                {
                    if (_Dg_Row.Cells["Imprimir"].Value.ToString().Trim() == "1")
                    { Cursor = Cursors.Default; return true; }
                }
            }
            Cursor = Cursors.Default;
            return false;
        }
        private bool _Mtd_VerificarImpresos()
        {
            Cursor = Cursors.WaitCursor;
            foreach (DataGridViewRow _Dg_Row in _Dg_Grid.Rows)
            {
                if (_Dg_Row.Cells["Numero"].Value == null)
                { _Dg_Row.Cells["Numero"].Value = ""; }
                if (_Dg_Row.Cells["Imprimir"].Value != null)
                {
                    if (_Dg_Row.Cells["Imprimir"].Value.ToString().Trim() == "1" & _Dg_Row.Cells["Numero"].Value.ToString().Trim().Length==0)
                    { Cursor = Cursors.Default; return false; }
                }
            }
            Cursor = Cursors.Default;
            return true;
        }
        private void _Mtd_ActualizarNumeros()
        {
            string _Str_Comprob = "";
            DataSet _Ds;
            string _Str_Cadena = "";
            foreach (DataGridViewRow _Dg_Row in _Dg_Grid.Rows)
            {
                if (_Dg_Row.Cells["Imprimir"].Value != null)
                {
                    if (_Dg_Row.Cells["Imprimir"].Value.ToString().Trim() == "1")
                    {
                        if (_Int_Sw == 1 || _Int_Sw == 5 || _Int_Sw == 8)
                        {
                            if (Convert.ToString(_Dg_Row.Cells["cidcomprob"].Value).Trim().Length == 0 | Convert.ToString(_Dg_Row.Cells["cidcomprob"].Value).Trim() == "0")
                            {
                                _Str_Cadena = "SELECT cidcomprob FROM TNOTACREDICC WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and ccompany='" + Frm_Padre._Str_Comp + "' and cidnotcredicc='" + _Dg_Row.Cells["Documento"].Value.ToString().Trim() + "'";
                                _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                                if (_Ds.Tables[0].Rows.Count > 0)
                                {
                                    _Str_Comprob = Convert.ToString(_Ds.Tables[0].Rows[0][0]);
                                }
                            }
                            else
                            {
                                _Str_Comprob = Convert.ToString(_Dg_Row.Cells["cidcomprob"].Value);
                            }
                            _Str_Cadena = "Update TNOTACREDICC set cnumcontrolnc='" + _Dg_Row.Cells["Numero"].Value.ToString().Trim() + "' where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and ccompany='" + Frm_Padre._Str_Comp + "' and cidnotcredicc='" + _Dg_Row.Cells["Documento"].Value.ToString().Trim() + "'";
                            Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                            _Str_Cadena = "Update TCOMPROBANC set clvalidado='1',cvalidate='" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate()) + "' where ccompany='" + Frm_Padre._Str_Comp + "' and cidcomprob='" + _Str_Comprob + "'";
                        }
                        else if (_Int_Sw == 2)
                        {
                            if (Convert.ToString(_Dg_Row.Cells["cidcomprob"].Value).Trim().Length == 0 | Convert.ToString(_Dg_Row.Cells["cidcomprob"].Value).Trim() == "0")
                            {
                                _Str_Cadena = "SELECT cidcomprob FROM TNOTADEBICC WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and ccompany='" + Frm_Padre._Str_Comp + "' and cidnotadebitocc='" + _Dg_Row.Cells["Documento"].Value.ToString().Trim() + "'";
                                _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                                if (_Ds.Tables[0].Rows.Count > 0)
                                {
                                    _Str_Comprob = Convert.ToString(_Ds.Tables[0].Rows[0][0]);
                                }
                            }
                            else
                            {
                                _Str_Comprob = Convert.ToString(_Dg_Row.Cells["cidcomprob"].Value);
                            }
                            _Str_Cadena = "Update TNOTADEBICC set cnumcontrolnd='" + _Dg_Row.Cells["Numero"].Value.ToString().Trim() + "' where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and ccompany='" + Frm_Padre._Str_Comp + "' and cidnotadebitocc='" + _Dg_Row.Cells["Documento"].Value.ToString().Trim() + "'";
                            Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                            _Str_Cadena = "Update TCOMPROBANC set clvalidado='1',cvalidate='" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate()) + "' where ccompany='" + Frm_Padre._Str_Comp + "' and cidcomprob='" + _Str_Comprob + "'";
                        }
                        else if (_Int_Sw == 3)
                        { _Str_Cadena = "Update TFACTURAM set c_numerocontrol='" + Convert.ToString(_Dg_Row.Cells["Numero"].Value.ToString()).Trim() + "',cdateupd='" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ()) + "' where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and ccompany='" + _Str_CompFact + "' and cfactura='" + Convert.ToString(_Dg_Row.Cells["Documento"].Value).Trim() + "'"; }
                        if (_Int_Sw == 7)
                        {
                            if (Convert.ToString(_Dg_Row.Cells["cidcomprob"].Value).Trim().Length == 0)
                            {
                                _Str_Cadena = "SELECT cidcomprob FROM TNOTADEBICC WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and ccompany='" + Frm_Padre._Str_Comp + "' and cidnotadebitocc='" + _Dg_Row.Cells["Documento"].Value.ToString().Trim() + "'";
                                _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                                if (_Ds.Tables[0].Rows.Count > 0)
                                {
                                    _Str_Comprob = Convert.ToString(_Ds.Tables[0].Rows[0][0]);
                                }
                            }
                            else
                            {
                                _Str_Comprob = Convert.ToString(_Dg_Row.Cells["cidcomprob"].Value);
                            }
                            _Str_Cadena = "Update TNOTADEBICC set cnumcontrolnd='" + _Dg_Row.Cells["Numero"].Value.ToString().Trim() + "' where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and ccompany='" + Frm_Padre._Str_Comp + "' and cidnotadebitocc='" + _Dg_Row.Cells["Documento"].Value.ToString().Trim() + "'";
                            Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                            _Str_Cadena = "Update TCOMPROBANC set clvalidado='1',cvalidate='" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate()) + "' where ccompany='" + Frm_Padre._Str_Comp + "' and cidcomprob='" + _Str_Comprob + "'";
                        }
                        Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                    }
                }
            }
            System.Threading.ThreadPool.QueueUserWorkItem(((Frm_Padre)Application.OpenForms["Frm_Padre"])._Frm_Contenedor._async_Default);
        }
        private void _Mtd_ColocarNumeros(int _P_Str_Numero)
        {
            foreach (DataGridViewRow _Dg_Row in _Dg_Grid.Rows)
            {
                if (_Dg_Row.Cells["Imprimir"].Value != null)
                {
                    if (_Dg_Row.Cells["Imprimir"].Value.ToString().Trim() == "1")
                    {
                        _Dg_Row.Cells["Numero"].Value = _P_Str_Numero; 
                        _P_Str_Numero++;
                    }
                }
            }
        }
        private bool _Mtd_VerificarComprobanteIgualTodos()
        {
            string _Str_Comprobante = "";
            foreach (DataGridViewRow _Dg_Row in _Dg_Grid.Rows)
            {
                if (Convert.ToString(_Dg_Row.Cells["Imprimir"].Value).Trim() == "1")
                {
                    if (_Dg_Row.Cells["Documento"].Value != null)
                    { _Str_Comprobante = _Dg_Row.Cells["cidcomprob"].Value.ToString().Trim(); }
                    else
                    { _Str_Comprobante = "0"; }
                    break;
                }
            }
            foreach (DataGridViewRow _Dg_Row in _Dg_Grid.Rows)
            {
                if (Convert.ToString(_Dg_Row.Cells["Imprimir"].Value).Trim() != "1")
                {
                    if (_Str_Comprobante == _Dg_Row.Cells["cidcomprob"].Value.ToString().Trim().Trim())
                    { return false; }
                }
            }
            return true;
        }
        //Verifica si tiene
        private bool _Mtd_VerificarComprobanteIgual()
        {
            string _Str_Comprobante = "";
            int _Int_Sw = 0;
            foreach (DataGridViewRow _Dg_Row in _Dg_Grid.Rows)
            {
                if (Convert.ToString(_Dg_Row.Cells["Imprimir"].Value).Trim() == "1")
                {
                    if (_Int_Sw == 0)
                    {
                        if (_Dg_Row.Cells["Documento"].Value != null)
                        { _Str_Comprobante = _Dg_Row.Cells["cidcomprob"].Value.ToString().Trim(); }
                        else
                        { _Str_Comprobante = "0"; }
                        _Int_Sw = 1;
                    }
                    if (_Str_Comprobante != _Dg_Row.Cells["cidcomprob"].Value.ToString().Trim().Trim())
                    { return false; }
                }
            }
            return true;
        }
        private bool _Mtd_VerificarSinComprobante()
        {
            string _Str_Comprobante = "0";
            foreach (DataGridViewRow _Dg_Row in _Dg_Grid.Rows)
            {
                if (Convert.ToString(_Dg_Row.Cells["Imprimir"].Value).Trim() == "1")
                {
                    if (_Str_Comprobante != _Dg_Row.Cells["cidcomprob"].Value.ToString().Trim().Trim())
                    { return false; }
                }
            }
            return true;
        }
        private bool _Mtd_VerificarEgresosEliminados()
        {
            string _Str_Cadena = "";
            string[] _Str_IDEgreCheq = new string[0];
            string[] _Str_NumCheq = new string[0];
            string[] _Str_NumDepo = new string[0];
            string[] _Str_Cliente = new string[0];
            int _Int_Index = 0;
            foreach (DataGridViewRow _Dg_Row in _Dg_Grid.Rows)
            {
                if (Convert.ToString(_Dg_Row.Cells["Imprimir"].Value).Trim() == "1")
                {
                    _Str_IDEgreCheq = (string[])CLASES._Cls_Varios_Metodos._Mtd_ArrayRedim(_Str_IDEgreCheq, _Str_IDEgreCheq.Length + 1);
                    _Str_IDEgreCheq[_Str_IDEgreCheq.Length - 1] = Convert.ToString(_Dg_Row.Cells["Documento"].Value.ToString());
                    //----------------
                    _Str_NumCheq = (string[])CLASES._Cls_Varios_Metodos._Mtd_ArrayRedim(_Str_NumCheq, _Str_NumCheq.Length + 1);
                    _Str_NumCheq[_Str_NumCheq.Length - 1] = Convert.ToString(_Dg_Row.Cells["Tipo"].Value.ToString());
                    //----------------
                    _Str_NumDepo = (string[])CLASES._Cls_Varios_Metodos._Mtd_ArrayRedim(_Str_NumDepo, _Str_NumDepo.Length + 1);
                    _Str_NumDepo[_Str_NumDepo.Length - 1] = Convert.ToString(_Dg_Row.Cells["cnumdepo"].Value.ToString());
                    //----------------
                    _Str_Cliente = (string[])CLASES._Cls_Varios_Metodos._Mtd_ArrayRedim(_Str_Cliente, _Str_Cliente.Length + 1);
                    _Str_Cliente[_Str_Cliente.Length - 1] = Convert.ToString(_Dg_Row.Cells["ccliente"].Value.ToString());
                    _Str_Cadena = "SELECT cidegrecheqtran FROM TEGRECHEQTRAN WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cidegrecheqtran='" + _Str_IDEgreCheq[_Int_Index] + "' AND cnumcheque='" + _Str_NumCheq[_Int_Index] + "' AND cnumdepo='" + _Str_NumDepo[_Int_Index] + "' AND ccliente='" + _Str_Cliente[_Int_Index] + "'";
                    if (Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena).Tables[0].Rows.Count == 0)
                    {
                        return true;
                    }
                    _Int_Index++;
                }
            }
            return false;
        }
        private bool _Mtd_GenerarComprobanteEgreCheq()
        {
            PrintDialog _Print = new PrintDialog();
            string[] _Str_IDEgreCheq = new string[0];
            string[] _Str_NumCheq = new string[0];
            string[] _Str_NumDepo = new string[0];
            string[] _Str_Cliente = new string[0];
            string _Str_Comprobante = "";
            foreach (DataGridViewRow _Dg_Row in _Dg_Grid.Rows)
            {
                if (Convert.ToString(_Dg_Row.Cells["Imprimir"].Value).Trim() == "1")
                {
                    _Str_IDEgreCheq = (string[])CLASES._Cls_Varios_Metodos._Mtd_ArrayRedim(_Str_IDEgreCheq, _Str_IDEgreCheq.Length + 1);
                    _Str_IDEgreCheq[_Str_IDEgreCheq.Length - 1] = Convert.ToString(_Dg_Row.Cells["Documento"].Value.ToString());
                    //----------------
                    _Str_NumCheq = (string[])CLASES._Cls_Varios_Metodos._Mtd_ArrayRedim(_Str_NumCheq, _Str_NumCheq.Length + 1);
                    _Str_NumCheq[_Str_NumCheq.Length - 1] = Convert.ToString(_Dg_Row.Cells["Tipo"].Value.ToString());
                    //----------------
                    _Str_NumDepo = (string[])CLASES._Cls_Varios_Metodos._Mtd_ArrayRedim(_Str_NumDepo, _Str_NumDepo.Length + 1);
                    _Str_NumDepo[_Str_NumDepo.Length - 1] = Convert.ToString(_Dg_Row.Cells["cnumdepo"].Value.ToString());
                    //----------------
                    _Str_Cliente = (string[])CLASES._Cls_Varios_Metodos._Mtd_ArrayRedim(_Str_Cliente, _Str_Cliente.Length + 1);
                    _Str_Cliente[_Str_Cliente.Length - 1] = Convert.ToString(_Dg_Row.Cells["ccliente"].Value.ToString());
                }
            }
            string _Str_Cadena = "SELECT cidcomprob FROM TEGRECHEQTRAN WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cidegrecheqtran='" + _Str_IDEgreCheq[0] + "' AND cnumcheque='" + _Str_NumCheq[0] + "' AND cnumdepo='" + _Str_NumDepo[0] + "' AND ccliente='" + _Str_Cliente[0] + "' AND (cidcomprob<>0 AND NOT cidcomprob IS NULL)";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count > 0)
            { _Str_Comprobante = _Ds.Tables[0].Rows[0][0].ToString().Trim(); }
            else
            {
                Cursor = Cursors.WaitCursor;
                Clases._Cls_ProcesosCont _My_Cls_ProcesosCont = new T3.Clases._Cls_ProcesosCont("P_CxC_EGRCHQT");
                _Str_Comprobante = _My_Cls_ProcesosCont._Mtd_Proceso_P_CxC_EGRCHQT(_Str_IDEgreCheq, _Str_NumCheq, _Str_NumDepo, _Str_Cliente);
                _Mtd_ActualizarComprobantes(6, _Str_Comprobante);
                Cursor = Cursors.Default;
            }
        _PrintComprob:
            if (_Print.ShowDialog() == DialogResult.OK)
            {
                //-----------------------------------------------------------------
                Cursor = Cursors.WaitCursor;
                REPORTESS _Frm_A = new REPORTESS(new string[] { "vst_reportecomprobante" }, "", "T3.Report.rcomprobante", "Section1", "cabecera", "rif", "nit", "ccompany='" + Frm_Padre._Str_Comp + "' and cidcomprob='" + _Str_Comprobante + "'", _Print, true);
                Cursor = Cursors.Default;
                _Frm_A.Show();
                if (MessageBox.Show("¿El comprobante se imprimió correctamente?", "Requerimiento", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    _Frm_A.Close();
                    _Frm_A.Dispose();
                    _Str_Cadena = "UPDATE TCOMPROBANC SET clvalidado='1',cvalidate='" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate()) + "' WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cidcomprob='" + _Str_Comprobante + "'";
                    Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                    if ((Frm_Padre)this.MdiParent != null)
                    {
                        System.Threading.ThreadPool.QueueUserWorkItem(((Frm_Padre)this.MdiParent)._Frm_Contenedor._async_Default);
                    }
                    return true;
                }
                else
                { _Frm_A.Close(); _Frm_A.Dispose(); goto _PrintComprob; }
            }
            return false; 
        }
        private bool _Mtd_GenerarComprobanteCheqDev()
        {
            PrintDialog _Print = new PrintDialog();
            string[] _Str_IDCheqDev = new string[0];
            string[] _Str_NumCheq = new string[0];
            string[] _Str_Cliente = new string[0];
            string _Str_Comprobante = "";
            foreach (DataGridViewRow _Dg_Row in _Dg_Grid.Rows)
            {
                if (Convert.ToString(_Dg_Row.Cells["Imprimir"].Value).Trim() == "1")
                {
                    _Str_IDCheqDev = (string[])CLASES._Cls_Varios_Metodos._Mtd_ArrayRedim(_Str_IDCheqDev, _Str_IDCheqDev.Length + 1);
                    _Str_IDCheqDev[_Str_IDCheqDev.Length - 1] = Convert.ToString(_Dg_Row.Cells["Documento"].Value.ToString());
                    //----------------
                    _Str_NumCheq = (string[])CLASES._Cls_Varios_Metodos._Mtd_ArrayRedim(_Str_NumCheq, _Str_NumCheq.Length + 1);
                    _Str_NumCheq[_Str_NumCheq.Length - 1] = Convert.ToString(_Dg_Row.Cells["cnumcheque"].Value.ToString());
                    //----------------
                    _Str_Cliente = (string[])CLASES._Cls_Varios_Metodos._Mtd_ArrayRedim(_Str_Cliente, _Str_Cliente.Length + 1);
                    _Str_Cliente[_Str_Cliente.Length - 1] = Convert.ToString(_Dg_Row.Cells["ccliente"].Value.ToString());
                }
            }
            string _Str_Cadena = "SELECT cidcomprob FROM TCHEQDEVUELT WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cidcheqdevuelt='" + _Str_IDCheqDev[0] + "' AND (cidcomprob<>0 AND NOT cidcomprob IS NULL)";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count > 0)
            { _Str_Comprobante = _Ds.Tables[0].Rows[0][0].ToString().Trim(); }
            else
            {
                Cursor = Cursors.WaitCursor;
                _Str_Comprobante = _MyUtilidad._Mtd_Proceso_P_CXC_CHEQDEV(_Str_IDCheqDev, _Str_NumCheq, _Str_Cliente);
                _Mtd_ActualizarComprobantes(3, _Str_Comprobante);
                Cursor = Cursors.Default;
            }
            _PrintComprob:
            if (_Print.ShowDialog() == DialogResult.OK)
            {
                //-----------------------------------------------------------------
                Cursor = Cursors.WaitCursor;
                REPORTESS _Frm_A = new REPORTESS(new string[] { "vst_reportecomprobante" }, "", "T3.Report.rcomprobante", "Section1", "cabecera", "rif", "nit", "ccompany='" + Frm_Padre._Str_Comp + "' and cidcomprob='" + _Str_Comprobante + "'", _Print, true);
                Cursor = Cursors.Default;
                _Frm_A.Show();
                if (MessageBox.Show("¿El comprobante se imprimió correctamente?", "Requerimiento", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    _Frm_A.Close();
                    _Frm_A.Dispose();
                    _Str_Cadena = "UPDATE TCOMPROBANC SET clvalidado='1',cvalidate='" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate()) + "' WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cidcomprob='" + _Str_Comprobante + "'";
                    Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                    if ((Frm_Padre)this.MdiParent != null)
                    {
                        System.Threading.ThreadPool.QueueUserWorkItem(((Frm_Padre)this.MdiParent)._Frm_Contenedor._async_Default);
                    }
                    return true;
                }
                else
                { _Frm_A.Close(); _Frm_A.Dispose(); goto _PrintComprob; }
            }
            return false;
        }
        private string _Mtd_Retornar_ID_Devol(string _P_Str_NC)
        {
            string _Str_Cadena = "SELECT ISNULL(ciddevventa,0) FROM TNOTACREDICC WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cidnotcredicc='" + _P_Str_NC + "' AND ISNULL(ciddevventa,0)>0";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                string _Str_ID_Devol = _Ds.Tables[0].Rows[0][0].ToString().Trim();
                //-------------
                _Str_Cadena = "SELECT ciddevventa FROM TNOTACREDICC WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND ciddevventa='" + _Str_ID_Devol + "'";
                _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                int _Int_Cantidad = _Ds.Tables[0].Rows.Count;
                //-------------
                _Str_Cadena = "SELECT ciddevventa FROM TNOTACREDICC WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND ciddevventa='" + _Str_ID_Devol + "' AND cimpresa='1'";
                _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                if (_Int_Cantidad == _Ds.Tables[0].Rows.Count)
                { return _Str_ID_Devol; }
            }
            return "0";
        }
        private void _Mtd_ImprimirNCcxc()
        {
            string _Str_PrefijoCorrel = CLASES._Cls_Varios_Metodos._Mtd_ObtenerPrefijoCorrel(Frm_Padre._Str_Comp);
            PrintDialog _Print = new PrintDialog();
            _Print.PrinterSettings.DefaultPageSettings.PaperSize = new System.Drawing.Printing.PaperSize("Carta_Mitad", 850, 550);
            PrintDialog _Print_A = new PrintDialog();
            PrintDialog _Print_B = new PrintDialog();
            DataSet _Ds = new DataSet();
            DataTable _Dta_Tabla = new DataTable("Temporal");
            DataTable _Dta_TablaList = new DataTable("Temporal");
            DataColumn _Dta_Columna = new DataColumn();
            string _Str_Cadena = "";
            string[] _Str_NC = new string[0];
            string[] _Str_NC_EMIT = new string[0];
            double _Dbl_MontoSimp = 0, _Dbl_MontoImp = 0, _Dbl_MontoDesc = 0, _Dbl_MontoTotal = 0;
            int _Int_DocMin = 0, _Int_DocMax = 0, _Int_Id_Comprobante = 0;
            string _Str_TipoNC = _MyUtilidad._Mtd_TipoDocument_CXC("ctipdocnotcred");//Aux
            if (_Print.ShowDialog() == DialogResult.OK)
            {
                //-----------------------------------------------------------------
                foreach (DataGridViewRow _Dg_Row in _Dg_Grid.Rows)
                {
                    if (Convert.ToString(_Dg_Row.Cells["Imprimir"].Value).Trim() == "1")
                    {
                        //---------------------------------------------------------
                        if (_LstBox_DocPrint.Items.Count > 0)
                        {
                            if (_LstBox_DocPrint.FindStringExact(Convert.ToString(_Dg_Row.Cells["Documento"].Value.ToString())) != -1)
                            {
                                _Str_NC = (string[])CLASES._Cls_Varios_Metodos._Mtd_ArrayRedim(_Str_NC, _Str_NC.Length + 1);
                                _Str_NC[_Str_NC.Length - 1] = Convert.ToString(_Dg_Row.Cells["Documento"].Value.ToString());
                            }
                        }
                        else
                        {
                            _Str_NC = (string[])CLASES._Cls_Varios_Metodos._Mtd_ArrayRedim(_Str_NC, _Str_NC.Length + 1);
                            _Str_NC[_Str_NC.Length - 1] = Convert.ToString(_Dg_Row.Cells["Documento"].Value.ToString());
                        }
                        //------------------------LISTA------------------------------------
                        if (_G_Str_ccaja.Trim().Length > 0)
                        {
                            _Str_NC_EMIT = (string[])CLASES._Cls_Varios_Metodos._Mtd_ArrayRedim(_Str_NC_EMIT, _Str_NC_EMIT.Length + 1);
                            _Str_NC_EMIT[_Str_NC_EMIT.Length - 1] = Convert.ToString(_Dg_Row.Cells["Documento"].Value.ToString());
                        }
                        //-----------------------------------------------------------------
                        if (_Int_DocMax < Convert.ToInt32(_Dg_Row.Cells["Documento"].Value))
                        {
                            _Int_DocMax = Convert.ToInt32(_Dg_Row.Cells["Documento"].Value);
                            if (_Int_DocMin == 0)
                            {
                                _Int_DocMin = _Int_DocMax;
                            }
                        }
                        if (_Int_DocMin > Convert.ToInt32(_Dg_Row.Cells["Documento"].Value))
                        {
                            _Int_DocMin = Convert.ToInt32(_Dg_Row.Cells["Documento"].Value);
                        }
                        _Str_Cadena = "SELECT SUM(cmontosimp + ISNULL(cbasexcenta,0)) AS cmontototsi,SUM(cimpuesto) AS cimpuesto,SUM(cmontototal) AS ctotaldocu,SUM(ISNULL(cmontosimpdpp,0)) AS cmontosimpdpp,SUM(ISNULL(cimpuestodpp,0)) AS cimpuestodpp,SUM(ISNULL(cbasexcentadpp,0)) AS cbasexcentadpp,SUM(ISNULL(cmontototaldpp,0)) AS cmontototaldpp FROM TNOTACREDICCD WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cidnotcredicc='" + _Dg_Row.Cells["Documento"].Value.ToString().Trim() + "' GROUP BY cidnotcredicc";
                        _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                        if (_Ds.Tables[0].Rows.Count > 0)
                        {
                            if (Convert.ToString(_Ds.Tables[0].Rows[0]["cmontototsi"]).Length > 0)
                            {
                                _Dbl_MontoSimp = _Dbl_MontoSimp + (Convert.ToDouble(_Ds.Tables[0].Rows[0]["cmontototsi"]) + Convert.ToDouble(_Ds.Tables[0].Rows[0]["cmontosimpdpp"]) + Convert.ToDouble(_Ds.Tables[0].Rows[0]["cbasexcentadpp"]));
                            }
                            if (Convert.ToString(_Ds.Tables[0].Rows[0]["cimpuesto"]).Length > 0)
                            {
                                _Dbl_MontoImp = _Dbl_MontoImp + Convert.ToDouble(_Ds.Tables[0].Rows[0]["cimpuesto"]);
                            }
                            if (Convert.ToString(_Ds.Tables[0].Rows[0]["ctotaldocu"]).Length > 0)
                            {
                                _Dbl_MontoTotal = _Dbl_MontoTotal + Convert.ToDouble(_Ds.Tables[0].Rows[0]["ctotaldocu"]);
                            }
                            if (Convert.ToString(_Ds.Tables[0].Rows[0]["cmontototaldpp"]).Length > 0)
                            {
                                _Dbl_MontoDesc = _Dbl_MontoDesc + (Convert.ToDouble(_Ds.Tables[0].Rows[0]["cmontosimpdpp"]) + Convert.ToDouble(_Ds.Tables[0].Rows[0]["cbasexcentadpp"]));
                            }
                        }
                        else
                        {
                            _Str_Cadena = "SELECT cmontototsi + ISNULL(cexento,0) as cmontototsi,cimpuesto,ctotaldocu FROM TNOTACREDICC WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cidnotcredicc='" + _Dg_Row.Cells["Documento"].Value.ToString().Trim() + "'";
                            _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                            if (_Ds.Tables[0].Rows.Count > 0)
                            {
                                if (Convert.ToString(_Ds.Tables[0].Rows[0]["cmontototsi"]).Length > 0)
                                {
                                    _Dbl_MontoSimp = _Dbl_MontoSimp + Convert.ToDouble(_Ds.Tables[0].Rows[0]["cmontototsi"]);
                                }
                                if (Convert.ToString(_Ds.Tables[0].Rows[0]["cimpuesto"]).Length > 0)
                                {
                                    _Dbl_MontoImp = _Dbl_MontoImp + Convert.ToDouble(_Ds.Tables[0].Rows[0]["cimpuesto"]);
                                }
                                if (Convert.ToString(_Ds.Tables[0].Rows[0]["ctotaldocu"]).Length > 0)
                                {
                                    _Dbl_MontoTotal = _Dbl_MontoTotal + Convert.ToDouble(_Ds.Tables[0].Rows[0]["ctotaldocu"]);
                                }
                            }
                        }
                        //---------------------------------------------------------
                    }
                }
                _LstBox_DocPrint.Items.Clear();
                _Pnl_ReImpresion.Visible = false;
                //------------------------LISTA------------------------------------
                if (_G_Str_ccaja.Trim().Length > 0)
                {
                    _Dta_Columna = new DataColumn("cgroupcomp");
                    _Dta_Columna.DataType = typeof(string);
                    _Dta_TablaList.Columns.Add(_Dta_Columna);
                    _Dta_Columna = new DataColumn("ccompany");
                    _Dta_Columna.DataType = typeof(string);
                    _Dta_TablaList.Columns.Add(_Dta_Columna);
                    _Dta_Columna = new DataColumn("cidnotcredicc");
                    _Dta_Columna.DataType = typeof(double);
                    _Dta_TablaList.Columns.Add(_Dta_Columna);
                    _Dta_Columna = new DataColumn("ccliente");
                    _Dta_Columna.DataType = typeof(double);
                    _Dta_TablaList.Columns.Add(_Dta_Columna);
                    _Dta_Columna = new DataColumn("c_nomb_comer");
                    _Dta_Columna.DataType = typeof(string);
                    _Dta_TablaList.Columns.Add(_Dta_Columna);
                    _Dta_Columna = new DataColumn("cvendedor");
                    _Dta_Columna.DataType = typeof(string);
                    _Dta_TablaList.Columns.Add(_Dta_Columna);
                    _Dta_Columna = new DataColumn("cimpresa");
                    _Dta_Columna.DataType = typeof(int);
                    _Dta_TablaList.Columns.Add(_Dta_Columna);
                    _Dta_Columna = new DataColumn("cmontototsi");
                    _Dta_Columna.DataType = typeof(double);
                    _Dta_TablaList.Columns.Add(_Dta_Columna);
                    _Dta_Columna = new DataColumn("cimpuesto");
                    _Dta_Columna.DataType = typeof(double);
                    _Dta_TablaList.Columns.Add(_Dta_Columna);
                    _Dta_Columna = new DataColumn("cfecha");
                    _Dta_Columna.DataType = typeof(DateTime);
                    _Dta_TablaList.Columns.Add(_Dta_Columna);
                    _Dta_Columna = new DataColumn("Codcidmotivo");
                    _Dta_Columna.DataType = typeof(int);
                    _Dta_TablaList.Columns.Add(_Dta_Columna);
                    _Dta_Columna = new DataColumn("cmontototaldpp");
                    _Dta_Columna.DataType = typeof(double);
                    _Dta_TablaList.Columns.Add(_Dta_Columna);
                    _Dta_Columna = new DataColumn("cnumdocu");
                    _Dta_Columna.DataType = typeof(double);
                    _Dta_TablaList.Columns.Add(_Dta_Columna);
                }
                //------------------------------------------------------------
                Cursor = Cursors.WaitCursor;
                _Dta_Columna = new DataColumn("ccliente");
                _Dta_Columna.DataType = typeof(double);
                _Dta_Tabla.Columns.Add(_Dta_Columna);
                _Dta_Columna = new DataColumn("c_nomb_comer");
                _Dta_Columna.DataType = typeof(string);
                _Dta_Tabla.Columns.Add(_Dta_Columna);
                _Dta_Columna = new DataColumn("c_telefono");
                _Dta_Columna.DataType = typeof(string);
                _Dta_Tabla.Columns.Add(_Dta_Columna);
                _Dta_Columna = new DataColumn("cvendedor");
                _Dta_Columna.DataType = typeof(string);
                _Dta_Tabla.Columns.Add(_Dta_Columna);
                _Dta_Columna = new DataColumn("cname");
                _Dta_Columna.DataType = typeof(string);
                _Dta_Tabla.Columns.Add(_Dta_Columna);
                _Dta_Columna = new DataColumn("c_rif");
                _Dta_Columna.DataType = typeof(string);
                _Dta_Tabla.Columns.Add(_Dta_Columna);
                _Dta_Columna = new DataColumn("cidnotcredicc");
                _Dta_Columna.DataType = typeof(string);
                _Dta_Tabla.Columns.Add(_Dta_Columna);
                _Dta_Columna = new DataColumn("cdescripcion");
                _Dta_Columna.DataType = typeof(string);
                _Dta_Tabla.Columns.Add(_Dta_Columna);
                _Dta_Columna = new DataColumn("cfecha");
                _Dta_Columna.DataType = typeof(string);
                _Dta_Tabla.Columns.Add(_Dta_Columna);
                _Dta_Columna = new DataColumn("cmontototsi");
                _Dta_Columna.DataType = typeof(double);
                _Dta_Tabla.Columns.Add(_Dta_Columna);
                _Dta_Columna = new DataColumn("cimpuesto");
                _Dta_Columna.DataType = typeof(double);
                _Dta_Tabla.Columns.Add(_Dta_Columna);
                _Dta_Columna = new DataColumn("ctotaldocu");
                _Dta_Columna.DataType = typeof(double);
                _Dta_Tabla.Columns.Add(_Dta_Columna);
                _Dta_Columna = new DataColumn("c_direcc_fiscal");
                _Dta_Columna.DataType = typeof(string);
                _Dta_Tabla.Columns.Add(_Dta_Columna);
                _Dta_Columna = new DataColumn("c_razsocial_1");
                _Dta_Columna.DataType = typeof(string);
                _Dta_Tabla.Columns.Add(_Dta_Columna);
                _Dta_Columna = new DataColumn("cexento");
                _Dta_Columna.DataType = typeof(double);
                _Dta_Tabla.Columns.Add(_Dta_Columna);
                //-----------------Producto
                _Dta_Columna = new DataColumn("ccajas");
                _Dta_Columna.DataType = typeof(int);
                _Dta_Tabla.Columns.Add(_Dta_Columna);
                _Dta_Columna = new DataColumn("cunidades");
                _Dta_Columna.DataType = typeof(int);
                _Dta_Tabla.Columns.Add(_Dta_Columna);
                _Dta_Columna = new DataColumn("cmontosimpdet");
                _Dta_Columna.DataType = typeof(double);
                _Dta_Tabla.Columns.Add(_Dta_Columna);
                _Dta_Columna = new DataColumn("cimpuestodet");
                _Dta_Columna.DataType = typeof(double);
                _Dta_Tabla.Columns.Add(_Dta_Columna);
                _Dta_Columna = new DataColumn("cmontototaldet");
                _Dta_Columna.DataType = typeof(double);
                _Dta_Tabla.Columns.Add(_Dta_Columna);
                _Dta_Columna = new DataColumn("cbasegrabadadet");
                _Dta_Columna.DataType = typeof(double);
                _Dta_Tabla.Columns.Add(_Dta_Columna);
                _Dta_Columna = new DataColumn("cbasexcentadet");
                _Dta_Columna.DataType = typeof(double);
                _Dta_Tabla.Columns.Add(_Dta_Columna);
                _Dta_Columna = new DataColumn("calicuotadet");
                _Dta_Columna.DataType = typeof(double);
                _Dta_Tabla.Columns.Add(_Dta_Columna);
                _Dta_Columna = new DataColumn("cproducto");
                _Dta_Columna.DataType = typeof(string);
                _Dta_Tabla.Columns.Add(_Dta_Columna);
                _Dta_Columna = new DataColumn("cnamefc");
                _Dta_Columna.DataType = typeof(string);
                _Dta_Tabla.Columns.Add(_Dta_Columna);
                //-----------Nuevos Registros
                _Dta_Columna = new DataColumn("cfactura");
                _Dta_Columna.DataType = typeof(string);
                _Dta_Tabla.Columns.Add(_Dta_Columna);
                _Dta_Columna = new DataColumn("c_fecha_factura");
                _Dta_Columna.DataType = typeof(string);
                _Dta_Tabla.Columns.Add(_Dta_Columna);
                _Dta_Columna = new DataColumn("ctotal_fact");
                _Dta_Columna.DataType = typeof(double);
                _Dta_Tabla.Columns.Add(_Dta_Columna);
                foreach (string _Str_String in _Str_NC)
                {
                    //------------------ACTUALIACIÓN DE FECHA
                    _Str_Cadena = "Update TNOTACREDICC set cfecha='" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate()) + "' where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and ccompany='" + Frm_Padre._Str_Comp + "' and cidnotcredicc='" + _Str_String + "'";
                    Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                    //------------------
                    object _Ob_ItemTemp = new object();
                    _Str_Cadena = "SELECT ccliente,c_nomb_comer,c_telefono,cvendedor,cname,c_rif,'" + _Str_PrefijoCorrel + "'+CONVERT(VARCHAR,cidnotcredicc) AS cidnotcredicc,cdescripcion,cfecha,cmontototsi,cimpuesto,ctotaldocu,c_direcc_fiscal,c_razsocial_1,ISNULL(cexento,0) AS cexento,ccajas,cunidades,cmontosimpdet,cimpuestodet,cmontototaldet,cbasegrabadadet,cbasexcentadet,calicuotadet,cproducto,cnamefc,cfactura,c_fecha_factura,ctotal_fact FROM [VST_NC_EMISION] where ccompany='" + Frm_Padre._Str_Comp + "' and cidnotcredicc ='" + _Str_String + "'";
                    _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                    foreach (DataRow _Dtw_Item in _Ds.Tables[0].Rows)
                    {
                        _Dta_Tabla.Rows.Add(new object[] { _Dtw_Item[0].ToString().TrimEnd(), _Dtw_Item[1].ToString().TrimEnd(), _Dtw_Item[2].ToString().TrimEnd(), _Dtw_Item[3].ToString().TrimEnd(), _Dtw_Item[4].ToString().TrimEnd(), _Dtw_Item[5].ToString().TrimEnd(), _Dtw_Item[6].ToString().TrimEnd(), _Dtw_Item[7].ToString().TrimEnd(), _Dtw_Item[8].ToString().TrimEnd(), _Dtw_Item[9].ToString().TrimEnd(), _Dtw_Item[10].ToString().TrimEnd(), _Dtw_Item[11].ToString().TrimEnd(), _Dtw_Item[12].ToString().TrimEnd(), _Dtw_Item[13].ToString().TrimEnd(), _Dtw_Item[14].ToString().TrimEnd(), _Dtw_Item[15].ToString().TrimEnd(), _Dtw_Item[16].ToString().TrimEnd(), _Dtw_Item[17].ToString().TrimEnd(), _Dtw_Item[18].ToString().TrimEnd(), _Dtw_Item[19].ToString().TrimEnd(), _Dtw_Item[20].ToString().TrimEnd(), _Dtw_Item[21].ToString().TrimEnd(), _Dtw_Item[22].ToString().TrimEnd(), _Dtw_Item[23].ToString().TrimEnd(), _Dtw_Item[24].ToString().TrimEnd(), _Dtw_Item[25].ToString().TrimEnd(), _Dtw_Item[26].ToString().TrimEnd(), _Dtw_Item[27].ToString().TrimEnd() });
                        _Ob_ItemTemp = _Dtw_Item;
                    }
                    DataRow _Dtw_ItemTemp = (DataRow)_Ob_ItemTemp;
                    for (int _Int_I = 6; _Int_I > _Ds.Tables[0].Rows.Count; _Int_I--)
                    {
                        _Dta_Tabla.Rows.Add(new object[] { _Dtw_ItemTemp[0].ToString().TrimEnd(), _Dtw_ItemTemp[1].ToString().TrimEnd(), _Dtw_ItemTemp[2].ToString().TrimEnd(), _Dtw_ItemTemp[3].ToString().TrimEnd(), _Dtw_ItemTemp[4].ToString().TrimEnd(), _Dtw_ItemTemp[5].ToString().TrimEnd(), _Dtw_ItemTemp[6].ToString().TrimEnd(), _Dtw_ItemTemp[7].ToString().TrimEnd(), _Dtw_ItemTemp[8].ToString().TrimEnd(), _Dtw_ItemTemp[9].ToString().TrimEnd(), _Dtw_ItemTemp[10].ToString().TrimEnd(), _Dtw_ItemTemp[11].ToString().TrimEnd(), _Dtw_ItemTemp[12].ToString().TrimEnd(), _Dtw_ItemTemp[13].ToString().TrimEnd(), _Dtw_ItemTemp[14].ToString().TrimEnd(), 0, 0, 0, 0, 0, 0, 0, 0, "", "", "", "", 0 });
                    }
                }
                //------------------------LISTA------------------------------------
                if (_G_Str_ccaja.Trim().Length > 0)
                {
                    foreach (string _Str_String in _Str_NC_EMIT)
                    {
                        _Str_Cadena = "SELECT cgroupcomp,ccompany,cidnotcredicc,ccliente,c_nomb_comer,cvendedor,cimpresa,cmontototsi,cimpuesto,cfecha,CASE WHEN Codcidmotivo IS NULL THEN '0' ELSE Codcidmotivo END as Codcidmotivo,cmontototaldpp, cnumdocu FROM [VST_NOTACREDITOEMIT] where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and ccompany='" + Frm_Padre._Str_Comp + "' and cidnotcredicc ='" + _Str_String + "'";
                        _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                        foreach (DataRow _Dtw_Item2 in _Ds.Tables[0].Rows)
                        {
                            _Dta_TablaList.Rows.Add(new object[] { _Dtw_Item2[0].ToString().TrimEnd(), _Dtw_Item2[1].ToString().TrimEnd(), _Dtw_Item2[2].ToString().TrimEnd(), _Dtw_Item2[3].ToString().TrimEnd(), _Dtw_Item2[4].ToString().TrimEnd(), _Dtw_Item2[5].ToString().TrimEnd(), _Dtw_Item2[6].ToString().TrimEnd(), _Dtw_Item2[7].ToString().TrimEnd(), _Dtw_Item2[8].ToString().TrimEnd(), _Dtw_Item2[9].ToString().TrimEnd(), _Dtw_Item2[10].ToString().TrimEnd(), _Dtw_Item2["cmontototaldpp"].ToString().TrimEnd(), _Dtw_Item2["cnumdocu"].ToString().TrimEnd() });
                        }
                    }
                }
                //------------------------------------------------------------
                if (_Dta_Tabla.Rows.Count > 0)
                {
                    REPORTESS _Frm_Reporte = new REPORTESS("T3.Report.rEmisionNC", _Dta_Tabla, _Print, true, "Section2", "", "", "");
                }
                Cursor = Cursors.Default;
                //-----------------------------------------------------------------
                if (MessageBox.Show("¿La impresión fue realizada correctamente?", "Requerimiento", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    //Se verifica si tiene comprobante contable
                    //-------------------------------------------------------------
                    _Str_Cadena = "Select cidcomprob from TNOTACREDICC where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and ccompany='" + Frm_Padre._Str_Comp + "' and cidnotcredicc='" + _Str_NC[0] + "'";
                    _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                    if (_Ds.Tables[0].Rows.Count > 0)
                    {
                        if (_Ds.Tables[0].Rows[0][0].ToString().Trim() == "0")
                        {
                            string _Str_Proceso = "";//Aux
                            if (_Int_Sw == 8)
                            {
                                Clases._Cls_ProcesosCont _My_Cls_ProcesosCont = new T3.Clases._Cls_ProcesosCont("P_CXC_NCDPP");
                                _Int_Id_Comprobante = Convert.ToInt32(_My_Cls_ProcesosCont._Mtd_Proceso_P_CXC_NCDPP(_Int_DocMin.ToString(), _Int_DocMax.ToString(), _Dbl_MontoSimp, _Dbl_MontoImp, _Dbl_MontoTotal));
                                _Str_Proceso = "P_CXC_NCDPP";//Aux
                            }
                            else
                            {
                                _Int_Id_Comprobante = Convert.ToInt32(_MyUtilidad._Mtd_Proceso_P_CXC_NC(_Int_DocMin.ToString(), _Int_DocMax.ToString(), _Dbl_MontoSimp, _Dbl_MontoImp, _Dbl_MontoTotal, _Dbl_MontoDesc));
                                _Str_Proceso = "P_CXC_NC";//Aux
                            }
                            _Mtd_ActualizarComprobantes(0, _Int_Id_Comprobante.ToString());//Se actualiza el numero de comprobante en las NC seleccionadas
                            _MyUtilidad._Mtd_InsertarAuxiliarNC(_Int_DocMin.ToString(), _Int_DocMax.ToString(), _Int_Id_Comprobante.ToString(), _Str_Proceso);//Aux
                            _Str_Cadena = "UPDATE TCOMPROBANDD SET cstatus='2' where ccompany='" + Frm_Padre._Str_Comp + "' and cidcomprob='" + _Int_Id_Comprobante.ToString() + "'";//Aux
                            Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);//Aux
                            _Str_Cadena = "UPDATE TCOMPROBANC SET cstatus='1' where ccompany='" + Frm_Padre._Str_Comp + "' and cidcomprob='" + _Int_Id_Comprobante.ToString() + "'";//Aux
                            Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);//Aux
                        }
                        else
                        {
                            _Int_Id_Comprobante = Convert.ToInt32(_Ds.Tables[0].Rows[0][0].ToString());
                        }
                    }
                //-------------------------------------------------------------
                PrintComprobNC:
                    MessageBox.Show("Se va a proceder a imprimir el comprobante contable.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (_Print_A.ShowDialog() == DialogResult.OK)
                    {
                        REPORTESS _Frm_A = new REPORTESS(new string[] { "vst_reportecomprobante" }, "", "T3.Report.rcomprobante", "Section1", "cabecera", "rif", "nit", "ccompany='" + Frm_Padre._Str_Comp + "' and cidcomprob='" + _Int_Id_Comprobante.ToString() + "'", _Print_A, true);
                        _Frm_A.Show();
                        if (MessageBox.Show("¿El comprobante se imprimió correctamente?", "Requerimiento", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            _Frm_A.Close();
                            _Frm_A.Dispose();
                            Cursor = Cursors.WaitCursor;
                            foreach (DataGridViewRow _Dg_Row in _Dg_Grid.Rows)
                            {
                                if (Convert.ToString(_Dg_Row.Cells["Imprimir"].Value).Trim() == "1")
                                {
                                    _Str_Cadena = "Update TNOTACREDICC set cfvfnotcredcc='" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate()) + "',cimpresa=1,cactivo=1 where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and ccompany='" + Frm_Padre._Str_Comp + "' and cidnotcredicc='" + _Dg_Row.Cells["Documento"].Value.ToString().Trim() + "'";
                                    Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                                    _Str_Cadena = "UPDATE TCOMPROBANDD SET cstatus='1',cfechavencimiento='" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate()) + "' WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cidcomprob='" + _Dg_Row.Cells["cidcomprob"].Value.ToString().Trim() + "' AND cnumdocu='" + _Dg_Row.Cells["Documento"].Value.ToString().Trim() + "' AND ctdocument='" + _Str_TipoNC + "'";//Aux
                                    Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);//Aux
                                    if (_Int_Sw == 1)
                                    {
                                        string _Str_ID_Devol = _Mtd_Retornar_ID_Devol(_Dg_Row.Cells["Documento"].Value.ToString().Trim());//Aqui se retorna el ID de la devolucion siempre y cuando esten impresas todas las NC que generó la devolución de lo contrario devuelve '0'.
                                        if (_Str_ID_Devol != "0")
                                        {
                                            _Str_Cadena = "UPDATE TDEVVENTAM SET cimprimenc=1 WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND ciddevventa='" + _Str_ID_Devol + "'";
                                            Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                                        }
                                    }
                                }
                            }
                            Cursor = Cursors.Default;
                            //------------------------LISTA------------------------------------
                            if (_G_Str_ccaja.Trim().Length > 0)
                            {
                                MessageBox.Show("Se va a imprimir el listado de Notas de Crédito Emitidas. Coloque el tipo de papel para este documento", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            _PrintList:
                                if (_Print_B.ShowDialog() == DialogResult.OK)
                                {
                                    try
                                    {
                                        Cursor = Cursors.WaitCursor;
                                        Report.rInfNotaCredEmit _My_Reporte = new T3.Report.rInfNotaCredEmit();
                                        _My_Reporte.SetDataSource(_Dta_TablaList);
                                        Section _sec = _My_Reporte.ReportDefinition.Sections["Section2"];
                                        TextObject tex1 = _sec.ReportObjects["cabecera"] as TextObject;
                                        tex1.Text = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset("SELECT rtrim(cname) FROM TCOMPANY WHERE ccompany='" + Frm_Padre._Str_Comp + "'").Tables[0].Rows[0][0].ToString();
                                        TextObject tex2 = _sec.ReportObjects["txt_desde_hasta"] as TextObject;
                                        tex2.Text = "Caja N#: " + _G_Str_ccaja;
                                        TextObject tex3 = _sec.ReportObjects["txt_titulo"] as TextObject;
                                        tex3.Text = "NOTAS DE CRÉDITO EMITIDAS";
                                        //---Configuración de impresión.
                                        var _PageSettings = new System.Drawing.Printing.PageSettings();
                                        _PageSettings.PaperSize = new System.Drawing.Printing.PaperSize("Letter", 850, 1100);
                                        _PageSettings.Landscape = false;
                                        var _PrtSettings = new System.Drawing.Printing.PrinterSettings { PrinterName = _Print_B.PrinterSettings.PrinterName, Copies = _Print_B.PrinterSettings.Copies, Collate = _Print_B.PrinterSettings.Collate };
                                        _My_Reporte.PrintToPrinter(_PrtSettings, _PageSettings, false);
                                        //---Configuración de impresión.
                                        Cursor = Cursors.Default;
                                    }
                                    catch { }
                                }
                                if (MessageBox.Show("¿La impresión fue realizada correctamente?", "Requerimiento", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                                { goto _PrintList; }
                            }
                            //------------------------LISTA------------------------------------
                            _Bt_Imprimir.Enabled = false;
                            _Pnl_Numero.Visible = true;
                            //_Dg_Grid.Columns["Imprimir"].ReadOnly = true;
                        }
                        else
                        {
                            _Frm_A.Close();
                            _Frm_A.Dispose();
                            goto PrintComprobNC;
                        }
                    }
                    else
                    { _Bt_Imprimir.Enabled = true; }
                }
                else
                {
                    _Pnl_ReImpresion.BringToFront();
                    _Pnl_ReImpresion.Visible = true;
                }
            }
            else
            { _Bt_Imprimir.Enabled = true; }
            GC.Collect();
        }
        private void _Mtd_ImprimirNDcxc()
        {
            string _Str_PrefijoCorrel = CLASES._Cls_Varios_Metodos._Mtd_ObtenerPrefijoCorrel(Frm_Padre._Str_Comp);
            PrintDialog _Print = new PrintDialog();
            _Print.PrinterSettings.DefaultPageSettings.PaperSize = new System.Drawing.Printing.PaperSize("Carta_Mitad", 850, 550);
            PrintDialog _Print_A = new PrintDialog();
            PrintDialog _Print_B = new PrintDialog();
            DataSet _Ds = new DataSet(); ;
            DataTable _Dta_Tabla = new DataTable("Temporal");
            DataTable _Dta_TablaList = new DataTable("Temporal");
            DataColumn _Dta_Columna = new DataColumn();
            string _Str_Cadena = "";
            string[] _Str_ND = new string[0];
            double _Dbl_MontoSimp = 0, _Dbl_MontoImp = 0, _Dbl_MontoTotal = 0;
            int _Int_DocMin = 0, _Int_DocMax = 0, _Int_Id_Comprobante = 0;
            string _Str_TipoND = _MyUtilidad._Mtd_TipoDocument_CXC("ctipdocnotdeb");
            if (_Print.ShowDialog() == DialogResult.OK)
            {
                //-----------------------------------------------------------------
                foreach (DataGridViewRow _Dg_Row in _Dg_Grid.Rows)
                {
                    if (Convert.ToString(_Dg_Row.Cells["Imprimir"].Value).Trim() == "1")
                    {
                        //---------------------------------------------------------
                        if (_LstBox_DocPrint.Items.Count > 0)
                        {
                            if (_LstBox_DocPrint.FindStringExact(Convert.ToString(_Dg_Row.Cells["Documento"].Value.ToString())) != -1)
                            {
                                _Str_ND = (string[])CLASES._Cls_Varios_Metodos._Mtd_ArrayRedim(_Str_ND, _Str_ND.Length + 1);
                                _Str_ND[_Str_ND.Length - 1] = Convert.ToString(_Dg_Row.Cells["Documento"].Value.ToString());
                            }
                        }
                        else
                        {
                            _Str_ND = (string[])CLASES._Cls_Varios_Metodos._Mtd_ArrayRedim(_Str_ND, _Str_ND.Length + 1);
                            _Str_ND[_Str_ND.Length - 1] = Convert.ToString(_Dg_Row.Cells["Documento"].Value.ToString());
                        }
                        //---------------------------------------------------------
                        if (_Int_DocMax < Convert.ToInt32(_Dg_Row.Cells["Documento"].Value))
                        {
                            _Int_DocMax = Convert.ToInt32(_Dg_Row.Cells["Documento"].Value);
                            if (_Int_DocMin == 0)
                            {
                                _Int_DocMin = _Int_DocMax;
                            }
                        }
                        if (_Int_DocMin > Convert.ToInt32(_Dg_Row.Cells["Documento"].Value))
                        {
                            _Int_DocMin = Convert.ToInt32(_Dg_Row.Cells["Documento"].Value);
                        }
                        _Str_Cadena = "SELECT cmontototsi + ISNULL(cexento,0) as cmontototsi,cimpuesto,ctotaldocu FROM TNOTADEBICC WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cidnotadebitocc='" + _Dg_Row.Cells["Documento"].Value.ToString().Trim() + "'";
                        _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                        if (_Ds.Tables[0].Rows.Count > 0)
                        {
                            if (Convert.ToString(_Ds.Tables[0].Rows[0]["cmontototsi"]).Length > 0)
                            {
                                _Dbl_MontoSimp = _Dbl_MontoSimp + Convert.ToDouble(_Ds.Tables[0].Rows[0]["cmontototsi"]);
                            }
                            if (Convert.ToString(_Ds.Tables[0].Rows[0]["cimpuesto"]).Length > 0)
                            {
                                _Dbl_MontoImp = _Dbl_MontoImp + Convert.ToDouble(_Ds.Tables[0].Rows[0]["cimpuesto"]);
                            }
                            if (Convert.ToString(_Ds.Tables[0].Rows[0]["ctotaldocu"]).Length > 0)
                            {
                                _Dbl_MontoTotal = _Dbl_MontoTotal + Convert.ToDouble(_Ds.Tables[0].Rows[0]["ctotaldocu"]);
                            }
                        }
                        //---------------------------------------------------------
                    }
                }
                _LstBox_DocPrint.Items.Clear();
                _Pnl_ReImpresion.Visible = false;

                //------------------------LISTA------------------------------------
                _Dta_Columna = new DataColumn("cgroupcomp");
                _Dta_Columna.DataType = typeof(string);
                _Dta_TablaList.Columns.Add(_Dta_Columna);
                _Dta_Columna = new DataColumn("ccompany");
                _Dta_Columna.DataType = typeof(string);
                _Dta_TablaList.Columns.Add(_Dta_Columna);
                _Dta_Columna = new DataColumn("cidnotadebitocc");
                _Dta_Columna.DataType = typeof(double);
                _Dta_TablaList.Columns.Add(_Dta_Columna);
                _Dta_Columna = new DataColumn("ccliente");
                _Dta_Columna.DataType = typeof(double);
                _Dta_TablaList.Columns.Add(_Dta_Columna);
                _Dta_Columna = new DataColumn("c_nomb_comer");
                _Dta_Columna.DataType = typeof(string);
                _Dta_TablaList.Columns.Add(_Dta_Columna);
                _Dta_Columna = new DataColumn("cvendedor");
                _Dta_Columna.DataType = typeof(string);
                _Dta_TablaList.Columns.Add(_Dta_Columna);
                _Dta_Columna = new DataColumn("cimpresa");
                _Dta_Columna.DataType = typeof(int);
                _Dta_TablaList.Columns.Add(_Dta_Columna);
                _Dta_Columna = new DataColumn("cmontototsi");
                _Dta_Columna.DataType = typeof(double);
                _Dta_TablaList.Columns.Add(_Dta_Columna);
                _Dta_Columna = new DataColumn("cimpuesto");
                _Dta_Columna.DataType = typeof(double);
                _Dta_TablaList.Columns.Add(_Dta_Columna);
                _Dta_Columna = new DataColumn("cfecha");
                _Dta_Columna.DataType = typeof(DateTime);
                _Dta_TablaList.Columns.Add(_Dta_Columna);
                _Dta_Columna = new DataColumn("cidmotivo");
                _Dta_Columna.DataType = typeof(int);
                _Dta_TablaList.Columns.Add(_Dta_Columna);
                _Dta_Columna = new DataColumn("ctipodocument");
                _Dta_Columna.DataType = typeof(string);
                _Dta_TablaList.Columns.Add(_Dta_Columna);
                _Dta_Columna = new DataColumn("cnumdocu");
                _Dta_Columna.DataType = typeof(string);
                _Dta_TablaList.Columns.Add(_Dta_Columna);

                //------------------------------------------------------------

                //-----------------------------------------------------------------
                Cursor = Cursors.WaitCursor;
                _Dta_Columna = new DataColumn("ccliente");
                _Dta_Columna.DataType = typeof(string);
                _Dta_Tabla.Columns.Add(_Dta_Columna);
                _Dta_Columna = new DataColumn("c_nomb_comer");
                _Dta_Columna.DataType = typeof(string);
                _Dta_Tabla.Columns.Add(_Dta_Columna);
                _Dta_Columna = new DataColumn("c_telefono");
                _Dta_Columna.DataType = typeof(string);
                _Dta_Tabla.Columns.Add(_Dta_Columna);
                _Dta_Columna = new DataColumn("cvendedor");
                _Dta_Columna.DataType = typeof(string);
                _Dta_Tabla.Columns.Add(_Dta_Columna);
                _Dta_Columna = new DataColumn("cname");
                _Dta_Columna.DataType = typeof(string);
                _Dta_Tabla.Columns.Add(_Dta_Columna);
                _Dta_Columna = new DataColumn("c_rif");
                _Dta_Columna.DataType = typeof(string);
                _Dta_Tabla.Columns.Add(_Dta_Columna);
                _Dta_Columna = new DataColumn("cidnotadebitocc");
                _Dta_Columna.DataType = typeof(string);
                _Dta_Tabla.Columns.Add(_Dta_Columna);
                _Dta_Columna = new DataColumn("cdescripcion");
                _Dta_Columna.DataType = typeof(string);
                _Dta_Tabla.Columns.Add(_Dta_Columna);
                _Dta_Columna = new DataColumn("cfecha");
                _Dta_Columna.DataType = typeof(string);
                _Dta_Tabla.Columns.Add(_Dta_Columna);
                _Dta_Columna = new DataColumn("cmontototsi");
                _Dta_Columna.DataType = typeof(double);
                _Dta_Tabla.Columns.Add(_Dta_Columna);
                _Dta_Columna = new DataColumn("cimpuesto");
                _Dta_Columna.DataType = typeof(double);
                _Dta_Tabla.Columns.Add(_Dta_Columna);
                _Dta_Columna = new DataColumn("ctotaldocu");
                _Dta_Columna.DataType = typeof(double);
                _Dta_Tabla.Columns.Add(_Dta_Columna);
                _Dta_Columna = new DataColumn("c_direcc_fiscal");
                _Dta_Columna.DataType = typeof(string);
                _Dta_Tabla.Columns.Add(_Dta_Columna);
                _Dta_Columna = new DataColumn("c_razsocial_1");
                _Dta_Columna.DataType = typeof(string);
                _Dta_Tabla.Columns.Add(_Dta_Columna);
                _Dta_Columna = new DataColumn("cexento");
                _Dta_Columna.DataType = typeof(double);
                _Dta_Tabla.Columns.Add(_Dta_Columna);
                //-----------------Producto
                _Dta_Columna = new DataColumn("ccajas");
                _Dta_Columna.DataType = typeof(int);
                _Dta_Tabla.Columns.Add(_Dta_Columna);
                _Dta_Columna = new DataColumn("cunidades");
                _Dta_Columna.DataType = typeof(int);
                _Dta_Tabla.Columns.Add(_Dta_Columna);
                _Dta_Columna = new DataColumn("cmontosimpdet");
                _Dta_Columna.DataType = typeof(double);
                _Dta_Tabla.Columns.Add(_Dta_Columna);
                _Dta_Columna = new DataColumn("cimpuestodet");
                _Dta_Columna.DataType = typeof(double);
                _Dta_Tabla.Columns.Add(_Dta_Columna);
                _Dta_Columna = new DataColumn("cmontototaldet");
                _Dta_Columna.DataType = typeof(double);
                _Dta_Tabla.Columns.Add(_Dta_Columna);
                _Dta_Columna = new DataColumn("cbasegrabadadet");
                _Dta_Columna.DataType = typeof(double);
                _Dta_Tabla.Columns.Add(_Dta_Columna);
                _Dta_Columna = new DataColumn("cbasexcentadet");
                _Dta_Columna.DataType = typeof(double);
                _Dta_Tabla.Columns.Add(_Dta_Columna);
                _Dta_Columna = new DataColumn("calicuotadet");
                _Dta_Columna.DataType = typeof(double);
                _Dta_Tabla.Columns.Add(_Dta_Columna);
                _Dta_Columna = new DataColumn("cproducto");
                _Dta_Columna.DataType = typeof(string);
                _Dta_Tabla.Columns.Add(_Dta_Columna);
                _Dta_Columna = new DataColumn("cnamefc");
                _Dta_Columna.DataType = typeof(string);
                _Dta_Tabla.Columns.Add(_Dta_Columna);
                //-----------Nuevos Registros
                _Dta_Columna = new DataColumn("cfactura");
                _Dta_Columna.DataType = typeof(string);
                _Dta_Tabla.Columns.Add(_Dta_Columna);
                _Dta_Columna = new DataColumn("c_fecha_factura");
                _Dta_Columna.DataType = typeof(string);
                _Dta_Tabla.Columns.Add(_Dta_Columna);
                _Dta_Columna = new DataColumn("ctotal_fact");
                _Dta_Columna.DataType = typeof(double);
                _Dta_Tabla.Columns.Add(_Dta_Columna);
                foreach (string _Str_String in _Str_ND)
                {
                    //------------------ACTUALIACIÓN DE FECHA
                    _Str_Cadena = "Update TNOTADEBICC set cfecha='" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate()) + "' where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and ccompany='" + Frm_Padre._Str_Comp + "' and cidnotadebitocc='" + _Str_String + "'";
                    Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                    //------------------
                    object _Ob_ItemTemp = new object();
                    _Str_Cadena = "SELECT ccliente,c_nomb_comer,c_telefono,cvendedor,cname,c_rif,'" + _Str_PrefijoCorrel + "'+CONVERT(VARCHAR,cidnotadebitocc) AS cidnotadebitocc,cdescripcion,cfecha,cmontototsi,cimpuesto,ctotaldocu,c_direcc_fiscal,c_razsocial_1,ISNULL(cexento,0) AS cexento,ccajas,cunidades,cmontosimpdet,cimpuestodet,cmontototaldet,cbasegrabadadet,cbasexcentadet,calicuotadet,cproducto,cnamefc,cfactura,c_fecha_factura,ctotal_fact FROM [VST_ND_EMISION] where ccompany='" + Frm_Padre._Str_Comp + "' and cidnotadebitocc ='" + _Str_String + "'";
                    _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                    foreach (DataRow _Dtw_Item in _Ds.Tables[0].Rows)
                    {
                        _Dta_Tabla.Rows.Add(new object[] { _Dtw_Item[0].ToString().TrimEnd(), _Dtw_Item[1].ToString().TrimEnd(), _Dtw_Item[2].ToString().TrimEnd(), _Dtw_Item[3].ToString().TrimEnd(), _Dtw_Item[4].ToString().TrimEnd(), _Dtw_Item[5].ToString().TrimEnd(), _Dtw_Item[6].ToString().TrimEnd(), _Dtw_Item[7].ToString().TrimEnd(), _Dtw_Item[8].ToString().TrimEnd(), _Dtw_Item[9].ToString().TrimEnd(), _Dtw_Item[10].ToString().TrimEnd(), _Dtw_Item[11].ToString().TrimEnd(), _Dtw_Item[12].ToString().TrimEnd(), _Dtw_Item[13].ToString().TrimEnd(), _Dtw_Item[14].ToString().TrimEnd(), _Dtw_Item[15].ToString().TrimEnd(), _Dtw_Item[16].ToString().TrimEnd(), _Dtw_Item[17].ToString().TrimEnd(), _Dtw_Item[18].ToString().TrimEnd(), _Dtw_Item[19].ToString().TrimEnd(), _Dtw_Item[20].ToString().TrimEnd(), _Dtw_Item[21].ToString().TrimEnd(), _Dtw_Item[22].ToString().TrimEnd(), _Dtw_Item[23].ToString().TrimEnd(), _Dtw_Item[24].ToString().TrimEnd(), _Dtw_Item[25].ToString().TrimEnd(), _Dtw_Item[26].ToString().TrimEnd(), _Dtw_Item[27].ToString().TrimEnd() });
                        _Ob_ItemTemp = _Dtw_Item;
                    }
                    DataRow _Dtw_ItemTemp = (DataRow)_Ob_ItemTemp;
                    for (int _Int_I = 6; _Int_I > _Ds.Tables[0].Rows.Count; _Int_I--)
                    {
                        _Dta_Tabla.Rows.Add(new object[] { _Dtw_ItemTemp[0].ToString().TrimEnd(), _Dtw_ItemTemp[1].ToString().TrimEnd(), _Dtw_ItemTemp[2].ToString().TrimEnd(), _Dtw_ItemTemp[3].ToString().TrimEnd(), _Dtw_ItemTemp[4].ToString().TrimEnd(), _Dtw_ItemTemp[5].ToString().TrimEnd(), _Dtw_ItemTemp[6].ToString().TrimEnd(), _Dtw_ItemTemp[7].ToString().TrimEnd(), _Dtw_ItemTemp[8].ToString().TrimEnd(), _Dtw_ItemTemp[9].ToString().TrimEnd(), _Dtw_ItemTemp[10].ToString().TrimEnd(), _Dtw_ItemTemp[11].ToString().TrimEnd(), _Dtw_ItemTemp[12].ToString().TrimEnd(), _Dtw_ItemTemp[13].ToString().TrimEnd(), _Dtw_ItemTemp[14].ToString().TrimEnd(), 0, 0, 0, 0, 0, 0, 0, 0, "", "", "", "", 0 });
                    }
                    // ------------------ ND EMITIDAS
                    _Str_Cadena = "SELECT cgroupcomp,ccompany,cidnotadebitocc,ccliente,c_nomb_comer,cvendedor,cimpresa,cmontototsi,cimpuesto,cfecha,CASE WHEN cidmotivo IS NULL THEN '0' ELSE cidmotivo END as cidmotivo,ctipodocument,cnumdocu FROM [VST_NOTADEBITOEMIT] where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and ccompany='" + Frm_Padre._Str_Comp + "' and cidnotadebitocc ='" + _Str_String + "'";
                    _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                    foreach (DataRow _Dtw_Item2 in _Ds.Tables[0].Rows)
                    {
                        _Dta_TablaList.Rows.Add(new object[] { _Dtw_Item2[0].ToString().TrimEnd(), _Dtw_Item2[1].ToString().TrimEnd(), _Dtw_Item2[2].ToString().TrimEnd(), _Dtw_Item2[3].ToString().TrimEnd(), _Dtw_Item2[4].ToString().TrimEnd(), _Dtw_Item2[5].ToString().TrimEnd(), _Dtw_Item2[6].ToString().TrimEnd(), _Dtw_Item2[7].ToString().TrimEnd(), _Dtw_Item2[8].ToString().TrimEnd(), _Dtw_Item2[9].ToString().TrimEnd(), _Dtw_Item2[10].ToString().TrimEnd(), _Dtw_Item2["ctipodocument"].ToString().TrimEnd(), _Dtw_Item2["cnumdocu"].ToString().TrimEnd() });
                    }
                    // -------------------------------
                }
                if (_Dta_Tabla.Rows.Count > 0)
                {
                    REPORTESS _Frm_Reporte = new REPORTESS("T3.Report.rEmisionND", _Dta_Tabla, _Print, true, "Section2", "", "", "");
                }
                Cursor = Cursors.Default;
                //-----------------------------------------------------------------
                if (MessageBox.Show("¿La impresión fue realizada correctamente?", "Requerimiento", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    //Se verifica si tiene comprobante contable
                    //-------------------------------------------------------------
                    _Str_Cadena = "Select cidcomprob from TNOTADEBICC where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and ccompany='" + Frm_Padre._Str_Comp + "' and cidnotadebitocc='" + _Str_ND[0] + "'";
                    _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                    if (_Ds.Tables[0].Rows.Count > 0)
                    {
                        if (_Ds.Tables[0].Rows[0][0].ToString().Trim() == "0")
                        {
                            _Int_Id_Comprobante = Convert.ToInt32(_MyUtilidad._Mtd_Proceso_P_CXC_ND(_Int_DocMin.ToString(), _Int_DocMax.ToString(), _Dbl_MontoSimp, _Dbl_MontoImp, _Dbl_MontoTotal));
                            _Mtd_ActualizarComprobantes(1, _Int_Id_Comprobante.ToString());//Se actualiza el numero de comprobante en las ND seleccionadas
                            _MyUtilidad._Mtd_InsertarAuxiliarND(_Int_DocMin.ToString(), _Int_DocMax.ToString(), _Int_Id_Comprobante.ToString(), "P_CXC_ND");//Aux
                            _Str_Cadena = "UPDATE TCOMPROBANDD SET cstatus='2' where ccompany='" + Frm_Padre._Str_Comp + "' and cidcomprob='" + _Int_Id_Comprobante.ToString() + "'";//Aux
                            Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);//Aux
                            _Str_Cadena = "UPDATE TCOMPROBANC SET cstatus='1' where ccompany='" + Frm_Padre._Str_Comp + "' and cidcomprob='" + _Int_Id_Comprobante.ToString() + "'";//Aux
                            Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);//Aux
                        }
                        else
                        {
                            _Int_Id_Comprobante = Convert.ToInt32(_Ds.Tables[0].Rows[0][0].ToString());
                        }
                    }
                //-------------------------------------------------------------
                PrintComprobND:
                    MessageBox.Show("Se va a proceder a imprimir el comprobante contable.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (_Print_A.ShowDialog() == DialogResult.OK)
                    {
                        REPORTESS _Frm_A = new REPORTESS(new string[] { "vst_reportecomprobante" }, "", "T3.Report.rcomprobante", "Section1", "cabecera", "rif", "nit", "ccompany='" + Frm_Padre._Str_Comp + "' and cidcomprob='" + _Int_Id_Comprobante.ToString() + "'", _Print_A, true);
                        _Frm_A.Show();
                        if (MessageBox.Show("¿El comprobante se imprimió correctamente?", "Requerimiento", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            _Frm_A.Close();
                            _Frm_A.Dispose();
                            foreach (DataGridViewRow _Dg_Row in _Dg_Grid.Rows)
                            {
                                if (Convert.ToString(_Dg_Row.Cells["Imprimir"].Value).Trim() == "1")
                                {
                                    _Str_Cadena = "Update TNOTADEBICC Set cfvfnotadebitop='" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate()) + "',cimpresa='1',cactivo='1' where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and ccompany='" + Frm_Padre._Str_Comp + "' and cidnotadebitocc='" + _Dg_Row.Cells["Documento"].Value.ToString().Trim() + "'";
                                    Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                                    _Str_Cadena = "UPDATE TCOMPROBANDD SET cstatus='1',cfechavencimiento='" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate()) + "' WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cidcomprob='" + _Dg_Row.Cells["cidcomprob"].Value.ToString().Trim() + "' AND cnumdocu='" + _Dg_Row.Cells["Documento"].Value.ToString().Trim() + "' AND ctdocument='" + _Str_TipoND + "'";//Aux
                                    Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);//Aux
                                }
                            }
                            MessageBox.Show("Se va a imprimir el listado de Notas de Débitos Emitidas. Coloque el tipo de papel para este documento", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        _PrintList:
                            if (_Print_B.ShowDialog() == DialogResult.OK)
                            {
                                try
                                {
                                    Cursor = Cursors.WaitCursor;
                                    Report.rInfNotaDebEmit _My_Reporte = new T3.Report.rInfNotaDebEmit();
                                    _My_Reporte.SetDataSource(_Dta_TablaList);
                                    Section _sec = _My_Reporte.ReportDefinition.Sections["Section2"];
                                    TextObject tex1 = _sec.ReportObjects["cabecera"] as TextObject;
                                    tex1.Text = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset("SELECT rtrim(cname) FROM TCOMPANY WHERE ccompany='" + Frm_Padre._Str_Comp + "'").Tables[0].Rows[0][0].ToString();
                                    TextObject tex2 = _sec.ReportObjects["txt_desde_hasta"] as TextObject;
                                    tex2.Text = "";
                                    TextObject tex3 = _sec.ReportObjects["txt_titulo"] as TextObject;
                                    tex3.Text = "NOTAS DE DÉBITOS EMITIDAS";
                                    //---Configuración de impresión.
                                    var _PageSettings = new System.Drawing.Printing.PageSettings();
                                    _PageSettings.PaperSize = new System.Drawing.Printing.PaperSize("Letter", 850, 1100);
                                    _PageSettings.Landscape = false;
                                    var _PrtSettings = new System.Drawing.Printing.PrinterSettings { PrinterName = _Print_B.PrinterSettings.PrinterName, Copies = _Print_B.PrinterSettings.Copies, Collate = _Print_B.PrinterSettings.Collate };
                                    _My_Reporte.PrintToPrinter(_PrtSettings, _PageSettings, false);
                                    //---Configuración de impresión.
                                    Cursor = Cursors.Default;
                                }
                                catch { }
                            }
                            if (MessageBox.Show("¿La impresión fue realizada correctamente?", "Requerimiento", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                            { goto _PrintList; }
                            _Bt_Imprimir.Enabled = false;
                            _Pnl_Numero.Visible = true;
                            //_Dg_Grid.Columns["Imprimir"].ReadOnly = true;
                        }
                        else
                        {
                            _Frm_A.Close();
                            _Frm_A.Dispose();
                            goto PrintComprobND;
                        }
                    }
                    else
                    { _Bt_Imprimir.Enabled = true; }
                }
                else
                {
                    _Pnl_ReImpresion.BringToFront();
                    _Pnl_ReImpresion.Visible = true;
                }
            }
            else
            { _Bt_Imprimir.Enabled = true; }
            GC.Collect();
        }
        private void _Mtd_ImprimirNR()
        {
            string _Str_PrefijoCorrel = CLASES._Cls_Varios_Metodos._Mtd_ObtenerPrefijoCorrel(Frm_Padre._Str_Comp);
            PrintDialog _Print = new PrintDialog();
            string[] _Str_NR = new string[0];
            DataSet _Ds;
            string _Str_Cadena = "";
            DataTable _Dt_Tabla = new DataTable("Temporal");
            DataColumn _Dt_Colum = new DataColumn();
            if (_Print.ShowDialog() == DialogResult.OK)
            {
                foreach (DataGridViewRow _Dg_Row in _Dg_Grid.Rows)
                {
                    if (Convert.ToString(_Dg_Row.Cells["Imprimir"].Value).Trim() == "1")
                    {
                        //---------------------------------------------------------
                        if (_LstBox_DocPrint.Items.Count > 0)
                        {
                            if (_LstBox_DocPrint.FindStringExact(Convert.ToString(_Dg_Row.Cells["Documento"].Value.ToString())) != -1)
                            {
                                _Str_NR = (string[])CLASES._Cls_Varios_Metodos._Mtd_ArrayRedim(_Str_NR, _Str_NR.Length + 1);
                                _Str_NR[_Str_NR.Length - 1] = Convert.ToString(_Dg_Row.Cells["Documento"].Value.ToString());
                            }
                        }
                        else
                        {
                            _Str_NR = (string[])CLASES._Cls_Varios_Metodos._Mtd_ArrayRedim(_Str_NR, _Str_NR.Length + 1);
                            _Str_NR[_Str_NR.Length - 1] = Convert.ToString(_Dg_Row.Cells["Documento"].Value.ToString());
                        }
                        //---------------------------------------------------------
                    }
                }
                _LstBox_DocPrint.Items.Clear();
                _Pnl_ReImpresion.Visible = false;
                //-------------------------------------------------------
                Cursor = Cursors.WaitCursor;
                _Dt_Colum = new DataColumn("cgroupcomp");
                _Dt_Colum.DataType = typeof(int);
                _Dt_Tabla.Columns.Add(_Dt_Colum);
                _Dt_Colum = new DataColumn("ccompany");
                _Dt_Colum.DataType = typeof(string);
                _Dt_Tabla.Columns.Add(_Dt_Colum);
                _Dt_Colum = new DataColumn("cidnotrecepc");
                _Dt_Colum.DataType = typeof(string);
                _Dt_Tabla.Columns.Add(_Dt_Colum);
                _Dt_Colum = new DataColumn("ctiponotrecep");
                _Dt_Colum.DataType = typeof(string);
                _Dt_Tabla.Columns.Add(_Dt_Colum);
                _Dt_Colum = new DataColumn("cfechanotrecep");
                _Dt_Colum.DataType = typeof(DateTime);
                _Dt_Tabla.Columns.Add(_Dt_Colum);
                _Dt_Colum = new DataColumn("ctipodocument");
                _Dt_Colum.DataType = typeof(string);
                _Dt_Tabla.Columns.Add(_Dt_Colum);
                _Dt_Colum = new DataColumn("cnumdocu");
                _Dt_Colum.DataType = typeof(string);
                _Dt_Tabla.Columns.Add(_Dt_Colum);
                _Dt_Colum = new DataColumn("cfechadocu");
                _Dt_Colum.DataType = typeof(DateTime);
                _Dt_Tabla.Columns.Add(_Dt_Colum);
                _Dt_Colum = new DataColumn("cmontosi");
                _Dt_Colum.DataType = typeof(double);
                _Dt_Tabla.Columns.Add(_Dt_Colum);
                _Dt_Colum = new DataColumn("cmontoimp");
                _Dt_Colum.DataType = typeof(double);
                _Dt_Tabla.Columns.Add(_Dt_Colum);
                _Dt_Colum = new DataColumn("cporcreconoce");
                _Dt_Colum.DataType = typeof(double);
                _Dt_Tabla.Columns.Add(_Dt_Colum);
                _Dt_Colum = new DataColumn("cimpreso");
                _Dt_Colum.DataType = typeof(int);
                _Dt_Tabla.Columns.Add(_Dt_Colum);
                _Dt_Colum = new DataColumn("cporcinvendible");
                _Dt_Colum.DataType = typeof(double);
                _Dt_Tabla.Columns.Add(_Dt_Colum);
                _Dt_Colum = new DataColumn("cproveedor");
                _Dt_Colum.DataType = typeof(string);
                _Dt_Tabla.Columns.Add(_Dt_Colum);
                _Dt_Colum = new DataColumn("cidcomprob");
                _Dt_Colum.DataType = typeof(int);
                _Dt_Tabla.Columns.Add(_Dt_Colum);
                _Dt_Colum = new DataColumn("ciddnotrecepc");
                _Dt_Colum.DataType = typeof(int);
                _Dt_Tabla.Columns.Add(_Dt_Colum);
                _Dt_Colum = new DataColumn("cproducto");
                _Dt_Colum.DataType = typeof(string);
                _Dt_Tabla.Columns.Add(_Dt_Colum);
                _Dt_Colum = new DataColumn("cempaques");
                _Dt_Colum.DataType = typeof(double);
                _Dt_Tabla.Columns.Add(_Dt_Colum);
                _Dt_Colum = new DataColumn("cunidades");
                _Dt_Colum.DataType = typeof(double);
                _Dt_Tabla.Columns.Add(_Dt_Colum);
                _Dt_Colum = new DataColumn("cmontosi_det");
                _Dt_Colum.DataType = typeof(double);
                _Dt_Tabla.Columns.Add(_Dt_Colum);
                _Dt_Colum = new DataColumn("cmontoimp_det");
                _Dt_Colum.DataType = typeof(double);
                _Dt_Tabla.Columns.Add(_Dt_Colum);
                _Dt_Colum = new DataColumn("ccliente");
                _Dt_Colum.DataType = typeof(int);
                _Dt_Tabla.Columns.Add(_Dt_Colum);
                _Dt_Colum = new DataColumn("c_nomb_comer");
                _Dt_Colum.DataType = typeof(string);
                _Dt_Tabla.Columns.Add(_Dt_Colum);
                _Dt_Colum = new DataColumn("cnamefc");
                _Dt_Colum.DataType = typeof(string);
                _Dt_Tabla.Columns.Add(_Dt_Colum);
                _Dt_Colum = new DataColumn("cidmotivo");
                _Dt_Colum.DataType = typeof(int);
                _Dt_Tabla.Columns.Add(_Dt_Colum);
                _Dt_Colum = new DataColumn("ctipodocument_name");
                _Dt_Colum.DataType = typeof(string);
                _Dt_Tabla.Columns.Add(_Dt_Colum);
                _Dt_Colum = new DataColumn("total_det");
                _Dt_Colum.DataType = typeof(double);
                _Dt_Tabla.Columns.Add(_Dt_Colum);
                _Dt_Colum = new DataColumn("cprecioventamax");
                _Dt_Colum.DataType = typeof(double);
                _Dt_Tabla.Columns.Add(_Dt_Colum);
                _Dt_Colum = new DataColumn("cnumlote");
                _Dt_Colum.DataType = typeof(int);
                _Dt_Tabla.Columns.Add(_Dt_Colum);
                foreach (string _Str_String in _Str_NR)
                {
                    _Str_Cadena = "SELECT cgroupcomp,ccompany,'" + _Str_PrefijoCorrel + "'+CONVERT(VARCHAR,cidnotrecepc) AS cidnotrecepc,ctiponotrecep,cfechanotrecep,ctipodocument,cnumdocu,cfechadocu,cmontosi,cmontoimp,cporcreconoce,cimpreso,cporcinvendible,cproveedor,cidcomprob,ciddnotrecepc,cproducto,cempaques,cunidades,cmontosi_det,cmontoimp_det,ccliente,c_nomb_comer,cnamefc,cidmotivo,ctipodocument_name,total_det, cidproductod, cprecioventamax, cnumlote FROM VST_RPT_NOTARECEP_DEVOL where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and ccompany='" + Frm_Padre._Str_Comp + "' and cidnotrecepc ='" + _Str_String + "'";
                    _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                    foreach (DataRow _Dtw_Item in _Ds.Tables[0].Rows)
                    {
                        _Dt_Tabla.Rows.Add((new object[] { _Dtw_Item["cgroupcomp"].ToString().TrimEnd(), _Dtw_Item["ccompany"].ToString().TrimEnd(),
                    _Dtw_Item["cidnotrecepc"].ToString().TrimEnd(), _Dtw_Item["ctiponotrecep"].ToString().TrimEnd(), _Dtw_Item["cfechanotrecep"].ToString().TrimEnd(),
                    _Dtw_Item["ctipodocument"].ToString().TrimEnd(), _Dtw_Item["cnumdocu"], _Dtw_Item["cfechadocu"],
                    _Dtw_Item["cmontosi"].ToString().TrimEnd(), _Dtw_Item["cmontoimp"].ToString().TrimEnd(), _Dtw_Item["cporcreconoce"].ToString().TrimEnd(),
                    _Dtw_Item["cimpreso"].ToString().TrimEnd(), _Dtw_Item["cporcinvendible"].ToString().TrimEnd(), _Dtw_Item["cproveedor"].ToString().TrimEnd(),
                    _Dtw_Item["cidcomprob"].ToString().TrimEnd(), _Dtw_Item["ciddnotrecepc"].ToString().TrimEnd(), _Dtw_Item["cproducto"].ToString().TrimEnd(),
                    _Dtw_Item["cempaques"].ToString().TrimEnd(), _Dtw_Item["cunidades"].ToString().TrimEnd(), _Dtw_Item["cmontosi_det"].ToString().TrimEnd(),
                    _Dtw_Item["cmontoimp_det"].ToString().TrimEnd(), _Dtw_Item["ccliente"].ToString().TrimEnd(), _Dtw_Item["c_nomb_comer"].ToString().TrimEnd(),
                    _Dtw_Item["cnamefc"].ToString().TrimEnd(), _Dtw_Item["cidmotivo"].ToString().TrimEnd(), _Dtw_Item["ctipodocument_name"].ToString().TrimEnd(),
                    _Dtw_Item["total_det"].ToString().TrimEnd(), _Dtw_Item["cprecioventamax"].ToString().TrimEnd(), _Dtw_Item["cnumlote"].ToString().TrimEnd() }));
                    }
                }
                if (_Dt_Tabla.Rows.Count > 0)
                {
                    REPORTESS _Frm_Reporte = new REPORTESS("T3.Report.rNotaRecep_Devol", _Dt_Tabla, _Print, true, "Section2", "", "", "");
                }
                Cursor = Cursors.Default;
                //-------------------------------------------------------
                if (MessageBox.Show("¿La impresión fue realizada correctamente?", "Requerimiento", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Cursor = Cursors.WaitCursor;
                    foreach (string _Str_String in _Str_NR)
                    {
                        Program._MyClsCnn._mtd_conexion._Mtd_modificar("TNOTARECEPC", "cimpreso='1',cdateupd='" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ()) + "',cuserupd='" + Frm_Padre._Str_Use + "'", "cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and ccompany='" + Frm_Padre._Str_Comp + "' and cidnotrecepc='" + _Str_String + "'");
                        _Str_Cadena = "UPDATE TDEVVENTAM SET cimprimenr=1 WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cidnotrecepc='" + _Str_String + "'";
                        Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                    }
                    Cursor = Cursors.Default;
                    System.Threading.ThreadPool.QueueUserWorkItem(((Frm_Padre)this.MdiParent)._Frm_Contenedor._async_Default);
                    MessageBox.Show("La operación ha sido realizada correctamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    _Pnl_ReImpresion.BringToFront();
                    _Pnl_ReImpresion.Visible = true;
                }
            }
        }
        private int _Mtd_Comprobante_NC_CxC_ANUL_SIN_EXED()
        {
            DataSet _Ds = new DataSet();
            string _Str_Cadena = "";
            string[] _Str_NC = new string[0];
            string[] _Str_NC_EMIT = new string[0];
            double _Dbl_MontoSimp = 0, _Dbl_MontoImp = 0, _Dbl_MontoTotal = 0, _Dbl_MontoDesc = 0;
            int _Int_DocMin = 0, _Int_DocMax = 0, _Int_Id_Comprobante = 0;
            foreach (DataGridViewRow _Dg_Row in _Dg_Grid.Rows)
            {
                if (Convert.ToString(_Dg_Row.Cells["Imprimir"].Value).Trim() == "1" && !_Mtd_NC_EXEDENTE_DE_COBRO(_Dg_Row.Cells["Documento"].Value.ToString().Trim()) && !_Mtd_NC_INTERCOMPAÑIA(_Dg_Row.Cells["Documento"].Value.ToString().Trim()))
                {
                    //---------------------------------------------------------
                    _Str_NC = (string[])CLASES._Cls_Varios_Metodos._Mtd_ArrayRedim(_Str_NC, _Str_NC.Length + 1);
                    _Str_NC[_Str_NC.Length - 1] = Convert.ToString(_Dg_Row.Cells["Documento"].Value.ToString());
                    //-----------------------------------------------------------------
                    if (_Int_DocMax < Convert.ToInt32(_Dg_Row.Cells["Documento"].Value))
                    {
                        _Int_DocMax = Convert.ToInt32(_Dg_Row.Cells["Documento"].Value);
                        if (_Int_DocMin == 0)
                        {
                            _Int_DocMin = _Int_DocMax;
                        }
                    }
                    if (_Int_DocMin > Convert.ToInt32(_Dg_Row.Cells["Documento"].Value))
                    {
                        _Int_DocMin = Convert.ToInt32(_Dg_Row.Cells["Documento"].Value);
                    }
                    _Str_Cadena = "SELECT SUM(cmontosimp + ISNULL(cbasexcenta,0)) AS cmontototsi,SUM(cimpuesto) AS cimpuesto,SUM(cmontototal) AS ctotaldocu,SUM(ISNULL(cmontosimpdpp,0)) AS cmontosimpdpp,SUM(ISNULL(cimpuestodpp,0)) AS cimpuestodpp,SUM(ISNULL(cbasexcentadpp,0)) AS cbasexcentadpp,SUM(ISNULL(cmontototaldpp,0)) AS cmontototaldpp FROM TNOTACREDICCD WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cidnotcredicc='" + _Dg_Row.Cells["Documento"].Value.ToString().Trim() + "' GROUP BY cidnotcredicc";
                    _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                    if (_Ds.Tables[0].Rows.Count > 0)
                    {
                        if (Convert.ToString(_Ds.Tables[0].Rows[0]["cmontototsi"]).Length > 0)
                        {
                            _Dbl_MontoSimp = _Dbl_MontoSimp + (Convert.ToDouble(_Ds.Tables[0].Rows[0]["cmontototsi"]) + Convert.ToDouble(_Ds.Tables[0].Rows[0]["cmontosimpdpp"]) + Convert.ToDouble(_Ds.Tables[0].Rows[0]["cbasexcentadpp"]));
                        }
                        if (Convert.ToString(_Ds.Tables[0].Rows[0]["cimpuesto"]).Length > 0)
                        {
                            _Dbl_MontoImp = _Dbl_MontoImp + Convert.ToDouble(_Ds.Tables[0].Rows[0]["cimpuesto"]);
                        }
                        if (Convert.ToString(_Ds.Tables[0].Rows[0]["ctotaldocu"]).Length > 0)
                        {
                            _Dbl_MontoTotal = _Dbl_MontoTotal + Convert.ToDouble(_Ds.Tables[0].Rows[0]["ctotaldocu"]);
                        }
                        if (Convert.ToString(_Ds.Tables[0].Rows[0]["cmontototaldpp"]).Length > 0)
                        {
                            _Dbl_MontoDesc = _Dbl_MontoDesc + (Convert.ToDouble(_Ds.Tables[0].Rows[0]["cmontosimpdpp"]) + Convert.ToDouble(_Ds.Tables[0].Rows[0]["cbasexcentadpp"]));
                        }
                    }
                    else
                    {
                        _Str_Cadena = "SELECT cmontototsi + ISNULL(cexento,0) as cmontototsi,cimpuesto,ctotaldocu FROM TNOTACREDICC WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cidnotcredicc='" + _Dg_Row.Cells["Documento"].Value.ToString().Trim() + "'";
                        _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                        if (_Ds.Tables[0].Rows.Count > 0)
                        {
                            if (Convert.ToString(_Ds.Tables[0].Rows[0]["cmontototsi"]).Length > 0)
                            {
                                _Dbl_MontoSimp = _Dbl_MontoSimp + Convert.ToDouble(_Ds.Tables[0].Rows[0]["cmontototsi"]);
                            }
                            if (Convert.ToString(_Ds.Tables[0].Rows[0]["cimpuesto"]).Length > 0)
                            {
                                _Dbl_MontoImp = _Dbl_MontoImp + Convert.ToDouble(_Ds.Tables[0].Rows[0]["cimpuesto"]);
                            }
                            if (Convert.ToString(_Ds.Tables[0].Rows[0]["ctotaldocu"]).Length > 0)
                            {
                                _Dbl_MontoTotal = _Dbl_MontoTotal + Convert.ToDouble(_Ds.Tables[0].Rows[0]["ctotaldocu"]);
                            }
                        }
                    }
                    //---------------------------------------------------------
                }
            }
            if (_Str_NC.Length > 0)
            {
                _Str_Cadena = "Select cidcomprobanul from TNOTACREDICC where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and ccompany='" + Frm_Padre._Str_Comp + "' and cidnotcredicc='" + _Str_NC[0] + "'";
                _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                if (_Ds.Tables[0].Rows.Count > 0)
                {
                    if (_Ds.Tables[0].Rows[0][0].ToString().Trim() == "0")
                    {
                        _Int_Id_Comprobante = Convert.ToInt32(_MyUtilidad._Mtd_Proceso_P_CXC_NC_A(_Str_NC, _Dbl_MontoSimp, _Dbl_MontoImp, _Dbl_MontoTotal, "P_CXC_NC_A", _Dbl_MontoDesc));
                        _Mtd_ActualizarComprobantes(4, _Int_Id_Comprobante.ToString());//Se actualiza el numero de comprobante en las NC seleccionadas
                    }
                    else
                    {
                        _Int_Id_Comprobante = Convert.ToInt32(_Ds.Tables[0].Rows[0][0].ToString());
                    }
                }
            }
            return _Int_Id_Comprobante;
        }
        private int _Mtd_Comprobante_NC_CxC_ANUL_CON_EXED()
        {
            DataSet _Ds = new DataSet();
            string _Str_Cadena = "";
            string[] _Str_NC = new string[0];
            string[] _Str_NC_EMIT = new string[0];
            double _Dbl_MontoSimp = 0, _Dbl_MontoImp = 0, _Dbl_MontoTotal = 0, _Dbl_MontoDesc = 0;
            int _Int_DocMin = 0, _Int_DocMax = 0, _Int_Id_Comprobante = 0;
            foreach (DataGridViewRow _Dg_Row in _Dg_Grid.Rows)
            {
                if (Convert.ToString(_Dg_Row.Cells["Imprimir"].Value).Trim() == "1" && _Mtd_NC_EXEDENTE_DE_COBRO(_Dg_Row.Cells["Documento"].Value.ToString().Trim()))
                {
                    //---------------------------------------------------------
                    _Str_NC = (string[])CLASES._Cls_Varios_Metodos._Mtd_ArrayRedim(_Str_NC, _Str_NC.Length + 1);
                    _Str_NC[_Str_NC.Length - 1] = Convert.ToString(_Dg_Row.Cells["Documento"].Value.ToString());
                    //-----------------------------------------------------------------
                    if (_Int_DocMax < Convert.ToInt32(_Dg_Row.Cells["Documento"].Value))
                    {
                        _Int_DocMax = Convert.ToInt32(_Dg_Row.Cells["Documento"].Value);
                        if (_Int_DocMin == 0)
                        {
                            _Int_DocMin = _Int_DocMax;
                        }
                    }
                    if (_Int_DocMin > Convert.ToInt32(_Dg_Row.Cells["Documento"].Value))
                    {
                        _Int_DocMin = Convert.ToInt32(_Dg_Row.Cells["Documento"].Value);
                    }
                    _Str_Cadena = "SELECT SUM(cmontosimp + ISNULL(cbasexcenta,0)) AS cmontototsi,SUM(cimpuesto) AS cimpuesto,SUM(cmontototal) AS ctotaldocu,SUM(ISNULL(cmontosimpdpp,0)) AS cmontosimpdpp,SUM(ISNULL(cimpuestodpp,0)) AS cimpuestodpp,SUM(ISNULL(cbasexcentadpp,0)) AS cbasexcentadpp,SUM(ISNULL(cmontototaldpp,0)) AS cmontototaldpp FROM TNOTACREDICCD WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cidnotcredicc='" + _Dg_Row.Cells["Documento"].Value.ToString().Trim() + "' GROUP BY cidnotcredicc";
                    _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                    if (_Ds.Tables[0].Rows.Count > 0)
                    {
                        if (Convert.ToString(_Ds.Tables[0].Rows[0]["cmontototsi"]).Length > 0)
                        {
                            _Dbl_MontoSimp = _Dbl_MontoSimp + (Convert.ToDouble(_Ds.Tables[0].Rows[0]["cmontototsi"]) + Convert.ToDouble(_Ds.Tables[0].Rows[0]["cmontosimpdpp"]) + Convert.ToDouble(_Ds.Tables[0].Rows[0]["cbasexcentadpp"]));
                        }
                        if (Convert.ToString(_Ds.Tables[0].Rows[0]["cimpuesto"]).Length > 0)
                        {
                            _Dbl_MontoImp = _Dbl_MontoImp + Convert.ToDouble(_Ds.Tables[0].Rows[0]["cimpuesto"]);
                        }
                        if (Convert.ToString(_Ds.Tables[0].Rows[0]["ctotaldocu"]).Length > 0)
                        {
                            _Dbl_MontoTotal = _Dbl_MontoTotal + Convert.ToDouble(_Ds.Tables[0].Rows[0]["ctotaldocu"]);
                        }
                        if (Convert.ToString(_Ds.Tables[0].Rows[0]["cmontototaldpp"]).Length > 0)
                        {
                            _Dbl_MontoDesc = _Dbl_MontoDesc + (Convert.ToDouble(_Ds.Tables[0].Rows[0]["cmontosimpdpp"]) + Convert.ToDouble(_Ds.Tables[0].Rows[0]["cbasexcentadpp"]));
                        }
                    }
                    else
                    {
                        _Str_Cadena = "SELECT cmontototsi + ISNULL(cexento,0) as cmontototsi,cimpuesto,ctotaldocu FROM TNOTACREDICC WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cidnotcredicc='" + _Dg_Row.Cells["Documento"].Value.ToString().Trim() + "'";
                        _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                        if (_Ds.Tables[0].Rows.Count > 0)
                        {
                            if (Convert.ToString(_Ds.Tables[0].Rows[0]["cmontototsi"]).Length > 0)
                            {
                                _Dbl_MontoSimp = _Dbl_MontoSimp + Convert.ToDouble(_Ds.Tables[0].Rows[0]["cmontototsi"]);
                            }
                            if (Convert.ToString(_Ds.Tables[0].Rows[0]["cimpuesto"]).Length > 0)
                            {
                                _Dbl_MontoImp = _Dbl_MontoImp + Convert.ToDouble(_Ds.Tables[0].Rows[0]["cimpuesto"]);
                            }
                            if (Convert.ToString(_Ds.Tables[0].Rows[0]["ctotaldocu"]).Length > 0)
                            {
                                _Dbl_MontoTotal = _Dbl_MontoTotal + Convert.ToDouble(_Ds.Tables[0].Rows[0]["ctotaldocu"]);
                            }
                        }
                    }
                    //---------------------------------------------------------
                }
            }
            if (_Str_NC.Length > 0)
            {
                _Str_Cadena = "Select cidcomprobanul from TNOTACREDICC where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and ccompany='" + Frm_Padre._Str_Comp + "' and cidnotcredicc='" + _Str_NC[0] + "'";
                _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                if (_Ds.Tables[0].Rows.Count > 0)
                {
                    if (_Ds.Tables[0].Rows[0][0].ToString().Trim() == "0")
                    {
                        _Int_Id_Comprobante = Convert.ToInt32(_MyUtilidad._Mtd_Proceso_P_CXC_NC_A(_Str_NC, _Dbl_MontoSimp, _Dbl_MontoImp, _Dbl_MontoTotal, "P_CXC_NCEXCD_A", _Dbl_MontoDesc));
                        _Mtd_ActualizarComprobantes(5, _Int_Id_Comprobante.ToString());//Se actualiza el numero de comprobante en las NC seleccionadas
                    }
                    else
                    {
                        _Int_Id_Comprobante = Convert.ToInt32(_Ds.Tables[0].Rows[0][0].ToString());
                    }
                }
            }
            return _Int_Id_Comprobante;
        }

        /// <summary>
        /// Crea el comprobante de anulación solo para las NC de intercompañías seleccionadas.
        /// </summary>
        /// <returns>Id del comprobante generado.</returns>
        private int _Mtd_Comprobante_NC_CxC_ANUL_INTER()
        {
            DataSet _Ds = new DataSet();
            string _Str_Cadena = "";
            string[] _Str_NC = new string[0];
            string[] _Str_NC_EMIT = new string[0];
            double _Dbl_MontoSimp = 0, _Dbl_MontoImp = 0, _Dbl_MontoTotal = 0, _Dbl_MontoDesc = 0;
            int _Int_DocMin = 0, _Int_DocMax = 0, _Int_Id_Comprobante = 0;
            foreach (DataGridViewRow _Dg_Row in _Dg_Grid.Rows)
            {
                if (Convert.ToString(_Dg_Row.Cells["Imprimir"].Value).Trim() == "1" && _Mtd_NC_INTERCOMPAÑIA(_Dg_Row.Cells["Documento"].Value.ToString().Trim()))
                {
                    //---------------------------------------------------------
                    _Str_NC = (string[])CLASES._Cls_Varios_Metodos._Mtd_ArrayRedim(_Str_NC, _Str_NC.Length + 1);
                    _Str_NC[_Str_NC.Length - 1] = Convert.ToString(_Dg_Row.Cells["Documento"].Value.ToString());
                    //-----------------------------------------------------------------
                    if (_Int_DocMax < Convert.ToInt32(_Dg_Row.Cells["Documento"].Value))
                    {
                        _Int_DocMax = Convert.ToInt32(_Dg_Row.Cells["Documento"].Value);
                        if (_Int_DocMin == 0)
                        {
                            _Int_DocMin = _Int_DocMax;
                        }
                    }
                    if (_Int_DocMin > Convert.ToInt32(_Dg_Row.Cells["Documento"].Value))
                    {
                        _Int_DocMin = Convert.ToInt32(_Dg_Row.Cells["Documento"].Value);
                    }
                    _Str_Cadena = "SELECT SUM(cmontosimp + ISNULL(cbasexcenta,0)) AS cmontototsi,SUM(cimpuesto) AS cimpuesto,SUM(cmontototal) AS ctotaldocu,SUM(ISNULL(cmontosimpdpp,0)) AS cmontosimpdpp,SUM(ISNULL(cimpuestodpp,0)) AS cimpuestodpp,SUM(ISNULL(cbasexcentadpp,0)) AS cbasexcentadpp,SUM(ISNULL(cmontototaldpp,0)) AS cmontototaldpp FROM TNOTACREDICCD WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cidnotcredicc='" + _Dg_Row.Cells["Documento"].Value.ToString().Trim() + "' GROUP BY cidnotcredicc";
                    _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                    if (_Ds.Tables[0].Rows.Count > 0)
                    {
                        if (Convert.ToString(_Ds.Tables[0].Rows[0]["cmontototsi"]).Length > 0)
                        {
                            _Dbl_MontoSimp = _Dbl_MontoSimp + (Convert.ToDouble(_Ds.Tables[0].Rows[0]["cmontototsi"]) + Convert.ToDouble(_Ds.Tables[0].Rows[0]["cmontosimpdpp"]) + Convert.ToDouble(_Ds.Tables[0].Rows[0]["cbasexcentadpp"]));
                        }
                        if (Convert.ToString(_Ds.Tables[0].Rows[0]["cimpuesto"]).Length > 0)
                        {
                            _Dbl_MontoImp = _Dbl_MontoImp + Convert.ToDouble(_Ds.Tables[0].Rows[0]["cimpuesto"]);
                        }
                        if (Convert.ToString(_Ds.Tables[0].Rows[0]["ctotaldocu"]).Length > 0)
                        {
                            _Dbl_MontoTotal = _Dbl_MontoTotal + Convert.ToDouble(_Ds.Tables[0].Rows[0]["ctotaldocu"]);
                        }
                        if (Convert.ToString(_Ds.Tables[0].Rows[0]["cmontototaldpp"]).Length > 0)
                        {
                            _Dbl_MontoDesc = _Dbl_MontoDesc + (Convert.ToDouble(_Ds.Tables[0].Rows[0]["cmontosimpdpp"]) + Convert.ToDouble(_Ds.Tables[0].Rows[0]["cbasexcentadpp"]));
                        }
                    }
                    else
                    {
                        _Str_Cadena = "SELECT cmontototsi + ISNULL(cexento,0) as cmontototsi,cimpuesto,ctotaldocu FROM TNOTACREDICC WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cidnotcredicc='" + _Dg_Row.Cells["Documento"].Value.ToString().Trim() + "'";
                        _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                        if (_Ds.Tables[0].Rows.Count > 0)
                        {
                            if (Convert.ToString(_Ds.Tables[0].Rows[0]["cmontototsi"]).Length > 0)
                            {
                                _Dbl_MontoSimp = _Dbl_MontoSimp + Convert.ToDouble(_Ds.Tables[0].Rows[0]["cmontototsi"]);
                            }
                            if (Convert.ToString(_Ds.Tables[0].Rows[0]["cimpuesto"]).Length > 0)
                            {
                                _Dbl_MontoImp = _Dbl_MontoImp + Convert.ToDouble(_Ds.Tables[0].Rows[0]["cimpuesto"]);
                            }
                            if (Convert.ToString(_Ds.Tables[0].Rows[0]["ctotaldocu"]).Length > 0)
                            {
                                _Dbl_MontoTotal = _Dbl_MontoTotal + Convert.ToDouble(_Ds.Tables[0].Rows[0]["ctotaldocu"]);
                            }
                        }
                    }
                    //---------------------------------------------------------
                }
            }
            if (_Str_NC.Length > 0)
            {
                _Str_Cadena = "Select cidcomprobanul from TNOTACREDICC where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and ccompany='" + Frm_Padre._Str_Comp + "' and cidnotcredicc='" + _Str_NC[0] + "'";
                _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                if (_Ds.Tables[0].Rows.Count > 0)
                {
                    if (_Ds.Tables[0].Rows[0][0].ToString().Trim() == "0")
                    {
                        _Int_Id_Comprobante = Convert.ToInt32(_MyUtilidad._Mtd_Proceso_P_CXC_NC_A(_Str_NC, _Dbl_MontoSimp, _Dbl_MontoImp, _Dbl_MontoTotal, "P_CXC_NC_CIA_RELAC_A", _Dbl_MontoDesc));
                        _Mtd_ActualizarComprobantes(7, _Int_Id_Comprobante.ToString());//Se actualiza el numero de comprobante en las NC seleccionadas
                    }
                    else
                    {
                        _Int_Id_Comprobante = Convert.ToInt32(_Ds.Tables[0].Rows[0][0].ToString());
                    }
                }
            }
            return _Int_Id_Comprobante;
        }
        private bool _Mtd_ImprimirComprobantes_NC_CxC_ANUL()
        {
            REPORTESS _Frm = new REPORTESS();
            string _Str_Cadena = "";
            PrintDialog _Print = new PrintDialog();
            Cursor = Cursors.WaitCursor;
            string _Str_Mensaje = "Se va a proceder a imprimir el comprobante contable.";
            string _Str_MensajeConfirm = "¿Los comprobantes fueron impresos correctamente?";
            int _Int_CantidadComprob = 0;
            int _P_Int_ComprobateConExed = _Mtd_Comprobante_NC_CxC_ANUL_CON_EXED();
            if (_P_Int_ComprobateConExed > 0)
                _Int_CantidadComprob += 1;
            int _P_Int_ComprobateSinExed = _Mtd_Comprobante_NC_CxC_ANUL_SIN_EXED();
            if (_P_Int_ComprobateSinExed > 0)
                _Int_CantidadComprob += 1;
            int _P_Int_ComprobateInter = _Mtd_Comprobante_NC_CxC_ANUL_INTER();
            if (_P_Int_ComprobateInter > 0)
                _Int_CantidadComprob += 1;
            if (_Int_CantidadComprob == 3)
            { _Str_Mensaje = "Se va a proceder a imprimir tres comprobantes contables."; }
            else if (_Int_CantidadComprob == 2)
            { _Str_Mensaje = "Se va a proceder a imprimir dos comprobantes contables."; }
            else
            { _Str_MensajeConfirm = "¿El comprobante fue impreso correctamente?"; }
            Cursor = Cursors.Default;
            //----------------------------------
            MessageBox.Show(_Str_Mensaje, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
        PrintComprobNC_ANUL:
            if (_Print.ShowDialog() == DialogResult.OK)
            {
                Cursor = Cursors.WaitCursor;
                if (_P_Int_ComprobateConExed > 0)
                    _Frm = new REPORTESS(new string[] { "vst_reportecomprobante" }, "", "T3.Report.rcomprobante", "Section1", "cabecera", "rif", "nit", "ccompany='" + Frm_Padre._Str_Comp + "' and cidcomprob='" + _P_Int_ComprobateConExed.ToString() + "'", _Print, true);
                if (_P_Int_ComprobateSinExed > 0)
                    _Frm = new REPORTESS(new string[] { "vst_reportecomprobante" }, "", "T3.Report.rcomprobante", "Section1", "cabecera", "rif", "nit", "ccompany='" + Frm_Padre._Str_Comp + "' and cidcomprob='" + _P_Int_ComprobateSinExed.ToString() + "'", _Print, true);
                if (_P_Int_ComprobateInter > 0)
                    _Frm = new REPORTESS(new string[] { "vst_reportecomprobante" }, "", "T3.Report.rcomprobante", "Section1", "cabecera", "rif", "nit", "ccompany='" + Frm_Padre._Str_Comp + "' and cidcomprob='" + _P_Int_ComprobateInter.ToString() + "'", _Print, true);
                Cursor = Cursors.Default;
                if (MessageBox.Show(_Str_MensajeConfirm, "Requerimiento", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    _Frm.Close();
                    _Frm.Dispose();
                    Cursor = Cursors.WaitCursor;
                    foreach (DataGridViewRow _Dg_Row in _Dg_Grid.Rows)
                    {
                        if (Convert.ToString(_Dg_Row.Cells["Imprimir"].Value).Trim() == "1")
                        {
                            _Str_Cadena = "UPDATE TNOTACREDICC SET canulado='1' WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and ccompany='" + Frm_Padre._Str_Comp + "' and cidnotcredicc='" + Convert.ToString(_Dg_Row.Cells["Documento"].Value).Trim() + "'";
                            Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                            _Str_Cadena = "UPDATE TNCANUL SET cactivo=1,cestatusfirma=2 WHERE ccompany='" + Frm_Padre._Str_Comp + "' and cidnotcredit='" + Convert.ToString(_Dg_Row.Cells["Documento"].Value).Trim() + "'";
                            Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                        }
                    }
                    Cursor = Cursors.Default;
                    return true;
                }
                else
                { goto PrintComprobNC_ANUL; }
            }
            //----------------------------------
            return false;
        }
        private bool _Mtd_NC_EXEDENTE_DE_COBRO(string _P_Str_NC)
        {
            string _Str_Cadena = "select cexedentecobro from TNOTACREDICC where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and ccompany='" + Frm_Padre._Str_Comp + "' and cidnotcredicc='" + _P_Str_NC + "' AND cexedentecobro='1'";
            return Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena).Tables[0].Rows.Count > 0;
        }

        /// <summary>
        /// Retorna un valor que indica si una NC es de intercompañía.
        /// </summary>
        /// <param name="_P_Str_NC">Id de la NC.</param>
        /// <returns>Verdadero o falso.</returns>
        private bool _Mtd_NC_INTERCOMPAÑIA(string _P_Str_NC)
        {
            string _Str_Cadena = "select TNOTACREDICC.cidnotcredicc from TNOTACREDICC INNER JOIN TICRELAPROCLI ON TNOTACREDICC.ccliente=TICRELAPROCLI.ccliente and TNOTACREDICC.cgroupcomp=TICRELAPROCLI.cgroupcomp where TNOTACREDICC.cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and TNOTACREDICC.ccompany='" + Frm_Padre._Str_Comp + "' and TNOTACREDICC.cidnotcredicc='" + _P_Str_NC + "'";
            return Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena).Tables[0].Rows.Count > 0;
        }
        private void _Mtd_ActualizarComprobantes(int _P_Int_Sw, string _P_Str_Comprobante)
        {// 0 es NC , 1 es ND, 3 es CheqDev, 4 es NC_ANUL_SIN_EXEDEN, 5 es NC_ANUL_CON_EXEDEN, 6 es EgreCheq, 7 es NC_ANUL_INTER
            DataSet _Ds = new DataSet();
            string _Str_Cadena = "";
            foreach (DataGridViewRow _Dg_Row in _Dg_Grid.Rows)
            {
                if (Convert.ToString(_Dg_Row.Cells["Imprimir"].Value).Trim() == "1")
                {
                    if (_P_Int_Sw == 0)
                    { 
                        _Str_Cadena = "Update TNOTACREDICC Set cidcomprob='" + _P_Str_Comprobante + "' where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and ccompany='" + Frm_Padre._Str_Comp + "' and cidnotcredicc='" + _Dg_Row.Cells["Documento"].Value.ToString().Trim() + "'"; 
                        _Dg_Row.Cells["cidcomprob"].Value = _P_Str_Comprobante;
                        Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                    }
                    else if (_P_Int_Sw == 1)
                    { 
                        _Str_Cadena = "Update TNOTADEBICC set cidcomprob='" + _P_Str_Comprobante + "' where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and ccompany='" + Frm_Padre._Str_Comp + "' and cidnotadebitocc='" + _Dg_Row.Cells["Documento"].Value.ToString().Trim() + "'"; 
                        _Dg_Row.Cells["cidcomprob"].Value = _P_Str_Comprobante;
                        Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                    }
                    else if (_P_Int_Sw == 3)
                    {
                        _Str_Cadena = "UPDATE TCHEQDEVUELT SET cidcomprob='" + _P_Str_Comprobante + "' WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cidcheqdevuelt='" + Convert.ToString(_Dg_Row.Cells["Documento"].Value).ToString().Trim() + "' AND cnumcheque='" + Convert.ToString(_Dg_Row.Cells["cnumcheque"].Value).ToString().Trim() + "' AND ccliente='" + Convert.ToString(_Dg_Row.Cells["ccliente"].Value).ToString().Trim() + "'";
                        _Dg_Row.Cells["cidcomprob"].Value = _P_Str_Comprobante;
                        Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                    }
                    else if (_P_Int_Sw == 4)
                    {
                        if (!_Mtd_NC_EXEDENTE_DE_COBRO(_Dg_Row.Cells["Documento"].Value.ToString().Trim()) && !_Mtd_NC_INTERCOMPAÑIA(_Dg_Row.Cells["Documento"].Value.ToString().Trim()))
                        {
                            _Str_Cadena = "Update TNOTACREDICC Set cidcomprobanul='" + _P_Str_Comprobante + "' where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and ccompany='" + Frm_Padre._Str_Comp + "' and cidnotcredicc='" + _Dg_Row.Cells["Documento"].Value.ToString().Trim() + "'";
                            _Dg_Row.Cells["cidcomprob"].Value = _P_Str_Comprobante;
                            Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                        }
                    }
                    else if (_P_Int_Sw == 5)
                    {
                        if (_Mtd_NC_EXEDENTE_DE_COBRO(_Dg_Row.Cells["Documento"].Value.ToString().Trim()))
                        {
                            _Str_Cadena = "Update TNOTACREDICC Set cidcomprobanul='" + _P_Str_Comprobante + "' where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and ccompany='" + Frm_Padre._Str_Comp + "' and cidnotcredicc='" + _Dg_Row.Cells["Documento"].Value.ToString().Trim() + "'";
                            _Dg_Row.Cells["cidcomprob"].Value = _P_Str_Comprobante;
                            Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                        }
                    }
                    else if (_P_Int_Sw == 6)
                    {
                        //_Str_Cadena = "UPDATE TEGRECHEQTRAN SET cidcomprob='" + _P_Str_Comprobante + "' WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cidegrecheqtran='" + Convert.ToString(_Dg_Row.Cells["Documento"].Value).Trim() + "' AND cnumdepo='" + Convert.ToString(_Dg_Row.Cells["cnumdepo"].Value).Trim() + "' AND cnumcheque='" + Convert.ToString(_Dg_Row.Cells["Tipo"].Value).Trim() + "' AND ccliente='" + Convert.ToString(_Dg_Row.Cells["ccliente"].Value).Trim() + "'";
                        _Dg_Row.Cells["cidcomprob"].Value = _P_Str_Comprobante;
                       // Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                    }
                    else if (_P_Int_Sw == 7)
                    {
                        if (_Mtd_NC_INTERCOMPAÑIA(_Dg_Row.Cells["Documento"].Value.ToString().Trim()))
                        {
                            _Str_Cadena = "Update TNOTACREDICC Set cidcomprobanul='" + _P_Str_Comprobante + "' where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and ccompany='" + Frm_Padre._Str_Comp + "' and cidnotcredicc='" + _Dg_Row.Cells["Documento"].Value.ToString().Trim() + "'";
                            _Dg_Row.Cells["cidcomprob"].Value = _P_Str_Comprobante;
                            Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                        }
                    }
                }
            }
        }
        private bool _Mtd_VerificarNumContrlMayorComp(string _P_Str_Comp, string _P_Str_NumCtrl)
        {
            try
            {
                string _Str_Cadena = "SELECT c_numerocontrol FROM TFACTURAM WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + _P_Str_Comp + "' AND ISNULL(c_numerocontrol,0)>=" + _P_Str_NumCtrl.Trim();
                bool _Bol_Return = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena).Tables[0].Rows.Count > 0;
                if (_Bol_Return)
                {
                    MessageBox.Show("El número de control ya fue ingresado anteriormente. Por favor verifique...", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                return _Bol_Return;
            }
            catch(Exception _Ex) 
            {
                MessageBox.Show("Error al verificar el número de control.\n" + _Ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return true;
            } 
        }
        private string _Mtd_ProximoNumControl(string _P_Str_Comp, string _P_Str_Tipo, string _P_Str_NumCtrl)
        {
            string _Str_Cadena = "";
            if (_P_Str_Tipo == "NC")
            { _Str_Cadena = "SELECT TOP 1 ISNULL(cnumcontrolnc,0) + 1 FROM TNOTACREDICC WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and ccompany='" + _P_Str_Comp + "' ORDER BY cnumcontrolnc DESC"; }
            else if (_P_Str_Tipo == "ND")
            { _Str_Cadena = "SELECT TOP 1 ISNULL(cnumcontrolnd,0) + 1 FROM TNOTADEBICC WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and ccompany='" + _P_Str_Comp + "'  ORDER BY cnumcontrolnd DESC"; }
            else
            { _Str_Cadena = "SELECT TOP 1 ISNULL(c_numerocontrol,0) + 1 FROM TFACTURAM WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and ccompany='" + _P_Str_Comp + "'  ORDER BY c_numerocontrol DESC"; }
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                if (Convert.ToDouble(_Ds.Tables[0].Rows[0][0]) != Convert.ToDouble(_P_Str_NumCtrl))
                {
                    return "El número de control que usted está ingresando no es consecutivo al último cargado.\n¿Esta seguro de continuar?";
                }
            }
            return "";
        }
        private void _Bt_AceptarNumero_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            if (_Txt_Numero.Text.Trim().Length > 0)
            {
                if (Convert.ToInt32(_Txt_Numero.Text) > 0)
                {
                    string _Str_Cadena = "";
                    if (_Int_Sw == 1 || _Int_Sw == 8)
                    { _Str_Cadena = "Select * from TNOTACREDICC where ccompany='" + Frm_Padre._Str_Comp + "' and cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and cnumcontrolnc='" + _Txt_Numero.Text.Trim() + "'"; }
                    else if (_Int_Sw == 2)
                    { _Str_Cadena = "Select * from TNOTADEBICC where ccompany='" + Frm_Padre._Str_Comp + "' and cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and cnumcontrolnd='" + _Txt_Numero.Text.Trim() + "'"; }
                    else if (_Int_Sw == 3)
                    {
                        if (!_Mtd_VerificarNumContrlMayorComp(_Str_CompFact, _Txt_Numero.Text))
                        {
                            _Str_Cadena = "";
                            string _Str_Mensaje = _Mtd_ProximoNumControl(_Str_CompFact, "FACT", _Txt_Numero.Text);
                            if (_Str_Mensaje.Trim().Length > 0)
                            {
                                if (new Frm_MessageBox(_Str_Mensaje, "Advertencia", SystemIcons.Warning, 4).ShowDialog() == DialogResult.Yes)
                                {
                                    _Mtd_ColocarNumeros(Convert.ToInt32(_Txt_Numero.Text)); _Pnl_Numero.Visible = false; _Bt_Actualizar.Enabled = true; _Dg_Grid.Columns["Numero"].ReadOnly = false;
                                }
                            }
                            else
                            { _Mtd_ColocarNumeros(Convert.ToInt32(_Txt_Numero.Text)); _Pnl_Numero.Visible = false; _Bt_Actualizar.Enabled = true; _Dg_Grid.Columns["Numero"].ReadOnly = false; }
                        }
                        //else
                        //{
                        //    MessageBox.Show("El número de control ya fue ingresado anteriormente. Por favor verifique...", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //}
                    }
                    else if (_Int_Sw == 5 || _Int_Sw == 7)
                    {
                        _Str_Cadena = "";
                        string _Str_Mensaje = "";
                        if (_Int_Sw == 5)
                        { _Str_Mensaje = _Mtd_ProximoNumControl(Frm_Padre._Str_Comp, "NC", _Txt_Numero.Text); }
                        else
                        { _Str_Mensaje = _Mtd_ProximoNumControl(Frm_Padre._Str_Comp, "ND", _Txt_Numero.Text); }
                        if (_Str_Mensaje.Trim().Length > 0)
                        {
                            if (new Frm_MessageBox(_Str_Mensaje, "Advertencia", SystemIcons.Warning, 4).ShowDialog() == DialogResult.Yes)
                            {
                                _Mtd_ColocarNumeros(Convert.ToInt32(_Txt_Numero.Text)); _Pnl_Numero.Visible = false; _Bt_Actualizar.Enabled = true; _Dg_Grid.Columns["Numero"].ReadOnly = false;
                            }
                        }
                        else
                        { _Mtd_ColocarNumeros(Convert.ToInt32(_Txt_Numero.Text)); _Pnl_Numero.Visible = false; _Bt_Actualizar.Enabled = true; _Dg_Grid.Columns["Numero"].ReadOnly = false; }
                    }
                    if (_Str_Cadena.Length > 0)
                    {
                        if (Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena).Tables[0].Rows.Count == 0)
                        {

                            string _Str_Mensaje = "";
                            if (_Int_Sw == 1 | _Int_Sw == 8)
                            { _Str_Mensaje = _Mtd_ProximoNumControl(Frm_Padre._Str_Comp, "NC", _Txt_Numero.Text); }
                            else
                            { _Str_Mensaje = _Mtd_ProximoNumControl(Frm_Padre._Str_Comp, "ND", _Txt_Numero.Text); }
                            if (_Str_Mensaje.Trim().Length > 0)
                            {
                                if (new Frm_MessageBox(_Str_Mensaje, "Advertencia", SystemIcons.Warning, 4).ShowDialog() == DialogResult.Yes)
                                {
                                    _Mtd_ColocarNumeros(Convert.ToInt32(_Txt_Numero.Text)); _Pnl_Numero.Visible = false; _Bt_Actualizar.Enabled = true; _Dg_Grid.Columns["Numero"].ReadOnly = false; 
                                }
                            }
                            else
                            { _Mtd_ColocarNumeros(Convert.ToInt32(_Txt_Numero.Text)); _Pnl_Numero.Visible = false; _Bt_Actualizar.Enabled = true; _Dg_Grid.Columns["Numero"].ReadOnly = false; }
                        }
                        else
                        { MessageBox.Show("El número de control ya existe. Coloque uno diferente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information); }
                    }
                }
                else
                { MessageBox.Show("Debe ingresar un número mayor a 0", "Requerimiento", MessageBoxButtons.OK, MessageBoxIcon.Asterisk); }
            }
            else
            { MessageBox.Show("Debe ingresar un número", "Requerimiento", MessageBoxButtons.OK, MessageBoxIcon.Asterisk); }
            this.Cursor = Cursors.Default;
        }
        private bool _Mtd_NC_AntPorImprimir()
        {
            bool _Bol_Menor = false;
            string _Str_Cadena = "";
            string _Str_PrimerDoc = "";
            foreach (DataGridViewRow _Dg_Row in _Dg_Grid.Rows)
            {
                if (Convert.ToString(_Dg_Row.Cells["Imprimir"].Value).Trim() == "1")
                {
                    if (_Str_PrimerDoc.Trim().Length == 0)
                    { _Str_PrimerDoc = Convert.ToString(_Dg_Row.Cells["Documento"].Value).Trim(); }
                    _Str_Cadena = "SELECT TNOTACREDICC.cidnotcredicc FROM TNOTACREDICC LEFT JOIN TNOTARECEPC ON TNOTACREDICC.ccompany=TNOTARECEPC.ccompany AND TNOTACREDICC.cgroupcomp=TNOTARECEPC.cgroupcomp AND TNOTACREDICC.cidnotrecepc=TNOTARECEPC.cidnotrecepc WHERE TNOTACREDICC.cdelete='0' AND TNOTACREDICC.ccompany='" + Frm_Padre._Str_Comp + "' AND TNOTACREDICC.cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND TNOTACREDICC.cimpresa='0' AND TNOTACREDICC.cactivo='0' AND ((TNOTACREDICC.cestatusfirma=2 AND ISNULL(TNOTACREDICC.cidnotrecepc,0)=0) OR TNOTARECEPC.cimpreso=1) AND TNOTACREDICC.cidnotcredicc<" + Convert.ToString(_Dg_Row.Cells["Documento"].Value).Trim();
                    if (Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena).Tables[0].Rows.Count > 0 & _Bol_Menor)
                    {
                        return true;
                    }
                }
                else
                {
                    _Bol_Menor = true;
                }
            }
            _Str_Cadena = "SELECT TNOTACREDICC.cidnotcredicc FROM TNOTACREDICC LEFT JOIN TNOTARECEPC ON TNOTACREDICC.ccompany=TNOTARECEPC.ccompany AND TNOTACREDICC.cgroupcomp=TNOTARECEPC.cgroupcomp AND TNOTACREDICC.cidnotrecepc=TNOTARECEPC.cidnotrecepc WHERE TNOTACREDICC.cdelete='0' AND TNOTACREDICC.ccompany='" + Frm_Padre._Str_Comp + "' AND TNOTACREDICC.cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND TNOTACREDICC.cimpresa='0' AND TNOTACREDICC.cactivo='0' AND ((TNOTACREDICC.cestatusfirma=2 AND ISNULL(TNOTACREDICC.cidnotrecepc,0)=0) OR TNOTARECEPC.cimpreso=1) AND TNOTACREDICC.cidnotcredicc<" + _Str_PrimerDoc;
            if (Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena).Tables[0].Rows.Count > 0)
            {
                return true;
            }
            return false;
        }
        private bool _Mtd_ND_AntPorImprimir()
        {
            bool _Bol_Menor = false;
            string _Str_Cadena = "";
            string _Str_PrimerDoc = "";
            foreach (DataGridViewRow _Dg_Row in _Dg_Grid.Rows)
            {
                if (Convert.ToString(_Dg_Row.Cells["Imprimir"].Value).Trim() == "1")
                {
                    if (_Str_PrimerDoc.Trim().Length == 0)
                    { _Str_PrimerDoc = Convert.ToString(_Dg_Row.Cells["Documento"].Value).Trim(); }
                    _Str_Cadena = "SELECT cidnotadebitocc FROM TNOTADEBICC WHERE cdelete='0' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND cimpresa='0' AND cactivo='0' AND cestatusfirma=2 AND cidnotadebitocc<" + Convert.ToString(_Dg_Row.Cells["Documento"].Value).Trim();
                    if (Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena).Tables[0].Rows.Count > 0 & _Bol_Menor)
                    {
                        return true;
                    }
                }
                else
                {
                    _Bol_Menor = true;
                }
            }
            _Str_Cadena = "SELECT cidnotadebitocc FROM TNOTADEBICC WHERE cdelete='0' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND cimpresa='0' AND cactivo='0' AND cestatusfirma=2 AND cidnotadebitocc<" + _Str_PrimerDoc;
            if (Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena).Tables[0].Rows.Count > 0)
            {
                return true;
            }
            return false;
        }
        private void _Bt_Imprimir_Click(object sender, EventArgs e)
        {
            if (_Mtd_Seleccionar())//Verifica si tiene elementos seleccionado
            {
                if (_Int_Sw == 1 | _Int_Sw == 2 | _Int_Sw == 8 | _Int_Sw == 12 | _Int_Sw == 13 | _Int_Sw == 14)
                {
                    if (_Mtd_VerificarSinComprobante())//Verifica si los seleccionados no tienen comprobante
                    {
                        if (_Int_Sw == 1 | _Int_Sw == 8)
                        {
                            if (_Mtd_NC_AntPorImprimir())
                            { MessageBox.Show("Existen NC por imprimir anteriores a la primera seleccionada. Debe imprimir las NC en orden descendente.\nPor favor verifique...", "Requerimiento", MessageBoxButtons.OK, MessageBoxIcon.Information); }
                            else
                            { _Pnl_Clave.Visible = true; }
                        }
                        else if (_Int_Sw == 2)
                        {
                            if (_Mtd_ND_AntPorImprimir())
                            { MessageBox.Show("Existen ND por imprimir anteriores a la primera seleccionada. Debe imprimir las ND en orden descendente.\nPor favor verifique...", "Requerimiento", MessageBoxButtons.OK, MessageBoxIcon.Information); }
                            else
                            { _Pnl_Clave.Visible = true; }
                        }
                        else
                        { _Pnl_Clave.Visible = true; }
                    }
                    else
                    {
                        if (_Mtd_VerificarComprobanteIgual())//Verifica si los comprobantes seleccionados son iguales
                        {
                            if (_Mtd_VerificarComprobanteIgualTodos())//Verifica si se seleccionaron todos los comprobantes que son iguales
                            {
                                if (_Int_Sw == 1)
                                {
                                    if (_Mtd_NC_AntPorImprimir())
                                    { MessageBox.Show("Existen NC anteriores a la primera selecciona por imprimir. Debe imprimir las NC en orden descendente.\nPor favor verifique...", "Requerimiento", MessageBoxButtons.OK, MessageBoxIcon.Information); }
                                    else
                                    { _Pnl_Clave.Visible = true; }
                                }
                                else if (_Int_Sw == 2)
                                {
                                    if (_Mtd_ND_AntPorImprimir())
                                    { MessageBox.Show("Existen ND anteriores a la primera selecciona por imprimir. Debe imprimir las ND en orden descendente.\nPor favor verifique...", "Requerimiento", MessageBoxButtons.OK, MessageBoxIcon.Information); }
                                    else
                                    { _Pnl_Clave.Visible = true; }
                                }
                                else
                                { _Pnl_Clave.Visible = true; }
                            }
                            else
                            { MessageBox.Show("Debe seleccionar todos los registros del mismo comprobante"); }
                        }
                        else
                        {
                            MessageBox.Show("Debe seleccionar registros de igual comprobante");
                        }
                    }
                }
                else
                { _Pnl_Clave.Visible = true; }
            }
            else
            { MessageBox.Show("No se han seleccionado documentos", "Requerimiento", MessageBoxButtons.OK, MessageBoxIcon.Asterisk); }

        }
       
        private void _Bt_CancelarClave_Click(object sender, EventArgs e)
        {
            _Pnl_Clave.Visible = false;
        }
        public static Byte[] _Mtd_ConvertStringToByteArray(String s)
        {
            return (new UnicodeEncoding()).GetBytes(s);
        }
        private void _Bt_AceptarClave_Click(object sender, EventArgs e)
        {
            string _Str_Mensaje="";
            byte[] hash = _Mtd_ConvertStringToByteArray(_Txt_Clave.Text);
            byte[] valorhash = ((HashAlgorithm)CryptoConfig.CreateFromName("MD5")).ComputeHash(hash);
            string cod = BitConverter.ToString(valorhash);
            cod = cod.Replace("-", "");
            try
            {
                string _Str_Cadena = "SELECT   cpassw  FROM TUSER WHERE cuser= '" + Frm_Padre._Str_Use.ToString() + "' and cpassw= '" + cod.ToString() + "'";
                System.Data.DataSet Ds22 = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                if (Ds22.Tables[0].Rows.Count > 0)
                {
                    _Pnl_Clave.Visible = false;
                    if (_Int_Sw == 1 || _Int_Sw == 8)
                    {
                        _Str_Mensaje = "N/C. Coloque el formato de hoja debido para este documento.";
                        MessageBox.Show("Se va a proceder a Imprimir las " + _Str_Mensaje, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //_Mtd_Imprimir();
                        _Bt_Imprimir.Enabled = false;
                        _Mtd_ImprimirNCcxc();
                    }
                    else if (_Int_Sw == 2)
                    {
                        _Str_Mensaje = "N/D. Coloque el formato de hoja debido para este documento.";
                        MessageBox.Show("Se va a proceder a Imprimir las " + _Str_Mensaje, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        _Bt_Imprimir.Enabled = false;
                        _Mtd_ImprimirNDcxc();
                        //_Mtd_Imprimir();
                    }
                    else if (_Int_Sw == 3)
                    {
                        _Str_Mensaje = "FACTURAS. Coloque el formato de hoja debido para este documento.";
                        MessageBox.Show("Se va a proceder a Imprimir las " + _Str_Mensaje, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //_Mtd_Imprimir();
                        _Bt_Imprimir.Enabled = false;
                    }
                    else if (_Int_Sw == 4)
                    {//NC por aprobar
                        if (_MyUtilidad._Mtd_UsuarioProceso(Frm_Padre._Str_Use, "F_N2_NC_CXC"))
                        {
                            if (_Bol_Rechazar)
                            {
                                string _Str_Sql = "UPDATE TNOTACREDICCTEMP SET cestatusfirma='9',cdateupd='" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ()) + "',cuserupd='" + Frm_Padre._Str_Use + "' WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cidnotcredicctemp='" + Convert.ToString(_Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells["Documento"].Value).ToString().Trim() + "'";
                                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
                                _Str_Sql = "SELECT cidnotcredicc FROM TNOTACREDICCTEMP WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cidnotcredicctemp='" + Convert.ToString(_Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells["Documento"].Value).ToString().Trim() + "' AND ISNULL(cidnotcredicc,0)>0";
                                DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
                                if (_Ds.Tables[0].Rows.Count > 0)
                                {
                                    _Str_Sql = "UPDATE TNOTACREDICC SET cestatusfirma='9',cdateupd='" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ()) + "',cuserupd='" + Frm_Padre._Str_Use + "' WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cidnotcredicc='" + _Ds.Tables[0].Rows[0][0].ToString() + "'";
                                    Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
                                }
                                _Mtd_Actualizar(_Int_Sw, _Tool_Consulta.Text, _Int_Seleccion, _Str_Factura);
                                if ((Frm_Padre)this.MdiParent != null)
                                {
                                    System.Threading.ThreadPool.QueueUserWorkItem(((Frm_Padre)this.MdiParent)._Frm_Contenedor._async_Default);
                                }
                                MessageBox.Show("Nota de crédito rechazada.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                string _Str_Sql = "";
                                foreach (DataGridViewRow _DgRow in _Dg_Grid.Rows)
                                {
                                    if (Convert.ToString(_DgRow.Cells["Imprimir"].Value).Trim() == "1")
                                    {
                                        try
                                        {
                                            _Str_Sql = "SELECT cidnotcredicc FROM TNOTACREDICCTEMP WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cidnotcredicctemp='" + Convert.ToString(_DgRow.Cells["Documento"].Value) + "' AND ISNULL(cidnotcredicc,0)>0";
                                            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
                                            if (_Ds.Tables[0].Rows.Count > 0)
                                            {
                                                //Si da algún error se actualiza primero en cestatusfirma=2 para que no quede pendiente y se pueda resolver.
                                                _Str_Sql = "UPDATE TNOTACREDICCTEMP SET cestatusfirma=2,cdateupd='" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ()) + "',cuserupd='" + Frm_Padre._Str_Use + "' WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cidnotcredicctemp='" + Convert.ToString(_DgRow.Cells["Documento"].Value) + "'";
                                                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
                                                _Str_Sql = "UPDATE TNOTACREDICC SET cestatusfirma='2',cdateupd='" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ()) + "',cuserupd='" + Frm_Padre._Str_Use + "' WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cidnotcredicc='" + _Ds.Tables[0].Rows[0][0].ToString() + "'";
                                                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
                                            }
                                            else
                                            {
                                                //Si da algún error se actualiza primero en cestatusfirma=2 para que no quede pendiente y se pueda resolver.
                                                string _Str_ID_NC = _MyUtilidad._Mtd_Correlativo("SELECT MAX(cidnotcredicc) FROM TNOTACREDICC WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "'");
                                                _Str_Sql = "UPDATE TNOTACREDICCTEMP SET cestatusfirma=2,cidnotcredicc='" + _Str_ID_NC + "',cdateupd='" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ()) + "',cuserupd='" + Frm_Padre._Str_Use + "' WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cidnotcredicctemp='" + Convert.ToString(_DgRow.Cells["Documento"].Value) + "'";
                                                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
                                                _Str_Sql = "INSERT INTO TNOTACREDICC (cgroupcomp,ccompany,cidnotcredicc,ccliente,ctipodocument,cnumdocu,cfecha,cdescripcion,cmontototsi,cimpuesto,ctotaldocu,cidmotivo,cdateadd,cuseradd,cvendedor,cvendedorc,cgerarea,calicuota,cexedentecobro,cexento,cdelete,cdescontada,cactivo,cimpresa,cmanual,cestatusfirma,cdateupd,cuserupd) " +
                                                "SELECT cgroupcomp,ccompany," + _Str_ID_NC + ",ccliente,ctipodocument,cnumdocu,cfecha,cdescripcion,cmontototsi,cimpuesto,ctotaldocu,cidmotivo,cdateadd,cuseradd,cvendedor,cvendedorc,cgerarea,calicuota,cexedentecobro,cexento,0,0,0,0,1,2,cdateupd,cuserupd FROM TNOTACREDICCTEMP WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cidnotcredicctemp='" + Convert.ToString(_DgRow.Cells["Documento"].Value) + "'";
                                                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
                                            }
                                        }
                                        catch (Exception _Ex)
                                        {
                                            MessageBox.Show("Problemas al aprobar la NC " + Convert.ToString(_DgRow.Cells["Documento"].Value) + "." + _Ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                        }
                                    }
                                }
                                _Mtd_Actualizar(_Int_Sw, _Tool_Consulta.Text, _Int_Seleccion, _Str_Factura);
                                _Bt_Imprimir.Enabled = false;
                                if ((Frm_Padre)this.MdiParent != null)
                                {
                                    System.Threading.ThreadPool.QueueUserWorkItem(((Frm_Padre)this.MdiParent)._Frm_Contenedor._async_Default);
                                }
                                this.Close();
                            }
                        }
                        else
                        {
                            MessageBox.Show("Usted no tiene permisos para realizar esta operación.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else if (_Int_Sw == 6)
                    {//NC por aprobar
                        if (_MyUtilidad._Mtd_UsuarioProceso(Frm_Padre._Str_Use, "F_N2_ND_CXC"))
                        {
                            if (_Bol_Rechazar)
                            {
                                string _Str_Sql = "UPDATE TNOTADEBICCTEMP SET cestatusfirma='9',cdateupd='" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ()) + "',cuserupd='" + Frm_Padre._Str_Use + "' WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cidnotadebitocctemp='" + Convert.ToString(_Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells["Documento"].Value).ToString().Trim() + "'";
                                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
                                _Str_Sql = "SELECT cidnotadebitocc FROM TNOTADEBICCTEMP WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cidnotadebitocctemp='" + Convert.ToString(_Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells["Documento"].Value).ToString().Trim() + "' AND ISNULL(cidnotadebitocc,0)>0";
                                DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
                                if (_Ds.Tables[0].Rows.Count > 0)
                                {
                                    _Str_Sql = "UPDATE TNOTADEBICC SET cestatusfirma='9',cdateupd='" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ()) + "',cuserupd='" + Frm_Padre._Str_Use + "' WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cidnotadebitocc='" + _Ds.Tables[0].Rows[0][0].ToString() + "'";
                                    Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
                                }
                                _Mtd_Actualizar(_Int_Sw, _Tool_Consulta.Text, _Int_Seleccion, _Str_Factura);
                                if ((Frm_Padre)this.MdiParent != null)
                                {
                                    System.Threading.ThreadPool.QueueUserWorkItem(((Frm_Padre)this.MdiParent)._Frm_Contenedor._async_Default);
                                }
                                MessageBox.Show("Nota de débito rechazada.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                string _Str_Sql = "";
                                foreach (DataGridViewRow _DgRow in _Dg_Grid.Rows)
                                {
                                    if (Convert.ToString(_DgRow.Cells["Imprimir"].Value).Trim() == "1")
                                    {
                                        try
                                        {
                                            _Str_Sql = "SELECT cidnotadebitocc FROM TNOTADEBICCTEMP WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cidnotadebitocctemp='" + Convert.ToString(_DgRow.Cells["Documento"].Value) + "' AND ISNULL(cidnotadebitocc,0)>0";
                                            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
                                            if (_Ds.Tables[0].Rows.Count > 0)
                                            {
                                                //Si da algún error se actualiza primero en cestatusfirma=2 para que no quede pendiente y se pueda resolver.
                                                _Str_Sql = "UPDATE TNOTADEBICCTEMP SET cestatusfirma=2,cdateupd='" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ()) + "',cuserupd='" + Frm_Padre._Str_Use + "' WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cidnotadebitocctemp='" + Convert.ToString(_DgRow.Cells["Documento"].Value) + "'";
                                                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
                                                _Str_Sql = "UPDATE TNOTADEBICC SET cestatusfirma=2,cdateupd='" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ()) + "',cuserupd='" + Frm_Padre._Str_Use + "' WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cidnotadebitocc='" + _Ds.Tables[0].Rows[0][0].ToString() + "'";
                                                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
                                            }
                                            else
                                            {
                                                //Si da algún error se actualiza primero en cestatusfirma=2 para que no quede pendiente y se pueda resolver.
                                                string _Str_ID_ND = _MyUtilidad._Mtd_Correlativo("SELECT MAX(cidnotadebitocc) FROM TNOTADEBICC WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "'");
                                                _Str_Sql = "EXEC PA_INSERTARNDTEMPAFINAL '" + Convert.ToString(_DgRow.Cells["Documento"].Value) + "','" + Frm_Padre._Str_Comp + "','" + Frm_Padre._Str_GroupComp + "','" + _Str_ID_ND + "'";
                                                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
                                            }
                                        }
                                        catch (Exception _Ex)
                                        {
                                            MessageBox.Show("Problemas al aprobar la ND " + Convert.ToString(_DgRow.Cells["Documento"].Value) + "." + _Ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                        }
                                    }
                                }
                                _Mtd_Actualizar(_Int_Sw, _Tool_Consulta.Text, _Int_Seleccion, _Str_Factura);
                                _Bt_Imprimir.Enabled = false;
                                if ((Frm_Padre)this.MdiParent != null)
                                {
                                    System.Threading.ThreadPool.QueueUserWorkItem(((Frm_Padre)this.MdiParent)._Frm_Contenedor._async_Default);
                                }
                                this.Close();
                            }
                        }
                        else
                        {
                            MessageBox.Show("Usted no tiene permisos para realizar esta operación.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else if (_Int_Sw == 9)
                    { //NR Por Imprimir
                        _Str_Mensaje = "NR. Coloque el formato de hoja debido para este documento.";
                        MessageBox.Show("Se va a proceder a Imprimir las " + _Str_Mensaje, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        _Mtd_ImprimirNR();
                        _Bt_Imprimir.Enabled = false;
                    }
                    else if (_Int_Sw == 10)
                    {//ND por aprobar
                        if (_MyUtilidad._Mtd_UsuarioProceso(Frm_Padre._Str_Use, "F_N2_ND_CXP"))
                        {
                            if (_Bol_Rechazar)
                            {
                                string _Str_Sql = "UPDATE TNOTADEBITOCPTEMP SET cestatusfirma='9',cdateupd='" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ()) + "',cuserupd='" + Frm_Padre._Str_Use + "' WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cidnotadebitocxptemp='" + Convert.ToString(_Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells["Documento"].Value).ToString().Trim() + "'";
                                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
                                _Str_Sql = "SELECT cidnotadebitocxp FROM TNOTADEBITOCPTEMP WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cidnotadebitocxptemp='" + Convert.ToString(_Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells["Documento"].Value).ToString().Trim() + "' AND ISNULL(cidnotadebitocxp,0)>0";
                                DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
                                if (_Ds.Tables[0].Rows.Count > 0)
                                {
                                    _Str_Sql = "UPDATE TNOTADEBITOCP SET cestatusfirma='9',cdateupd='" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ()) + "',cuserupd='" + Frm_Padre._Str_Use + "' WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cidnotadebitocxp='" + _Ds.Tables[0].Rows[0][0].ToString() + "'";
                                    Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
                                }
                                _Mtd_Actualizar(_Int_Sw, _Tool_Consulta.Text, _Int_Seleccion, _Str_Factura);
                                if ((Frm_Padre)this.MdiParent != null)
                                {
                                    System.Threading.ThreadPool.QueueUserWorkItem(((Frm_Padre)this.MdiParent)._Frm_Contenedor._async_Default);
                                }
                                MessageBox.Show("Nota de débito rechazada.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                string _Str_Sql = "";
                                foreach (DataGridViewRow _DgRow in _Dg_Grid.Rows)
                                {
                                    if (Convert.ToString(_DgRow.Cells["Imprimir"].Value).Trim() == "1")
                                    {
                                        try
                                        {
                                            _Str_Sql = "SELECT cidnotadebitocxp FROM TNOTADEBITOCPTEMP WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cidnotadebitocxptemp='" + Convert.ToString(_DgRow.Cells["Documento"].Value) + "' AND ISNULL(cidnotadebitocxp,0)>0";
                                            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
                                            if (_Ds.Tables[0].Rows.Count > 0)
                                            {
                                                //Si da algún error se actualiza primero en cestatusfirma=2 para que no quede pendiente y se pueda resolver.
                                                _Str_Sql = "UPDATE TNOTADEBITOCPTEMP SET cestatusfirma=2,cdateupd='" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ()) + "',cuserupd='" + Frm_Padre._Str_Use + "' WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cidnotadebitocxptemp='" + Convert.ToString(_DgRow.Cells["Documento"].Value) + "'";
                                                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
                                                _Str_Sql = "UPDATE TNOTADEBITOCP SET cestatusfirma=2,cdateupd='" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ()) + "',cuserupd='" + Frm_Padre._Str_Use + "' WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cidnotadebitocxp='" + _Ds.Tables[0].Rows[0][0].ToString() + "'";
                                                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
                                            }
                                            else
                                            {
                                                //Si da algún error se actualiza primero en cestatusfirma=2 para que no quede pendiente y se pueda resolver.
                                                string _Str_ID_ND = _MyUtilidad._Mtd_Correlativo("SELECT MAX(cidnotadebitocxp) FROM TNOTADEBITOCP WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "'");
                                                _Str_Sql = "UPDATE TNOTADEBITOCPTEMP SET cestatusfirma=2,cidnotadebitocxp='" + _Str_ID_ND + "',cdateupd='" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ()) + "',cuserupd='" + Frm_Padre._Str_Use + "' WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cidnotadebitocxptemp='" + Convert.ToString(_DgRow.Cells["Documento"].Value) + "'";
                                                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
                                                _Str_Sql = "INSERT INTO TNOTADEBITOCP (ccompany,cgroupcomp,cidnotadebitocxp,cnumcontrolnd,cproveedor,ctipodocument,cnumdocu,cfechand,cdescripcion,cmontototsi,cimpuesto,ctotaldocu,cporcinvendible,cbasegrabada,cidnotrecepc,cidmotivo,cdateadd,cuseradd,calicuota,cbaseexcenta,cdescfinanporc,cdescfinanmonto,cdescfinanmontobexcenta,cdescfinanmontobgrabada,cdescontada,canulado,cidcomprob,cactivo,cimpresa,cdelete,cmanual,cestatusfirma,cdateupd,cuserupd) " +
                                                                             "SELECT ccompany,cgroupcomp," + _Str_ID_ND + ",cnumcontrolnd,cproveedor,ctipodocument,cnumdocu,cfechand,cdescripcion,cmontototsi,cimpuesto,ctotaldocu,cporcinvendible,cbasegrabada,cidnotrecepc,cidmotivo,cdateadd,cuseradd,calicuota,cbaseexcenta,cdescfinanporc,cdescfinanmonto,cdescfinanmontobexcenta,cdescfinanmontobgrabada,0,0,0,0,0,0,1,2,cdateupd,cuserupd FROM TNOTADEBITOCPTEMP WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cidnotadebitocxptemp='" + Convert.ToString(_DgRow.Cells["Documento"].Value) + "'";
                                                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
                                            }
                                        }
                                        catch (Exception _Ex)
                                        {
                                            MessageBox.Show("Problemas al aprobar la ND " + Convert.ToString(_DgRow.Cells["Documento"].Value) + "." + _Ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                        }
                                    }
                                }
                                _Mtd_Actualizar(_Int_Sw, _Tool_Consulta.Text, _Int_Seleccion, _Str_Factura);
                                _Bt_Imprimir.Enabled = false;
                                if ((Frm_Padre)this.MdiParent != null)
                                {
                                    System.Threading.ThreadPool.QueueUserWorkItem(((Frm_Padre)this.MdiParent)._Frm_Contenedor._async_Default);
                                }
                                this.Close();
                            }
                        }
                    }
                    else if (_Int_Sw == 11)
                    {//NC por aprobar
                        if (_MyUtilidad._Mtd_UsuarioProceso(Frm_Padre._Str_Use, "F_N2_NC_CXP"))
                        {
                            if (_Bol_Rechazar)
                            {
                                string _Str_Sql = "UPDATE TNOTACREDICPTEMP SET cestatusfirma='9',cdateupd='" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ()) + "',cuserupd='" + Frm_Padre._Str_Use + "' WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cidnotacreditocxptemp='" + Convert.ToString(_Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells["Documento"].Value).ToString().Trim() + "'";
                                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
                                _Str_Sql = "SELECT cidnotacreditocxp FROM TNOTACREDICPTEMP WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cidnotacreditocxptemp='" + Convert.ToString(_Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells["Documento"].Value).ToString().Trim() + "' AND ISNULL(cidnotacreditocxp,0)>0";
                                DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
                                if (_Ds.Tables[0].Rows.Count > 0)
                                {
                                    _Str_Sql = "UPDATE TNOTACREDICP SET cestatusfirma='9',cdateupd='" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ()) + "',cuserupd='" + Frm_Padre._Str_Use + "' WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cidnotacreditocxp='" + _Ds.Tables[0].Rows[0][0].ToString() + "'";
                                    Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
                                }
                                _Mtd_Actualizar(_Int_Sw, _Tool_Consulta.Text, _Int_Seleccion, _Str_Factura);
                                if ((Frm_Padre)this.MdiParent != null)
                                {
                                    System.Threading.ThreadPool.QueueUserWorkItem(((Frm_Padre)this.MdiParent)._Frm_Contenedor._async_Default);
                                }
                                MessageBox.Show("Nota de crédito rechazada.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                string _Str_Sql = "";
                                foreach (DataGridViewRow _DgRow in _Dg_Grid.Rows)
                                {
                                    if (Convert.ToString(_DgRow.Cells["Imprimir"].Value).Trim() == "1")
                                    {
                                        try
                                        {
                                            _Str_Sql = "SELECT cidnotacreditocxp FROM TNOTACREDICPTEMP WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cidnotacreditocxptemp='" + Convert.ToString(_DgRow.Cells["Documento"].Value) + "' AND ISNULL(cidnotacreditocxp,0)>0";
                                            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
                                            if (_Ds.Tables[0].Rows.Count > 0)
                                            {
                                                //Si da algún error se actualiza primero en cestatusfirma=2 para que no quede pendiente y se pueda resolver.
                                                _Str_Sql = "UPDATE TNOTACREDICPTEMP SET cestatusfirma=2,cdateupd='" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ()) + "',cuserupd='" + Frm_Padre._Str_Use + "' WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cidnotacreditocxptemp='" + Convert.ToString(_DgRow.Cells["Documento"].Value) + "'";
                                                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
                                                _Str_Sql = "UPDATE TNOTACREDICP SET cestatusfirma=2,cdateupd='" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ()) + "',cuserupd='" + Frm_Padre._Str_Use + "' WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cidnotacreditocxp='" + _Ds.Tables[0].Rows[0][0].ToString() + "'";
                                                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
                                            }
                                            else
                                            {
                                                //Si da algún error se actualiza primero en cestatusfirma=2 para que no quede pendiente y se pueda resolver.
                                                string _Str_ID_NC = _MyUtilidad._Mtd_Correlativo("SELECT MAX(cidnotacreditocxp) FROM TNOTACREDICP WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "'");
                                                _Str_Sql = "UPDATE TNOTACREDICPTEMP SET cestatusfirma=2,cidnotacreditocxp='" + _Str_ID_NC + "',cdateupd='" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ()) + "',cuserupd='" + Frm_Padre._Str_Use + "' WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cidnotacreditocxptemp='" + Convert.ToString(_DgRow.Cells["Documento"].Value) + "'";
                                                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
                                                _Str_Sql = "INSERT INTO TNOTACREDICP (ccompany,cgroupcomp,cidnotacreditocxp,cnumcontrolnc,cproveedor,ctipodocument,cnumdocu,cfechanc,cdescripcion,cmontototsi,cimpuesto,ctotaldocu,cporcinvendible,cbasegrabada,cidnotrecepc,cidmotivo,cdateadd,cuseradd,calicuota,cbaseexcenta,cdescfinanporc,cdescfinanmonto,cdescfinanmontobexcenta,cdescfinanmontobgrabada,cdescontada,canulado,cidcomprob,cactivo,cimpresa,cdelete,cmanual,cestatusfirma,cdateupd,cuserupd) " +
                                                                             "SELECT ccompany,cgroupcomp," + _Str_ID_NC + ",cnumcontrolnc,cproveedor,ctipodocument,cnumdocu,cfechanc,cdescripcion,cmontototsi,cimpuesto,ctotaldocu,cporcinvendible,cbasegrabada,cidnotrecepc,cidmotivo,cdateadd,cuseradd,calicuota,cbaseexcenta,cdescfinanporc,cdescfinanmonto,cdescfinanmontobexcenta,cdescfinanmontobgrabada,0,0,0,0,0,0,1,2,cdateupd,cuserupd FROM TNOTACREDICPTEMP WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cidnotacreditocxptemp='" + Convert.ToString(_DgRow.Cells["Documento"].Value) + "'";
                                                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
                                            }
                                        }
                                        catch (Exception _Ex)
                                        {
                                            MessageBox.Show("Problemas al aprobar la ND " + Convert.ToString(_DgRow.Cells["Documento"].Value) + "." + _Ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                        }
                                    }
                                }
                                _Mtd_Actualizar(_Int_Sw, _Tool_Consulta.Text, _Int_Seleccion, _Str_Factura);
                                _Bt_Imprimir.Enabled = false;
                                if ((Frm_Padre)this.MdiParent != null)
                                {
                                    System.Threading.ThreadPool.QueueUserWorkItem(((Frm_Padre)this.MdiParent)._Frm_Contenedor._async_Default);
                                }
                                this.Close();
                            }
                        }
                    }
                    else if (_Int_Sw == 12)
                    {
                        MessageBox.Show("Se va a proceder a imprimir el comprobante contable.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        if (_Mtd_GenerarComprobanteCheqDev())
                        {
                            MessageBox.Show("La operación ha sido realizada correctamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            _Mtd_Actualizar(_Int_Sw, _Tool_Consulta.Text, _Int_Seleccion,"");
                            if (_Dg_Grid.RowCount == 0) { this.Close(); }
                        }
                    }
                    else if (_Int_Sw == 13)
                    {
                        if (_Bol_Rechazar)
                        {
                            string _Str_Sql = "UPDATE TNOTACREDICC SET cmotivoanulacion=null,cfechaanul=null WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and ccompany='" + Frm_Padre._Str_Comp + "' and cidnotcredicc='" + Convert.ToString(_Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells["Documento"].Value).ToString().Trim() + "'";
                            Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
                            _Str_Sql = "DELETE FROM TNCANUL WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cidnotcredit='" + Convert.ToString(_Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells["Documento"].Value).ToString().Trim() + "'";
                            Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
                            _Mtd_Actualizar(_Int_Sw, _Tool_Consulta.Text, _Int_Seleccion, _Str_Factura);
                            if ((Frm_Padre)this.MdiParent != null)
                            {
                                System.Threading.ThreadPool.QueueUserWorkItem(((Frm_Padre)this.MdiParent)._Frm_Contenedor._async_Default);
                            }
                            MessageBox.Show("Anulación de NC rechazada.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            if (_Mtd_ImprimirComprobantes_NC_CxC_ANUL())
                            {
                                MessageBox.Show("La anulación ha sido realizada correctamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                _Mtd_Actualizar(_Int_Sw, _Tool_Consulta.Text, _Int_Seleccion, "");
                                if ((Frm_Padre)this.MdiParent != null)
                                {
                                    System.Threading.ThreadPool.QueueUserWorkItem(((Frm_Padre)this.MdiParent)._Frm_Contenedor._async_Default);
                                }
                                if (_Dg_Grid.RowCount == 0)
                                { this.Close(); }
                            }
                        }
                    }
                    else if (_Int_Sw == 14)
                    {
                        if (!_Mtd_VerificarEgresosEliminados())
                        {
                            MessageBox.Show("Se va a proceder a imprimir el comprobante contable.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            if (_Mtd_GenerarComprobanteEgreCheq())
                            {
                                MessageBox.Show("La operación ha sido realizada correctamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                _Mtd_Actualizar(_Int_Sw, _Tool_Consulta.Text, _Int_Seleccion, "");
                                if (_Dg_Grid.RowCount == 0) { this.Close(); }
                            }
                        }
                        else
                        {
                            MessageBox.Show("Uno o mas egresos han sido eliminados por otro usuario. La consulta se va a ejecutar nuevamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            _Mtd_Actualizar(_Int_Sw, _Tool_Consulta.Text, _Int_Seleccion, "");
                        }
                    }
                }
                else { MessageBox.Show(this, "Clave incorrecta!!!", "Verificar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); _Txt_Clave.Focus(); _Txt_Clave.Select(0, _Txt_Clave.Text.Length); }
            }
            catch (Exception _Ex)
            {
                MessageBox.Show(_Ex.Message);
                Cursor = Cursors.Default;
            }
        }

        private void _Bt_Actualizar_Click(object sender, EventArgs e)
        {
            _Bol_Rechazar = false;
            Cursor = Cursors.WaitCursor;
            if (_Int_Sw == 4)
            {//NC POR APROBAR
                if (_Mtd_Seleccionar())
                {
                    _Pnl_Clave.Visible = true;
                }
                else
                { 
                    MessageBox.Show("No se han seleccionado documentos", "Requerimiento", MessageBoxButtons.OK, MessageBoxIcon.Asterisk); 
                }
            }
            else if (_Int_Sw == 5 || _Int_Sw == 7)
            {
                if (_Mtd_VerificarImpresos())
                {
                    _Mtd_ActualizarNumeros();
                    _Mtd_Actualizar(_Int_Sw, _Tool_Consulta.Text, _Int_Seleccion, _Str_Factura);
                    MessageBox.Show("La operación fue realizada correctamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (_Dg_Grid.Rows.Count == 0)
                    { this.Close(); }
                }
                else
                {
                    _Pnl_Numero.Visible = true;
                }
            }
            else if (_Int_Sw == 6)
            {
                //ND POR APROBAR
                if (_Mtd_Seleccionar())
                {
                    _Pnl_Clave.Visible = true;
                }
                else
                {
                    MessageBox.Show("No se han seleccionado documentos", "Requerimiento", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
            }
            else if (_Int_Sw == 10)
            {//ND POR APROBAR A PROVEEDORES
                if (_Mtd_Seleccionar())
                {
                    _Pnl_Clave.Visible = true;
                }
                else
                {
                    MessageBox.Show("No se han seleccionado documentos", "Requerimiento", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
            }
            else if (_Int_Sw == 11)
            {//NC POR APROBAR A PROVEEDORES
                if (_Mtd_Seleccionar())
                {
                    _Pnl_Clave.Visible = true;
                }
                else
                {
                    MessageBox.Show("No se han seleccionado documentos", "Requerimiento", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
            }
            else
            {
                if (_Mtd_VerificarImpresos())
                {
                    _Mtd_ActualizarNumeros();
                    _Mtd_Actualizar(_Int_Sw, _Tool_Consulta.Text, _Int_Seleccion, _Str_Factura);
                    MessageBox.Show("La operación fue realizada correctamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (_Dg_Grid.Rows.Count == 0)
                    { this.Close(); }
                    else
                    {
                        if (_Int_Sw == 3)
                        { _Bt_Imprimir.Enabled = false; }
                        else
                        { _Bt_Imprimir.Enabled = true; }
                        _Bt_Actualizar.Enabled = false;
                    }
                }
                else
                { MessageBox.Show("Existen documentos seleccionados sin Nº de control. Por favor verifique.", "Requerimiento", MessageBoxButtons.OK, MessageBoxIcon.Asterisk); }
            }
            
            Cursor = Cursors.Default;
        }
        bool _Bol_Boleano = false;
        private void _Dg_Grid_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (!_Bol_Boleano)
            {
                e.Control.KeyPress += new KeyPressEventHandler(Control_KeyPress);
                e.Control.TextChanged += new EventHandler(Control_TextChanged);
                _Bol_Boleano = true;
            }
        }
        void Control_TextChanged(object sender, EventArgs e)
        {
            if (_Dg_Grid.Columns[_Dg_Grid.CurrentCell.ColumnIndex].Name.Trim() == "Numero")
            {
                if (!_Mtd_IsNumeric(((TextBox)sender).Text) || ((TextBox)sender).Text.Trim().Length > 9)
                {
                    ((TextBox)sender).Text = "";
                }
            }
        }

        void Control_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (_Dg_Grid.Columns[_Dg_Grid.CurrentCell.ColumnIndex].Name.Trim() == "Numero")
            {
                if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8)
                {
                    e.Handled = true;
                }
            }
        }

        private void _Tool_Seleccionar_Click(object sender, EventArgs e)
        {
            _Int_Seleccion = 1;
            Cursor = Cursors.WaitCursor;
            _Mtd_Actualizar(_Int_Sw, _Tool_Consulta.Text, _Int_Seleccion, _Str_Factura);
            Cursor = Cursors.Default;
        }

        private void _Tool_Quitar_Click(object sender, EventArgs e)
        {
            _Int_Seleccion = 0;
            Cursor = Cursors.WaitCursor;
            _Mtd_Actualizar(_Int_Sw, _Tool_Consulta.Text, _Int_Seleccion, _Str_Factura);
            Cursor = Cursors.Default;
        }

        private void _Tool_NumeroControl_Click(object sender, EventArgs e)
        {
            if (_Mtd_Seleccionar())
            {
                _Pnl_Numero.Visible = true; ;
            }
            else
            { MessageBox.Show("No se han seleccionado documentos", "Requerimiento", MessageBoxButtons.OK, MessageBoxIcon.Asterisk); }
        }

        private void Frm_ImpresionLote_FormClosing(object sender, FormClosingEventArgs e)
        {
            GC.Collect();
        }

        private void _Bt_AddNumDoc_Click(object sender, EventArgs e)
        {
            if (_Txt_NumDoc.Text.Trim().Length > 0)
            {
                bool _Bol_FacturaExisGrid = _Mtd_FacturaExistente(_Txt_NumDoc.Text);
                int _Int_FacturaExisList = _LstBox_DocPrint.FindStringExact(_Txt_NumDoc.Text.Trim());
                bool _Bol_FacturaMarcada = _Mtd_FacturaMarcada(_Txt_NumDoc.Text);
                if (_Int_FacturaExisList == -1 & _Bol_FacturaExisGrid & _Bol_FacturaMarcada)
                {
                    _LstBox_DocPrint.Items.Add(_Txt_NumDoc.Text.Trim());
                }
                else
                {
                    if (_Int_FacturaExisList > -1)
                    { MessageBox.Show("Este número de documento ya fue cargado en la lista.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
                    else if (!_Bol_FacturaExisGrid)
                    { MessageBox.Show("Este número de documento no existe.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
                    else
                    { MessageBox.Show("Este número de documento no fue previamente marcado.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
                }
            }
        }

        private void _Bt_RestNumDoc_Click(object sender, EventArgs e)
        {
            if (_LstBox_DocPrint.SelectedIndex>-1)
            {
                _LstBox_DocPrint.Items.RemoveAt(_LstBox_DocPrint.SelectedIndex);
            }
        }

        private void _LstBox_DocPrint_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_LstBox_DocPrint.SelectedIndex > -1)
            {
                _Txt_NumDoc.Text = _LstBox_DocPrint.Items[_LstBox_DocPrint.SelectedIndex].ToString();
            }
        }
        private bool _Mtd_ReImprimir()
        {
            bool _Bol_R = false;
            string[] _Str_ND_ = new string[0];
            if (_Int_Sw == 1 || _Int_Sw == 8)
            {//NC
                _Mtd_ImprimirNCcxc();
            }
            else if (_Int_Sw == 2)
            {//ND
                _Mtd_ImprimirNDcxc();
            }
            else if (_Int_Sw == 9)
            {//NR
                _Mtd_ImprimirNR();
            }
            if (MessageBox.Show("Se imprimio correctamente los documentos?", "Confirme", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                _Bol_R = true;
            }
            return _Bol_R;
        }
        private bool _Mtd_FacturaExistente(string _P_Str_NumFactura)
        {
            DataView _Dtv = new DataView(((DataTable)_Dg_Grid.DataSource).DataSet.Tables[0]);
            _Dtv.RowFilter = "Documento='" + _P_Str_NumFactura + "'";
            if (_Dtv.Count > 0)
            {
                return true;
            }
            return false;
        }
        private bool _Mtd_FacturaMarcada(string _P_Str_NumFactura)
        {
            DataView _Dtv = new DataView(((DataTable)_Dg_Grid.DataSource).DataSet.Tables[0]);
            _Dtv.RowFilter = "Documento='" + _P_Str_NumFactura + "'";
            if (_Dtv.Count > 0)
            {
                return (_Dtv[0].Row["Imprimir"].ToString().Trim() == "1");
            }
            return false;
        }
        private void _Bt_ReImprime_Click(object sender, EventArgs e)
        {
            try
            {
                if (_LstBox_DocPrint.Items.Count > 0)
                {
                    if (_Int_Sw == 1 || _Int_Sw == 8)
                    {//NC
                        _Mtd_ImprimirNCcxc();
                    }
                    else if (_Int_Sw == 2)
                    {//ND
                        _Mtd_ImprimirNDcxc();
                    }
                    else if (_Int_Sw == 9)
                    {//NR
                        _Mtd_ImprimirNR();
                    }
                    _Pnl_ReImpresion.Visible = false;
                }
            }
            catch (Exception _Ex)
            {
                MessageBox.Show(_Ex.Message);
                Cursor = Cursors.Default;
            }
        }

        private void _Pnl_ReImpresion_VisibleChanged(object sender, EventArgs e)
        {
            if (_Pnl_ReImpresion.Visible)
            {
                _Pnl_ReImpresion.BringToFront();
                _Tool_Principal.Enabled = false; _Dg_Grid.Enabled = false; _Pnl_Inferior.Enabled = false;
                _LstBox_DocPrint.Items.Clear();
                _Txt_NumDoc.Text = "";
                _Txt_NumDoc.Focus(); 
            }
            else
            {
                _Tool_Principal.Enabled = true; _Dg_Grid.Enabled = true; _Pnl_Inferior.Enabled = true; 
                
            }
        }

        private void _Txt_NumDoc_KeyPress(object sender, KeyPressEventArgs e)
        {
            _MyUtilidad._Mtd_Valida_Numeros(_Txt_NumDoc, e, 10, 0);
            int KeyAscii = Convert.ToInt32(e.KeyChar);
            if (KeyAscii == 13)
            {
                _Bt_AddNumDoc.PerformClick();
            }
        }

        private void _Bt_DesdeNumDoc_Click(object sender, EventArgs e)
        {
            if (_Txt_NumDoc.Text.Trim().Length > 0)
            {
                _LstBox_DocPrint.Items.Clear();
                foreach (DataGridViewRow _DgRow in _Dg_Grid.Rows)
                {
                    if (Convert.ToString(_DgRow.Cells["Imprimir"].Value) == "1")
                    {
                        if (Convert.ToInt32(_DgRow.Cells["Documento"].Value) >= Convert.ToInt32(_Txt_NumDoc.Text))
                        {
                            _LstBox_DocPrint.Items.Add(_DgRow.Cells["Documento"].Value.ToString());
                        }
                    }
                }
            }
            else
            {
                _Txt_NumDoc.Focus();
            }
        }
        private bool _Mtd_BuscarIguales(int _P_Int_Index,object _P_Ob_Valor)
        {
            foreach (DataGridViewRow _Dg_Row in _Dg_Grid.Rows)
            {
                if (_Dg_Row.Index != _P_Int_Index)
                {
                    if (Convert.ToString(_Dg_Row.Cells["Numero"].Value).Trim() == _P_Ob_Valor.ToString().Trim() & Convert.ToString(_Dg_Row.Cells["Imprimir"].Value) == "1")
                    { return true; }
                }
            }
            return false;
        }
        private void _Dg_Grid_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                if (_Dg_Grid.Columns[e.ColumnIndex].Name.Trim() == "Numero")
                {
                    if (_Dg_Grid.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
                    {
                        if (_Dg_Grid.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString().Trim().Length == 0)
                        {
                            _Dg_Grid.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = _Str_NumeroTemp;
                        }
                        else if (_Mtd_BuscarIguales(e.RowIndex, _Dg_Grid.Rows[e.RowIndex].Cells["Numero"].Value) & _Dg_Grid.Rows[e.RowIndex].Cells["Imprimir"].Value.ToString().Trim() == "1")
                        {
                            MessageBox.Show("El valor que introdujo ya existe", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            _Dg_Grid.Rows[e.RowIndex].Cells["Numero"].Value = _Str_NumeroTemp;
                        }
                        else
                        {
                            if (_Int_Sw == 3)
                            {
                                if (_Mtd_VerificarNumContrlMayorComp(_Str_CompFact,Convert.ToString(_Dg_Grid.Rows[e.RowIndex].Cells["Numero"].Value).Trim()) & _Dg_Grid.Rows[e.RowIndex].Cells["Imprimir"].Value.ToString().Trim() == "1")
                                {
                                    //MessageBox.Show("El número de control ya fue ingresado anteriormente. Por favor verifique...", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    _Dg_Grid.Rows[e.RowIndex].Cells["Numero"].Value = _Str_NumeroTemp;
                                }
                                else
                                {
                                    _Str_NumeroTemp = _Dg_Grid.Rows[e.RowIndex].Cells["Numero"].Value.ToString();
                                }
                            }
                            else
                            {
                                _Str_NumeroTemp = _Dg_Grid.Rows[e.RowIndex].Cells["Numero"].Value.ToString();
                            }
                        }
                    }
                    else
                    { _Dg_Grid.Rows[e.RowIndex].Cells["Numero"].Value = _Str_NumeroTemp; }
                }
            }
        }
        string _Str_NumeroTemp = "";
        private void _Dg_Grid_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                if (_Dg_Grid.Columns[e.ColumnIndex].Name.Trim() == "Numero")
                {
                    _Str_NumeroTemp = Convert.ToString(_Dg_Grid.Rows[e.RowIndex].Cells["Numero"].Value);
                }
            }
        }

        private void _Dg_Grid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex >= 0 & e.RowIndex >= 0)
            {
                if (_Dg_Grid.Columns[e.ColumnIndex].Name.Trim() == "Imprimir" & !_Dg_Grid.Columns["Imprimir"].ReadOnly)
                {
                    if (_Dg_Grid.Rows[e.RowIndex].Cells["Imprimir"].Value != null)
                    {
                        if (_Dg_Grid.Rows[e.RowIndex].Cells["Imprimir"].Value.ToString().Trim() == "1")
                        { 
                            _Dg_Grid.Rows[e.RowIndex].Cells["Imprimir"].Value = 0;
                            if (_Dg_Grid.Columns.IndexOf(Numero) != -1)
                            { _Dg_Grid.Rows[e.RowIndex].Cells["Numero"].Value = ""; }
                        }
                        else
                        { _Dg_Grid.Rows[e.RowIndex].Cells["Imprimir"].Value = 1; }
                        _Dg_Grid.EndEdit();
                    }
                }
            }
        }

        private void _Dg_Grid_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                if (_Dg_Grid.Columns[e.ColumnIndex].Name == "Numero")
                {
                    if (Convert.ToString(_Dg_Grid.Rows[e.RowIndex].Cells["Imprimir"].Value).Trim() == "1")
                    { _Dg_Grid.Rows[e.RowIndex].Cells["Numero"].ReadOnly = false; }
                    else
                    { _Dg_Grid.Rows[e.RowIndex].Cells["Numero"].ReadOnly = true; }
                }
            }
        }
        private DataSet _Mtd_DataSets(int _P_Int_Sw, string _P_Str_Ducumento)
        {
            string _Str_Cadena = "";
            if (_P_Int_Sw == 4)
            {
                if (_P_Str_Ducumento.Trim().Length == 0)
                { _Str_Cadena = "SELECT TDOCUMENT.cname as Tipo, TNOTACREDICCTEMP.cidnotcredicctemp as Documento, TNOTACREDICCTEMP.cdescripcion as Descripcion,TNOTACREDICCTEMP.cmontototsi + ISNULL(TNOTACREDICCTEMP.cexento,0) as Monto, TNOTACREDICCTEMP.cnumdocu AS Factura FROM TNOTACREDICCTEMP INNER JOIN TCONFIGCXC ON TNOTACREDICCTEMP.ccompany = TCONFIGCXC.ccompany INNER JOIN TDOCUMENT ON TCONFIGCXC.ctipdocnotcred = TDOCUMENT.ctdocument WHERE (TNOTACREDICCTEMP.cgroupcomp = '" + Frm_Padre._Str_GroupComp + "') AND (TNOTACREDICCTEMP.ccompany = '" + Frm_Padre._Str_Comp + "') AND (cestatusfirma=1) ORDER BY TNOTACREDICCTEMP.cidnotcredicctemp"; }
                else
                { _Str_Cadena = "SELECT TDOCUMENT.cname as Tipo, TNOTACREDICCTEMP.cidnotcredicctemp as Documento, TNOTACREDICCTEMP.cdescripcion as Descripcion,TNOTACREDICCTEMP.cmontototsi + ISNULL(TNOTACREDICCTEMP.cexento,0) as Monto, TNOTACREDICCTEMP.cnumdocu AS Factura FROM TNOTACREDICCTEMP INNER JOIN TCONFIGCXC ON TNOTACREDICCTEMP.ccompany = TCONFIGCXC.ccompany INNER JOIN TDOCUMENT ON TCONFIGCXC.ctipdocnotcred = TDOCUMENT.ctdocument WHERE (TNOTACREDICCTEMP.cgroupcomp = '" + Frm_Padre._Str_GroupComp + "') AND (TNOTACREDICCTEMP.ccompany = '" + Frm_Padre._Str_Comp + "') AND (cestatusfirma=1) AND (TNOTACREDICCTEMP.cidnotcredicctemp LIKE '" + _P_Str_Ducumento + "%') ORDER BY TNOTACREDICCTEMP.cidnotcredicctemp"; }
            }
            else if (_P_Int_Sw == 5)
            {//NC SIN NUMERO DE CONTROL
                if (_P_Str_Ducumento.Trim().Length == 0)
                { _Str_Cadena = "SELECT TDOCUMENT.cname AS Tipo, TNOTACREDICC.cidnotcredicc AS Documento, TNOTACREDICC.cdescripcion AS Descripcion, TNOTACREDICC.cnumdocu AS Factura, CONVERT(VARCHAR,TFACTURAM.c_fecha_factura,103) AS [Fecha Factura] FROM TNOTACREDICC INNER JOIN TCONFIGCXC ON TNOTACREDICC.ccompany = TCONFIGCXC.ccompany INNER JOIN TDOCUMENT ON TCONFIGCXC.ctipdocnotcred = TDOCUMENT.ctdocument INNER JOIN TFACTURAM ON TNOTACREDICC.cgroupcomp = TFACTURAM.cgroupcomp AND TNOTACREDICC.ccompany = TFACTURAM.ccompany AND TNOTACREDICC.cnumdocu = TFACTURAM.cfactura WHERE (TNOTACREDICC.cgroupcomp = '" + Frm_Padre._Str_GroupComp + "') AND (TNOTACREDICC.cdelete = '0') AND (TNOTACREDICC.cimpresa = 1) AND (TNOTACREDICC.cactivo = 1) AND (TNOTACREDICC.canulado = 0) AND (TNOTACREDICC.cnumcontrolnc = 0 OR TNOTACREDICC.cnumcontrolnc IS NULL) AND (TNOTACREDICC.ccompany = '" + Frm_Padre._Str_Comp + "') ORDER BY TNOTACREDICC.cidnotcredicc"; }
                else
                { _Str_Cadena = "SELECT TDOCUMENT.cname AS Tipo, TNOTACREDICC.cidnotcredicc AS Documento, TNOTACREDICC.cdescripcion AS Descripcion, TNOTACREDICC.cnumdocu AS Factura, CONVERT(VARCHAR,TFACTURAM.c_fecha_factura,103) AS [Fecha Factura] FROM TNOTACREDICC INNER JOIN TCONFIGCXC ON TNOTACREDICC.ccompany = TCONFIGCXC.ccompany INNER JOIN TDOCUMENT ON TCONFIGCXC.ctipdocnotcred = TDOCUMENT.ctdocument INNER JOIN TFACTURAM ON TNOTACREDICC.cgroupcomp = TFACTURAM.cgroupcomp AND TNOTACREDICC.ccompany = TFACTURAM.ccompany AND TNOTACREDICC.cnumdocu = TFACTURAM.cfactura WHERE (TNOTACREDICC.cgroupcomp = '" + Frm_Padre._Str_GroupComp + "') AND (TNOTACREDICC.cdelete = '0') AND (TNOTACREDICC.cimpresa = 1) AND (TNOTACREDICC.cactivo = 1) AND (TNOTACREDICC.canulado = 0) AND (TNOTACREDICC.cnumcontrolnc = 0 OR TNOTACREDICC.cnumcontrolnc IS NULL) AND (TNOTACREDICC.ccompany = '" + Frm_Padre._Str_Comp + "') AND (TNOTACREDICC.cidnotcredicc LIKE '" + _P_Str_Ducumento + "%') ORDER BY TNOTACREDICC.cidnotcredicc"; }
            }
            else if (_P_Int_Sw == 6)
            {
                if (_P_Str_Ducumento.Trim().Length == 0)
                { _Str_Cadena = "SELECT TDOCUMENT.cname as Tipo, TNOTADEBICCTEMP.cidnotadebitocctemp as Documento, TNOTADEBICCTEMP.cdescripcion as Descripcion, TNOTADEBICCTEMP.cmontototsi + ISNULL(TNOTADEBICCTEMP.cexento,0) as Monto,TNOTADEBICCTEMP.cnumdocu as [Doc. Afectado] FROM TNOTADEBICCTEMP INNER JOIN TCONFIGCXC ON TNOTADEBICCTEMP.ccompany = TCONFIGCXC.ccompany INNER JOIN TDOCUMENT ON TCONFIGCXC.ctipdocnotdeb = TDOCUMENT.ctdocument WHERE (TNOTADEBICCTEMP.cgroupcomp = '" + Frm_Padre._Str_GroupComp + "') AND (TNOTADEBICCTEMP.ccompany = '" + Frm_Padre._Str_Comp + "') AND (cestatusfirma=1) ORDER BY TNOTADEBICCTEMP.cidnotadebitocctemp"; }
                else
                { _Str_Cadena = "SELECT TDOCUMENT.cname as Tipo, TNOTADEBICCTEMP.cidnotadebitocctemp as Documento, TNOTADEBICCTEMP.cdescripcion as Descripcion, TNOTADEBICCTEMP.cmontototsi + ISNULL(TNOTADEBICCTEMP.cexento,0) as Monto,TNOTADEBICCTEMP.cnumdocu as [Doc. Afectado] FROM TNOTADEBICCTEMP INNER JOIN TCONFIGCXC ON TNOTADEBICCTEMP.ccompany = TCONFIGCXC.ccompany INNER JOIN TDOCUMENT ON TCONFIGCXC.ctipdocnotdeb = TDOCUMENT.ctdocument WHERE (TNOTADEBICCTEMP.cgroupcomp = '" + Frm_Padre._Str_GroupComp + "') AND (TNOTADEBICCTEMP.ccompany = '" + Frm_Padre._Str_Comp + "') AND (cestatusfirma=1) AND (TNOTADEBICCTEMP.cidnotadebitocctemp LIKE '" + _P_Str_Ducumento + "%') ORDER BY TNOTADEBICCTEMP.cidnotadebitocctemp"; }
            }
            else if (_P_Int_Sw == 7)
            {//ND SIN NUMERO DE CONTROL
                if (_P_Str_Ducumento.Trim().Length == 0)
                { _Str_Cadena = "SELECT TDOCUMENT.cname AS Tipo, TNOTADEBICC.cidnotadebitocc AS Documento, TNOTADEBICC.cdescripcion AS Descripcion, TNOTADEBICC.cnumdocu AS [Doc. Afectado] FROM TNOTADEBICC INNER JOIN TCONFIGCXC ON TNOTADEBICC.ccompany = TCONFIGCXC.ccompany INNER JOIN TDOCUMENT ON TCONFIGCXC.ctipdocnotdeb = TDOCUMENT.ctdocument WHERE (TNOTADEBICC.cgroupcomp = '" + Frm_Padre._Str_GroupComp + "') AND (TNOTADEBICC.cdelete = '0') AND (TNOTADEBICC.cimpresa = 1) AND (TNOTADEBICC.cactivo = 1) AND (TNOTADEBICC.canulado = 0) AND (TNOTADEBICC.cnumcontrolnd = 0 OR TNOTADEBICC.cnumcontrolnd IS NULL) AND (TNOTADEBICC.ccompany = '" + Frm_Padre._Str_Comp + "') ORDER BY TNOTADEBICC.cidnotadebitocc"; }
                else
                { _Str_Cadena = "SELECT TDOCUMENT.cname AS Tipo, TNOTADEBICC.cidnotadebitocc AS Documento, TNOTADEBICC.cdescripcion AS Descripcion, TNOTADEBICC.cnumdocu AS [Doc. Afectado] FROM TNOTADEBICC INNER JOIN TCONFIGCXC ON TNOTADEBICC.ccompany = TCONFIGCXC.ccompany INNER JOIN TDOCUMENT ON TCONFIGCXC.ctipdocnotdeb = TDOCUMENT.ctdocument WHERE (TNOTADEBICC.cgroupcomp = '" + Frm_Padre._Str_GroupComp + "') AND (TNOTADEBICC.cdelete = '0') AND (TNOTADEBICC.cimpresa = 1) AND (TNOTADEBICC.cactivo = 1) AND (TNOTADEBICC.canulado = 0) AND (TNOTADEBICC.cnumcontrolnd = 0 OR TNOTADEBICC.cnumcontrolnd IS NULL) AND (TNOTADEBICC.ccompany = '" + Frm_Padre._Str_Comp + "') AND (TNOTADEBICC.cidnotadebitocc LIKE '" + _P_Str_Ducumento + "%') ORDER BY TNOTADEBICC.cidnotadebitocc"; }
            }
            return Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
        }
        private string _Mtd_RetornarNombreHojaExcel(int _P_Int_Sw)
        {
            if (_P_Int_Sw == 4)
            {//NC POR APROBAR
                return "NC_POP_APROBAR " + CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate().Day.ToString() + "-" + DateTime.Now.Month.ToString() + "-" + DateTime.Now.Year.ToString();
            }
            else if (_P_Int_Sw == 5)
            {//NC SIN NUMERO DE CONTROL
                return "NC_SIN_NUM_CTRL " + CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate().Day.ToString() + "-" + DateTime.Now.Month.ToString() + "-" + DateTime.Now.Year.ToString();
            }
            else if (_P_Int_Sw == 6)
            {//ND POR APROBAR
                return "ND_POP_APROBAR " + CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate().Day.ToString() + "-" + DateTime.Now.Month.ToString() + "-" + DateTime.Now.Year.ToString();
            }
            else if (_P_Int_Sw == 7)
            {//ND SIN NUMERO DE CONTROL
                return "ND_SIN_NUM_CTRL " + CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate().Day.ToString() + "-" + DateTime.Now.Month.ToString() + "-" + DateTime.Now.Year.ToString();
            }
            return "";
        }
        private void _Bt_Exportar_Click(object sender, EventArgs e)
        {
            if (_Dg_Grid.RowCount > 0)
            {
                try
                {
                    if (_Sfd_1.ShowDialog() == DialogResult.OK)
                    {
                        Cursor = Cursors.WaitCursor;
                        Clases._Cls_ExcelUtilidades _MyExcel = new T3.Clases._Cls_ExcelUtilidades();
                        _MyExcel._Mtd_DatasetToExcel(_Mtd_DataSets(_Int_Sw, _Tool_Consulta.Text).Tables[0], _Sfd_1.FileName, _Mtd_RetornarNombreHojaExcel(_Int_Sw));
                        _MyExcel = null;
                        Cursor = Cursors.Default;
                    }
                }
                catch { Cursor = Cursors.Default; MessageBox.Show("Error al intentar exportar", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information); }
            }
        }

        private void _Cntx_Menu_Opening(object sender, CancelEventArgs e)
        {
            if (_Dg_Grid.Rows.Count == 0 | _Dg_Grid.CurrentCell == null)
            { e.Cancel = true; }
            else
            {
                if (_Dg_Grid.CurrentCell.RowIndex == -1 | _Dg_Grid.SelectedRows.Count == 0)
                { e.Cancel = true; }
                else
                {
                    if (_Int_Sw == 4 | _Int_Sw == 11)
                    { _Cntx_Menu_Rech.Text = "Rechazar NC"; }
                    else if (_Int_Sw == 6 | _Int_Sw == 10)
                    { _Cntx_Menu_Rech.Text = "Rechazar ND"; }
                    else if (_Int_Sw == 13)
                    { _Cntx_Menu_Rech.Text = "Rechazar anulación de NC"; }
                }
            }
        }

        bool _Bol_Rechazar = false;
        private void _Cntx_Menu_Rech_Click(object sender, EventArgs e)
        {
            string _Str_NDoNC = "";
            if (_Int_Sw == 4 | _Int_Sw == 11)
            { _Str_NDoNC = "NC"; }
            else if (_Int_Sw == 6 | _Int_Sw == 10)
            { _Str_NDoNC = "ND"; }
            if (_Int_Sw == 4 | _Int_Sw == 11 | _Int_Sw == 6 | _Int_Sw == 10)
            {
                if (MessageBox.Show("Esta seguro de rechazar la " + _Str_NDoNC + " número " + Convert.ToString(_Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells["Documento"].Value), "Precaución", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                { _Pnl_Clave.Visible = true; _Bol_Rechazar = true; }
            }
            else if (_Int_Sw == 13)
            {
                if (MessageBox.Show("Esta seguro de rechazar la anulación de la NC número " + Convert.ToString(_Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells["Documento"].Value), "Precaución", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                { _Pnl_Clave.Visible = true; _Bol_Rechazar = true; }
            }
        }

        private void _Dg_Grid_MouseEnter(object sender, EventArgs e)
        {
            if (_Int_Sw == 4 | _Int_Sw == 6)
            {
                _Lbl_DgInfo.Visible = true;
            }
        }

        private void _Dg_Grid_MouseLeave(object sender, EventArgs e)
        {
            _Lbl_DgInfo.Visible = false;
        }

        private void _Tool_AjustarCol_Click(object sender, EventArgs e)
        {
            if (_Dg_Grid.AutoSizeColumnsMode == DataGridViewAutoSizeColumnsMode.None)
            { _Dg_Grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells; }
            else
            { _Dg_Grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None; }
        }
    }
}