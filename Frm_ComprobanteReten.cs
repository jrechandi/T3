using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace T3
{
    public partial class Frm_ComprobanteReten : Form
    {
        public Frm_ComprobanteReten()
        {
            InitializeComponent();
            _Pnl_PorcRetiene.Visible = false;
        }

        public Frm_ComprobanteReten(string _Pr_Str_Tpo,string _Pr_Str_ComprobId, double _Pr_Dbl_Imp, string _Pr_Str_TpoDoc, string _Pr_Str_NumDoc, string _Pr_Str_FechaEmi, string _Pr_Str_NumCtrl, double _Pr_Dbl_MontoSimp, string _Pr_Str_Prov)
        {
            InitializeComponent();
            _Str_F_Tpo = _Pr_Str_Tpo;

            _Str_ComprobId = _Pr_Str_ComprobId;
            _Dbl_Impuesto = _Pr_Dbl_Imp;
            _Str_TpoDoc = _Pr_Str_TpoDoc;
            _Str_NumDoc = _Pr_Str_NumDoc;
            _Str_FechaEmi = _Pr_Str_FechaEmi;
            _Str_NumCtrl = _Pr_Str_NumCtrl;
            _Dbl_MontoSimp = _Pr_Dbl_MontoSimp;
            _Str_ProvId = _Pr_Str_Prov;

            _Pnl_PorcRetiene.Visible = true;
            //ARMO EL COMPROBANTE
            _Mtd_CargarComprobante(_Str_ComprobId);
        }

        //DataGridView _Dg_CompAux = new DataGridView();
        string _Str_F_Tpo = "";

        public string _Str_TpoDoc = "";
        public string _Str_NumDoc = "";
        public string _Str_FechaEmi = "";
        public string _Str_NumCtrl = "";
        public double _Dbl_MontoSimp = 0;
        public string _Str_ProvId = "";
        public string _Str_FrmCompRet = "";

        CLASES._Cls_Varios_Metodos myUtilidad = new CLASES._Cls_Varios_Metodos(true);//*gian

        public string _Str_ComprobId = "";

        public double _Dbl_PorcImp = 0;
        public double _Dbl_Impuesto = 0;
        public double _Dbl_TotalCXP = 0;

        private void Frm_ComprobanteReten_Load(object sender, EventArgs e)
        {

        }

        private void _Mtd_CargarComprobante(string _Pr_Str_Id)
        {
            string _Str_Sql = "";
            double _Dbl_ImpComproReten = 0;

            DataSet _Ds_A = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset("SELECT ctotdebe FROM TCOMPROBANC WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cidcomprob='" + _Pr_Str_Id + "'");
            if (_Ds_A.Tables[0].Rows.Count>0)
            {
                _Dbl_TotalCXP = Convert.ToDouble(_Ds_A.Tables[0].Rows[0][0]);
            }
            
            _Dg_Comprobante.Rows.Clear();
            //CARGO LOS DEBES
            _Ds_A.Tables.Clear();
            _Str_Sql = "SELECT * FROM TCOMPROBAND WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cidcomprob='" + _Pr_Str_Id + "' and (ctotdebe IS NULL or ctotdebe=0)";
            _Ds_A = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
            foreach (DataRow _DRow in _Ds_A.Tables[0].Rows)
            {
                _Dg_Comprobante.Rows.Add();
                _Dg_Comprobante[0, _Dg_Comprobante.RowCount - 1].Value = Convert.ToString(_DRow["corder"]);
                _Dg_Comprobante[1, _Dg_Comprobante.RowCount - 1].Value = Convert.ToString(_DRow["ccount"]);
                _Dg_Comprobante[3, _Dg_Comprobante.RowCount - 1].Value = Convert.ToString(_DRow["cdescrip"]);
                _Dg_Comprobante[4, _Dg_Comprobante.RowCount - 1].Value = Convert.ToDouble(_DRow["ctothaber"]).ToString("#,##0.00");
            }
            _Str_Sql = "SELECT * FROM TCOMPROBAND WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cidcomprob='" + _Pr_Str_Id + "' and (ctothaber IS NULL or ctothaber=0)";
            _Ds_A = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
            foreach (DataRow _DRow in _Ds_A.Tables[0].Rows)
            {
                _Dg_Comprobante.Rows.Add();
                _Dg_Comprobante[0, _Dg_Comprobante.RowCount - 1].Value = Convert.ToString(_DRow["corder"]);
                _Dg_Comprobante[1, _Dg_Comprobante.RowCount - 1].Value = Convert.ToString(_DRow["ccount"]);
                _Dg_Comprobante[3, _Dg_Comprobante.RowCount - 1].Value = Convert.ToString(_DRow["cdescrip"]);
                _Dg_Comprobante[4, _Dg_Comprobante.RowCount - 1].Value = Convert.ToDouble(_DRow["ctothaber"]).ToString("#,##0.00");
            }
            if (_Rb_100.Checked)
            { _Dbl_PorcImp = 1; }
            else if (_Rb_75.Checked)
            { _Dbl_PorcImp = 0.75; }
            //CARGO EL HABER
            //_Ds_A.Tables.Clear();
            //_Str_Sql = "SELECT * FROM VST_PROCESOSCONTD WHERE cidproceso='P_CXP_COMP_RETENCION' and cnaturaleza='H'";
            //_Ds_A = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
            //if (_Ds_A.Tables[0].Rows.Count > 0)
            //{
            //    _Dg_Comprobante.Rows.Add();
            //    _Dg_Comprobante[1, _Dg_Comprobante.Rows.Count - 1].Value = Convert.ToString(_Ds_A.Tables[0].Rows[0]["ccount"]);
            //    _Dg_Comprobante[3, _Dg_Comprobante.Rows.Count - 1].Value = Convert.ToString(_Ds_A.Tables[0].Rows[0]["ccountname"]);
            //    _Dbl_ImpComproReten = _Dbl_Impuesto * _Dbl_PorcImp;
            //    _Dg_Comprobante[5, _Dg_Comprobante.Rows.Count - 1].Value = _Dbl_ImpComproReten.ToString("#,##0.00");
            //}
            _Dg_Comprobante.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            
        }

        public void _Mtd_CargarComprobCont(DataGridView _Pr_Dg_CxP)
        {
            string _Str_Sql = "";
            string _Str_Prov = "";
            double _Dbl_ImpComproReten = 0;
            int _Int_C = 0;
            DataSet _Ds_A = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset("SELECT c_nomb_abreviado FROM TPROVEEDOR WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cproveedor='" + _Str_ProvId + "'");
            if (_Ds_A.Tables[0].Rows.Count>0)
            { _Str_Prov = Convert.ToString(_Ds_A.Tables[0].Rows[0][0]); }
            

            //CARGO EL DEBE QUE ES EL HABER DEL COMPROBANTE DE CUENTAS POR PAGAR
            foreach (DataGridViewRow _DgRow in _Pr_Dg_CxP.Rows)
            {
                if (Convert.ToString(_DgRow.Cells[4].Value) != "" && Convert.ToString(_DgRow.Cells[4].Value) != "0")
                {
                    
                    _Dg_Comprobante.Rows.Add();
                    _Dg_Comprobante[1, _Dg_Comprobante.Rows.Count - 1].Value = Convert.ToString(_DgRow.Cells[0].Value);
                    _Dg_Comprobante[3, _Dg_Comprobante.Rows.Count - 1].Value = Convert.ToString(_DgRow.Cells[2].Value);
                    
                    _Dg_Comprobante[4, _Dg_Comprobante.Rows.Count - 1].Value = Convert.ToString(_DgRow.Cells[4].Value);
                    if (_Int_C == 0)
                    {
                        if (_Str_FrmCompRet != "")
                        { _Dg_Comprobante[3, _Dg_Comprobante.Rows.Count - 1].Value = _Str_Prov + " CXP COMPROBANTE DE RETENCION #" + _Str_FrmCompRet + " S/F# " + _Str_NumDoc + " FECHA:" + _Str_FechaEmi; }
                        else
                        { _Dg_Comprobante[3, _Dg_Comprobante.Rows.Count - 1].Value = _Str_Prov + " CXP COMPROBANTE DE RETENCION #__  S/F# " + _Str_NumDoc + " FECHA:" + _Str_FechaEmi; }
                        
                    }
                    else
                    { }
                    _Int_C++;
                }
            }
            //CARGO EL HABER
            _Ds_A.Tables.Clear();
            _Str_Sql = "SELECT * FROM VST_PROCESOSCONTD WHERE cidproceso='P_CXP_COMP_RETENCION' and cnaturaleza='H' AND ccompany='" + Frm_Padre._Str_Comp + "'";
            _Ds_A = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
            if (_Ds_A.Tables[0].Rows.Count > 0)
            {
                _Dg_Comprobante.Rows.Add();

                _Dg_Comprobante[1, _Dg_Comprobante.Rows.Count - 1].Value = Convert.ToString(_Ds_A.Tables[0].Rows[0]["ccount"]);
                if (_Str_FrmCompRet != "")
                { _Dg_Comprobante[3, _Dg_Comprobante.Rows.Count - 1].Value = Convert.ToString(_Ds_A.Tables[0].Rows[0]["ccountname"]) + " RETENCION #" + _Str_FrmCompRet + " S/F# " + _Str_NumDoc + " " + _Str_Prov + " " + _Str_FechaEmi; }
                else
                { _Dg_Comprobante[3, _Dg_Comprobante.Rows.Count - 1].Value = Convert.ToString(_Ds_A.Tables[0].Rows[0]["ccountname"]) + " RETENCION #__ S/F# " + _Str_NumDoc + " " + _Str_Prov + " " + _Str_FechaEmi; }
                

                _Dbl_ImpComproReten = _Dbl_Impuesto * _Dbl_PorcImp;
                _Dg_Comprobante[5, _Dg_Comprobante.Rows.Count - 1].Value = _Dbl_ImpComproReten.ToString("#,##0.00");
                _Dg_Comprobante[4, 0].Value = _Dbl_ImpComproReten.ToString("#,##0.00");
            }
             
            _Dg_Comprobante.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }

        public bool _Mtd_AbiertoOno(Form _Frm_Formulario, Frm_Padre _Pr_Frm_Padre)
        {
            foreach (Form _Frm_Hijo in _Pr_Frm_Padre.MdiChildren)
            {
                if (_Frm_Hijo.Name == _Frm_Formulario.Name)
                {
                    _Frm_Hijo.Activate();
                    return true;
                }
            }
            return false;
        }

        private void Frm_ComprobanteReten_Activated(object sender, EventArgs e)
        {
            CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "";
            CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "Cerrado";
        }

        private void Frm_ComprobanteReten_FormClosing(object sender, FormClosingEventArgs e)
        {
            CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "";
            CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "Cerrado";
        }

        private void _Rb_75_CheckedChanged(object sender, EventArgs e)
        {
            if (_Pnl_PorcRetiene.Visible && _Rb_75.Checked)
            { _Mtd_CargarComprobante(_Str_ComprobId); }
        }

        private void _Rb_100_CheckedChanged(object sender, EventArgs e)
        {
            if (_Pnl_PorcRetiene.Visible && _Rb_100.Checked)
            { _Mtd_CargarComprobante(_Str_ComprobId); }
        }

        private void _Bt_Ok_Click(object sender, EventArgs e)
        {
            string _Str_calicuotaporc = "";
            string _Str_cidcomprobret = "";
            string _Str_ctipotransacc = "";
            string _Str_SQL = "";
            double _Dbl_Retenido = 0;

            //GUARDO LOS DATOS DEL COMPROBANTE DE RETENCION
            DataSet _Ds_E = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset("SELECT ctdocumentgov FROM TDOCUMENT WHERE ctdocument=(Select TPROCESOSCONTD.ctipodocumento from TPROCESOSCONTD where TPROCESOSCONTD.cidproceso='P_COMPRA' GROUP BY TPROCESOSCONTD.ctipodocumento)");
            if (_Ds_E.Tables[0].Rows.Count > 0)
            { _Str_ctipotransacc = Convert.ToString(_Ds_E.Tables[0].Rows[0][0]); }
            _Ds_E = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset("SELECT cpercent FROM TTAX WHERE ctax=(SELECT ctipimpuesto FROM TCONFIGCXP WHERE ccompany='" + Frm_Padre._Str_Comp + "')");
            _Str_calicuotaporc = Convert.ToString(_Ds_E.Tables[0].Rows[0][0]);
            _Str_cidcomprobret = myUtilidad._Mtd_Correlativo("SELECT MAX(cidcomprobret) FROM TCOMPROBANRET WHERE ccompany='" + Frm_Padre._Str_Comp + "'");

            _Str_SQL = "INSERT INTO TCOMPROBANRET (ccompany,cidcomprobret,cidcomprob,cproveedor,ctdocument,cnumdocu,cfechadocu,cnumcontrolfact,ctipotransacc,ctotcaomp_iva,ctotcaomp_siva,cbaseimponible,calicuotaporc,cimpuesto,cretenido,canulado) VALUES('" +
            Frm_Padre._Str_Comp + "'," + _Str_cidcomprobret + "," + _Str_ComprobId + ",'" + _Str_ProvId + "','" + _Str_TpoDoc + "','" + _Str_NumDoc + "','" + _Str_FechaEmi + "','" + _Str_NumCtrl + "','" + _Str_ctipotransacc + "'," + _Dbl_TotalCXP.ToString().Replace(",", ".") + "," + _Dbl_Impuesto.ToString().Replace(",", ".") + "," + _Dbl_MontoSimp.ToString().Replace(",", ".") + ",'" + _Str_calicuotaporc + "'," + _Dbl_Impuesto.ToString().Replace(",", ".") + "," + _Dbl_Retenido.ToString() + ",0)";
            Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_SQL);
            
            _Str_SQL = "UPDATE TCOMPROBANC SET cidcomprobret='" + _Str_cidcomprobret + "' WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cidcomprob='" + _Str_ComprobId + "'";
            Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_SQL);
            MessageBox.Show("Se generó el Comprobante de Retención # " + _Str_cidcomprobret);
        }
    }
}