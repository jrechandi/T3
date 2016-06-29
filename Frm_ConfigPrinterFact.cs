using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Text;
using System.Windows.Forms;

namespace T3
{
    public partial class Frm_ConfigPrinterFact : Form
    {
        public Frm_ConfigPrinterFact()
        {
            InitializeComponent();
        }

        string _Str_MyProceso = "";
        string _Str_Frm_Id = "";
        CLASES._Cls_Varios_Metodos myUtilidad = new CLASES._Cls_Varios_Metodos(true);
        PrintDialog _My_PrintDialogo = new PrintDialog();

        private void _Mtd_CargarPrinters()
        {
            try
            {
                _Cb_Printers.SelectedIndexChanged -= new EventHandler(_Cb_Printers_SelectedIndexChanged);
                _Cb_Printers.Items.Clear();
                _Cb_Printers.Items.Add("...");
                for (int _I = 0; _I < PrinterSettings.InstalledPrinters.Count; _I++)
                {
                    _Cb_Printers.Items.Add(PrinterSettings.InstalledPrinters[_I].ToString());
                }
                _Cb_Printers.SelectedIndex = 0;
                _Cb_Printers.SelectedIndexChanged += new EventHandler(_Cb_Printers_SelectedIndexChanged);
            }
            catch 
            {
                throw new Exception("Problemas al cargar las impresoras.");
            }
        }

        private void _Mtd_CargarFontPaper(string _Pr_Str_Printer)
        {
            try
            {
                System.Collections.ArrayList _myArrayList = new System.Collections.ArrayList();
                _Cb_TpoFontPaper.SelectedIndexChanged -= new EventHandler(_Cb_TpoFontPaper_SelectedIndexChanged);
                _Cb_TpoFontPaper.DataSource = null;
                _My_PrintDialogo.PrinterSettings.PrinterName = _Pr_Str_Printer;
                _myArrayList.Add(new T3.Clases._Cls_ArrayList("...", "nulo"));
                for (int _I = 0; _I < _My_PrintDialogo.PrinterSettings.PaperSources.Count; _I++)
                {
                    _myArrayList.Add(new T3.Clases._Cls_ArrayList(_My_PrintDialogo.PrinterSettings.PaperSources[_I].SourceName, _My_PrintDialogo.PrinterSettings.PaperSources[_I].RawKind.ToString()));
                }
                _Cb_TpoFontPaper.DataSource = _myArrayList;
                _Cb_TpoFontPaper.DisplayMember = "Display";
                _Cb_TpoFontPaper.ValueMember = "Value";
                _Cb_TpoFontPaper.SelectedValue = "nulo";
                _Cb_TpoFontPaper.SelectedIndexChanged += new EventHandler(_Cb_TpoFontPaper_SelectedIndexChanged);
            }
            catch 
            {
                throw new Exception("Problemas al cargar las fuentes de papel.");
            }
        }

        private void _Mtd_CargarSizePaper(string _Pr_Str_Printer)
        {
            try
            {
                System.Collections.ArrayList _myArrayList = new System.Collections.ArrayList();
                _Cb_SizePaper.DataSource = null;
                _My_PrintDialogo.PrinterSettings.PrinterName = _Pr_Str_Printer;
                _myArrayList.Add(new T3.Clases._Cls_ArrayList("...", "nulo"));
                for (int _I = 0; _I < _My_PrintDialogo.PrinterSettings.PaperSizes.Count; _I++)
                {
                    _myArrayList.Add(new T3.Clases._Cls_ArrayList(_My_PrintDialogo.PrinterSettings.PaperSizes[_I].PaperName, _My_PrintDialogo.PrinterSettings.PaperSizes[_I].RawKind.ToString()));
                }
                _Cb_SizePaper.DataSource = _myArrayList;
                _Cb_SizePaper.DisplayMember = "Display";
                _Cb_SizePaper.ValueMember = "Value";
                _Cb_SizePaper.SelectedValue = "nulo";
            }
            catch 
            {
                throw new Exception("Problemas al cargar los tamaños de papel.");
            }
        }

        public void _Mtd_Ini()
        {
            _Str_Frm_Id = "";
            _Mtd_CargarPrinters();
            _Cb_SizePaper.DataSource = null;
            _Cb_TpoFontPaper.DataSource = null;
            _Mtd_Bloquear(false);
        }

        private void _Mtd_CargarData(string _Pr_Str_Id)
        {
            try
            {
                string _Str_Sql = "SELECT * FROM TCONFIGPRINTER WHERE ccompany='" + Frm_Padre._Str_Comp + "'";
                if (_Pr_Str_Id != "")
                {
                    _Str_Sql = _Str_Sql + " AND ccprinter_id='" + _Pr_Str_Id + "'";
                }
                DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
                if (_Ds.Tables[0].Rows.Count > 0)
                {
                    _Str_MyProceso = "";
                    _Mtd_CargarPrinters();
                    _Str_Frm_Id = _Ds.Tables[0].Rows[0]["ccprinter_id"].ToString();
                    _Cb_Printers.Text = _Ds.Tables[0].Rows[0]["ccprinter_name"].ToString();
                    _Cb_SizePaper.SelectedValue = Convert.ToString(_Ds.Tables[0].Rows[0]["cpapersize"]);
                    _Cb_TpoFontPaper.SelectedValue = Convert.ToString(_Ds.Tables[0].Rows[0]["cpapersource"]);
                    _Mtd_Bloquear(false);
                }
                else
                {
                    _Mtd_Ini();
                }
                _Er_Error.Dispose();
            }
            catch
            {
                throw new Exception("Problemas al cargar los datos de la impresora.");
            }
        }

        private void _Mtd_Bloquear(bool _Pr_Bol_Val)
        {
            _Cb_Printers.Enabled = _Pr_Bol_Val;
            _Cb_SizePaper.Enabled = _Pr_Bol_Val;
            _Cb_TpoFontPaper.Enabled = _Pr_Bol_Val;
        }

        public void _Mtd_BotonesMenu()
        {
            string _Str_Sql = "";
            CONTROLES._Ctrl_Buscar._frm_Formulario = this;
            CONTROLES._Ctrl_Buscar._Tb_Tab = this._Tb_Tab;
            CONTROLES._Ctrl_Buscar._Bl_Especial = true;
            CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "";
            CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "Abierto";
            if (_Str_MyProceso == "A")
            {
                CONTROLES._Ctrl_Buscar._Bl_Modifi = false;
                ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_nuevo2.Enabled = true;
                ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_editar2.Enabled = false;
                ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_guardar2.Enabled = true;
                ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_borrar2.Enabled = false;
                ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_cancelar2.Enabled = true;
            }
            if (_Str_MyProceso == "M")
            {
                CONTROLES._Ctrl_Buscar._Bl_Modifi = true; ;
                ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_nuevo2.Enabled = false;
                ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_editar2.Enabled = false;
                ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_guardar2.Enabled = true;
                ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_borrar2.Enabled = false;
                ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_cancelar2.Enabled = false;
            }
            if (_Str_MyProceso == "")
            {
                if (_Cb_Printers.SelectedIndex > 0)
                {
                    ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_nuevo2.Enabled = false;
                    ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_editar2.Enabled = true;
                    ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_guardar2.Enabled = false;
                    ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_borrar2.Enabled = true;
                    ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_cancelar2.Enabled = false;
                }
                else
                {
                    _Str_Sql = "SELECT * FROM TCONFIGPRINTER WHERE ccompany='" + Frm_Padre._Str_Comp + "'";
                    if (Program._MyClsCnn._mtd_conexion._Mtd_ExistenRegistros(_Str_Sql))
                    {
                        ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_nuevo2.Enabled = false;
                    }
                    else
                    {
                        ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_nuevo2.Enabled = true;
                    }
                    ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_editar2.Enabled = false;
                    ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_guardar2.Enabled = false;
                    ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_borrar2.Enabled = false;
                    ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_cancelar2.Enabled = false;
                }
            }
        }

        public void _Mtd_Nuevo()
        {
            _Mtd_Ini();
            _Mtd_Bloquear(true);
            _Str_MyProceso = "A";
            _Cb_Printers.Focus();
            _Mtd_BotonesMenu();
        }

        public void _Mtd_Habilitar()
        {
            _Mtd_Bloquear(true);
            _Cb_Printers.Focus();
            _Str_MyProceso = "M";
        }

        public bool _Mtd_Guardar()
        {
            string _Str_Sql = "";
            string _Str_Id = "";
            bool _Bol_Val = false;
            bool _Bol_R = false;
            if (_Cb_Printers.SelectedIndex <= 0)
            {
                _Er_Error.SetError(_Cb_Printers, "Seleccione una Impresora");
                _Bol_Val = true;
            }
            if (_Cb_SizePaper.SelectedIndex <= 0)
            {
                _Er_Error.SetError(_Cb_SizePaper, "Seleccione un Tamaño de papel.");
                _Bol_Val = true;
            }
            if (_Cb_TpoFontPaper.SelectedIndex <= 0)
            {
                _Er_Error.SetError(_Cb_TpoFontPaper, "Seleccione un tipo de fuente de papel.");
                _Bol_Val = true;
            }
            if (!_Bol_Val)
            {
                
                try 
                {
                    _Str_Sql = "Select Max(ccprinter_id) FROM TCONFIGPRINTER WHERE ccompany='" + Frm_Padre._Str_Comp + "'";
                    _Str_Id = myUtilidad._Mtd_Correlativo(_Str_Sql);
                    _Str_Sql = "INSERT INTO TCONFIGPRINTER (ccompany,ccprinter_id,ccprinter_name,cpapersource,cpapersource_name,cpapersize,cpapersize_name) VALUES" +
                    "('" + Frm_Padre._Str_Comp + "','" + _Str_Id + "','" + _Cb_Printers.Text + "','" + _Cb_TpoFontPaper.SelectedValue.ToString() + "','" + _Cb_TpoFontPaper.Text + "','" + _Cb_SizePaper.SelectedValue.ToString() + "','" + _Cb_SizePaper.Text + "')";
                    Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
                    MessageBox.Show("Se guardó correctamente.", "Importante", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _Mtd_CargarData(_Str_Id);
                    _Bol_R = true;
                }
                catch
                {
                    MessageBox.Show("Problemas al guardar la transacción.", "Importante", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    _Bol_R = false;
                }
                
            }

            return _Bol_R;
        }

        public bool _Mtd_Editar()
        {
            string _Str_Sql = "";
            bool _Bol_Val = false;
            bool _Bol_R = false;
            if (_Cb_Printers.SelectedIndex <= 0)
            {
                _Er_Error.SetError(_Cb_Printers, "Seleccione una Impresora");
                _Bol_Val = true;
            }
            if (_Cb_SizePaper.SelectedIndex <= 0)
            {
                _Er_Error.SetError(_Cb_SizePaper, "Seleccione un Tamaño de papel.");
                _Bol_Val = true;
            }
            if (_Cb_TpoFontPaper.SelectedIndex <= 0)
            {
                _Er_Error.SetError(_Cb_TpoFontPaper, "Seleccione un tipo de fuente de papel.");
                _Bol_Val = true;
            }
            if (!_Bol_Val)
            {
                try
                {
                    _Str_Sql = "UPDATE TCONFIGPRINTER SET ccprinter_name='" + _Cb_Printers.Text + "',cpapersource='" + _Cb_TpoFontPaper.SelectedValue.ToString() + "',cpapersource_name='" + _Cb_TpoFontPaper.Text + "',cpapersize='" + _Cb_SizePaper.SelectedValue.ToString() + "',cpapersize_name='" + _Cb_SizePaper.Text + "'" +
                    " WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND ccprinter_id=" + _Str_Frm_Id;
                    Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
                    MessageBox.Show("Se guardó correctamente.", "Importante", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _Mtd_CargarData(_Str_Frm_Id);
                    _Bol_R = true;
                }
                catch
                {
                    MessageBox.Show("Problemas al guardar la transacción.", "Importante", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    _Bol_R = false;
                }
                
            }
            return _Bol_R;
        }

        public bool _Mtd_Eliminar()
        {
            bool _Bol_R = false;
            string _Str_Sql = "";
            if (MessageBox.Show("Está seguro de Eliminar esta configuración?", "Confirme", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                _Str_Sql = "delete from TCONFIGPRINTER where ccompany='" + Frm_Padre._Str_Comp + "' AND ccprinter_id=" + _Str_Frm_Id;
                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
                _Mtd_CargarData("");
                _Bol_R = true;
            }

            return _Bol_R;
        }

        private void Frm_ConfigPrinterFact_Load(object sender, EventArgs e)
        {
            _Mtd_CargarData("");
        }

        private void _Cb_TpoFontPaper_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void _Cb_Printers_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_Cb_Printers.SelectedIndex > 0)
            {
                _Mtd_CargarFontPaper(_Cb_Printers.Text);
                _Mtd_CargarSizePaper(_Cb_Printers.Text);
            }
        }

        private void Frm_ConfigPrinterFact_Activated(object sender, EventArgs e)
        {
            _Mtd_BotonesMenu();
        }

        private void Frm_ConfigPrinterFact_FormClosing(object sender, FormClosingEventArgs e)
        {
            CONTROLES._Ctrl_Buscar._txt_text.Text = "";
            CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "Cerrado";
        }
    }
}