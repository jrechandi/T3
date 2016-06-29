using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace T3
{
    public partial class Frm_ConsolidaObligaciones : Form
    {
        public Frm_ConsolidaObligaciones()
        {
            InitializeComponent();
        }

        int _Int_SwProvTpo = 0;
        Control[] _Ctrl_Controles = new Control[3];
        string _Str_FechaIni = "";
        string _Str_FrmProvRetISLR = "";
        string _Str_FrmProvRetIVA = "";
        CLASES._Cls_Varios_Metodos _Cls_MyUtilidad = new CLASES._Cls_Varios_Metodos(true);
        clslibraryconssa._Cls_Formato _Cls_Formato = new clslibraryconssa._Cls_Formato("es-VE");

        private string _Mtd_PrimerDiaSemana(string _Pr_Str_Ano, string _Pr_Str_Mes, string _Pr_Str_Semana)
        {
            string _Str_R = "";
            string _Str_Sql = "";
            //_Str_Sql = "SELECT CONVERT(VARCHAR,cdiafecha,103) FROM TCALENDVTA WHERE canocalend=" + _Pr_Str_Ano + " and cmesubicado=" + _Pr_Str_Mes + " and csemcalend=" + _Pr_Str_Semana + " order by cdiafecha";//order by cdiacalend
            _Str_Sql = "SELECT CONVERT(VARCHAR, TCALENDCONT.cdiafecha_cal,103) FROM TCALENDCONT WHERE TCALENDCONT.ccompany = '" + Frm_Padre._Str_Comp + "' AND TCALENDCONT.canocalend=" + _Pr_Str_Ano + " and TCALENDCONT.cmescalend=" + _Pr_Str_Mes + " and 1 + datepart(ww,cdiafecha_cal)- datepart(ww,CONVERT(DATETIME,'01/'+CONVERT(VARCHAR,MONTH(cdiafecha_cal))+'/'+CONVERT(VARCHAR,YEAR(cdiafecha_cal))))=" + _Pr_Str_Semana + " order by TCALENDCONT.cdiafecha_cal";
            DataSet _Ds_Data = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
            if (_Ds_Data.Tables[0].Rows.Count > 0)
            {
                _Str_R = Convert.ToString(_Ds_Data.Tables[0].Rows[0][0]);
            }
            return _Str_R;
        }

        private string _Mtd_UltimoDiaSemana(string _Pr_Str_Ano, string _Pr_Str_Mes, string _Pr_Str_Semana)
        {
            string _Str_R = "";
            string _Str_Sql = "";
            //_Str_Sql = "SELECT CONVERT(VARCHAR,cdiafecha,103) FROM TCALENDVTA WHERE canocalend=" + _Pr_Str_Ano + " and cmesubicado=" + _Pr_Str_Mes + " and csemcalend=" + _Pr_Str_Semana + " order by cdiafecha";//order by cdiacalend
            _Str_Sql = "SELECT CONVERT(VARCHAR, TCALENDCONT.cdiafecha_cal,103) FROM TCALENDCONT WHERE TCALENDCONT.ccompany = '" + Frm_Padre._Str_Comp + "' AND TCALENDCONT.canocalend=" + _Pr_Str_Ano + " and TCALENDCONT.cmescalend=" + _Pr_Str_Mes + " and 1 + datepart(ww,cdiafecha_cal)- datepart(ww,CONVERT(DATETIME,'01/'+CONVERT(VARCHAR,MONTH(cdiafecha_cal))+'/'+CONVERT(VARCHAR,YEAR(cdiafecha_cal))))=" + _Pr_Str_Semana + " order by TCALENDCONT.cdiafecha_cal";
            DataSet _Ds_Data = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
            if (_Ds_Data.Tables[0].Rows.Count > 0)
            {
                _Str_R = Convert.ToString(_Ds_Data.Tables[0].Rows[(_Ds_Data.Tables[0].Rows.Count - 1)][0]);
            }
            return _Str_R;
        }


        private void _Mtd_SemanaActual()
        {
            DataGridViewColumn _Dg_ColSemanaActual = new DataGridViewColumn();
            string _Str_Sql = "";
            _Str_Sql = "Select TCALENDCONT.canocalend AS canocalend, TCALENDCONT.cmescalend AS cmescalend, 1 + datepart(ww,cdiafecha_cal)- datepart(ww,CONVERT(DATETIME,'01/'+CONVERT(VARCHAR,MONTH(cdiafecha_cal))+'/'+CONVERT(VARCHAR,YEAR(cdiafecha_cal)))) AS csemcalend FROM TCALENDCONT WHERE TCALENDCONT.ccompany = '" + Frm_Padre._Str_Comp + "' AND CONVERT(VARCHAR,TCALENDCONT.cdiafecha_cal,103)='" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate()) + "'";
            DataSet _Ds_Data = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
            if (_Ds_Data.Tables[0].Rows.Count > 0)
            {
                _Str_FechaIni = CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate().ToShortDateString();
                _Dg_ColSemanaActual.HeaderText = "SEMANA " + _Mtd_PrimerDiaSemana(_Ds_Data.Tables[0].Rows[0]["canocalend"].ToString(), _Ds_Data.Tables[0].Rows[0]["cmescalend"].ToString(), _Ds_Data.Tables[0].Rows[0]["csemcalend"].ToString()) + " al " + _Mtd_UltimoDiaSemana(_Ds_Data.Tables[0].Rows[0]["canocalend"].ToString(), _Ds_Data.Tables[0].Rows[0]["cmescalend"].ToString(), _Ds_Data.Tables[0].Rows[0]["csemcalend"].ToString());
            }
        }

        private void _Mtd_CargarProveedores()
        {
            string _Str_Sql = "";
            _Str_Sql = "SELECT cproveedor,c_nomb_abreviado FROM VST_FACTPPAGARM WHERE cactivo=1 and canulado=0 and csaldo<>0 and cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and ccompany='" + Frm_Padre._Str_Comp + "'";
            //_Str_Sql = "SELECT cproveedor,c_nomb_abreviado FROM TPROVEEDOR WHERE cdelete=0";
            if (_Cmb_Proveedor.SelectedIndex > 0)
            { _Str_Sql = _Str_Sql + " AND cproveedor='" + Convert.ToString(_Cmb_Proveedor.SelectedValue) + "'"; }
            if (_Cmb_TipoProv.SelectedIndex > 0)
            { _Str_Sql = _Str_Sql + " AND cglobal=" + Convert.ToString(_Cmb_TipoProv.SelectedValue); }
            if (_Cmb_CategProv.SelectedIndex > 0)
            {
                if (_Cmb_CategProv.SelectedIndex > 0)
                { _Str_Sql = _Str_Sql + " AND ccatproveedor='" + Convert.ToString(_Cmb_CategProv.SelectedValue) + "'"; }
            }
            _Str_Sql = _Str_Sql + " GROUP BY cproveedor,c_nomb_abreviado";
            _Dg_Calendario.Rows.Clear();
            _Mtd_ReiniciarGrid();
            DataSet _Ds_Data = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
            //_Str_Sql = "SELECT cproveedor,c_nomb_abreviado FROM TPROVEEDOR WHERE cdelete=0" +
            //" AND ccompany='" + Frm_Padre._Str_Comp + "' or cglobal=1 ORDER BY c_nomb_abreviado";
            //DataSet _Ds_Data = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
            foreach (DataRow _DRow_A in _Ds_Data.Tables[0].Rows)
            {
                _Dg_Calendario.Rows.Add();
                _Dg_Calendario[0, (_Dg_Calendario.RowCount - 1)].Value = _DRow_A["cproveedor"].ToString();
                _Dg_Calendario[1, (_Dg_Calendario.RowCount - 1)].Value = _DRow_A["c_nomb_abreviado"].ToString();
            }
        }

        private void _Mtd_CargarSemanas()
        {
            DataGridViewColumn _Dg_Col = new DataGridViewColumn();
            string _Str_FechaTemp = "";
            int _Int_Col = 0;
            Int64 _Int_Cont = 0;
            string _Str_Sql = "";

            string _Str_Fact = "";
            string _Str_ND = "";
            string _Str_NC = "";
            string _Str_NDP = "";
            string _Str_NCP = "";
            string _Str_Ret = "";
            string _Str_RetISLR = "";
            string _Str_RetPatente = "";

            double _Dbl_NC = 0;
            double _Dbl_ND = 0;
            double _Dbl_NDP = 0;
            double _Dbl_SaldoFact = 0;
            double _Dbl_ValorAux = 0;

            double _Dbl_NCval = 0;
            double _Dbl_NDval = 0;
            double _Dbl_NDPval = 0;
            DataSet _Ds_A;
            DataSet _Ds_Data = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset("SELECT ctipdocfact,ctipodocnd,ctipodocnc,ctipdocretiva,ctipdocretislr,ctipodocndp,ctipodocncp,ctipodocretpat FROM TCONFIGCXP WHERE ccompany='" + Frm_Padre._Str_Comp + "'");
            if (_Ds_Data.Tables[0].Rows.Count > 0)
            {
                _Str_Fact = Convert.ToString(_Ds_Data.Tables[0].Rows[0]["ctipdocfact"]);
                _Str_ND = Convert.ToString(_Ds_Data.Tables[0].Rows[0]["ctipodocnd"]);
                _Str_NC = Convert.ToString(_Ds_Data.Tables[0].Rows[0]["ctipodocnc"]);
                _Str_NDP = Convert.ToString(_Ds_Data.Tables[0].Rows[0]["ctipodocndp"]);
                _Str_Ret = Convert.ToString(_Ds_Data.Tables[0].Rows[0]["ctipdocretiva"]);
                _Str_RetISLR = Convert.ToString(_Ds_Data.Tables[0].Rows[0]["ctipdocretislr"]);
                _Str_NCP = Convert.ToString(_Ds_Data.Tables[0].Rows[0]["ctipodocncp"]);
                _Str_RetPatente = Convert.ToString(_Ds_Data.Tables[0].Rows[0]["ctipodocretpat"]);
            }

            _Str_Sql = "SELECT cproveedor,ctipodocument,cfechavencimiento,ctotalimp,ctotalsimp,csaldo FROM VST_FACTPPAGARM WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND (ctipodocument='" + _Str_Fact + "' OR ctipodocument='" + _Str_Ret + "' OR ctipodocument='" + _Str_RetISLR + "' or ctipodocument='" + _Str_RetPatente + "')" +
            " and cactivo=1 and canulado=0 and cfechavencimiento>='" + _Cls_Formato._Mtd_fecha(Convert.ToDateTime(_Str_FechaIni)).ToString() + "' AND csaldo <> 0 ORDER BY cfechavencimiento";

            //_Str_Sql = "SELECT cproveedor,ctipodocument,cfechavencimiento,ctotalimp,ctotalsimp,csaldo FROM VST_FACTPPAGARM WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND ctipodocument='" + _Str_Fact + "'" +
            //" and cactivo=1 and canulado=0 and cfechavencimiento>='" + _Cls_Formato._Mtd_fecha(Convert.ToDateTime(_Str_FechaIni)).ToString() + "' AND csaldo <> 0 ORDER BY cfechavencimiento";


            _Ds_Data = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
            foreach (DataRow _DRow_A in _Ds_Data.Tables[0].Rows)
            {

                //CARGO LA FECHA A BUSCAR EN LOS COLHEADERS
                _Str_Sql = "Select TCALENDCONT.canocalend AS canocalend, TCALENDCONT.cmescalend AS cmescalend, 1 + datepart(ww,cdiafecha_cal)- datepart(ww,CONVERT(DATETIME,'01/'+CONVERT(VARCHAR,MONTH(cdiafecha_cal))+'/'+CONVERT(VARCHAR,YEAR(cdiafecha_cal)))) AS csemcalend FROM TCALENDCONT WHERE TCALENDCONT.ccompany = '" + Frm_Padre._Str_Comp + "' AND CONVERT(VARCHAR,TCALENDCONT.cdiafecha_cal,103)='" + _Cls_Formato._Mtd_fecha(Convert.ToDateTime(_DRow_A["cfechavencimiento"])).ToString() + "'";

                _Ds_A = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
                if (_Ds_A.Tables[0].Rows.Count > 0)
                {
                    _Str_FechaTemp = "SEMANA " + _Mtd_PrimerDiaSemana(_Ds_A.Tables[0].Rows[0]["canocalend"].ToString(), _Ds_A.Tables[0].Rows[0]["cmescalend"].ToString(), _Ds_A.Tables[0].Rows[0]["csemcalend"].ToString()) + " al " + _Mtd_UltimoDiaSemana(_Ds_A.Tables[0].Rows[0]["canocalend"].ToString(), _Ds_A.Tables[0].Rows[0]["cmescalend"].ToString(), _Ds_A.Tables[0].Rows[0]["csemcalend"].ToString());
                }
                else
                {
                    _Str_FechaTemp = "FECHA NO ENCONTRADA EN EL CALENDARIO";
                }
                //VERIFICO SI YA LA AGREGUE EN EL GRID LA COLUMNA
                for (_Int_Col = 0; _Int_Col <= (_Dg_Calendario.Columns.Count - 1); _Int_Col++)
                {
                    if (_Dg_Calendario.Columns[_Int_Col].HeaderText == _Str_FechaTemp)
                    {
                        break;
                    }
                }
                if (_Int_Col == _Dg_Calendario.Columns.Count)
                { // CREO LA COLUMNA
                    _Dg_Col = new System.Windows.Forms.DataGridViewTextBoxColumn();
                    _Dg_Col.Name = "_Dg_CalendarioCol_" + _Int_Col.ToString();
                    _Dg_Col.HeaderText = _Str_FechaTemp;
                    _Dg_Col.CellTemplate.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                    _Dg_Calendario.Columns.Add(_Dg_Col);
                }


                if (_DRow_A["ctipodocument"].ToString() == _Str_Fact)
                {
                    //VER SI AQUI HACE FALTA ALGUM CAMBIO PARA MOSTRAR LAS CANTIDADES DE LAS RETENCIONES
                    //BUSCO LA FILA DEL PROVEEDOR
                    foreach (DataGridViewRow _Dg_Row in _Dg_Calendario.Rows)
                    {
                        if (Convert.ToString(_Dg_Row.Cells[0].Value) == _DRow_A["cproveedor"].ToString())
                        {
                            if (Convert.ToString(_Dg_Row.Cells[_Int_Col].Value) == "")
                            { _Dbl_SaldoFact = 0; }
                            else if (Convert.ToDouble(_Dg_Row.Cells[_Int_Col].Value) == 0)
                            { _Dbl_SaldoFact = 0; }
                            else
                            { _Dbl_SaldoFact = Convert.ToDouble(_Dg_Row.Cells[_Int_Col].Value); }

                            _Dg_Row.Cells[_Int_Col].Value = _Dbl_SaldoFact + Convert.ToDouble(_DRow_A["csaldo"]);
                            _Dg_Row.Cells[_Int_Col].Value = Convert.ToDouble(_Dg_Row.Cells[_Int_Col].Value).ToString("#,##0.00");
                        }
                    }
                }
            }

            foreach (DataGridViewRow _Dg_Row in _Dg_Calendario.Rows)
            {
                _Str_Sql = "SELECT SUM(csaldo) from VST_FACTPPAGARM WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cproveedor='" + Convert.ToString(_Dg_Row.Cells[0].Value) + "' AND cfechavencimiento<'" + _Cls_Formato._Mtd_fecha(Convert.ToDateTime(_Str_FechaIni)).ToString() + "' and cactivo=1 and canulado=0 AND (ctipodocument='" + _Str_Fact + "')";
                DataSet _Ds_B = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
                if (_Ds_B.Tables[0].Rows.Count > 0)
                {
                    if (Convert.ToString(_Ds_B.Tables[0].Rows[0][0]) != "")
                    { _Dg_Row.Cells[6].Value = Convert.ToDouble(_Ds_B.Tables[0].Rows[0][0]).ToString("#,##0.00"); }
                    else
                    { _Dg_Row.Cells[6].Value = "0"; }
                }
                else
                { _Dg_Row.Cells[6].Value = "0"; }

                //CARGO LOS DATOS DE NC
                _Dbl_NC = 0;
                //_Str_Sql = "SELECT cproveedor,ctipodocument,cfechavencimiento,ctotalimp,ctotalsimp,csaldo FROM TMOVCXPM WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cfechavencimiento>'" + _Str_FechaIni + "'" +
                _Str_Sql = "SELECT cproveedor,ctipodocument,cfechavencimiento,ctotalimp,ctotalsimp,csaldo FROM VST_FACTPPAGARM WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "'" +
                " AND (ctipodocument='" + _Str_NC + "' OR ctipodocument='" + _Str_NDP + "') and cproveedor='" + Convert.ToString(_Dg_Row.Cells[0].Value) + "' and cactivo=1 and canulado=0 ORDER BY cfechavencimiento";
                _Ds_B = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
                foreach (DataRow _Dt_Row in _Ds_B.Tables[0].Rows)
                {
                    if (Convert.ToString(_Dt_Row["csaldo"]) != "")
                    {
                        _Dbl_NCval = Convert.ToDouble(_Dt_Row["csaldo"]);
                    }
                    else
                    { _Dbl_NCval = 0; }
                    _Dbl_NC = _Dbl_NC + _Dbl_NCval;
                }
                _Dg_Row.Cells[2].Value = _Dbl_NC.ToString("#,##0.00");
                //---------------------NUEVO----------------------------
                ////CARGO LOS DATOS DE NC
                //_Dbl_NDP = 0;
                ////_Str_Sql = "SELECT cproveedor,ctipodocument,cfechavencimiento,ctotalimp,ctotalsimp,csaldo FROM TMOVCXPM WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cfechavencimiento>'" + _Str_FechaIni + "'" +
                //_Str_Sql = "SELECT cproveedor,ctipodocument,cfechavencimiento,ctotalimp,ctotalsimp,csaldo FROM VST_FACTPPAGARM WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "'" +
                //" AND ctipodocument='" + _Str_NDP + "' and cproveedor='" + Convert.ToString(_Dg_Row.Cells[0].Value) + "' and cactivo=1 and canulado=0 ORDER BY cfechavencimiento";
                //_Ds_B = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
                //foreach (DataRow _Dt_Row in _Ds_B.Tables[0].Rows)
                //{
                //    if (Convert.ToString(_Dt_Row["csaldo"]) != "")
                //    {
                //        _Dbl_NDPval = Convert.ToDouble(_Dt_Row["csaldo"]);
                //    }
                //    else
                //    { _Dbl_NDPval = 0; }
                //    _Dbl_NDP = _Dbl_NDP + _Dbl_NDPval;
                //}
                //_Dg_Row.Cells[2].Value = _Dbl_NDP.ToString("#,##0.00");
                //---------------------NUEVO----------------------------
                //CARGO LOS DATOS DE ND
                _Dbl_ND = 0;
                //_Str_Sql = "SELECT cproveedor,ctipodocument,cfechavencimiento,ctotalimp,ctotalsimp,csaldo FROM TMOVCXPM WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cfechavencimiento>'" + _Str_FechaIni + "'" +
                _Str_Sql = "SELECT cproveedor,ctipodocument,cfechavencimiento,ctotalimp,ctotalsimp,csaldo FROM VST_FACTPPAGARM WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "'" +
                " AND (ctipodocument='" + _Str_ND + "' OR ctipodocument='" + _Str_NCP + "') and cproveedor='" + Convert.ToString(_Dg_Row.Cells[0].Value) + "' and cactivo=1 and canulado=0 ORDER BY cfechavencimiento";
                _Ds_B = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
                foreach (DataRow _Dt_Row in _Ds_B.Tables[0].Rows)
                {
                    if (Convert.ToString(_Dt_Row["csaldo"]) != "")
                    {
                        _Dbl_NDval = Convert.ToDouble(_Dt_Row["csaldo"]);
                    }
                    else
                    { _Dbl_NDval = 0; }
                    _Dbl_ND = _Dbl_ND + _Dbl_NDval;
                }
                _Dg_Row.Cells[3].Value = _Dbl_ND.ToString("#,##0.00");
                //--------------------------CHEQUES
                _Str_Sql = "SELECT SUM(cmontototal) FROM VST_EMICHEQTRANSM WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cproveedor='" + _Dg_Row.Cells[0].Value.ToString() + "' AND centregado=0 AND canulado='0' AND cimpimiocheq='1' AND cfpago='CHEQ'";
                _Ds_Data = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
                if (_Ds_Data.Tables[0].Rows.Count > 0)
                {
                    if (Convert.ToString(_Ds_Data.Tables[0].Rows[0][0]) != "")
                    {
                        _Dg_Row.Cells[5].Value = Convert.ToDouble(_Ds_Data.Tables[0].Rows[0][0]).ToString("#,##0.00");
                    }

                }
                //--------------------------
                //Cargo las Retenciones (IVA , ISLR)
                _Str_Sql = "select sum(csaldo) from VST_FACTPPAGARM where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "'" +
                " AND (ctipodocument='" + _Str_Ret + "' OR ctipodocument='" + _Str_RetISLR + "' OR ctipodocument='" + _Str_RetPatente + "') and cproveedor='" + Convert.ToString(_Dg_Row.Cells[0].Value) + "' and cactivo=1 and canulado=0";
                _Ds_B = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
                if (_Ds_B.Tables[0].Rows.Count > 0)
                {
                    if (Convert.ToString(_Ds_B.Tables[0].Rows[0][0]) != "")
                    {
                        if (_Str_FrmProvRetISLR != _Dg_Row.Cells[0].Value.ToString() && _Str_FrmProvRetIVA != _Dg_Row.Cells[0].Value.ToString())
                        {
                            if (Convert.ToDouble(_Ds_B.Tables[0].Rows[0][0]) < 0)
                            { _Dg_Row.Cells[4].Value = Convert.ToDouble(_Ds_B.Tables[0].Rows[0][0]).ToString("#,##0.00").Replace("-", ""); }
                            else
                            { _Dg_Row.Cells[4].Value = Convert.ToDouble(_Ds_B.Tables[0].Rows[0][0]).ToString("#,##0.00"); }

                        }
                        else
                        {
                            //UBICACION EN LAS FECHAS
                            _Str_Sql = "SELECT csaldo,cfechavencimiento FROM VST_FACTPPAGARM WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND (ctipodocument='" + _Str_Ret + "' OR ctipodocument='" + _Str_RetISLR + "' OR ctipodocument='" + _Str_RetPatente + "')" +
                            " and cactivo=1 and canulado=0 and cfechavencimiento>='" + _Cls_Formato._Mtd_fecha(Convert.ToDateTime(_Str_FechaIni)).ToString() + "' AND csaldo <> 0 AND cproveedor='" + _Dg_Row.Cells[0].Value.ToString() + "'";
                            _Ds_Data = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
                            foreach (DataRow _DRow_A in _Ds_Data.Tables[0].Rows)
                            {
                                _Str_Sql = "Select TCALENDCONT.canocalend AS canocalend, TCALENDCONT.cmescalend AS cmescalend, 1 + datepart(ww,cdiafecha_cal)- datepart(ww,CONVERT(DATETIME,'01/'+CONVERT(VARCHAR,MONTH(cdiafecha_cal))+'/'+CONVERT(VARCHAR,YEAR(cdiafecha_cal)))) AS csemcalend FROM TCALENDCONT WHERE TCALENDCONT.ccompany = '" + Frm_Padre._Str_Comp + "' AND CONVERT(VARCHAR,TCALENDCONT.cdiafecha_cal,103)='" + _Cls_Formato._Mtd_fecha(Convert.ToDateTime(_DRow_A["cfechavencimiento"])).ToString() + "'";
                                _Ds_A = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
                                if (_Ds_A.Tables[0].Rows.Count > 0)
                                {
                                    _Str_FechaTemp = "SEMANA " + _Mtd_PrimerDiaSemana(_Ds_A.Tables[0].Rows[0]["canocalend"].ToString(), _Ds_A.Tables[0].Rows[0]["cmescalend"].ToString(), _Ds_A.Tables[0].Rows[0]["csemcalend"].ToString()) + " al " + _Mtd_UltimoDiaSemana(_Ds_A.Tables[0].Rows[0]["canocalend"].ToString(), _Ds_A.Tables[0].Rows[0]["cmescalend"].ToString(), _Ds_A.Tables[0].Rows[0]["csemcalend"].ToString());
                                }
                                else
                                { _Str_FechaTemp = "FECHA NO ENCONTRADA EN EL CALENDARIO"; }
                                //VERIFICO SI YA LA AGREGUE EN EL GRID LA COLUMNA
                                foreach (DataGridViewColumn _DgCol in _Dg_Calendario.Columns)
                                {
                                    if (_DgCol.HeaderText == _Str_FechaTemp)
                                    {
                                        if (Convert.ToString(_Dg_Row.Cells[_DgCol.Index].Value) != "")
                                        {
                                            _Dbl_ValorAux = Convert.ToDouble(_Dg_Row.Cells[_DgCol.Index].Value);
                                        }
                                        else
                                        {
                                            _Dbl_ValorAux = 0;
                                        }
                                        _Dbl_ValorAux = _Dbl_ValorAux + Convert.ToDouble(_DRow_A["csaldo"]);
                                        _Dg_Row.Cells[_DgCol.Index].Value = _Dbl_ValorAux.ToString("#,##0.00");
                                    }
                                }
                            }
                            //UBICACION EN LOS VENCIDOS
                            _Str_Sql = "SELECT SUM(csaldo) FROM VST_FACTPPAGARM WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND (ctipodocument='" + _Str_Ret + "' OR ctipodocument='" + _Str_RetISLR + "' OR ctipodocument='" + _Str_RetPatente + "')" +
                            " and cactivo=1 and canulado=0 and cfechavencimiento<'" + _Cls_Formato._Mtd_fecha(Convert.ToDateTime(_Str_FechaIni)).ToString() + "' AND csaldo <> 0 AND cproveedor='" + _Dg_Row.Cells[0].Value.ToString() + "'";
                            _Ds_Data = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
                            if (_Ds_Data.Tables[0].Rows.Count > 0)
                            {
                                if (Convert.ToString(_Ds_Data.Tables[0].Rows[0][0]) != "")
                                {
                                    _Dg_Row.Cells[6].Value = Convert.ToDouble(_Ds_Data.Tables[0].Rows[0][0]).ToString("#,##0.00");
                                }

                            }
                        }

                    }
                }

            }
            //_Dg_Calendario.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }

        private void _Mtd_CargarTotalCols()
        {
            DataGridViewColumn _Dg_Col;
            double _Dbl_Acum = 0;
            double _Dbl_Val = 0;
            double _Dbl_TotFil = 0;
            double _Dbl_NC = 0;
            double _Dbl_ND = 0;
            double _Dbl_Cheq = 0;
            double _Dbl_Venc = 0;
            double _Dbl_Ret = 0;
            int _Int_Col = 0;
            int _Int_Fil = 0;
            _Dg_Calendario.Rows.Add();
            _Dg_Calendario[1, _Dg_Calendario.RowCount - 1].Value = "TOTAL PROVEEDORES";
            _Dg_Calendario.Rows[_Dg_Calendario.RowCount - 1].DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            for (_Int_Col = 2; _Int_Col <= (_Dg_Calendario.ColumnCount - 1); _Int_Col++)
            {
                for (_Int_Fil = 0; _Int_Fil <= (_Dg_Calendario.RowCount - 1); _Int_Fil++)
                {
                    if (Convert.ToString(_Dg_Calendario[_Int_Col, _Int_Fil].Value) == "")
                    { _Dbl_Val = 0; }
                    else
                    { _Dbl_Val = Convert.ToDouble(_Dg_Calendario[_Int_Col, _Int_Fil].Value); }
                    _Dbl_Acum = _Dbl_Acum + _Dbl_Val;
                }
                _Dg_Calendario[_Int_Col, _Dg_Calendario.RowCount - 1].Value = _Dbl_Acum.ToString("#,##0.00");
                _Dbl_Acum = 0;
            }

            _Dg_Col = new System.Windows.Forms.DataGridViewTextBoxColumn();
            _Dg_Col.Name = "_Dg_CalendarioCol_" + Convert.ToString(_Dg_Calendario.ColumnCount - 1);
            _Dg_Col.HeaderText = "TOTAL";
            _Dg_Col.CellTemplate.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            _Dg_Col.DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            _Dg_Calendario.Columns.Add(_Dg_Col);

            for (_Int_Fil = 0; _Int_Fil <= (_Dg_Calendario.RowCount - 1); _Int_Fil++)
            {
                if (Convert.ToString(_Dg_Calendario[2, _Int_Fil].Value) == "")
                { _Dbl_NC = 0; }
                else
                { _Dbl_NC = Convert.ToDouble(_Dg_Calendario[2, _Int_Fil].Value); }
                if (Convert.ToString(_Dg_Calendario[3, _Int_Fil].Value) == "")
                { _Dbl_ND = 0; }
                else
                { _Dbl_ND = Convert.ToDouble(_Dg_Calendario[3, _Int_Fil].Value); }
                if (Convert.ToString(_Dg_Calendario[4, _Int_Fil].Value) == "")
                { _Dbl_Ret = 0; }
                else
                { _Dbl_Ret = Convert.ToDouble(_Dg_Calendario[4, _Int_Fil].Value); }
                if (Convert.ToString(_Dg_Calendario[5, _Int_Fil].Value) == "")
                { _Dbl_Cheq = 0; }
                else
                { _Dbl_Cheq = Convert.ToDouble(_Dg_Calendario[5, _Int_Fil].Value); }
                if (Convert.ToString(_Dg_Calendario[6, _Int_Fil].Value) == "")
                { _Dbl_Venc = 0; }
                else
                { _Dbl_Venc = Convert.ToDouble(_Dg_Calendario[6, _Int_Fil].Value); }
                _Dbl_Acum = 0;
                for (_Int_Col = 7; _Int_Col <= (_Dg_Calendario.ColumnCount - 2); _Int_Col++)
                {
                    if (Convert.ToString(_Dg_Calendario[_Int_Col, _Int_Fil].Value) == "")
                    { _Dbl_Val = 0; }
                    else
                    { _Dbl_Val = Convert.ToDouble(_Dg_Calendario[_Int_Col, _Int_Fil].Value); }
                    _Dbl_Acum = _Dbl_Acum + _Dbl_Val;
                }
                //_Dbl_TotFil = _Dbl_Cheq + _Dbl_Venc + _Dbl_Acum + _Dbl_NC - _Dbl_ND - _Dbl_Ret;
                _Dbl_TotFil = _Dbl_Venc + _Dbl_Acum + _Dbl_NC - _Dbl_ND - _Dbl_Ret;
                if (_Dbl_TotFil < 0)
                { _Dbl_TotFil = _Dbl_TotFil * (-1); }
                _Dg_Calendario[(_Dg_Calendario.ColumnCount - 1), _Int_Fil].Value = _Dbl_TotFil.ToString("#,##0.00");

            }

        }

        private void _Mtd_ReiniciarGrid()
        {
            int _Int_I = 7;
            while (_Int_I <= _Dg_Calendario.ColumnCount - 1)
            {
                _Dg_Calendario.Columns.RemoveAt(_Int_I);
            }
            _Dg_Calendario.Rows.Clear();
        }

        private void _Mtd_CargarTipoProv()
        {
            System.Collections.ArrayList _myArrayList = new System.Collections.ArrayList();
            _Cmb_TipoProv.DataSource = null;
            _myArrayList.Add(new T3.Clases._Cls_ArrayList("...", "nulo"));
            _myArrayList.Add(new T3.Clases._Cls_ArrayList("SERVICIO", "0"));
            _myArrayList.Add(new T3.Clases._Cls_ArrayList("MATERIA PRIMA", "1"));
            _myArrayList.Add(new T3.Clases._Cls_ArrayList("OTROS", "2"));
            _Cmb_TipoProv.DataSource = _myArrayList;
            _Cmb_TipoProv.DisplayMember = "Display";
            _Cmb_TipoProv.ValueMember = "Value";
            _Cmb_TipoProv.SelectedValue = "nulo";
            _Cmb_TipoProv.DataSource = _myArrayList;
            _Cmb_TipoProv.SelectedIndex = 0;
        }
        private void _Mtd_CargarCategProv()
        {
            Cursor = Cursors.WaitCursor;
            string _Str_Cadena = "SELECT ccatproveedor,UPPER(cnombre) AS Nombre FROM TCATPROVEEDOR WHERE cdelete='0'";
            if (_Cmb_TipoProv.SelectedIndex > 0)
            { _Str_Cadena += " AND cglobal='" + _Cmb_TipoProv.SelectedValue.ToString().Trim() + "'"; }
            _Str_Cadena += " ORDER BY Nombre";
            _Cls_MyUtilidad._Mtd_CargarCombo(_Cmb_CategProv, _Str_Cadena);
            Cursor = Cursors.Default;
        }
        private void _Mtd_CargarProvee()
        {
            Cursor = Cursors.WaitCursor;
            string _Str_Cadena = "SELECT DISTINCT TPROVEEDOR.cproveedor,TPROVEEDOR.c_nomb_abreviado FROM TPROVEEDOR LEFT JOIN TGRUPPROVEE ON TPROVEEDOR.cproveedor =TGRUPPROVEE.cproveedor WHERE ISNULL(TPROVEEDOR.cdelete,0)='0' AND ISNULL(TGRUPPROVEE.cdelete,0)='0' AND TPROVEEDOR.c_activo='1'";
            if (_Cmb_TipoProv.SelectedIndex > 0)
            {
                if (_Cmb_TipoProv.SelectedValue.ToString().Trim() == "0" | _Cmb_TipoProv.SelectedValue.ToString().Trim() == "2")
                { _Str_Cadena += " AND TPROVEEDOR.ccompany='" + Frm_Padre._Str_Comp + "' AND TPROVEEDOR.cglobal='" + _Cmb_TipoProv.SelectedValue.ToString().Trim() + "'"; }
                else
                { _Str_Cadena += " AND TGRUPPROVEE.ccompany='" + Frm_Padre._Str_Comp + "' AND cglobal='" + _Cmb_TipoProv.SelectedValue.ToString().Trim() + "'"; }
            }
            else
            { _Str_Cadena += " AND ((TGRUPPROVEE.CCOMPANY='" + Frm_Padre._Str_Comp + "' AND TPROVEEDOR.cglobal='1') OR (TPROVEEDOR.cglobal<>'1' AND TPROVEEDOR.ccompany='" + Frm_Padre._Str_Comp + "'))"; }
            //-----------
            if (_Cmb_CategProv.SelectedIndex > 0)
            { _Str_Cadena += " AND TPROVEEDOR.ccatproveedor='" + _Cmb_CategProv.SelectedValue.ToString().Trim() + "'"; }
            //_Str_Cadena += " ORDER BY TPROVEEDOR.c_nomb_abreviado";

            //Union PQseada para que salgan los proveedores no activos
            _Str_Cadena += " UNION ";
            _Str_Cadena += " SELECT TPROVEEDOR.cproveedor,TPROVEEDOR.c_nomb_abreviado ";
            _Str_Cadena += " FROM TPROVEEDOR INNER JOIN ";
            _Str_Cadena += " TPROVEEDORHISTORICO ON TPROVEEDOR.cproveedor = TPROVEEDORHISTORICO.cproveedor AND TPROVEEDOR.c_rif = TPROVEEDORHISTORICO.c_rif ";
            _Str_Cadena += " WHERE ";
            _Str_Cadena += " TPROVEEDORHISTORICO.ccompany='" + Frm_Padre._Str_Comp + "' ";
            _Str_Cadena += " ORDER BY TPROVEEDOR.c_nomb_abreviado";

            _Cls_MyUtilidad._Mtd_CargarCombo(_Cmb_Proveedor, _Str_Cadena);
            Cursor = Cursors.Default;
        }
        private void Frm_ConsolidaObligaciones_Load(object sender, EventArgs e)
        {
            _Mtd_CargarProveedoresEspeciales();
            _Mtd_Sorted(_Dg_Calendario);
            _Mtd_CargarTipoProv();
            _Mtd_CargarCategProv();
            _Mtd_CargarProvee();
            _Mtd_Busqueda();
        }



        public void _Mtd_Sorted(DataGridView _Dg_My)
        {
            for (int _Int_i = 0; _Int_i < _Dg_My.Columns.Count; _Int_i++)
            {
                _Dg_My.Columns[_Int_i].SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }

        private void _Bt_Export_Click(object sender, EventArgs e)
        {
            if (_Dg_Calendario.RowCount > 0)
            {
                _Pgb_A.Value = 0;
                _Sfd_1.FileName = "Obligaciones" + CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate().Day.ToString() + "_" + CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate().Month.ToString() + "_" + CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate().Year.ToString() + ".xls";
                if (_Sfd_1.ShowDialog() == DialogResult.OK)
                {
                    if (_Sfd_1.FileName != "")
                    {
                        Cursor = Cursors.WaitCursor;
                        _Pgb_A.Value = 30;
                        System.Threading.Thread th1 = new System.Threading.Thread(new System.Threading.ThreadStart(_Mtd_Exportar));
                        th1.Start();
                        _Pgb_A.Value = 70;
                        th1.Join();
                        _Pgb_A.Value = 100;
                        Cursor = Cursors.Default;
                        MessageBox.Show("Exportación Completa.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        _Pgb_A.Value = 0;
                    }
                }
            }
        }

        private void _Mtd_Exportar()
        {
            _Cls_MyUtilidad._Mtd_GridViewtoExcelFormatoNumerico(_Dg_Calendario, _Sfd_1.FileName);
        }

        private void _Mtd_GridLimpiar()
        {
            foreach (DataGridViewRow _Dg_Row in _Dg_Calendario.Rows)
            {
                for (int _Int_I = 2; _Int_I < _Dg_Calendario.ColumnCount; _Int_I++)
                {
                    if (_Mtd_IsNumeric(_Dg_Row.Cells[_Int_I].Value))
                    {
                        if (Convert.ToDouble(_Dg_Row.Cells[_Int_I].Value) == 0)
                        {
                            _Dg_Row.Cells[_Int_I].Value = "";
                        }
                    }
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

        private void Frm_ConsolidaObligaciones_FormClosing(object sender, FormClosingEventArgs e)
        {
            CONTROLES._Ctrl_Buscar._txt_text.Text = "";
            CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "Cerrado";
        }

        private void Frm_ConsolidaObligaciones_Activated(object sender, EventArgs e)
        {
            _Ctrl_Controles[0] = _Cmb_TipoProv;
            _Ctrl_Controles[1] = _Cmb_CategProv;
            _Ctrl_Controles[2] = _Cmb_Proveedor;
            CLASES._Cls_Varios_Metodos _Cls_CL = new CLASES._Cls_Varios_Metodos(_Ctrl_Controles);
            _Cls_CL._Mtd_Foco();
            CONTROLES._Ctrl_Buscar._txt_text.Text = "";
            CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "Cerrado";
        }

        private void _Mtd_Busqueda()
        {
            Cursor = Cursors.WaitCursor;
            _Str_FechaIni = CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate().ToShortDateString();
            _Mtd_CargarProveedoresEspeciales();
            _Mtd_CargarProveedores();
            _Mtd_CargarSemanas();
            _Mtd_GridLimpiar();
            _Mtd_CargarTotalCols();
            _Mtd_Sorted(_Dg_Calendario);
            //_Dg_Calendario.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            Cursor = Cursors.Default;
        }

        private void _Bt_Find_Click(object sender, EventArgs e)
        {
            _Mtd_Busqueda();
        }

        private void _Dg_Calendario_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            Frm_RelPagProv _Frm = new Frm_RelPagProv(Convert.ToString(_Dg_Calendario[0, e.RowIndex].Value));
            Cursor = Cursors.Default;
            _Frm.MdiParent = this.MdiParent;
            _Frm.Dock = DockStyle.Fill;
            _Frm.Show();
        }

        private void _Mtd_CargarProveedoresEspeciales()
        {
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset("SELECT cprovretislr,cprovretiva FROM TCONFIGCXP WHERE ccompany='" + Frm_Padre._Str_Comp + "'");
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                _Str_FrmProvRetISLR = Convert.ToString(_Ds.Tables[0].Rows[0]["cprovretislr"]);
                _Str_FrmProvRetIVA = Convert.ToString(_Ds.Tables[0].Rows[0]["cprovretiva"]);
            }

        }

        private void _Dg_Calendario_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
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


        private void _Cmb_TipoProv_SelectedIndexChanged(object sender, EventArgs e)
        {
            _Mtd_CargarCategProv();
            _Mtd_CargarProvee();
            _Dg_Calendario.Rows.Clear();
        }

        private void _Cmb_CategProv_DropDown(object sender, EventArgs e)
        {
            _Mtd_CargarCategProv();
        }

        private void _Cmb_CategProv_SelectedIndexChanged(object sender, EventArgs e)
        {
            _Mtd_CargarProvee();
            _Dg_Calendario.Rows.Clear();
        }

        private void _Cmb_Proveedor_DropDown(object sender, EventArgs e)
        {
            _Mtd_CargarProvee();
        }

        private void _Cmb_Proveedor_SelectedIndexChanged(object sender, EventArgs e)
        {
            _Dg_Calendario.Rows.Clear();
        }
    }
}