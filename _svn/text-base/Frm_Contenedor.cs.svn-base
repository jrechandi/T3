using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Threading;
using System.Net;
using System.Xml;
using System.Configuration;
using System.IO;
using System.Net.NetworkInformation;
using System.Net;
namespace T3
{
    public partial class Frm_Contenedor : Form
    {
        CLASES._Cls_Varios_Metodos myUtilidad = new CLASES._Cls_Varios_Metodos(true);
        public bool _Bol_Inventario = false;
        public Frm_ConteoInventario _Frm_Conteo;
        DataSet _Ds_FrmTabs;
        Form _Frm_MdiParent;
        int _Int_Heigth = 0;
        int _Int_0 = 0, _Int_1 = 0, _Int_2 = 0, _Int_3 = 0, _Int_4 = 0;
        int _Int_5 = 0, _Int_6 = 0, _Int_7 = 0, _Int_8 = 0, _Int_9 = 0;
        int _Int_10 = 0, _Int_11 = 0, _Int_12 = 0, _Int_13 = 0, _Int_14 = 0;
        int _Int_15 = 0, _Int_16 = 0, _Int_17 = 0, _Int_18 = 0, _Int_19 = 0;
        int _Int_20 = 0, _Int_21 = 0, _Int_22 = 0, _Int_23 = 0, _Int_24 = 0;
        int _Int_25 = 0, _Int_26 = 0, _Int_27 = 0, _Int_28 = 0, _Int_29 = 0;
        int _Int_30 = 0, _Int_31 = 0, _Int_32 = 0, _Int_33 = 0, _Int_34 = 0;
        int _Int_35 = 0, _Int_36 = 0, _Int_37 = 0, _Int_38 = 0, _Int_39 = 0;
        int _Int_40 = 0, _Int_41 = 0, _Int_42 = 0, _Int_43 = 0, _Int_44 = 0;
        int _Int_45 = 0, _Int_46 = 0, _Int_47 = 0, _Int_48 = 0, _Int_49 = 0;
        int _Int_50 = 0, _Int_51 = 0, _Int_52 = 0, _Int_53 = 0, _Int_54 = 0;
        int _Int_55 = 0, _Int_56 = 0, _Int_57 = 0, _Int_58 = 0, _Int_59 = 0;
        int _Int_60 = 0, _Int_61 = 0, _Int_62 = 0, _Int_63 = 0, _Int_64 = 0;
        int _Int_65 = 0, _Int_66 = 0, _Int_67 = 0, _Int_68 = 0, _Int_69 = 0;
        int _Int_70 = 0, _Int_71 = 0, _Int_72 = 0, _Int_73 = 0, _Int_74 = 0;
        int _Int_75 = 0, _Int_76 = 0, _Int_77 = 0, _Int_78 = 0, _Int_79 = 0;
        int _Int_80 = 0, _Int_81 = 0, _Int_82 = 0, _Int_83 = 0, _Int_84 = 0;
        int _Int_85 = 0, _Int_86 = 0, _Int_87 = 0, _Int_88 = 0, _Int_89 = 0;
        int _Int_90 = 0, _Int_91 = 0, _Int_92 = 0, _Int_93 = 0, _Int_94 = 0;
        int _Int_95 = 0, _Int_96 = 0, _Int_97 = 0, _Int_98 = 0, _Int_99 = 0;
        int _Int_100 = 0, _Int_101 = 0, _Int_102 = 0, _Int_ControlFalla = -1;
        int _Int_103 = 0, _Int_104 = 0, _Int_105 = 0, _Int_106 = 0, _Int_107 = 0;
        int _Int_108 = 0, _Int_109 = 0, _Int_110 = 0, _Int_111 = 0, _Int_112=0;
        int _Int_113 = 0, _Int_114 = 0, _Int_115 = 0, _Int_116=0, _Int_117 = 0;
        int _Int_118 = 0, _Int_119 = 0, _Int_120 = 0, _Int_121 = 0, _Int_122 = 0;
        int _Int_123 = 0, _Int_124 = 0, _Int_125 = 0, _Int_126 = 0, _Int_127 = 0;
        int _Int_129 = 0, _Int_130 = 0, _Int_131 = 0, _Int_132 = 0, _Int_133 = 0;
        int _Int_134 = 0, _Int_135 = 0, _Int_136 = 0, _Int_137 = 0, _Int_138 = 0;
        int _Int_139 = 0, _Int_140 = 0, _Int_141 = 0, _Int_142 = 0, _Int_143 = 0;
        int _Int_144 = 0, _Int_145 = 0, _Int_146 = 0, _Int_147 = 0;
        //bool _Bol_TabsP = false;
        public bool _Bol_CnnSw = false;
        WaitCallback _async_Favoritos;
        public WaitCallback _async_Default;

        public Frm_Contenedor()
        {
            InitializeComponent();
        }
        public Frm_Contenedor(Form _P_Frm_MdiParent)
        {
            _Frm_MdiParent = _P_Frm_MdiParent;
            InitializeComponent();
            _Lbl_Comp.Text = Frm_Padre._Str_Comp.Trim() + " - " + _Mtd_NombComp().Trim();
        }
        private bool _Mtd_VerificarIp(string _P_Str_Ip)
        {
            try
            {
                Ping _Ping = new Ping();
                PingReply _Reply = _Ping.Send(_P_Str_Ip, 1500);
                return _Reply.Status == IPStatus.Success;
            }
            catch { }
            return false;
        }
        private void _Mtd_DetectarCambio()
        {
            SqlConnection _Sgl = Program._MyClsCnn._mtd_conexion._SQL_Conector;
            
        }
        private void _Mtd_DsTabs()
        {
            string _Str_Sql = "SELECT TTABS.ctabs " +
                 "FROM TUSER INNER JOIN " +
                 "TTABS ON TUSER.cgroup = TTABS.cgroup " +
                 "WHERE TUSER.cdelete = 0 and TUSER.cuser='" + Frm_Padre._Str_Use + "'";
            //_Ds_FrmTabs = _Mtd_GetDataSet(_Str_Sql);
            _Ds_FrmTabs = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
        }
        public delegate void MyDelegate_Ctrl_LinkForm(_Ctrl_LinkForm _Pr_MyControl);
        public void DelegateMethod_Ctrl_LinkForm(_Ctrl_LinkForm _Pr_MyControl)
        {
            _Pnl_ContenedorF.Controls.Add(_Pr_MyControl);
        }
        private void _Mtd_Cargar_Favoritos(Object param)
        {
            string _Str_Cadena = "select c_menuId from TMENUGROUP where cgroup='" + Frm_Padre._Str_UserGroup + "' and c_favorito='1'";
            DataSet _Ds = _Mtd_GetDataSet(_Str_Cadena);
            foreach (DataRow _Row in _Ds.Tables[0].Rows)
            {
                if (((Frm_Padre)_Frm_MdiParent).menuStrip1.Items.Find(_Row[0].ToString(), true).Length > 0)
                {
                    _Ctrl_LinkForm _Ctrl = new _Ctrl_LinkForm();
                    _Ctrl._Descripcion = ((Frm_Padre)_Frm_MdiParent).menuStrip1.Items.Find(_Row[0].ToString(), true)[0].Text;
                    _Ctrl._Menu = ((Frm_Padre)_Frm_MdiParent).menuStrip1.Items.Find(_Row[0].ToString(), true)[0];
                    _Ctrl.Dock = DockStyle.Top;
                    if (InvokeRequired)
                    {
                        object[] myArray = new object[1];

                        myArray[0] = _Ctrl;

                        this.Invoke(new MyDelegate_Ctrl_LinkForm(DelegateMethod_Ctrl_LinkForm), myArray);
                    }
                    else
                    {
                        _Pnl_ContenedorF.Controls.Add(_Ctrl);
                    }
                }
            }
            //_Bol_TabsP = false;
        }


        public delegate void MyDelegate_Ctrl_Tabs_Del(_Ctrl_Tabs _Pr_MyControl);
        public void DelegateMethod_Ctrl_Tabs_Del(_Ctrl_Tabs _Pr_MyControl)
        {
            _Pr_MyControl.Dispose();
        }
        public delegate void MyDelegate_Ctrl_Tabs_Change(_Ctrl_Tabs _Pr_MyControl, string _Pr_Str_Descrip);
        public void DelegateMethod_Ctrl_Tabs_Change(_Ctrl_Tabs _Pr_MyControl,string _Pr_Str_Descrip)
        {
            _Pr_MyControl._Descripcion = _Pr_Str_Descrip;
        }

        public delegate void MyDelegate_Ctrl_Tabs(_Ctrl_Tabs _Pr_MyControl);
        public void DelegateMethod_Ctrl_Tabs(_Ctrl_Tabs _Pr_MyControl)
        {
            _Pnl_Contenedor.Controls.Add(_Pr_MyControl);
        }
        public delegate void MyDelegate_Ctrl_Habilitar(Control _Pr_MyControl,bool _Pr_Sw);
        public void DelegateMethod_Ctrl_Habilitar(Control _Pr_MyControl, bool _Pr_Sw)
        {
            if (_Pr_MyControl.Name == "button1")
            {
                ((Button)_Pr_MyControl).ImageList = _LstImg_Main;
                if (_Pr_Sw)
                {
                    ((Button)_Pr_MyControl).ImageIndex = 1;    
                }
                else
                {
                    ((Button)_Pr_MyControl).ImageIndex = 0;
                }
            }
            _Pr_MyControl.Enabled = _Pr_Sw;
        }
        string _Str_Comps = "";
        DataSet _Ds_AuxTabs = new DataSet();
        private void _Mtd_Cargar_Tabs(Object param)
        {
            //_Bol_TabsP = true;
            if (_Str_Comps.Trim().Length == 0)
            { _Str_Comps = CLASES._Cls_Varios_Metodos._Mtd_SQL_Comp(); }
            _Mtd_DsTabs();
            string _Str_expression;
            string _Str_TabActual = "";
            bool _Bol_SwTimbre = false;
            object[] _myArrayHabilitar = new object[2];
            _myArrayHabilitar[0] = button1;
            _myArrayHabilitar[1] = false;
            try
            {
                
                this.Invoke(new MyDelegate_Ctrl_Habilitar(DelegateMethod_Ctrl_Habilitar), _myArrayHabilitar);

                int _Int_Count = 0;
                string _Str_Cadena = "";
                string _Str_Url = "";
                string _Str_Sql = "";
                string[] _Str_Campos;
                ToolStripMenuItem[] _Tsm_Menu;
                //---------------------TABS NÚMERO 0
                _Str_expression = "ctabs = 0";
                DataRow[] _Drow_found = _Ds_FrmTabs.Tables[0].Select(_Str_expression);
                if (_Drow_found.Length > 0)
                {
                    _Str_TabActual = "PROSPECTOS";
                    _Str_Sql = "select count(cdelete) from TPROSPECTO where c_solicitud='1' and cdelete='0' and cgroupcomp='" + Frm_Padre._Str_GroupComp + "'";
                    _Ds_AuxTabs = _Mtd_GetDataSet(_Str_Sql);
                    if (Convert.ToString(_Ds_AuxTabs.Tables[0].Rows[0][0]) != "")
                    {
                        _Int_Count = Convert.ToInt32(_Ds_AuxTabs.Tables[0].Rows[0][0]);
                    }
                    if (_Int_Count != _Int_0)
                    {
                        object[] myArray = new object[1];
                        if (_Int_Count > _Int_0)
                        { _Bol_SwTimbre = true; }
                        if (_Pnl_Contenedor.Controls.Find("_Ctrl0", false).Length > 0)
                        {
                            myArray[0] = ((_Ctrl_Tabs)(_Pnl_Contenedor.Controls.Find("_Ctrl0", false)[0]));
                            this.Invoke(new MyDelegate_Ctrl_Tabs_Del(DelegateMethod_Ctrl_Tabs_Del), myArray);
                            _Int_0 = _Int_Count;
                        }
                        if (_Int_Count > 0)
                        {
                            _Ctrl_Tabs _Ctrl = new _Ctrl_Tabs();
                            _Ctrl.Name = "_Ctrl0";
                            _Ctrl._Descripcion = "PROSPECTOS  ( " + _Int_Count.ToString() + " )";
                            _Ctrl._Formulario = "T3.Frm_Prospectos";
                            _Ctrl._FormularioMdi = _Frm_MdiParent;
                            //_Ctrl._Parametros = new object[] { false };
                            _Ctrl._Parametros = new object[] { };
                            _Ctrl.Dock = DockStyle.Top;
                            myArray[0] = _Ctrl;
                            this.Invoke(new MyDelegate_Ctrl_Tabs(DelegateMethod_Ctrl_Tabs), myArray);
                            _Int_0 = _Int_Count;
                        }
                    }
                }
                //---------------------TABS NÚMERO 0
                //---------------------------------------------------------------------------------------------------------
                //---------------------TABS NÚMERO 1
                _Str_expression = "ctabs = 1";
                _Drow_found = _Ds_FrmTabs.Tables[0].Select(_Str_expression);
                if (_Drow_found.Length > 0)
                {
                    _Str_TabActual = "PEDIDOS BLOQUEADOS";
                    _Int_Count = 0;
                    _Str_Sql = "SELECT count(ccliente) FROM TCOTPEDFACM INNER JOIN TCLIENTE ON TCOTPEDFACM.ccliente = TCLIENTE.ccliente INNER JOIN TVENDEDOR ON TCOTPEDFACM.ccompany = TVENDEDOR.ccompany AND TCOTPEDFACM.cvendedor = TVENDEDOR.cvendedor WHERE (TCOTPEDFACM.cstatus = 2) AND (TCOTPEDFACM.ccliente>0) AND (TCOTPEDFACM.cfactura <= 0) AND (TCOTPEDFACM.ccompany ='" + Frm_Padre._Str_Comp + "')" + " AND (TCLIENTE.cgroupcomp ='" + Frm_Padre._Str_GroupComp + "')";
                    _Ds_AuxTabs = _Mtd_GetDataSet(_Str_Sql);
                    if (Convert.ToString(_Ds_AuxTabs.Tables[0].Rows[0][0]) != "")
                    {
                        _Int_Count = Convert.ToInt32(_Ds_AuxTabs.Tables[0].Rows[0][0]);
                    }
                    if (_Int_Count != _Int_1)
                    {
                        object[] myArray = new object[1];
                        if (_Int_Count > _Int_1)
                        { _Bol_SwTimbre = true; }
                        if (_Pnl_Contenedor.Controls.Find("_Ctrl1", false).Length > 0)
                        {
                            myArray[0] = ((_Ctrl_Tabs)(_Pnl_Contenedor.Controls.Find("_Ctrl1", false)[0]));
                            this.Invoke(new MyDelegate_Ctrl_Tabs_Del(DelegateMethod_Ctrl_Tabs_Del), myArray);
                            _Int_1 = _Int_Count;
                        }
                        if (_Int_Count > 0)
                        {
                            _Ctrl_Tabs _Ctrl = new _Ctrl_Tabs();
                            _Ctrl.Name = "_Ctrl1";
                            _Ctrl._Descripcion = "PEDIDOS BLOQUEADOS  ( " + _Int_Count.ToString() + " )";
                            _Ctrl._Formulario = "Vacio";
                            _Ctrl.Dock = DockStyle.Top;
                            myArray[0] = _Ctrl;
                            this.Invoke(new MyDelegate_Ctrl_Tabs(DelegateMethod_Ctrl_Tabs), myArray);
                            _Int_1 = _Int_Count;
                        }
                    }
                }
                //---------------------TABS NÚMERO 1
                //---------------------------------------------------------------------------------------------------------
                //---------------------TABS NÚMERO 2
                _Str_expression = "ctabs = 2";
                _Drow_found = _Ds_FrmTabs.Tables[0].Select(_Str_expression);
                if (_Drow_found.Length > 0)
                {
                    _Str_TabActual = "CLIENTES BLOQUEADOS";
                    _Int_Count = 0;
                    _Str_Sql = "SELECT count(cgroupcomp) FROM TCLIENTE WHERE (c_estatus_cob = 'B') AND (cgroupcomp ='" + Frm_Padre._Str_GroupComp + "')";
                    _Ds_AuxTabs = _Mtd_GetDataSet(_Str_Sql);
                    if (Convert.ToString(_Ds_AuxTabs.Tables[0].Rows[0][0]) != "")
                    {
                        _Int_Count = Convert.ToInt32(_Ds_AuxTabs.Tables[0].Rows[0][0]);
                    }
                    if (_Int_Count != _Int_2)
                    {
                        object[] myArray = new object[1];
                        if (_Int_Count > _Int_2)
                        { _Bol_SwTimbre = true; }
                        if (_Pnl_Contenedor.Controls.Find("_Ctrl2", false).Length > 0)
                        {
                            myArray[0] = ((_Ctrl_Tabs)(_Pnl_Contenedor.Controls.Find("_Ctrl2", false)[0]));
                            this.Invoke(new MyDelegate_Ctrl_Tabs_Del(DelegateMethod_Ctrl_Tabs_Del), myArray);
                            _Int_2 = _Int_Count; 
                        }
                        if (_Int_Count > 0)
                        {
                            _Ctrl_Tabs _Ctrl = new _Ctrl_Tabs();
                            _Ctrl.Name = "_Ctrl2";
                            _Ctrl._Descripcion = "CLIENTES BLOQUEADOS  ( " + _Int_Count.ToString() + " )";
                            _Ctrl._Formulario = "Vacio";
                            _Ctrl.Dock = DockStyle.Top;
                            myArray[0] = _Ctrl;
                            this.Invoke(new MyDelegate_Ctrl_Tabs(DelegateMethod_Ctrl_Tabs), myArray);
                            _Int_2 = _Int_Count;
                        }
                    }
                }
                //---------------------TABS NÚMERO 2
                //---------------------------------------------------------------------------------------------------------
                //---------------------TABS NÚMERO 3
                _Str_expression = "ctabs = 3";
                _Drow_found = _Ds_FrmTabs.Tables[0].Select(_Str_expression);
                if (_Drow_found.Length > 0)
                {
                    _Str_TabActual = "N.C. POR APROBAR";
                    _Int_Count = 0;
                    _Str_Sql = "SELECT count(cactivo) FROM TNOTACREDIT WHERE (cactivo = '0') AND (ccompany ='" + Frm_Padre._Str_Comp + "')";
                    _Ds_AuxTabs = _Mtd_GetDataSet(_Str_Sql);
                    if (Convert.ToString(_Ds_AuxTabs.Tables[0].Rows[0][0]) != "")
                    {
                        _Int_Count = Convert.ToInt32(_Ds_AuxTabs.Tables[0].Rows[0][0]);
                    }
                    if (_Int_Count != _Int_3)
                    {
                        object[] myArray = new object[1];
                        if (_Int_Count > _Int_3)
                        { _Bol_SwTimbre = true; }
                        if (_Pnl_Contenedor.Controls.Find("_Ctrl3", false).Length > 0)
                        {
                            myArray[0] = ((_Ctrl_Tabs)(_Pnl_Contenedor.Controls.Find("_Ctrl3", false)[0]));
                            this.Invoke(new MyDelegate_Ctrl_Tabs_Del(DelegateMethod_Ctrl_Tabs_Del), myArray);
                            _Int_3 = _Int_Count; 
                        }
                        if (_Int_Count > 0)
                        {
                            _Ctrl_Tabs _Ctrl = new _Ctrl_Tabs();
                            _Ctrl.Name = "_Ctrl3";
                            _Ctrl._Descripcion = "N.C. POR APROBAR  ( " + _Int_Count.ToString() + " )";
                            _Ctrl._Formulario = "Vacio";
                            _Ctrl.Dock = DockStyle.Top;
                            myArray[0] = _Ctrl;
                            this.Invoke(new MyDelegate_Ctrl_Tabs(DelegateMethod_Ctrl_Tabs), myArray);
                            _Int_3 = _Int_Count;
                        }
                    }
                }
                //---------------------TABS NÚMERO 3
                //---------------------------------------------------------------------------------------------------------
                //---------------------TABS NÚMERO 4
                _Str_expression = "ctabs = 4";
                _Drow_found = _Ds_FrmTabs.Tables[0].Select(_Str_expression);
                if (_Drow_found.Length > 0)
                {
                    _Str_TabActual = "CLIENTES SIN ZONIFACIÓN";
                    _Int_Count = 0;
                    _Str_Sql = "SELECT count(cgroupcomp) FROM TCLIENTE WHERE c_zonificado='0' and cgroupcomp = '" + Frm_Padre._Str_GroupComp + "'";
                    _Ds_AuxTabs = _Mtd_GetDataSet(_Str_Sql);
                    if (Convert.ToString(_Ds_AuxTabs.Tables[0].Rows[0][0]) != "")
                    {
                        _Int_Count = Convert.ToInt32(_Ds_AuxTabs.Tables[0].Rows[0][0]);
                    }
                    if (_Int_Count != _Int_4)
                    {
                        object[] myArray = new object[1];
                        if (_Int_Count > _Int_4)
                        { _Bol_SwTimbre = true; }
                        if (_Pnl_Contenedor.Controls.Find("_Ctrl4", false).Length > 0)
                        {
                            myArray[0] = ((_Ctrl_Tabs)(_Pnl_Contenedor.Controls.Find("_Ctrl4", false)[0]));
                            this.Invoke(new MyDelegate_Ctrl_Tabs_Del(DelegateMethod_Ctrl_Tabs_Del), myArray);
                            _Int_4 = _Int_Count;
                        }
                        if (_Int_Count > 0)
                        {
                            _Ctrl_Tabs _Ctrl = new _Ctrl_Tabs();
                            _Ctrl.Name = "_Ctrl4";
                            _Ctrl._Descripcion = "CLIENTES SIN ZONIFACIÓN  ( " + _Int_Count.ToString() + " )";
                            _Ctrl._Formulario = "Vacio";
                            _Ctrl.Dock = DockStyle.Top;
                            myArray[0] = _Ctrl;
                            this.Invoke(new MyDelegate_Ctrl_Tabs(DelegateMethod_Ctrl_Tabs), myArray);
                            _Int_4 = _Int_Count;
                        }
                    }
                }
                //---------------------TABS NÚMERO 4
                //---------------------------------------------------------------------------------------------------------
                //---------------------TABS NÚMERO 5
                _Str_expression = "ctabs = 5";
                _Drow_found = _Ds_FrmTabs.Tables[0].Select(_Str_expression);
                if (_Drow_found.Length > 0)
                {
                    _Str_TabActual = "PUNTOS DE REORDEN";
                    _Int_Count = 0;
                    _Str_Sql = "SELECT count(cpuntoreorden) FROM TPRODUCTO WHERE  (cpuntoreorden >=cexisrealu1) AND (cpuntoreorden>0)";
                    _Ds_AuxTabs = _Mtd_GetDataSet(_Str_Sql);
                    if (Convert.ToString(_Ds_AuxTabs.Tables[0].Rows[0][0]) != "")
                    {
                        _Int_Count = Convert.ToInt32(_Ds_AuxTabs.Tables[0].Rows[0][0]);
                    }
                    if (_Int_Count != _Int_5)
                    {
                        object[] myArray = new object[1];
                        if (_Int_Count > _Int_5)
                        { _Bol_SwTimbre = true; }
                        if (_Pnl_Contenedor.Controls.Find("_Ctrl5", false).Length > 0)
                        {
                            myArray[0] = ((_Ctrl_Tabs)(_Pnl_Contenedor.Controls.Find("_Ctrl5", false)[0]));
                            this.Invoke(new MyDelegate_Ctrl_Tabs_Del(DelegateMethod_Ctrl_Tabs_Del), myArray);
                            _Int_5 = _Int_Count;
                        }
                        if (_Int_Count > 0)
                        {
                            _Ctrl_Tabs _Ctrl = new _Ctrl_Tabs();
                            _Ctrl.Name = "_Ctrl5";
                            _Ctrl._Descripcion = "PUNTOS DE REORDEN ( " + _Int_Count.ToString() + " )";
                            _Ctrl._Formulario = "Vacio";
                            _Ctrl.Dock = DockStyle.Top;
                            myArray[0] = _Ctrl;
                            this.Invoke(new MyDelegate_Ctrl_Tabs(DelegateMethod_Ctrl_Tabs), myArray);
                            _Int_5 = _Int_Count;
                        }
                    }
                }
                //---------------------TABS NÚMERO 5
                //---------------------------------------------------------------------------------------------------------
                //---------------------TABS NÚMERO 6
                _Str_expression = "ctabs = 6";
                _Drow_found = _Ds_FrmTabs.Tables[0].Select(_Str_expression);
                if (_Drow_found.Length > 0)
                {
                    _Str_TabActual = "PEDIDOS BLOQUEADOS";
                    _Int_Count = 0;
                    _Str_Sql = "SELECT count(TCOTPEDFACM.ccliente) FROM TCOTPEDFACM INNER JOIN TCLIENTE ON TCOTPEDFACM.ccliente = TCLIENTE.ccliente INNER JOIN TVENDEDOR ON TCOTPEDFACM.ccompany = TVENDEDOR.ccompany AND TCOTPEDFACM.cvendedor = TVENDEDOR.cvendedor WHERE (TCOTPEDFACM.cstatus = '3') AND (TCOTPEDFACM.ccompany ='" + Frm_Padre._Str_Comp + "')" + " AND (TCLIENTE.cgroupcomp ='" + Frm_Padre._Str_GroupComp + "')";
                    _Ds_AuxTabs = _Mtd_GetDataSet(_Str_Sql);
                    if (Convert.ToString(_Ds_AuxTabs.Tables[0].Rows[0][0]) != "")
                    {
                        _Int_Count = Convert.ToInt32(_Ds_AuxTabs.Tables[0].Rows[0][0]);
                    }
                    if (_Int_Count != _Int_6)
                    {
                        object[] myArray = new object[1];
                        if (_Int_Count > _Int_6)
                        { _Bol_SwTimbre = true; }
                        if (_Pnl_Contenedor.Controls.Find("_Ctrl6", false).Length > 0)
                        {
                            myArray[0] = ((_Ctrl_Tabs)(_Pnl_Contenedor.Controls.Find("_Ctrl6", false)[0]));
                            this.Invoke(new MyDelegate_Ctrl_Tabs_Del(DelegateMethod_Ctrl_Tabs_Del), myArray);
                            _Int_6 = _Int_Count;
                        }
                        if (_Int_Count > 0)
                        {
                            _Ctrl_Tabs _Ctrl = new _Ctrl_Tabs();
                            _Ctrl.Name = "_Ctrl6";
                            _Ctrl._Descripcion = "PEDIDOS BLOQUEADOS  ( " + _Int_Count.ToString() + " )";
                            _Ctrl._Formulario = "Vacio";
                            _Ctrl.Dock = DockStyle.Top;
                            myArray[0] = _Ctrl;
                            this.Invoke(new MyDelegate_Ctrl_Tabs(DelegateMethod_Ctrl_Tabs), myArray);
                            _Int_6 = _Int_Count;
                        }
                    }
                }
                //---------------------TABS NÚMERO 6
                //---------------------------------------------------------------------------------------------------------
                //---------------------TABS NÚMERO 7
                _Str_expression = "ctabs = 7";
                _Drow_found = _Ds_FrmTabs.Tables[0].Select(_Str_expression);
                if (_Drow_found.Length > 0)
                {
                    _Str_TabActual = "BACK-ORDER";
                    _Int_Count = 0;
                    _Str_Sql = "SELECT count(ccompany) FROM TBAKORDERM WHERE  (ccompany ='" + Frm_Padre._Str_Comp + "')";
                    _Ds_AuxTabs = _Mtd_GetDataSet(_Str_Sql);
                    if (Convert.ToString(_Ds_AuxTabs.Tables[0].Rows[0][0]) != "")
                    {
                        _Int_Count = Convert.ToInt32(_Ds_AuxTabs.Tables[0].Rows[0][0]);
                    }
                    if (_Int_Count != _Int_7)
                    {
                        object[] myArray = new object[1];
                        if (_Int_Count > _Int_7)
                        { _Bol_SwTimbre = true; }
                        if (_Pnl_Contenedor.Controls.Find("_Ctrl7", false).Length > 0)
                        {
                            myArray[0] = ((_Ctrl_Tabs)(_Pnl_Contenedor.Controls.Find("_Ctrl7", false)[0]));
                            this.Invoke(new MyDelegate_Ctrl_Tabs_Del(DelegateMethod_Ctrl_Tabs_Del), myArray);
                            _Int_7 = _Int_Count;
                        }
                        if (_Int_Count > 0)
                        {
                            _Ctrl_Tabs _Ctrl = new _Ctrl_Tabs();
                            _Ctrl.Name = "_Ctrl7";
                            _Ctrl._Descripcion = "BACK-ORDER  ( " + _Int_Count.ToString() + " )";
                            _Ctrl._Formulario = "Vacio";
                            _Ctrl.Dock = DockStyle.Top;
                            myArray[0] = _Ctrl;
                            this.Invoke(new MyDelegate_Ctrl_Tabs(DelegateMethod_Ctrl_Tabs), myArray);
                            _Int_7 = _Int_Count;
                        }
                    }
                }
                //---------------------TABS NÚMERO 7
                //---------------------------------------------------------------------------------------------------------
                //---------------------TABS NÚMERO 8
                _Str_expression = "ctabs = 8";
                _Drow_found = _Ds_FrmTabs.Tables[0].Select(_Str_expression);
                if (_Drow_found.Length > 0)
                {
                    _Str_TabActual = "P.O.C. POR VENDEDOR";
                    _Int_Count = 0;
                    _Str_Sql = "SELECT count(TPROVEEDOR.cproveedor) " +
    "FROM TPREORDENCM INNER JOIN " +
    "TPROVEEDOR ON TPREORDENCM.cproveedor = TPROVEEDOR.cproveedor AND " +
    "TPREORDENCM.cdelete = TPROVEEDOR.cdelete " +
    "WHERE (TPREORDENCM.cdelete = 0) AND (TPREORDENCM.cstatus = 5) AND (TPREORDENCM.ccompany = '" + Frm_Padre._Str_Comp + "')";
                    _Ds_AuxTabs = _Mtd_GetDataSet(_Str_Sql);
                    if (Convert.ToString(_Ds_AuxTabs.Tables[0].Rows[0][0]) != "")
                    {
                        _Int_Count = Convert.ToInt32(_Ds_AuxTabs.Tables[0].Rows[0][0]);
                    }
                    if (_Int_Count != _Int_8)
                    {
                        object[] myArray = new object[1];
                        if (_Int_Count > _Int_8)
                        { _Bol_SwTimbre = true; }
                        if (_Pnl_Contenedor.Controls.Find("_Ctrl8", false).Length > 0)
                        {
                            myArray[0] = ((_Ctrl_Tabs)(_Pnl_Contenedor.Controls.Find("_Ctrl8", false)[0]));
                            this.Invoke(new MyDelegate_Ctrl_Tabs_Del(DelegateMethod_Ctrl_Tabs_Del), myArray);
                            _Int_8 = _Int_Count; 
                        }
                        if (_Int_Count > 0)
                        {
                            _Ctrl_Tabs _Ctrl = new _Ctrl_Tabs();
                            _Ctrl.Name = "_Ctrl8";
                            _Ctrl._Descripcion = "P.O.C. POR VENDEDOR  ( " + _Int_Count.ToString() + " )";
                            _Str_Url = CLASES._Cls_Varios_Metodos._Str_Servidor_Web;
                            _Ctrl._Formulario = "T3.Frm_Navegador";
                            _Ctrl._FormularioMdi = _Frm_MdiParent;
                            _Ctrl._Parametros = new object[] { _Str_Url, true };
                            _Ctrl.Dock = DockStyle.Top;
                            myArray[0] = _Ctrl;
                            this.Invoke(new MyDelegate_Ctrl_Tabs(DelegateMethod_Ctrl_Tabs), myArray);
                            _Int_8 = _Int_Count;
                        }
                    }
                }
                //---------------------TABS NÚMERO 8
                //---------------------------------------------------------------------------------------------------------
                //---------------------TABS NÚMERO 9
                _Str_expression = "ctabs = 9";
                _Drow_found = _Ds_FrmTabs.Tables[0].Select(_Str_expression);
                if (_Drow_found.Length > 0)
                {
                    _Str_TabActual = "O.C. POR LLEGAR";
                    _Int_Count = 0;
                    _Str_Sql = "SELECT count(ccompany) " +
    "FROM vst_tabordencompra " +
    "WHERE (ccompany = '" + Frm_Padre._Str_Comp + "') AND (cocaprovee=1) AND (centroinvent=0) AND (ccerrada=0) AND (cefectividad<=(Select cmaxefectivioc from TCONFIGCOMP where ccompany='" + Frm_Padre._Str_Comp + "'))";
                    _Ds_AuxTabs = _Mtd_GetDataSet(_Str_Sql);
                    if (Convert.ToString(_Ds_AuxTabs.Tables[0].Rows[0][0]) != "")
                    {
                        _Int_Count = Convert.ToInt32(_Ds_AuxTabs.Tables[0].Rows[0][0]);
                    }
                    if (_Int_Count != _Int_9)
                    {
                        object[] myArray = new object[1];
                        if (_Int_Count > _Int_9)
                        { _Bol_SwTimbre = true; }
                        if (_Pnl_Contenedor.Controls.Find("_Ctrl9", false).Length > 0)
                        {
                            myArray[0] = ((_Ctrl_Tabs)(_Pnl_Contenedor.Controls.Find("_Ctrl9", false)[0]));
                            this.Invoke(new MyDelegate_Ctrl_Tabs_Del(DelegateMethod_Ctrl_Tabs_Del), myArray);
                            _Int_9 = _Int_Count;
                        }
                        if (_Int_Count > 0)
                        {
                            _Ctrl_Tabs _Ctrl = new _Ctrl_Tabs();
                            _Ctrl.Name = "_Ctrl9";
                            _Ctrl._Descripcion = "O.C. POR LLEGAR  ( " + _Int_Count.ToString() + " )";
                            string _Str_Web1 = CLASES._Cls_Varios_Metodos._Str_Servidor_Web + "/ocvista.aspx?" + osio.encriptar("CodOc") + "=";
                            string _Str_Web2 = "&" + osio.encriptar("CodComp") + "=" + osio.encriptar(Frm_Padre._Str_Comp);
                            _Tsm_Menu = new ToolStripMenuItem[3];
                            _Tsm_Menu[0] = new ToolStripMenuItem("Id O.C.");
                            _Tsm_Menu[1] = new ToolStripMenuItem("Fecha");
                            _Tsm_Menu[2] = new ToolStripMenuItem("Proveedor");
                            _Str_Campos = new string[3];
                            _Str_Campos[0] = "cnumoc";
                            _Str_Campos[1] = "cfechaoc";
                            _Str_Campos[2] = "c_nomb_abreviado";
                            _Str_Cadena = "SELECT cnumoc AS [Id O.C.],Fecha,Proveedor,Cajas,Monto " +
                            "FROM vst_tabordencompra " +
                            "WHERE (ccompany = '" + Frm_Padre._Str_Comp + "') AND (cocaprovee=1) AND (centroinvent=0) AND (ccerrada=0) AND (cefectividad<=(Select cmaxefectivioc from TCONFIGCOMP where ccompany='" + Frm_Padre._Str_Comp + "'))";
                            _Ctrl._Formulario = "T3.Frm_Busqueda";
                            _Ctrl._FormularioMdi = _Frm_MdiParent;
                            _Ctrl._Parametros = new object[] { _Str_Cadena, _Str_Campos, "Orden de Compra", _Tsm_Menu, _Str_Web1, _Str_Web2, true };
                            _Ctrl.Dock = DockStyle.Top;
                            myArray[0] = _Ctrl;
                            this.Invoke(new MyDelegate_Ctrl_Tabs(DelegateMethod_Ctrl_Tabs), myArray);
                            _Int_9 = _Int_Count;
                        }
                    }
                }
                //---------------------TABS NÚMERO 9
                //---------------------------------------------------------------------------------------------------------
                //---------------------TABS NÚMERO 10
                _Str_expression = "ctabs = 10";
                _Drow_found = _Ds_FrmTabs.Tables[0].Select(_Str_expression);
                if (_Drow_found.Length > 0)
                {
                    _Str_TabActual = "RECEPCIONES DE TRANSPORTE";
                    _Int_Count = 0;
                    _Str_Sql = "SELECT count(cidrecepcion) " +
    "FROM TRECEPCIONM INNER JOIN " +
    "TPROVEEDOR ON TRECEPCIONM.cproveedor = TPROVEEDOR.cproveedor " +
    "WHERE (TRECEPCIONM.cgroupcomp = '" + Frm_Padre._Str_GroupComp + "') AND (TPROVEEDOR.cdelete = 0) AND (TRECEPCIONM.ccerrada = 0) AND (TRECEPCIONM.ccargfactura = 0)";
                    _Ds_AuxTabs = _Mtd_GetDataSet(_Str_Sql);
                    if (Convert.ToString(_Ds_AuxTabs.Tables[0].Rows[0][0]) != "")
                    {
                        _Int_Count = Convert.ToInt32(_Ds_AuxTabs.Tables[0].Rows[0][0]);
                    }
                    if (_Int_Count != _Int_10)
                    {
                        object[] myArray = new object[1];
                        if (_Int_Count > _Int_10)
                        { _Bol_SwTimbre = true; }
                        if (_Pnl_Contenedor.Controls.Find("_Ctrl10", false).Length > 0)
                        {
                            myArray[0] = ((_Ctrl_Tabs)(_Pnl_Contenedor.Controls.Find("_Ctrl10", false)[0]));
                            this.Invoke(new MyDelegate_Ctrl_Tabs_Del(DelegateMethod_Ctrl_Tabs_Del), myArray);
                            _Int_10 = _Int_Count; 
                        }
                        if (_Int_Count > 0)
                        {
                            _Ctrl_Tabs _Ctrl = new _Ctrl_Tabs();
                            _Ctrl.Name = "_Ctrl10";
                            _Ctrl._Descripcion = "RECEPCIONES DE TRANSPORTE ( " + _Int_Count.ToString() + " )";
                            _Ctrl._Formulario = "T3.Frm_Busqueda2";
                            _Ctrl._FormularioMdi = _Frm_MdiParent;
                            _Ctrl._Parametros = new object[] { 83 };
                            _Ctrl.Dock = DockStyle.Top;
                            myArray[0] = _Ctrl;
                            this.Invoke(new MyDelegate_Ctrl_Tabs(DelegateMethod_Ctrl_Tabs), myArray);
                            _Int_10 = _Int_Count;
                        }
                    }
                }
                //---------------------TABS NÚMERO 10
                //---------------------------------------------------------------------------------------------------------
                //---------------------TABS NÚMERO 11
                _Str_expression = "ctabs = 11";
                _Drow_found = _Ds_FrmTabs.Tables[0].Select(_Str_expression);
                if (_Drow_found.Length > 0)
                {
                    _Str_TabActual = "RECEPCIONES DE TRANSPORTE";
                    _Int_Count=0;
                    _Str_Sql = "SELECT count(cidrecepcion) " +
    "FROM TRECEPCIONM INNER JOIN " +
    "TPROVEEDOR ON TRECEPCIONM.cproveedor = TPROVEEDOR.cproveedor " +
    "WHERE (TRECEPCIONM.cgroupcomp = '" + Frm_Padre._Str_GroupComp + "') AND (TPROVEEDOR.cdelete = 0) AND (TRECEPCIONM.ccerrada = 0) AND (TRECEPCIONM.cevaluado = 1)";
                    _Ds_AuxTabs = _Mtd_GetDataSet(_Str_Sql);
                    if (Convert.ToString(_Ds_AuxTabs.Tables[0].Rows[0][0]) != "")
                    {
                        _Int_Count = Convert.ToInt32(_Ds_AuxTabs.Tables[0].Rows[0][0]);
                    }
                    if (_Int_Count != _Int_11)
                    {
                        object[] myArray = new object[1];
                        if (_Int_Count > _Int_11)
                        { _Bol_SwTimbre = true; }
                        if (_Pnl_Contenedor.Controls.Find("_Ctrl11", false).Length > 0)
                        {
                            myArray[0] = ((_Ctrl_Tabs)(_Pnl_Contenedor.Controls.Find("_Ctrl11", false)[0]));
                            this.Invoke(new MyDelegate_Ctrl_Tabs_Del(DelegateMethod_Ctrl_Tabs_Del), myArray);
                            _Int_11 = _Int_Count; 
                        }
                        if (_Int_Count > 0)
                        {
                            _Ctrl_Tabs _Ctrl = new _Ctrl_Tabs();
                            _Ctrl.Name = "_Ctrl11";
                            _Ctrl._Descripcion = "RECEPCIONES DE TRANSPORTE  ( " + _Int_Count.ToString() + " )";
                            _Ctrl._Formulario = "T3.Frm_Recepcion";
                            _Ctrl._FormularioMdi = _Frm_MdiParent;
                            _Ctrl._Parametros = null;
                            _Ctrl.Dock = DockStyle.Top;
                            myArray[0] = _Ctrl;
                            this.Invoke(new MyDelegate_Ctrl_Tabs(DelegateMethod_Ctrl_Tabs), myArray);
                            _Int_11 = _Int_Count;
                        }
                    }
                }
                //---------------------TABS NÚMERO 11
                //---------------------------------------------------------------------------------------------------------
                //---------------------TABS NÚMERO 12
                _Str_expression = "ctabs = 12";
                _Drow_found = _Ds_FrmTabs.Tables[0].Select(_Str_expression);
                if (_Drow_found.Length > 0)
                {
                    _Str_TabActual = "O.C. POR CERRAR";
                    _Int_Count = 0;
                    _Str_Sql = "Select count(ccompany) from vst_ordendecompragerente where ccompany='" + Frm_Padre._Str_Comp + "' and cgroupcomp='" + Frm_Padre._Str_GroupComp + "'";
                    _Ds_AuxTabs = _Mtd_GetDataSet(_Str_Sql);
                    if (Convert.ToString(_Ds_AuxTabs.Tables[0].Rows[0][0]) != "")
                    {
                        _Int_Count = Convert.ToInt32(_Ds_AuxTabs.Tables[0].Rows[0][0]);
                    }
                    if (_Int_Count != _Int_12)
                    {
                        object[] myArray = new object[1];
                        if (_Int_Count > _Int_12)
                        { _Bol_SwTimbre = true; }
                        if (_Pnl_Contenedor.Controls.Find("_Ctrl12", false).Length > 0)
                        {
                            myArray[0] = ((_Ctrl_Tabs)(_Pnl_Contenedor.Controls.Find("_Ctrl12", false)[0]));
                            this.Invoke(new MyDelegate_Ctrl_Tabs_Del(DelegateMethod_Ctrl_Tabs_Del), myArray);
                            _Int_12 = _Int_Count;
                        }
                        if (_Int_Count > 0)
                        {
                            _Ctrl_Tabs _Ctrl = new _Ctrl_Tabs();
                            _Ctrl.Name = "_Ctrl12";
                            _Ctrl._Descripcion = "O.C. POR CERRAR  ( " + _Int_Count.ToString() + " )";
                            _Ctrl._Formulario = "T3.Frm_VistaGerente";
                            _Ctrl._FormularioMdi = _Frm_MdiParent;
                            _Ctrl._Parametros = null;
                            _Ctrl.Dock = DockStyle.Top;
                            myArray[0] = _Ctrl;
                            this.Invoke(new MyDelegate_Ctrl_Tabs(DelegateMethod_Ctrl_Tabs), myArray);
                            _Int_12 = _Int_Count;
                        }
                    }
                }
                //---------------------TABS NÚMERO 12
                //---------------------------------------------------------------------------------------------------------
                //---------------------TABS NÚMERO 13
                _Str_expression = "ctabs = 13";
                _Drow_found = _Ds_FrmTabs.Tables[0].Select(_Str_expression);
                if (_Drow_found.Length > 0)
                {
                    _Str_TabActual = "N.R. POR IMPRIMIR";
                    _Int_Count = 0;
                    _Str_Sql = "Select count(cdelete) from vst_consultanotarecepcionmaestra where cdelete='0' and cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and ccompany='" + Frm_Padre._Str_Comp + "' and cimpreso='0'";
                    _Ds_AuxTabs = _Mtd_GetDataSet(_Str_Sql);
                    if (Convert.ToString(_Ds_AuxTabs.Tables[0].Rows[0][0]) != "")
                    {
                        _Int_Count = Convert.ToInt32(_Ds_AuxTabs.Tables[0].Rows[0][0]);
                    }
                    if (_Int_Count != _Int_13)
                    {
                        object[] myArray = new object[1];
                        if (_Int_Count > _Int_13)
                        { _Bol_SwTimbre = true; }
                        if (_Pnl_Contenedor.Controls.Find("_Ctrl13", false).Length > 0)
                        {
                            myArray[0] = ((_Ctrl_Tabs)(_Pnl_Contenedor.Controls.Find("_Ctrl13", false)[0]));
                            this.Invoke(new MyDelegate_Ctrl_Tabs_Del(DelegateMethod_Ctrl_Tabs_Del), myArray);
                            _Int_13 = _Int_Count;
                        }
                        if (_Int_Count > 0)
                        {
                            _Ctrl_Tabs _Ctrl = new _Ctrl_Tabs();
                            _Ctrl.Name = "_Ctrl13";
                            _Ctrl._Descripcion = "N.R. POR IMPRIMIR  ( " + _Int_Count.ToString() + " )";
                            _Tsm_Menu = new ToolStripMenuItem[3];
                            _Tsm_Menu[0] = new ToolStripMenuItem("N.R.");
                            _Tsm_Menu[1] = new ToolStripMenuItem("T. Documento");
                            _Tsm_Menu[2] = new ToolStripMenuItem("Proveedor");
                            _Str_Campos = new string[3];
                            _Str_Campos[0] = "cidnotrecepc";
                            _Str_Campos[1] = "cname";
                            _Str_Campos[2] = "c_nomb_comer";
                            _Str_Cadena = "Select cidnotrecepc as [N.R.],cnumdocu as Factura,cname as [T. Documento],c_nomb_abreviado as Proveedor from vst_consultanotarecepcionmaestra where cdelete='0' and cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and ccompany='" + Frm_Padre._Str_Comp + "' and cimpreso='0'";
                            _Ctrl._Formulario = "T3.Frm_NRNCND";
                            _Ctrl._FormularioMdi = _Frm_MdiParent;
                            _Ctrl._Parametros = new object[] { _Str_Cadena, _Str_Campos, "N.R. por Imprimir", _Tsm_Menu, 1 };
                            _Ctrl.Dock = DockStyle.Top;
                            myArray[0] = _Ctrl;
                            this.Invoke(new MyDelegate_Ctrl_Tabs(DelegateMethod_Ctrl_Tabs), myArray);
                            _Int_13 = _Int_Count;
                        }
                    }
                }
                //---------------------TABS NÚMERO 13
                //---------------------------------------------------------------------------------------------------------
                //---------------------TABS NÚMERO 14
                _Str_expression = "ctabs = 14";
                _Drow_found = _Ds_FrmTabs.Tables[0].Select(_Str_expression);
                if (_Drow_found.Length > 0)
                {
                    _Str_TabActual = "N.D. POR IMPRIMIR A PROVEEDORES";
                    _Int_Count = 0;
                    _Str_Sql = "Select count(ccompany) from TNOTADEBITOCP where cdelete='0' and ccompany='" + Frm_Padre._Str_Comp + "' and cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and cimpresa='0' and cactivo='0' and cestatusfirma='2' and canulado='0' AND (cmanual='1' OR cidnotrecepc>0 OR (cmanual='0' AND cidnotrecepc='0' AND cidcomprob>0 AND cdescontada='1'))";//(cmanual='0' AND cidnotrecepc='0' AND cidcomprob>0 AND cdescontada='1') Son las de Descuento pronto pago.
                    _Ds_AuxTabs = _Mtd_GetDataSet(_Str_Sql);
                    if (Convert.ToString(_Ds_AuxTabs.Tables[0].Rows[0][0]) != "")
                    {
                        _Int_Count = Convert.ToInt32(_Ds_AuxTabs.Tables[0].Rows[0][0]);
                    }
                    if (_Int_Count != _Int_14)
                    {
                        object[] myArray = new object[1];
                        if (_Int_Count > _Int_14)
                        { _Bol_SwTimbre = true; }
                        if (_Pnl_Contenedor.Controls.Find("_Ctrl14", false).Length > 0)
                        {
                            myArray[0] = ((_Ctrl_Tabs)(_Pnl_Contenedor.Controls.Find("_Ctrl14", false)[0]));
                            this.Invoke(new MyDelegate_Ctrl_Tabs_Del(DelegateMethod_Ctrl_Tabs_Del), myArray);
                            _Int_14 = _Int_Count;
                        }
                        if (_Int_Count > 0)
                        {
                            _Ctrl_Tabs _Ctrl = new _Ctrl_Tabs();
                            _Ctrl.Name = "_Ctrl14";
                            _Ctrl._Descripcion = _Str_TabActual + " ( " + _Int_Count.ToString() + " )";
                            _Tsm_Menu = new ToolStripMenuItem[2];
                            _Tsm_Menu[0] = new ToolStripMenuItem("Código");
                            _Tsm_Menu[1] = new ToolStripMenuItem("Descripción");
                            _Str_Campos = new string[2];
                            _Str_Campos[0] = "cidnotadebitocxp";
                            _Str_Campos[1] = "cdescripcion";
                            _Str_Cadena = "Select cidnotadebitocxp as Código,cdescripcion as Descripción,CASE WHEN cidnotrecepc>0 THEN ISNULL(cmontototsi,0) ELSE ISNULL(cmontototsi,0)+ISNULL(cbaseexcenta,0) END as Monto from TNOTADEBITOCP where cdelete='0' and ccompany='" + Frm_Padre._Str_Comp + "' and cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and cimpresa='0' and cactivo='0' and cestatusfirma='2' and canulado='0' AND (cmanual='1' OR cidnotrecepc>0 OR (cmanual='0' AND cidnotrecepc='0' AND cidcomprob>0 AND cdescontada='1'))";
                            _Ctrl._Formulario = "T3.Frm_NRNCND";
                            _Ctrl._FormularioMdi = _Frm_MdiParent;
                            _Ctrl._Parametros = new object[] { _Str_Cadena, _Str_Campos, "N.D. por Imprimir - Proveedores", _Tsm_Menu, 2 };
                            _Ctrl.Dock = DockStyle.Top;
                            myArray[0] = _Ctrl;
                            this.Invoke(new MyDelegate_Ctrl_Tabs(DelegateMethod_Ctrl_Tabs), myArray);
                            _Int_14 = _Int_Count;
                        }
                    }
                }
                //---------------------TABS NÚMERO 14
                //---------------------------------------------------------------------------------------------------------
                //---------------------TABS NÚMERO 15
                _Str_expression = "ctabs = 15";
                _Drow_found = _Ds_FrmTabs.Tables[0].Select(_Str_expression);
                if (_Drow_found.Length > 0)
                {
                    _Str_TabActual = "N.C. POR IMPRIMIR A PROVEEDORES";
                    _Int_Count=0;
                    _Str_Sql = "Select count(*) from TNOTACREDICP where cdelete='0' and ccompany='" + Frm_Padre._Str_Comp + "' and cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and cimpresa='0' and cactivo='0' and cestatusfirma='2' and canulado='0' AND (cmanual='1' OR cidnotrecepc>0)";
                    _Ds_AuxTabs = _Mtd_GetDataSet(_Str_Sql);
                    if (Convert.ToString(_Ds_AuxTabs.Tables[0].Rows[0][0]) != "")
                    {
                        _Int_Count = Convert.ToInt32(_Ds_AuxTabs.Tables[0].Rows[0][0]);
                    }
                    if (_Int_Count != _Int_15)
                    {
                        object[] myArray = new object[1];
                        if (_Int_Count > _Int_15)
                        { _Bol_SwTimbre = true; }
                        if (_Pnl_Contenedor.Controls.Find("_Ctrl15", false).Length > 0)
                        {
                            myArray[0] = ((_Ctrl_Tabs)(_Pnl_Contenedor.Controls.Find("_Ctrl15", false)[0]));
                            this.Invoke(new MyDelegate_Ctrl_Tabs_Del(DelegateMethod_Ctrl_Tabs_Del), myArray);
                            _Int_15 = _Int_Count;
                        }
                        if (_Int_Count > 0)
                        {
                            _Ctrl_Tabs _Ctrl = new _Ctrl_Tabs();
                            _Ctrl.Name = "_Ctrl15";
                            _Ctrl._Descripcion = "N.C. POR IMPRIMIR A PROVEEDORES  ( " + _Int_Count.ToString() + " )";
                            _Tsm_Menu = new ToolStripMenuItem[2];
                            _Tsm_Menu[0] = new ToolStripMenuItem("Código");
                            _Tsm_Menu[1] = new ToolStripMenuItem("Descripción");
                            _Str_Campos = new string[2];
                            _Str_Campos[0] = "cidnotacreditocxp";
                            _Str_Campos[1] = "cdescripcion";
                            _Str_Cadena = "Select cidnotacreditocxp as Código,cdescripcion as Descripción,ISNULL(cmontototsi,0)+ISNULL(cbaseexcenta,0) as Monto from TNOTACREDICP where cdelete='0' and ccompany='" + Frm_Padre._Str_Comp + "' and cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and cimpresa='0' and cactivo='0' and cestatusfirma='2' and canulado='0' AND (cmanual='1' OR cidnotrecepc>0)";
                            _Ctrl._Formulario = "T3.Frm_NRNCND";
                            _Ctrl._FormularioMdi = _Frm_MdiParent;
                            _Ctrl._Parametros = new object[] { _Str_Cadena, _Str_Campos, "N.C. por Imprimir - Proveedores", _Tsm_Menu, 3 };
                            _Ctrl.Dock = DockStyle.Top;
                            myArray[0] = _Ctrl;
                            this.Invoke(new MyDelegate_Ctrl_Tabs(DelegateMethod_Ctrl_Tabs), myArray);
                            _Int_15 = _Int_Count;
                        }
                    }
                }
                //---------------------TABS NÚMERO 15
                //---------------------------------------------------------------------------------------------------------
                //---------------------TABS NÚMERO 16
                _Str_expression = "ctabs = 16";
                _Drow_found = _Ds_FrmTabs.Tables[0].Select(_Str_expression);
                if (_Drow_found.Length > 0)
                {
                    _Str_TabActual = "RECEPCIONES SIN FIRMAR";
                    _Int_Count=0;
                    _Str_Sql = "SELECT count(*) FROM vst_tabdeevaluacionespendientes WHERE cgroupcomp = '" + Frm_Padre._Str_GroupComp + "'";
                    _Ds_AuxTabs = _Mtd_GetDataSet(_Str_Sql);
                    if (Convert.ToString(_Ds_AuxTabs.Tables[0].Rows[0][0]) != "")
                    {
                        _Int_Count = Convert.ToInt32(_Ds_AuxTabs.Tables[0].Rows[0][0]);
                    }
                    if (_Int_Count != _Int_16)
                    {
                        object[] myArray = new object[1];
                        if (_Int_Count > _Int_16)
                        { _Bol_SwTimbre = true; }
                        if (_Pnl_Contenedor.Controls.Find("_Ctrl16", false).Length > 0)
                        {
                            myArray[0] = ((_Ctrl_Tabs)(_Pnl_Contenedor.Controls.Find("_Ctrl16", false)[0]));
                            this.Invoke(new MyDelegate_Ctrl_Tabs_Del(DelegateMethod_Ctrl_Tabs_Del), myArray);
                            _Int_16 = _Int_Count;
                        }
                        if (_Int_Count > 0)
                        {
                            _Ctrl_Tabs _Ctrl = new _Ctrl_Tabs();
                            _Ctrl.Name = "_Ctrl16";
                            _Ctrl._Descripcion = "RECEPCIONES SIN FIRMAR  ( " + _Int_Count.ToString() + " )";
                            _Ctrl._Formulario = "T3.Frm_Factura";
                            _Ctrl._FormularioMdi = _Frm_MdiParent;
                            _Ctrl._Parametros = new object[] { true };
                            _Ctrl.Dock = DockStyle.Top;
                            myArray[0] = _Ctrl;
                            this.Invoke(new MyDelegate_Ctrl_Tabs(DelegateMethod_Ctrl_Tabs), myArray);
                            _Int_16 = _Int_Count;
                        }
                    }
                }
                //---------------------TABS NÚMERO 16
                //---------------------------------------------------------------------------------------------------------
                //---------------------TABS NÚMERO 17
                _Str_expression = "ctabs = 17";
                _Drow_found = _Ds_FrmTabs.Tables[0].Select(_Str_expression);
                if (_Drow_found.Length > 0)
                {
                    _Str_TabActual = "O.P. PENDIENTES (PAGOS PENDIENTES)";
                    _Int_Count = 0;
                    _Str_Sql = "select count(*) from VST_PAGOSCXPM where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and ccompany='" + Frm_Padre._Str_Comp + "' and ccancelado=0 and canulado=0";
                    _Ds_AuxTabs = _Mtd_GetDataSet(_Str_Sql);
                    if (Convert.ToString(_Ds_AuxTabs.Tables[0].Rows[0][0]) != "")
                    {
                        _Int_Count = Convert.ToInt32(_Ds_AuxTabs.Tables[0].Rows[0][0]);
                    }
                    if (_Int_Count != _Int_17)
                    {
                        object[] myArray = new object[1];
                        if (_Int_Count > _Int_17)
                        { _Bol_SwTimbre = true; }
                        if (_Pnl_Contenedor.Controls.Find("_Ctrl17", false).Length > 0)
                        {
                            myArray[0] = ((_Ctrl_Tabs)(_Pnl_Contenedor.Controls.Find("_Ctrl17", false)[0]));
                            this.Invoke(new MyDelegate_Ctrl_Tabs_Del(DelegateMethod_Ctrl_Tabs_Del), myArray);
                            _Int_17 = _Int_Count; 
                        }
                        if (_Int_Count > 0)
                        {
                            _Ctrl_Tabs _Ctrl = new _Ctrl_Tabs();
                            _Ctrl.Name = "_Ctrl17";
                            _Ctrl._Descripcion = "O.P. PENDIENTES (PAGOS PENDIENTES)  ( " + _Int_Count.ToString() + " )";
                            _Ctrl._Formulario = "T3.Frm_OrdenPago";
                            _Ctrl._FormularioMdi = _Frm_MdiParent;
                            _Ctrl._Parametros = new object[] { "2" };
                            _Ctrl.Dock = DockStyle.Top;
                            myArray[0] = _Ctrl;
                            this.Invoke(new MyDelegate_Ctrl_Tabs(DelegateMethod_Ctrl_Tabs), myArray);
                            _Int_17 = _Int_Count;
                        }
                    }
                }
                //---------------------TABS NÚMERO 17
                //---------------------------------------------------------------------------------------------------------
                //---------------------TABS NÚMERO 18
                _Str_expression = "ctabs = 18";
                _Drow_found = _Ds_FrmTabs.Tables[0].Select(_Str_expression);
                if (_Drow_found.Length > 0)
                {
                    if (myUtilidad._Mtd_ObtenerUsuarioFirma(Frm_Padre._Str_Use) == "1")
                    {
                        if (myUtilidad._Mtd_UsuarioProceso(Frm_Padre._Str_Use, "F_EMISION_CHEQUE_CONT"))
                        {
                            _Str_TabActual = "SOLICITUD DE CHEQUES O TRANSFERENCIAS ";
                            _Int_Count = 0;
                            _Str_Sql = "select count(*) from VST_EMICHEQTRANSM WHERE (cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "') AND (cfuserfirmante1=0 AND cfusersolicitante=1) AND canulado='0'";
                            _Ds_AuxTabs = _Mtd_GetDataSet(_Str_Sql);
                            if (Convert.ToString(_Ds_AuxTabs.Tables[0].Rows[0][0]) != "")
                            {
                                _Int_Count = Convert.ToInt32(_Ds_AuxTabs.Tables[0].Rows[0][0]);
                            }
                            if (_Int_Count != _Int_18)
                            {
                                object[] myArray = new object[1];
                                if (_Int_Count > _Int_18)
                                { _Bol_SwTimbre = true; }
                                if (_Pnl_Contenedor.Controls.Find("_Ctrl18", false).Length > 0)
                                {
                                    myArray[0] = ((_Ctrl_Tabs)(_Pnl_Contenedor.Controls.Find("_Ctrl18", false)[0]));
                                    this.Invoke(new MyDelegate_Ctrl_Tabs_Del(DelegateMethod_Ctrl_Tabs_Del), myArray);
                                    _Int_18 = _Int_Count;
                                }
                                if (_Int_Count > 0)
                                {
                                    _Ctrl_Tabs _Ctrl = new _Ctrl_Tabs();
                                    _Ctrl.Name = "_Ctrl18";
                                    _Ctrl._Descripcion = "SOLICITUD DE CHEQUES O TRANSFERENCIAS  ( " + _Int_Count.ToString() + " )";
                                    _Ctrl._Formulario = "T3.Frm_EmisionCheque";
                                    _Ctrl._FormularioMdi = _Frm_MdiParent;
                                    _Ctrl._Parametros = new object[] { "2", "F_CONT" };
                                    _Ctrl.Dock = DockStyle.Top;
                                    myArray[0] = _Ctrl;
                                    this.Invoke(new MyDelegate_Ctrl_Tabs(DelegateMethod_Ctrl_Tabs), myArray);
                                    _Int_18 = _Int_Count;
                                }
                            }
                        }
                    }
                }
                //---------------------TABS NÚMERO 18
                //---------------------------------------------------------------------------------------------------------
                //---------------------TABS NÚMERO 19
                _Str_expression = "ctabs = 19";
                _Drow_found = _Ds_FrmTabs.Tables[0].Select(_Str_expression);
                if (_Drow_found.Length > 0)
                {
                    if (myUtilidad._Mtd_ObtenerUsuarioFirma(Frm_Padre._Str_Use) == "1")
                    {
                        if (myUtilidad._Mtd_UsuarioProceso(Frm_Padre._Str_Use, "F_EMISION_CHEQUE_FIRMA"))
                        {
                            _Str_TabActual = "SOLICITUD DE CHEQUES O TRANSFERENCIAS  ";
                            _Int_Count = 0;
                            _Str_Sql = "select count(*) from VST_EMICHEQTRANSM WHERE (cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "') AND (cfuseraprobador=0 AND cfusersolicitante=1 AND cfuserfirmante1=1) AND canulado='0'";
                            _Ds_AuxTabs = _Mtd_GetDataSet(_Str_Sql);
                            if (Convert.ToString(_Ds_AuxTabs.Tables[0].Rows[0][0]) != "")
                            {
                                _Int_Count = Convert.ToInt32(_Ds_AuxTabs.Tables[0].Rows[0][0]);
                            }
                            if (_Int_Count != _Int_19)
                            {
                                object[] myArray = new object[1];
                                if (_Int_Count > _Int_19)
                                { _Bol_SwTimbre = true; }
                                if (_Pnl_Contenedor.Controls.Find("_Ctrl19", false).Length > 0)
                                {
                                    myArray[0] = ((_Ctrl_Tabs)(_Pnl_Contenedor.Controls.Find("_Ctrl19", false)[0]));
                                    this.Invoke(new MyDelegate_Ctrl_Tabs_Del(DelegateMethod_Ctrl_Tabs_Del), myArray);
                                    _Int_19 = _Int_Count;
                                }
                                if (_Int_Count > 0)
                                {
                                    _Ctrl_Tabs _Ctrl = new _Ctrl_Tabs();
                                    _Ctrl.Name = "_Ctrl19";
                                    _Ctrl._Descripcion = "SOLICITUD DE CHEQUES O TRANSFERENCIAS  ( " + _Int_Count.ToString() + " )";
                                    _Ctrl._Formulario = "T3.Frm_EmisionCheque";
                                    _Ctrl._FormularioMdi = _Frm_MdiParent;
                                    _Ctrl._Parametros = new object[] { "2", "F_APROB" };
                                    _Ctrl.Dock = DockStyle.Top;
                                    myArray[0] = _Ctrl;
                                    this.Invoke(new MyDelegate_Ctrl_Tabs(DelegateMethod_Ctrl_Tabs), myArray);
                                    _Int_19 = _Int_Count;
                                }
                            }
                        }
                    }
                }
                //---------------------TABS NÚMERO 19
                //---------------------------------------------------------------------------------------------------------
                //---------------------TABS NÚMERO 20
                _Str_expression = "ctabs = 20";
                _Drow_found = _Ds_FrmTabs.Tables[0].Select(_Str_expression);
                if (_Drow_found.Length > 0)
                {
                    if (myUtilidad._Mtd_ObtenerUsuarioFirma(Frm_Padre._Str_Use) == "1")
                    {
                        if (myUtilidad._Mtd_UsuarioProceso(Frm_Padre._Str_Use, "F_EMISION_CHEQUE_IMP"))
                        {
                            _Str_TabActual = "CHEQUES POR IMPRIMIR";
                            _Int_Count = 0;
                            _Str_Sql = "select count(*) from VST_EMICHEQTRANSM WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' and cfusersolicitante=1 AND cfuserfirmante1=1 AND cfuseraprobador=1 AND cimpimiocheq=0 AND canulado='0' AND cfpago='CHEQ'";
                            _Ds_AuxTabs = _Mtd_GetDataSet(_Str_Sql);
                            if (Convert.ToString(_Ds_AuxTabs.Tables[0].Rows[0][0]) != "")
                            {
                                _Int_Count = Convert.ToInt32(_Ds_AuxTabs.Tables[0].Rows[0][0]);
                            }
                            if (_Int_Count != _Int_20)
                            {
                                object[] myArray = new object[1];
                                if (_Int_Count > _Int_20)
                                { _Bol_SwTimbre = true; }
                                if (_Pnl_Contenedor.Controls.Find("_Ctrl20", false).Length > 0)
                                {
                                    myArray[0] = ((_Ctrl_Tabs)(_Pnl_Contenedor.Controls.Find("_Ctrl20", false)[0]));
                                    this.Invoke(new MyDelegate_Ctrl_Tabs_Del(DelegateMethod_Ctrl_Tabs_Del), myArray);
                                    _Int_20 = _Int_Count; 
                                }
                                if (_Int_Count > 0)
                                {
                                    _Ctrl_Tabs _Ctrl = new _Ctrl_Tabs();
                                    _Ctrl.Name = "_Ctrl20";
                                    _Ctrl._Descripcion = "CHEQUES POR IMPRIMIR  ( " + _Int_Count.ToString() + " )";
                                    _Ctrl._Formulario = "T3.Frm_EmisionCheque";
                                    _Ctrl._FormularioMdi = _Frm_MdiParent;
                                    _Ctrl._Parametros = new object[] { "1", "CHEQ" };
                                    _Ctrl.Dock = DockStyle.Top;
                                    myArray[0] = _Ctrl;
                                    this.Invoke(new MyDelegate_Ctrl_Tabs(DelegateMethod_Ctrl_Tabs), myArray);
                                    _Int_20 = _Int_Count;
                                }
                            }
                        }
                    }
                }
                //---------------------TABS NÚMERO 20
                //---------------------------------------------------------------------------------------------------------
                //---------------------TABS NÚMERO 21
                _Str_expression = "ctabs = 21";
                _Drow_found = _Ds_FrmTabs.Tables[0].Select(_Str_expression);
                if (_Drow_found.Length > 0)
                {
                    _Str_TabActual = "COMPROBANTE NR";
                    _Int_Count = 0;
                    _Str_Sql = "SELECT count(*) FROM vst_tabdecomprobantnr where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and ccompany='" + Frm_Padre._Str_Comp + "'";
                    _Ds_AuxTabs = _Mtd_GetDataSet(_Str_Sql);
                    if (Convert.ToString(_Ds_AuxTabs.Tables[0].Rows[0][0]) != "")
                    {
                        _Int_Count = Convert.ToInt32(_Ds_AuxTabs.Tables[0].Rows[0][0]);
                    }
                    if (_Int_Count != _Int_21)
                    {
                        object[] myArray = new object[1];
                        if (_Int_Count > _Int_21)
                        { _Bol_SwTimbre = true; }
                        if (_Pnl_Contenedor.Controls.Find("_Ctrl21", false).Length > 0)
                        {
                            myArray[0] = ((_Ctrl_Tabs)(_Pnl_Contenedor.Controls.Find("_Ctrl21", false)[0]));
                            this.Invoke(new MyDelegate_Ctrl_Tabs_Del(DelegateMethod_Ctrl_Tabs_Del), myArray);
                            _Int_21 = _Int_Count; 
                        }
                        if (_Int_Count > 0)
                        {
                            _Ctrl_Tabs _Ctrl = new _Ctrl_Tabs();
                            _Ctrl.Name = "_Ctrl21";
                            _Ctrl._Descripcion = "COMPROBANTE NR  ( " + _Int_Count.ToString() + " )";
                            _Ctrl._Formulario = "T3.Frm_FacturasCargadas";
                            _Ctrl._FormularioMdi = _Frm_MdiParent;
                            _Ctrl._Parametros = new object[] { true };
                            _Ctrl.Dock = DockStyle.Top;
                            myArray[0] = _Ctrl;
                            this.Invoke(new MyDelegate_Ctrl_Tabs(DelegateMethod_Ctrl_Tabs), myArray);
                            _Int_21 = _Int_Count;
                        }
                    }
                }
                //---------------------TABS NÚMERO 21
                //---------------------------------------------------------------------------------------------------------
                //---------------------TABS NÚMERO 22
                _Str_expression = "ctabs = 22";
                _Drow_found = _Ds_FrmTabs.Tables[0].Select(_Str_expression);
                if (_Drow_found.Length > 0)
                {
                    _Str_TabActual = "CLIENTES SIN ZONA";
                    _Int_Count = 0;
                    _Str_Sql = "Select COUNT(*) from TCLIENTE where c_activo='1' and cdelete='0' and cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND NOT EXISTS(SELECT ccliente FROM TZONACLIENTE WHERE (cdelete='0') AND (ccompany = '" + Frm_Padre._Str_Comp + "') AND TCLIENTE.ccliente=TZONACLIENTE.ccliente)";
                    _Ds_AuxTabs = _Mtd_GetDataSet(_Str_Sql);
                    if (Convert.ToString(_Ds_AuxTabs.Tables[0].Rows[0][0]) != "")
                    {
                        _Int_Count = Convert.ToInt32(_Ds_AuxTabs.Tables[0].Rows[0][0]);
                    }
                    if (_Int_Count != _Int_22)
                    {
                        object[] myArray = new object[1];
                        if (_Int_Count > _Int_22)
                        { _Bol_SwTimbre = true; }
                        if (_Pnl_Contenedor.Controls.Find("_Ctrl22", false).Length > 0)
                        {
                            myArray[0] = ((_Ctrl_Tabs)(_Pnl_Contenedor.Controls.Find("_Ctrl22", false)[0]));
                            this.Invoke(new MyDelegate_Ctrl_Tabs_Del(DelegateMethod_Ctrl_Tabs_Del), myArray);
                            _Int_22 = _Int_Count;
                        }
                        if (_Int_Count > 0)
                        {
                            _Ctrl_Tabs _Ctrl = new _Ctrl_Tabs();
                            _Ctrl.Name = "_Ctrl22";
                            _Ctrl._Descripcion = "CLIENTES SIN ZONA  ( " + _Int_Count.ToString() + " )";
                            _Ctrl._Formulario = "T3.Frm_ClientesSinZona";
                            _Ctrl._FormularioMdi = _Frm_MdiParent;
                            _Ctrl._Parametros = null;
                            _Ctrl.Dock = DockStyle.Top;
                            myArray[0] = _Ctrl;
                            this.Invoke(new MyDelegate_Ctrl_Tabs(DelegateMethod_Ctrl_Tabs), myArray);
                            _Int_22 = _Int_Count;
                        }
                    }
                }
                //---------------------TABS NÚMERO 22
                //---------------------------------------------------------------------------------------------------------
                //---------------------TABS NÚMERO 23
                _Str_expression = "ctabs = 23";
                _Drow_found = _Ds_FrmTabs.Tables[0].Select(_Str_expression);
                if (_Drow_found.Length > 0)
                {
                    _Str_TabActual = "NR POR GENERAR";
                    _Int_Count = 0;
                    _Str_Sql = "SELECT count(distinct cidrecepcion) FROM vst_asciifactura where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and not exists(Select CIDRECEPCION from TNOTARECEPC where TNOTARECEPC.cgroupcomp=vst_asciifactura.cgroupcomp and TNOTARECEPC.cidrecepcion=vst_asciifactura.cidrecepcion and TNOTARECEPC.cnumdocu=vst_asciifactura.cnfacturapro)";
                    _Ds_AuxTabs = _Mtd_GetDataSet(_Str_Sql);
                    if (Convert.ToString(_Ds_AuxTabs.Tables[0].Rows[0][0]) != "")
                    {
                        _Int_Count = Convert.ToInt32(_Ds_AuxTabs.Tables[0].Rows[0][0]);
                    }
                    if (_Int_Count != _Int_23)
                    {
                        object[] myArray = new object[1];
                        if (_Int_Count > _Int_23)
                        { _Bol_SwTimbre = true; }
                        if (_Pnl_Contenedor.Controls.Find("_Ctrl23", false).Length > 0)
                        {
                            myArray[0] = ((_Ctrl_Tabs)(_Pnl_Contenedor.Controls.Find("_Ctrl23", false)[0]));
                            this.Invoke(new MyDelegate_Ctrl_Tabs_Del(DelegateMethod_Ctrl_Tabs_Del), myArray);
                            _Int_23 = _Int_Count;
                        }
                        if (_Int_Count > 0)
                        {
                            _Ctrl_Tabs _Ctrl = new _Ctrl_Tabs();
                            _Ctrl.Name = "_Ctrl23";
                            _Ctrl._Descripcion = "NR POR GENERAR  ( " + _Int_Count.ToString() + " )";
                            _Ctrl._Formulario = "T3.Frm_Factura";
                            _Ctrl._FormularioMdi = _Frm_MdiParent;
                            _Ctrl._Parametros = new object[] { 1 };
                            _Ctrl.Dock = DockStyle.Top;
                            myArray[0] = _Ctrl;
                            this.Invoke(new MyDelegate_Ctrl_Tabs(DelegateMethod_Ctrl_Tabs), myArray);
                            _Int_23 = _Int_Count;
                        }
                    }
                }
                //---------------------TABS NÚMERO 23
                //---------------------------------------------------------------------------------------------------------
                //---------------------TABS NÚMERO 24
                _Str_expression = "ctabs = 24";
                _Drow_found = _Ds_FrmTabs.Tables[0].Select(_Str_expression);
                if (_Drow_found.Length > 0)
                {
                    _Str_TabActual = "VENDEDORES SIN ZONA";
                    _Int_Count = 0;
                    _Str_Sql = "select count(*) from TVENDEDOR where c_activo='1' AND cdelete='0' and c_tipo_vend='1' and ccompany='" + Frm_Padre._Str_Comp + "' AND NOT EXISTS(SELECT * FROM  TZONAVENDEDOR WHERE (cdelete='0') AND (TVENDEDOR.ccompany =TZONAVENDEDOR.ccompany) AND (TVENDEDOR.cvendedor = TZONAVENDEDOR.cvendedor))";
                    _Ds_AuxTabs = _Mtd_GetDataSet(_Str_Sql);
                    if (Convert.ToString(_Ds_AuxTabs.Tables[0].Rows[0][0]) != "")
                    {
                        _Int_Count = Convert.ToInt32(_Ds_AuxTabs.Tables[0].Rows[0][0]);
                    }
                    if (_Int_Count != _Int_24)
                    {
                        object[] myArray = new object[1];
                        if (_Int_Count > _Int_24)
                        { _Bol_SwTimbre = true; }
                        if (_Pnl_Contenedor.Controls.Find("_Ctrl24", false).Length > 0)
                        {
                            myArray[0] = ((_Ctrl_Tabs)(_Pnl_Contenedor.Controls.Find("_Ctrl24", false)[0]));
                            this.Invoke(new MyDelegate_Ctrl_Tabs_Del(DelegateMethod_Ctrl_Tabs_Del), myArray);
                            _Int_24 = _Int_Count; 
                        }
                        if (_Int_Count > 0)
                        {
                            _Ctrl_Tabs _Ctrl = new _Ctrl_Tabs();
                            _Ctrl.Name = "_Ctrl24";
                            _Ctrl._Descripcion = "VENDEDORES SIN ZONA  ( " + _Int_Count.ToString() + " )";
                            _Ctrl._Formulario = "T3.Frm_VendedoresSinZona";
                            _Ctrl._FormularioMdi = _Frm_MdiParent;
                            _Ctrl._Parametros = null;
                            _Ctrl.Dock = DockStyle.Top;
                            myArray[0] = _Ctrl;
                            this.Invoke(new MyDelegate_Ctrl_Tabs(DelegateMethod_Ctrl_Tabs), myArray);
                            _Int_24 = _Int_Count;
                        }
                    }
                }
                //---------------------TABS NÚMERO 24
                //---------------------------------------------------------------------------------------------------------
                //---------------------TABS NÚMERO 25
                _Str_expression = "ctabs = 25";
                _Drow_found = _Ds_FrmTabs.Tables[0].Select(_Str_expression);
                if (_Drow_found.Length > 0)
                {
                    _Str_TabActual = "ZONAS SIN RUTA";
                    _Int_Count = 0;
                    _Str_Sql = "Select count(*) from TZONAVENTA where ccompany='" + Frm_Padre._Str_Comp + "' and cdelete='0' AND NOT EXISTS(SELECT * FROM  TRUTAVISITAM WHERE (cdelete='0') AND (TRUTAVISITAM.ccompany =TZONAVENTA.ccompany) AND (TRUTAVISITAM.c_zona = TZONAVENTA.c_zona))";
                    _Ds_AuxTabs = _Mtd_GetDataSet(_Str_Sql);
                    if (Convert.ToString(_Ds_AuxTabs.Tables[0].Rows[0][0]) != "")
                    {
                        _Int_Count = Convert.ToInt32(_Ds_AuxTabs.Tables[0].Rows[0][0]);
                    }
                    if (_Int_Count != _Int_25)
                    {
                        object[] myArray = new object[1];
                        if (_Int_Count > _Int_25)
                        { _Bol_SwTimbre = true; }
                        if (_Pnl_Contenedor.Controls.Find("_Ctrl25", false).Length > 0)
                        {
                            myArray[0] = ((_Ctrl_Tabs)(_Pnl_Contenedor.Controls.Find("_Ctrl25", false)[0]));
                            this.Invoke(new MyDelegate_Ctrl_Tabs_Del(DelegateMethod_Ctrl_Tabs_Del), myArray);
                            _Int_25 = _Int_Count;
                        }
                        if (_Int_Count > 0)
                        {
                            _Ctrl_Tabs _Ctrl = new _Ctrl_Tabs();
                            _Ctrl.Name = "_Ctrl25";
                            _Ctrl._Descripcion = "ZONAS SIN RUTA  ( " + _Int_Count.ToString() + " )";
                            _Ctrl._Formulario = "T3.Frm_Busqueda2";
                            _Ctrl._FormularioMdi = _Frm_MdiParent;
                            _Ctrl._Parametros = new object[] { 1 };
                            _Ctrl.Dock = DockStyle.Top;
                            myArray[0] = _Ctrl;
                            this.Invoke(new MyDelegate_Ctrl_Tabs(DelegateMethod_Ctrl_Tabs), myArray);
                            _Int_25 = _Int_Count;
                        }
                    }
                }
                //---------------------TABS NÚMERO 25
                //---------------------------------------------------------------------------------------------------------
                //---------------------TABS NÚMERO 26
                _Str_expression = "ctabs = 26";
                _Drow_found = _Ds_FrmTabs.Tables[0].Select(_Str_expression);
                if (_Drow_found.Length > 0)
                {
                    _Str_TabActual = "EVALUACIONES POR IMPRIMIR";
                    _Int_Count = 0;
                    _Str_Sql = "Select count(*) from VST_TABCOUNTEVALUACION where cgroupcomp='" + Frm_Padre._Str_GroupComp + "'";
                    _Ds_AuxTabs = _Mtd_GetDataSet(_Str_Sql);
                    if (Convert.ToString(_Ds_AuxTabs.Tables[0].Rows[0][0]) != "")
                    {
                        _Int_Count = Convert.ToInt32(_Ds_AuxTabs.Tables[0].Rows[0][0]);
                    }
                    if (_Int_Count != _Int_26)
                    {
                        object[] myArray = new object[1];
                        if (_Int_Count > _Int_26)
                        { _Bol_SwTimbre = true; }
                        if (_Pnl_Contenedor.Controls.Find("_Ctrl26", false).Length > 0)
                        {
                            myArray[0] = ((_Ctrl_Tabs)(_Pnl_Contenedor.Controls.Find("_Ctrl26", false)[0]));
                            this.Invoke(new MyDelegate_Ctrl_Tabs_Del(DelegateMethod_Ctrl_Tabs_Del), myArray);
                            _Int_26 = _Int_Count; 
                        }
                        if (_Int_Count > 0)
                        {
                            _Ctrl_Tabs _Ctrl = new _Ctrl_Tabs();
                            _Ctrl.Name = "_Ctrl26";
                            _Ctrl._Descripcion = "EVALUACIONES POR IMPRIMIR  ( " + _Int_Count.ToString() + " )";
                            _Ctrl._Formulario = "T3.Frm_Busqueda2";
                            _Ctrl._FormularioMdi = _Frm_MdiParent;
                            _Ctrl._Parametros = new object[] { 2 };
                            _Ctrl.Dock = DockStyle.Top;
                            myArray[0] = _Ctrl;
                            this.Invoke(new MyDelegate_Ctrl_Tabs(DelegateMethod_Ctrl_Tabs), myArray);
                            _Int_26 = _Int_Count;
                        }
                    }
                }
                //---------------------TABS NÚMERO 26
                //---------------------------------------------------------------------------------------------------------
                //---------------------TABS NÚMERO 27
                _Str_expression = "ctabs = 27";
                _Drow_found = _Ds_FrmTabs.Tables[0].Select(_Str_expression);
                if (_Drow_found.Length > 0)
                {
                    _Str_TabActual = "RETENCIONES DE IMPUESTO";
                    _Int_Count = 0;
                    _Str_Sql = "select count(*) from TCOMPROBANRETC WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cimpreso=0 AND canulado=0 AND NOT EXISTS(SELECT cidcomprobret FROM TFACTPPAGARM WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND TFACTPPAGARM.cidcomprobret=TCOMPROBANRETC.cidcomprobret AND cestatusfirma='1')";
                    _Ds_AuxTabs = _Mtd_GetDataSet(_Str_Sql);
                    if (Convert.ToString(_Ds_AuxTabs.Tables[0].Rows[0][0]) != "")
                    {
                        _Int_Count = Convert.ToInt32(_Ds_AuxTabs.Tables[0].Rows[0][0]);
                    }
                    if (_Int_Count != _Int_27)
                    {
                        object[] myArray = new object[1];
                        if (_Int_Count > _Int_27)
                        { _Bol_SwTimbre = true; }
                        if (_Pnl_Contenedor.Controls.Find("_Ctrl27", false).Length > 0)
                        {
                            myArray[0] = ((_Ctrl_Tabs)(_Pnl_Contenedor.Controls.Find("_Ctrl27", false)[0]));
                            this.Invoke(new MyDelegate_Ctrl_Tabs_Del(DelegateMethod_Ctrl_Tabs_Del), myArray);
                            _Int_27 = _Int_Count;
                        }
                        if (_Int_Count > 0)
                        {
                            _Ctrl_Tabs _Ctrl = new _Ctrl_Tabs();
                            _Ctrl.Name = "_Ctrl27";
                            _Ctrl._Descripcion = "RETENCIONES DE IMPUESTO  ( " + _Int_Count.ToString() + " )";
                            _Ctrl._Formulario = "T3.Frm_Busqueda2";
                            _Ctrl._FormularioMdi = _Frm_MdiParent;
                            _Ctrl._Parametros = new object[] { 4 };
                            _Ctrl.Dock = DockStyle.Top;
                            myArray[0] = _Ctrl;
                            this.Invoke(new MyDelegate_Ctrl_Tabs(DelegateMethod_Ctrl_Tabs), myArray);
                            _Int_27 = _Int_Count;
                        }
                    }
                }
                //---------------------TABS NÚMERO 27
                //---------------------------------------------------------------------------------------------------------
                //---------------------TABS NÚMERO 28
                _Str_expression = "ctabs = 28";
                _Drow_found = _Ds_FrmTabs.Tables[0].Select(_Str_expression);
                if (_Drow_found.Length > 0)
                {
                    _Str_TabActual = "PROVEEDORES PENDIENTES";
                    _Int_Count = 0;
                    _Str_Sql = "Select count(*) from TPROVEEDOR where (cdelete='0' and casignado='0' and cglobal<>'1')";
                    _Ds_AuxTabs = _Mtd_GetDataSet(_Str_Sql);
                    if (Convert.ToString(_Ds_AuxTabs.Tables[0].Rows[0][0]) != "")
                    {
                        _Int_Count = Convert.ToInt32(_Ds_AuxTabs.Tables[0].Rows[0][0]);
                    }
                    if (_Int_Count != _Int_28)
                    {
                        object[] myArray = new object[1];
                        if (_Int_Count > _Int_28)
                        { _Bol_SwTimbre = true; }
                        if (_Pnl_Contenedor.Controls.Find("_Ctrl28", false).Length > 0)
                        {
                            myArray[0] = ((_Ctrl_Tabs)(_Pnl_Contenedor.Controls.Find("_Ctrl28", false)[0]));
                            this.Invoke(new MyDelegate_Ctrl_Tabs_Del(DelegateMethod_Ctrl_Tabs_Del), myArray);
                            _Int_28 = _Int_Count; 
                        }
                        if (_Int_Count > 0)
                        {
                            _Ctrl_Tabs _Ctrl = new _Ctrl_Tabs();
                            _Ctrl.Name = "_Ctrl28";
                            _Ctrl._Descripcion = "PROVEEDORES PENDIENTES  ( " + _Int_Count.ToString() + " )";
                            _Ctrl._Formulario = "T3.Frm_Proveedores";
                            _Ctrl._FormularioMdi = _Frm_MdiParent;
                            _Ctrl._Parametros = new object[] { true };
                            _Ctrl.Dock = DockStyle.Top;
                            myArray[0] = _Ctrl;
                            this.Invoke(new MyDelegate_Ctrl_Tabs(DelegateMethod_Ctrl_Tabs), myArray);
                            _Int_28 = _Int_Count;
                        }
                    }
                }
                //---------------------TABS NÚMERO 28
                //---------------------------------------------------------------------------------------------------------
                //---------------------TABS NÚMERO 29
                _Str_expression = "ctabs = 29";
                _Drow_found = _Ds_FrmTabs.Tables[0].Select(_Str_expression);
                if (_Drow_found.Length > 0)
                {
                    _Str_TabActual = "CONTEO POR INICIAR";
                    _Int_Count = 0;
                    _Str_Sql = "Select count(*) from TINVFISICOM where ccompany='" + Frm_Padre._Str_Comp + "' and cimpreso='1' and cimpvertaremit='1' and ciniciado='0'";
                    _Ds_AuxTabs = _Mtd_GetDataSet(_Str_Sql);
                    if (Convert.ToString(_Ds_AuxTabs.Tables[0].Rows[0][0]) != "")
                    {
                        _Int_Count = Convert.ToInt32(_Ds_AuxTabs.Tables[0].Rows[0][0]);
                    }
                    if (_Int_Count != _Int_29)
                    {
                        object[] myArray = new object[1];
                        if (_Int_Count > _Int_29)
                        { _Bol_SwTimbre = true; }
                        if (_Pnl_Contenedor.Controls.Find("_Ctrl29", false).Length > 0)
                        {
                            myArray[0] = ((_Ctrl_Tabs)(_Pnl_Contenedor.Controls.Find("_Ctrl29", false)[0]));
                            this.Invoke(new MyDelegate_Ctrl_Tabs_Del(DelegateMethod_Ctrl_Tabs_Del), myArray);
                            _Int_29 = _Int_Count; 
                        }
                        if (_Int_Count > 0)
                        {
                            _Ctrl_Tabs _Ctrl = new _Ctrl_Tabs();
                            _Ctrl.Name = "_Ctrl29";
                            _Ctrl._Descripcion = "CONTEO POR INICIAR  ( " + _Int_Count.ToString() + " )";
                            _Ctrl._Formulario = "T3.Frm_ConteoCompleto";
                            _Ctrl._FormularioMdi = _Frm_MdiParent;
                            _Ctrl._Parametros = null;
                            _Ctrl.Dock = DockStyle.Top;
                            myArray[0] = _Ctrl;
                            this.Invoke(new MyDelegate_Ctrl_Tabs(DelegateMethod_Ctrl_Tabs), myArray);
                            _Int_29 = _Int_Count;
                        }
                    }
                }
                //---------------------TABS NÚMERO 29
                //---------------------------------------------------------------------------------------------------------
                //---------------------TABS NÚMERO 30
                _Str_expression = "ctabs = 30";
                _Drow_found = _Ds_FrmTabs.Tables[0].Select(_Str_expression);
                if (_Drow_found.Length > 0)
                {
                    _Str_TabActual = "RETENCIONES DE ISLR";
                    _Int_Count = 0;
                    _Str_Sql = "select count(*) from TCOMPROBANISLRC WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cimpreso=0 AND canulado=0 AND NOT EXISTS(SELECT cidcomprobislr FROM TFACTPPAGARM WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND TFACTPPAGARM.cidcomprobislr=TCOMPROBANISLRC.cidcomprobislr AND cestatusfirma='1')";
                    _Ds_AuxTabs = _Mtd_GetDataSet(_Str_Sql);
                    if (Convert.ToString(_Ds_AuxTabs.Tables[0].Rows[0][0]) != "")
                    {
                        _Int_Count = Convert.ToInt32(_Ds_AuxTabs.Tables[0].Rows[0][0]);
                    }
                    if (_Int_Count != _Int_30)
                    {
                        object[] myArray = new object[1];
                        if (_Int_Count > _Int_30)
                        { _Bol_SwTimbre = true; }
                        if (_Pnl_Contenedor.Controls.Find("_Ctrl30", false).Length > 0)
                        {
                            myArray[0] = ((_Ctrl_Tabs)(_Pnl_Contenedor.Controls.Find("_Ctrl30", false)[0]));
                            this.Invoke(new MyDelegate_Ctrl_Tabs_Del(DelegateMethod_Ctrl_Tabs_Del), myArray);
                            _Int_30 = _Int_Count; 
                        }
                        if (_Int_Count > 0)
                        {
                            _Ctrl_Tabs _Ctrl = new _Ctrl_Tabs();
                            _Ctrl.Name = "_Ctrl30";
                            _Ctrl._Descripcion = "RETENCIONES DE ISLR  ( " + _Int_Count.ToString() + " )";
                            _Ctrl._Formulario = "T3.Frm_Busqueda2";
                            _Ctrl._FormularioMdi = _Frm_MdiParent;
                            _Ctrl._Parametros = new object[] { 6 };
                            _Ctrl.Dock = DockStyle.Top;
                            myArray[0] = _Ctrl;
                            this.Invoke(new MyDelegate_Ctrl_Tabs(DelegateMethod_Ctrl_Tabs), myArray);
                            _Int_30 = _Int_Count;
                        }
                    }
                }
                //---------------------TABS NÚMERO 30
                //---------------------------------------------------------------------------------------------------------
                //---------------------TABS NÚMERO 31
                _Str_expression = "ctabs = 31";
                _Drow_found = _Ds_FrmTabs.Tables[0].Select(_Str_expression);
                if (_Drow_found.Length > 0)
                {
                    _Str_TabActual = "N.E. POR IMPRIMIR";
                    _Int_Count = 0;
                    _Str_Sql = "Select count(*) from VST_NOTAENTREGM where ccompany='" + Frm_Padre._Str_Comp + "' and cgroupcomp=" + Frm_Padre._Str_GroupComp + " and cdelete='0' and cimpresa='0'";
                    _Ds_AuxTabs = _Mtd_GetDataSet(_Str_Sql);
                    if (Convert.ToString(_Ds_AuxTabs.Tables[0].Rows[0][0]) != "")
                    {
                        _Int_Count = Convert.ToInt32(_Ds_AuxTabs.Tables[0].Rows[0][0]);
                    }
                    if (_Int_Count != _Int_31)
                    {
                        object[] myArray = new object[1];
                        if (_Int_Count > _Int_31)
                        { _Bol_SwTimbre = true; }
                        if (_Pnl_Contenedor.Controls.Find("_Ctrl31", false).Length > 0)
                        {
                            myArray[0] = ((_Ctrl_Tabs)(_Pnl_Contenedor.Controls.Find("_Ctrl31", false)[0]));
                            this.Invoke(new MyDelegate_Ctrl_Tabs_Del(DelegateMethod_Ctrl_Tabs_Del), myArray);
                            _Int_31 = _Int_Count; 
                        }
                        if (_Int_Count > 0)
                        {
                            _Ctrl_Tabs _Ctrl = new _Ctrl_Tabs();
                            _Ctrl.Name = "_Ctrl31";
                            _Ctrl._Descripcion = "N.E. POR IMPRIMIR  ( " + _Int_Count.ToString() + " )";
                            _Ctrl._Formulario = "T3.Frm_NotaEntrega";
                            _Ctrl._FormularioMdi = _Frm_MdiParent;
                            _Ctrl._Parametros = new object[] { true };
                            _Ctrl.Dock = DockStyle.Top;
                            myArray[0] = _Ctrl;
                            this.Invoke(new MyDelegate_Ctrl_Tabs(DelegateMethod_Ctrl_Tabs), myArray);
                            _Int_31 = _Int_Count;
                        }
                    }
                }
                //---------------------TABS NÚMERO 31
                //---------------------------------------------------------------------------------------------------------
                //---------------------TABS NÚMERO 32
                _Str_expression = "ctabs = 32";
                _Drow_found = _Ds_FrmTabs.Tables[0].Select(_Str_expression);
                if (_Drow_found.Length > 0)
                {
                    _Str_TabActual = "CHEQUES POR ENTREGAR";
                    _Int_Count = 0;
                    _Str_Sql = "select count(*) from VST_EMICHEQTRANSM WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' and cfusersolicitante=1 AND cfuserfirmante1=1 AND cfuseraprobador=1 AND centregado=0 AND cimpimiocheq=1 AND canulado='0' AND cfpago='CHEQ'";
                    _Ds_AuxTabs = _Mtd_GetDataSet(_Str_Sql);
                    if (Convert.ToString(_Ds_AuxTabs.Tables[0].Rows[0][0]) != "")
                    {
                        _Int_Count = Convert.ToInt32(_Ds_AuxTabs.Tables[0].Rows[0][0]);
                    }
                    if (_Int_Count != _Int_32)
                    {
                        object[] myArray = new object[1];
                        if (_Int_Count > _Int_32)
                        { _Bol_SwTimbre = true; }
                        if (_Pnl_Contenedor.Controls.Find("_Ctrl32", false).Length > 0)
                        {
                            myArray[0] = ((_Ctrl_Tabs)(_Pnl_Contenedor.Controls.Find("_Ctrl32", false)[0]));
                            this.Invoke(new MyDelegate_Ctrl_Tabs_Del(DelegateMethod_Ctrl_Tabs_Del), myArray);
                            _Int_32 = _Int_Count; 
                        }
                        if (_Int_Count > 0)
                        {
                            _Ctrl_Tabs _Ctrl = new _Ctrl_Tabs();
                            _Ctrl.Name = "_Ctrl32";
                            _Ctrl._Descripcion = "CHEQUES POR ENTREGAR  ( " + _Int_Count.ToString() + " )";
                            _Ctrl._Formulario = "T3.Frm_EntregaCheque";
                            _Ctrl._FormularioMdi = _Frm_MdiParent;
                            _Ctrl._Parametros = null;
                            _Ctrl.Dock = DockStyle.Top;
                            myArray[0] = _Ctrl;
                            this.Invoke(new MyDelegate_Ctrl_Tabs(DelegateMethod_Ctrl_Tabs), myArray);
                            _Int_32 = _Int_Count;
                        }
                    }
                }
                //---------------------TABS NÚMERO 32
                //---------------------------------------------------------------------------------------------------------
                //---------------------TABS NÚMERO 33
                _Str_expression = "ctabs = 33";
                _Drow_found = _Ds_FrmTabs.Tables[0].Select(_Str_expression);
                if (_Drow_found.Length > 0)
                {
                    if (myUtilidad._Mtd_ObtenerUsuarioFirma(Frm_Padre._Str_Use) == "1")
                    {
                        if (myUtilidad._Mtd_UsuarioProceso(Frm_Padre._Str_Use, "F_ENTRASALIDA_AJUSTE"))
                        {
                            _Str_TabActual = "AJUSTE DE ENT. POR APROBAR";
                            _Int_Count = 0;
                            _Str_Sql = "Select count(*) from TAJUSENTC where ccompany='" + Frm_Padre._Str_Comp + "' and cdelete='0' and cejecutada='0' AND canulado='0' and isnull(cfuseraprobador1,0)=0 and isnull(cfuseraprobador2,0)=0 AND ISNULL(cajusteintegrado,0)='0'";
                            _Ds_AuxTabs = _Mtd_GetDataSet(_Str_Sql);
                            if (Convert.ToString(_Ds_AuxTabs.Tables[0].Rows[0][0]) != "")
                            {
                                _Int_Count = Convert.ToInt32(_Ds_AuxTabs.Tables[0].Rows[0][0]);
                            }
                            if (_Int_Count != _Int_33)
                            {
                                object[] myArray = new object[1];
                                if (_Int_Count > _Int_33)
                                { _Bol_SwTimbre = true; }
                                if (_Pnl_Contenedor.Controls.Find("_Ctrl33", false).Length > 0)
                                {
                                    myArray[0] = ((_Ctrl_Tabs)(_Pnl_Contenedor.Controls.Find("_Ctrl33", false)[0]));
                                    this.Invoke(new MyDelegate_Ctrl_Tabs_Del(DelegateMethod_Ctrl_Tabs_Del), myArray);
                                    _Int_33 = _Int_Count; 
                                }
                                if (_Int_Count > 0)
                                {
                                    _Ctrl_Tabs _Ctrl = new _Ctrl_Tabs();
                                    _Ctrl.Name = "_Ctrl33";
                                    _Ctrl._Descripcion =   _Str_TabActual + " ( " + _Int_Count.ToString() + " )";
                                    _Ctrl._Formulario = "T3.Frm_AjusteEntrada";
                                    _Ctrl._FormularioMdi = _Frm_MdiParent;
                                    _Ctrl._Parametros = new object[] { true, 1 };
                                    _Ctrl.Dock = DockStyle.Top;
                                    myArray[0] = _Ctrl;
                                    this.Invoke(new MyDelegate_Ctrl_Tabs(DelegateMethod_Ctrl_Tabs), myArray);
                                    _Int_33 = _Int_Count;
                                }
                            }
                        }
                    }
                }
                //---------------------TABS NÚMERO 33
                //---------------------------------------------------------------------------------------------------------
                //---------------------TABS NÚMERO 34
                _Str_expression = "ctabs = 34";
                _Drow_found = _Ds_FrmTabs.Tables[0].Select(_Str_expression);
                if (_Drow_found.Length > 0)
                {
                    if (myUtilidad._Mtd_ObtenerUsuarioFirma(Frm_Padre._Str_Use) == "1")
                    {
                        if (myUtilidad._Mtd_UsuarioProceso(Frm_Padre._Str_Use, "F_ENTRASALIDA_AJUSTE"))
                        {
                            _Str_TabActual = "AJUSTE DE SAL. POR APROBAR";
                            _Int_Count = 0;
                            _Str_Sql = "Select count(*) from TAJUSSALC where ccompany='" + Frm_Padre._Str_Comp + "' and cdelete='0' and cejecutada='0' AND canulado='0'  and isnull(cfuseraprobador1,0)=0 and isnull(cfuseraprobador2,0)=0 AND ISNULL(cajusteintegrado,0)='0'";
                            _Ds_AuxTabs = _Mtd_GetDataSet(_Str_Sql);
                            if (Convert.ToString(_Ds_AuxTabs.Tables[0].Rows[0][0]) != "")
                            {
                                _Int_Count = Convert.ToInt32(_Ds_AuxTabs.Tables[0].Rows[0][0]);
                            }
                            if (_Int_Count != _Int_34)
                            {
                                object[] myArray = new object[1];
                                if (_Int_Count > _Int_34)
                                { _Bol_SwTimbre = true; }
                                if (_Pnl_Contenedor.Controls.Find("_Ctrl34", false).Length > 0)
                                {
                                    myArray[0] = ((_Ctrl_Tabs)(_Pnl_Contenedor.Controls.Find("_Ctrl34", false)[0]));
                                    this.Invoke(new MyDelegate_Ctrl_Tabs_Del(DelegateMethod_Ctrl_Tabs_Del), myArray);
                                    _Int_34 = _Int_Count; 
                                }
                                if (_Int_Count > 0)
                                {
                                    _Ctrl_Tabs _Ctrl = new _Ctrl_Tabs();
                                    _Ctrl.Name = "_Ctrl34";
                                    _Ctrl._Descripcion = _Str_TabActual + " ( " + _Int_Count.ToString() + " )";
                                    _Ctrl._Formulario = "T3.Frm_AjusteSalida";
                                    _Ctrl._FormularioMdi = _Frm_MdiParent;
                                    _Ctrl._Parametros = new object[] { true, 1 };
                                    _Ctrl.Dock = DockStyle.Top;
                                    myArray[0] = _Ctrl;
                                    this.Invoke(new MyDelegate_Ctrl_Tabs(DelegateMethod_Ctrl_Tabs), myArray);
                                    _Int_34 = _Int_Count;
                                }
                            }
                        }
                    }
                }
                //---------------------TABS NÚMERO 34
                //---------------------------------------------------------------------------------------------------------
                //---------------------TABS NÚMERO 35
                _Str_expression = "ctabs = 35";
                _Drow_found = _Ds_FrmTabs.Tables[0].Select(_Str_expression);
                if (_Drow_found.Length > 0)
                {
                    _Str_TabActual = "INVENTARIO EN MAL ESTADO";
                    _Int_Count = 0;
                    //_Str_Sql = "Select * from VST_TABPROVEEDORMERCMALESTADO  where ccompany='" + Frm_Padre._Str_Comp + "'";
                    _Str_Sql = "SELECT count(TPRODUCTO.cproducto) FROM TPRODUCTOVENCIMIENTO INNER JOIN TPRODUCTO ON TPRODUCTO.CPRODUCTO=TPRODUCTOVENCIMIENTO.CPRODUCTO WHERE TPRODUCTOVENCIMIENTO.ccompany='" + Frm_Padre._Str_Comp + "' and TPRODUCTOVENCIMIENTO.cfechavencimiento<getdate() AND (TPRODUCTO.cactivate = 1) AND (TPRODUCTOVENCIMIENTO.cempaques>0 OR TPRODUCTOVENCIMIENTO.cunidades>0)";
                    //_Str_Sql = "Select count(*) from VST_TABPROVEEDORMERCMALESTADO";
                    _Ds_AuxTabs = _Mtd_GetDataSet(_Str_Sql);
                    if (Convert.ToString(_Ds_AuxTabs.Tables[0].Rows[0][0]) != "")
                    {
                        _Int_Count = Convert.ToInt32(_Ds_AuxTabs.Tables[0].Rows[0][0]);
                    }
                    if (_Int_Count != _Int_35)
                    {
                        object[] myArray = new object[1];
                        if (_Int_Count > _Int_35)
                        { _Bol_SwTimbre = true; }
                        if (_Pnl_Contenedor.Controls.Find("_Ctrl35", false).Length > 0)
                        {
                            myArray[0] = ((_Ctrl_Tabs)(_Pnl_Contenedor.Controls.Find("_Ctrl35", false)[0]));
                            this.Invoke(new MyDelegate_Ctrl_Tabs_Del(DelegateMethod_Ctrl_Tabs_Del), myArray);
                            _Int_35 = _Int_Count; 
                        }
                        if (_Int_Count > 0)
                        {
                            _Ctrl_Tabs _Ctrl = new _Ctrl_Tabs();
                            _Ctrl.Name = "_Ctrl35";
                            _Ctrl._Descripcion = "INVENTARIO EN MAL ESTADO  ( " + _Int_Count.ToString() + " )";
                            _Ctrl._Formulario = "T3.Frm_Busqueda2";
                            _Ctrl._FormularioMdi = _Frm_MdiParent;
                            _Ctrl._Parametros = new object[] { 8 };
                            _Ctrl.Dock = DockStyle.Top;
                            myArray[0] = _Ctrl;
                            this.Invoke(new MyDelegate_Ctrl_Tabs(DelegateMethod_Ctrl_Tabs), myArray);
                            _Int_35 = _Int_Count;
                        }
                    }
                }
                //---------------------TABS NÚMERO 35
                //---------------------------------------------------------------------------------------------------------
                //---------------------TABS NÚMERO 36
                _Str_expression = "ctabs = 36";
                _Drow_found = _Ds_FrmTabs.Tables[0].Select(_Str_expression);
                if (_Drow_found.Length > 0)
                {
                    if (myUtilidad._Mtd_ObtenerUsuarioFirma(Frm_Padre._Str_Use) == "1")
                    {
                        if (myUtilidad._Mtd_UsuarioProceso(Frm_Padre._Str_Use, "F_TRANSFER_MME"))
                        {
                            _Str_TabActual = "TRANSFERENCIAS MAL ESTADO";
                            _Int_Count = 0;
                            _Str_Sql = "Select count(*) from TTRANSFERAMMEC where ccompany='" + Frm_Padre._Str_Comp + "' and cautorizatransf='0'";
                            _Ds_AuxTabs = _Mtd_GetDataSet(_Str_Sql);
                            if (Convert.ToString(_Ds_AuxTabs.Tables[0].Rows[0][0]) != "")
                            {
                                _Int_Count = Convert.ToInt32(_Ds_AuxTabs.Tables[0].Rows[0][0]);
                            }
                            if (_Int_Count != _Int_36)
                            {
                                object[] myArray = new object[1];
                                if (_Int_Count > _Int_36)
                                { _Bol_SwTimbre = true; }
                                if (_Pnl_Contenedor.Controls.Find("_Ctrl36", false).Length > 0)
                                {
                                    myArray[0] = ((_Ctrl_Tabs)(_Pnl_Contenedor.Controls.Find("_Ctrl36", false)[0]));
                                    this.Invoke(new MyDelegate_Ctrl_Tabs_Del(DelegateMethod_Ctrl_Tabs_Del), myArray);
                                    _Int_36 = _Int_Count;
                                }
                                if (_Int_Count > 0)
                                {
                                    _Ctrl_Tabs _Ctrl = new _Ctrl_Tabs();
                                    _Ctrl.Name = "_Ctrl36";
                                    _Ctrl._Descripcion = "TRANSFERENCIAS MAL ESTADO  ( " + _Int_Count.ToString() + " )";
                                    _Ctrl._Formulario = "T3.Frm_TransferMME";
                                    _Ctrl._FormularioMdi = _Frm_MdiParent;
                                    _Ctrl._Parametros = new object[] { true };
                                    _Ctrl.Dock = DockStyle.Top;
                                    myArray[0] = _Ctrl;
                                    this.Invoke(new MyDelegate_Ctrl_Tabs(DelegateMethod_Ctrl_Tabs), myArray);
                                    _Int_36 = _Int_Count;
                                }
                            }
                        }
                    }
                }
                //---------------------TABS NÚMERO 36
                //---------------------------------------------------------------------------------------------------------
                //---------------------TABS NÚMERO 37
                _Str_expression = "ctabs = 37";
                _Drow_found = _Ds_FrmTabs.Tables[0].Select(_Str_expression);
                if (_Drow_found.Length > 0)
                {
                    _Str_TabActual = "PEDIDOS BLOQUEADOS POR CRÉDITO";
                    _Int_Count = 0;
                    _Str_Sql = "Select count(*) from VST_CONSULTAPEDIDOSPORESTATUS where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and ccompany='" + Frm_Padre._Str_Comp + "' AND cstatus='3' and c_activo='1' AND isnull(caprobadocredito,0)=0";
                    _Ds_AuxTabs = _Mtd_GetDataSet(_Str_Sql);
                    if (Convert.ToString(_Ds_AuxTabs.Tables[0].Rows[0][0]) != "")
                    {
                        _Int_Count = Convert.ToInt32(_Ds_AuxTabs.Tables[0].Rows[0][0]);
                    }
                    if (_Int_Count != _Int_37)
                    {
                        object[] myArray = new object[1];
                        if (_Int_Count > _Int_37)
                        {_Bol_SwTimbre = true;}
                        if (_Pnl_Contenedor.Controls.Find("_Ctrl37", false).Length > 0)
                        {
                            myArray[0] = ((_Ctrl_Tabs)(_Pnl_Contenedor.Controls.Find("_Ctrl37", false)[0]));
                            this.Invoke(new MyDelegate_Ctrl_Tabs_Del(DelegateMethod_Ctrl_Tabs_Del), myArray);
                            _Int_37 = _Int_Count; 
                        }
                        if (_Int_Count > 0)
                        {
                            _Ctrl_Tabs _Ctrl = new _Ctrl_Tabs();
                            _Ctrl.Name = "_Ctrl37";
                            _Ctrl._Descripcion = "PEDIDOS BLOQUEADOS POR CRÉDITO  ( " + _Int_Count.ToString() + " )";
                            _Ctrl._Formulario = "T3.Frm_ConsultaMultiple";
                            _Ctrl._FormularioMdi = _Frm_MdiParent;
                            _Ctrl._Parametros = new object[] { _Enu_TiposConsultas.Pedido, "POR ESTADO", "BLOQUEADOS POR CRÉDITO - ACTUAL" };
                            _Ctrl.Dock = DockStyle.Top;
                            myArray[0] = _Ctrl;
                            this.Invoke(new MyDelegate_Ctrl_Tabs(DelegateMethod_Ctrl_Tabs), myArray);
                            _Int_37 = _Int_Count;
                        }
                    }
                }
                //---------------------TABS NÚMERO 37
                //---------------------------------------------------------------------------------------------------------
                //---------------------TABS NÚMERO 38
                _Str_expression = "ctabs = 38";
                _Drow_found = _Ds_FrmTabs.Tables[0].Select(_Str_expression);
                if (_Drow_found.Length > 0)
                {
                    _Str_TabActual = "PEDIDOS RECHAZADOS POR EXISTENCIA";
                    _Int_Count = 0;
                    _Str_Sql = "Select count(*) from VST_CONSULTAPEDIDOSPORESTATUS where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and ccompany='" + Frm_Padre._Str_Comp + "' AND c_rechabackorder='1' and cstatus='9' and c_pendientebackorder='0'";
                    _Ds_AuxTabs = _Mtd_GetDataSet(_Str_Sql);
                    if (Convert.ToString(_Ds_AuxTabs.Tables[0].Rows[0][0]) != "")
                    {
                        _Int_Count = Convert.ToInt32(_Ds_AuxTabs.Tables[0].Rows[0][0]);
                    }
                    if (_Int_Count != _Int_38)
                    {
                        object[] myArray = new object[1];
                        if (_Int_Count > _Int_38)
                        {_Bol_SwTimbre = true;}
                        if (_Pnl_Contenedor.Controls.Find("_Ctrl38", false).Length > 0)
                        {
                            myArray[0] = ((_Ctrl_Tabs)(_Pnl_Contenedor.Controls.Find("_Ctrl38", false)[0]));
                            this.Invoke(new MyDelegate_Ctrl_Tabs_Del(DelegateMethod_Ctrl_Tabs_Del), myArray);
                            _Int_38 = _Int_Count; 
                        }
                        if (_Int_Count > 0)
                        {
                            _Ctrl_Tabs _Ctrl = new _Ctrl_Tabs();
                            _Ctrl.Name = "_Ctrl38";
                            _Ctrl._Descripcion = "PEDIDOS RECHAZADOS POR EXISTENCIA  ( " + _Int_Count.ToString() + " )";
                            _Ctrl._Formulario = "T3.Frm_ConsultaMultiple";
                            _Ctrl._FormularioMdi = _Frm_MdiParent;
                            _Ctrl._Parametros = new object[] { _Enu_TiposConsultas.Pedido, "POR ESTADO", "RECHAZADOS POR EXISTENCIA" };
                            _Ctrl.Dock = DockStyle.Top;
                            myArray[0] = _Ctrl;
                            this.Invoke(new MyDelegate_Ctrl_Tabs(DelegateMethod_Ctrl_Tabs), myArray);
                            _Int_38 = _Int_Count;
                        }
                    }
                }
                //---------------------TABS NÚMERO 38
                //---------------------------------------------------------------------------------------------------------
                //---------------------TABS NÚMERO 39
                _Str_expression = "ctabs = 39";
                _Drow_found = _Ds_FrmTabs.Tables[0].Select(_Str_expression);
                if (_Drow_found.Length > 0)
                {
                    _Str_TabActual = "CLIENTES CON PEDIDOS BLOQ. POR EL SISTEMA";
                    _Int_Count = 0;
                    _Str_Sql = "Select count(*) from TCLIENTE where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and exists(select ccliente from TCOTPEDFACM where " + _Str_Comps + " and TCOTPEDFACM.ccliente=TCLIENTE.ccliente and cstatus='3' and isnull(caprobadocredito,0)=0) AND ISNULL(c_bloqueo_manual,0) = 0 AND cdelete='0' AND c_activo = 1";
                    //_Str_Sql = "Select count(*) from TCLIENTE where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and exists(select ccliente from TCOTPEDFACM where ccompany='" + Frm_Padre._Str_Comp + "' and TCOTPEDFACM.ccliente=TCLIENTE.ccliente and cstatus='3') AND ISNULL(c_bloqueo_manual,0) = 0 AND cdelete='0'";
                    _Ds_AuxTabs = _Mtd_GetDataSet(_Str_Sql);
                    if (Convert.ToString(_Ds_AuxTabs.Tables[0].Rows[0][0]) != "")
                    {
                        _Int_Count = Convert.ToInt32(_Ds_AuxTabs.Tables[0].Rows[0][0]);
                    }
                    if (_Int_Count != _Int_39)
                    {
                        object[] myArray = new object[1];
                        if (_Int_Count > _Int_39)
                        {_Bol_SwTimbre = true;}
                        if (_Pnl_Contenedor.Controls.Find("_Ctrl39", false).Length > 0)
                        {
                            myArray[0] = ((_Ctrl_Tabs)(_Pnl_Contenedor.Controls.Find("_Ctrl39", false)[0]));
                            this.Invoke(new MyDelegate_Ctrl_Tabs_Del(DelegateMethod_Ctrl_Tabs_Del), myArray);
                            _Int_39 = _Int_Count;
                        }
                        if (_Int_Count > 0)
                        {
                            _Ctrl_Tabs _Ctrl = new _Ctrl_Tabs();
                            _Ctrl.Name = "_Ctrl39";
                            _Ctrl._Descripcion = "CLIENTES CON PEDIDOS BLOQ. POR EL SISTEMA ( " + _Int_Count.ToString() + " )";
                            _Ctrl._Formulario = "T3.Frm_EstatusClientes";
                            _Ctrl._FormularioMdi = _Frm_MdiParent;
                            _Ctrl._Parametros = new object[] { 4 };
                            _Ctrl.Dock = DockStyle.Top;
                            myArray[0] = _Ctrl;
                            this.Invoke(new MyDelegate_Ctrl_Tabs(DelegateMethod_Ctrl_Tabs), myArray);
                            _Int_39 = _Int_Count;
                        }
                    }
                }
                //---------------------TABS NÚMERO 39
                //---------------------------------------------------------------------------------------------------------
                //---------------------TABS NÚMERO 40
                _Str_expression = "ctabs = 40";
                _Drow_found = _Ds_FrmTabs.Tables[0].Select(_Str_expression);
                if (_Drow_found.Length > 0)
                {
                    _Str_TabActual = "PEDIDOS ESPERANDO POR FACTURAR";
                    _Int_Count = 0;
                    _Str_Sql = "Select count(*) from VST_PREFACTURAS_TAB where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and ccompany='" + Frm_Padre._Str_Comp + "' and cdelete='0' and c_facturaanul=0 AND ((clistofacturar='1' and cprecarga='0' and cfacturado='0') or (c_factdevuelta='1' and cprecarga='0')) AND NOT EXISTS(SELECT VST_FACTURAS_ANUL.cpfactura FROM VST_FACTURAS_ANUL WHERE VST_FACTURAS_ANUL.cgroupcomp=VST_PREFACTURAS_TAB.cgroupcomp AND VST_FACTURAS_ANUL.ccompany=VST_PREFACTURAS_TAB.ccompany AND VST_FACTURAS_ANUL.cpfactura=VST_PREFACTURAS_TAB.cpfactura)";
                    _Ds_AuxTabs = _Mtd_GetDataSet(_Str_Sql);
                    if (Convert.ToString(_Ds_AuxTabs.Tables[0].Rows[0][0]) != "")
                    {
                        _Int_Count = Convert.ToInt32(_Ds_AuxTabs.Tables[0].Rows[0][0]);
                    }
                    if (_Int_Count != _Int_40)
                    {
                        if (_Int_Count > _Int_40)
                        {_Bol_SwTimbre = true;}
                        object[] myArray = new object[1];
                        if (_Pnl_Contenedor.Controls.Find("_Ctrl40", false).Length > 0)
                        {
                            myArray[0] = ((_Ctrl_Tabs)(_Pnl_Contenedor.Controls.Find("_Ctrl40", false)[0]));
                            this.Invoke(new MyDelegate_Ctrl_Tabs_Del(DelegateMethod_Ctrl_Tabs_Del), myArray);
                            _Int_40 = _Int_Count;
                        }
                        if (_Int_Count > 0)
                        {
                            _Ctrl_Tabs _Ctrl = new _Ctrl_Tabs();
                            _Ctrl.Name = "_Ctrl40";
                            _Ctrl._Descripcion = "PEDIDOS ESPERANDO POR FACTURAR  ( " + _Int_Count.ToString() + " )";                            
                            _Ctrl._Formulario = "T3.Frm_ConsultaMultiple";
                            _Ctrl._FormularioMdi = _Frm_MdiParent;                                                 
                            _Ctrl._Parametros = new object[] { _Enu_TiposConsultas.Prefactura, "POR ESTADO", "POR FACTURAR" };

                            _Ctrl.Dock = DockStyle.Top;
                            myArray[0] = _Ctrl;
                            this.Invoke(new MyDelegate_Ctrl_Tabs(DelegateMethod_Ctrl_Tabs), myArray);
                            _Int_40 = _Int_Count;
                        }
                    }
                }
                //---------------------TABS NÚMERO 40
                //---------------------------------------------------------------------------------------------------------
                //---------------------TABS NÚMERO 41
                _Str_expression = "ctabs = 41";
                _Drow_found = _Ds_FrmTabs.Tables[0].Select(_Str_expression);
                if (_Drow_found.Length > 0)
                {
                    _Str_TabActual = "PEDIDOS ESPERANDO POR FACTURAR";
                    _Int_Count = 0;
                    _Str_Sql = "Select count(*) from VST_PREFACTURAS_TAB where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and cdelete='0' and c_facturaanul=0 AND ((clistofacturar='1' and cprecarga='0' and cfacturado='0') or (c_factdevuelta='1' and cprecarga='0'))";
                    _Ds_AuxTabs = _Mtd_GetDataSet(_Str_Sql);
                    if (Convert.ToString(_Ds_AuxTabs.Tables[0].Rows[0][0]) != "")
                    {
                        _Int_Count = Convert.ToInt32(_Ds_AuxTabs.Tables[0].Rows[0][0]);
                    }
                    if (_Int_Count != _Int_41)
                    {
                        object[] myArray = new object[1];
                        if (_Int_Count > _Int_41)
                        {_Bol_SwTimbre = true;}
                        if (_Pnl_Contenedor.Controls.Find("_Ctrl41", false).Length > 0)
                        {
                            myArray[0] = ((_Ctrl_Tabs)(_Pnl_Contenedor.Controls.Find("_Ctrl41", false)[0]));
                            this.Invoke(new MyDelegate_Ctrl_Tabs_Del(DelegateMethod_Ctrl_Tabs_Del), myArray);
                            _Int_41 = _Int_Count; 
                        }
                        if (_Int_Count > 0)
                        {
                            _Ctrl_Tabs _Ctrl = new _Ctrl_Tabs();
                            _Ctrl.Name = "_Ctrl41";
                            _Ctrl._Descripcion = "PEDIDOS ESPERANDO POR FACTURAR  ( " + _Int_Count.ToString() + " )";
                            _Ctrl._Formulario = "T3.Frm_ControlDespacho";
                            _Ctrl._FormularioMdi = _Frm_MdiParent;
                            _Ctrl._Parametros = new object[] { 1 };
                            _Ctrl.Dock = DockStyle.Top;
                            myArray[0] = _Ctrl;
                            this.Invoke(new MyDelegate_Ctrl_Tabs(DelegateMethod_Ctrl_Tabs), myArray);
                            _Int_41 = _Int_Count;
                        }
                    }
                }
                //---------------------TABS NÚMERO 41
                //---------------------------------------------------------------------------------------------------------
                //---------------------TABS NÚMERO 42
                _Str_expression = "ctabs = 42";
                _Drow_found = _Ds_FrmTabs.Tables[0].Select(_Str_expression);
                if (_Drow_found.Length > 0)
                {
                    _Str_TabActual = "N.D. POR IMPRIMIR"; 
                    _Int_Count = 0;
                    _Str_Sql = "Select count(*) from TNOTADEBICC where cdelete='0' and ccompany='" + Frm_Padre._Str_Comp + "' and cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and cimpresa='0' and cactivo='0' AND cestatusfirma=2 AND NOT EXISTS(SELECT ccliente FROM TICRELAPROCLI WHERE TICRELAPROCLI.ccliente=TNOTADEBICC.ccliente AND ISNULL(TICRELAPROCLI.cdelete,0)=0)";
                    _Ds_AuxTabs = _Mtd_GetDataSet(_Str_Sql);
                    if (Convert.ToString(_Ds_AuxTabs.Tables[0].Rows[0][0]) != "")
                    {
                        _Int_Count = Convert.ToInt32(_Ds_AuxTabs.Tables[0].Rows[0][0]);
                    }
                    if (_Int_Count != _Int_42)
                    {
                        object[] myArray = new object[1];
                        if (_Int_Count > _Int_42)
                        {_Bol_SwTimbre = true;}
                        if (_Pnl_Contenedor.Controls.Find("_Ctrl42", false).Length > 0)
                        {
                            myArray[0] = ((_Ctrl_Tabs)(_Pnl_Contenedor.Controls.Find("_Ctrl42", false)[0]));
                            this.Invoke(new MyDelegate_Ctrl_Tabs_Del(DelegateMethod_Ctrl_Tabs_Del), myArray);
                            _Int_42 = _Int_Count;
                        }
                        if (_Int_Count > 0)
                        {
                            _Ctrl_Tabs _Ctrl = new _Ctrl_Tabs();
                            _Ctrl.Name = "_Ctrl42";
                            _Ctrl._Descripcion = "N.D. POR IMPRIMIR  ( " + _Int_Count.ToString() + " )";
                            _Ctrl._Formulario = "T3.Frm_ImpresionLote";
                            _Ctrl._FormularioMdi = _Frm_MdiParent;
                            _Ctrl._Parametros = new object[] { 2 };
                            _Ctrl.Dock = DockStyle.Top;
                            myArray[0] = _Ctrl;
                            this.Invoke(new MyDelegate_Ctrl_Tabs(DelegateMethod_Ctrl_Tabs), myArray);
                            _Int_42 = _Int_Count;
                        }
                    }
                }
                //---------------------TABS NÚMERO 42
                //---------------------------------------------------------------------------------------------------------
                //---------------------TABS NÚMERO 43
                _Str_expression = "ctabs = 43";
                _Drow_found = _Ds_FrmTabs.Tables[0].Select(_Str_expression);
                if (_Drow_found.Length > 0)
                {
                    _Str_TabActual = "N.C. POR IMPRIMIR";
                    _Int_Count = 0;
                    _Str_Sql = "SELECT ((Select count(cidnotcredicc) from TNOTACREDICC where cdelete='0' and ccompany='" + Frm_Padre._Str_Comp + "' and cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and cexedentecobro<>'1' and cimpresa='0' and cactivo='0' AND cestatusfirma=2 AND (cidnotrecepc=0 or cidnotrecepc is null) AND NOT EXISTS(SELECT ccliente FROM TICRELAPROCLI WHERE TICRELAPROCLI.ccliente=TNOTACREDICC.ccliente AND ISNULL(TICRELAPROCLI.cdelete,0)=0)) + " +
                    "(Select count(cidnotcredicc) from TNOTACREDICC INNER JOIN TNOTARECEPC ON TNOTACREDICC.ccompany=TNOTARECEPC.ccompany AND TNOTACREDICC.cgroupcomp=TNOTARECEPC.cgroupcomp AND TNOTACREDICC.cidnotrecepc=TNOTARECEPC.cidnotrecepc where TNOTACREDICC.cdelete='0' and TNOTACREDICC.ccompany='" + Frm_Padre._Str_Comp + "' and TNOTACREDICC.cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and TNOTACREDICC.cimpresa='0' and TNOTACREDICC.cactivo='0' and TNOTARECEPC.cimpreso=1 AND NOT EXISTS(SELECT ccliente FROM TICRELAPROCLI WHERE TICRELAPROCLI.ccliente=TNOTACREDICC.ccliente AND ISNULL(TICRELAPROCLI.cdelete,0)=0)))";
                    _Ds_AuxTabs = _Mtd_GetDataSet(_Str_Sql);
                    if (Convert.ToString(_Ds_AuxTabs.Tables[0].Rows[0][0]) != "")
                    {
                        _Int_Count = Convert.ToInt32(_Ds_AuxTabs.Tables[0].Rows[0][0]);
                    }
                    if (_Int_Count != _Int_43)
                    {
                        object[] myArray = new object[1];
                        if (_Int_Count > _Int_43)
                        {_Bol_SwTimbre = true;}
                        if (_Pnl_Contenedor.Controls.Find("_Ctrl43", false).Length > 0)
                        {
                            myArray[0] = ((_Ctrl_Tabs)(_Pnl_Contenedor.Controls.Find("_Ctrl43", false)[0]));
                            this.Invoke(new MyDelegate_Ctrl_Tabs_Del(DelegateMethod_Ctrl_Tabs_Del), myArray);
                            _Int_43 = _Int_Count; 
                        }
                        if (_Int_Count > 0)
                        {
                            _Ctrl_Tabs _Ctrl = new _Ctrl_Tabs();
                            _Ctrl.Name = "_Ctrl43";
                            _Ctrl._Descripcion = "N.C. POR IMPRIMIR  ( " + _Int_Count.ToString() + " )";
                            _Ctrl._Formulario = "T3.Frm_ImpresionLote";
                            _Ctrl._FormularioMdi = _Frm_MdiParent;
                            _Ctrl._Parametros = new object[] { 1 };
                            _Ctrl.Dock = DockStyle.Top;
                            myArray[0] = _Ctrl;
                            this.Invoke(new MyDelegate_Ctrl_Tabs(DelegateMethod_Ctrl_Tabs), myArray);
                            _Int_43 = _Int_Count;
                        }
                    }
                }
                //---------------------TABS NÚMERO 43
                //---------------------------------------------------------------------------------------------------------
                //---------------------TABS NÚMERO 44
                _Str_expression = "ctabs = 44";
                _Drow_found = _Ds_FrmTabs.Tables[0].Select(_Str_expression);
                if (_Drow_found.Length > 0)
                {
                    _Str_TabActual = "PRE-CARGAS PENDIENTES POR FACTURAR";
                    _Int_Count = 0;
                    _Str_Sql = "SELECT count(*) FROM TPRECARGAM WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND cimprimeprecarga=1 AND cverificascanpalm=1 AND cimprimefactura=0 AND cimprimeguiadesp=0 AND cplaca<>'0' AND ccedula<>'0'";
                    _Ds_AuxTabs = _Mtd_GetDataSet(_Str_Sql);
                    if (Convert.ToString(_Ds_AuxTabs.Tables[0].Rows[0][0]) != "")
                    {
                        _Int_Count = Convert.ToInt32(_Ds_AuxTabs.Tables[0].Rows[0][0]);
                    }
                    if (_Int_Count != _Int_44)
                    {
                        object[] myArray = new object[1];
                        if (_Int_Count > _Int_44)
                        {_Bol_SwTimbre = true;}
                        if (_Pnl_Contenedor.Controls.Find("_Ctrl44", false).Length > 0)
                        {
                            myArray[0] = ((_Ctrl_Tabs)(_Pnl_Contenedor.Controls.Find("_Ctrl44", false)[0]));
                            this.Invoke(new MyDelegate_Ctrl_Tabs_Del(DelegateMethod_Ctrl_Tabs_Del), myArray);
                            _Int_44 = _Int_Count; 
                        }
                        if (_Int_Count > 0)
                        {
                            _Ctrl_Tabs _Ctrl = new _Ctrl_Tabs();
                            _Ctrl.Name = "_Ctrl44";
                            _Ctrl._Descripcion = "PRE-CARGAS PENDIENTES POR FACTURAR  ( " + _Int_Count.ToString() + " )";
                            _Ctrl._Formulario = "T3.Frm_ControlFactura";
                            _Ctrl._FormularioMdi = _Frm_MdiParent;
                            _Ctrl._Parametros = null;
                            _Ctrl.Dock = DockStyle.Top;
                            myArray[0] = _Ctrl;
                            this.Invoke(new MyDelegate_Ctrl_Tabs(DelegateMethod_Ctrl_Tabs), myArray);
                            _Int_44 = _Int_Count;
                        }
                    }
                }
                //---------------------TABS NÚMERO 44
                //---------------------------------------------------------------------------------------------------------
                //---------------------TABS NÚMERO 45
                _Str_expression = "ctabs = 45";
                _Drow_found = _Ds_FrmTabs.Tables[0].Select(_Str_expression);
                if (_Drow_found.Length > 0)
                {
                    _Str_TabActual = "GUÍAS POR LIQUIDAR";
                    _Int_Count = 0;
                    _Str_Sql = "Select count(*) from VST_GUIADESPACHO where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and cliqguidespacho='0' AND cimprimeguiadesp=1 AND cestatusfirma=0";
                    _Ds_AuxTabs = _Mtd_GetDataSet(_Str_Sql);
                    if (Convert.ToString(_Ds_AuxTabs.Tables[0].Rows[0][0]) != "")
                    {
                        _Int_Count = Convert.ToInt32(_Ds_AuxTabs.Tables[0].Rows[0][0]);
                    }
                    if (_Int_Count != _Int_45)
                    {
                        object[] myArray = new object[1];
                        if (_Int_Count > _Int_45)
                        {_Bol_SwTimbre = true;}
                        if (_Pnl_Contenedor.Controls.Find("_Ctrl45", false).Length > 0)
                        {
                            myArray[0] = ((_Ctrl_Tabs)(_Pnl_Contenedor.Controls.Find("_Ctrl45", false)[0]));
                            this.Invoke(new MyDelegate_Ctrl_Tabs_Del(DelegateMethod_Ctrl_Tabs_Del), myArray);
                            _Int_45 = _Int_Count; 
                        }
                        if (_Int_Count > 0)
                        {
                            _Ctrl_Tabs _Ctrl = new _Ctrl_Tabs();
                            _Ctrl.Name = "_Ctrl45";
                            _Ctrl._Descripcion = "GUÍAS POR LIQUIDAR  ( " + _Int_Count.ToString() + " )";
                            _Ctrl._Formulario = "T3.Frm_GuiaDespacho";
                            _Ctrl._FormularioMdi = _Frm_MdiParent;
                            _Ctrl._Parametros = null;
                            _Ctrl.Dock = DockStyle.Top;
                            myArray[0] = _Ctrl;
                            this.Invoke(new MyDelegate_Ctrl_Tabs(DelegateMethod_Ctrl_Tabs), myArray);
                            _Int_45 = _Int_Count;
                        }
                    }
                }
                //---------------------TABS NÚMERO 45
                //---------------------------------------------------------------------------------------------------------
                //---------------------TABS NÚMERO 46
                _Str_expression = "ctabs = 46";
                _Drow_found = _Ds_FrmTabs.Tables[0].Select(_Str_expression);
                if (_Drow_found.Length > 0)
                {
                    _Str_TabActual = "PEDIDOS EN BACKORDER";
                    _Int_Count = 0;
                    _Str_Sql = "Select count(cgroupcomp) from VST_CONSULTABACKORDER where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and ccompany='" + Frm_Padre._Str_Comp + "'";
                    _Ds_AuxTabs = _Mtd_GetDataSet(_Str_Sql);
                    if (Convert.ToString(_Ds_AuxTabs.Tables[0].Rows[0][0]) != "")
                    {
                        _Int_Count = Convert.ToInt32(_Ds_AuxTabs.Tables[0].Rows[0][0]);
                    }
                    if (_Int_Count != _Int_46)
                    {
                        object[] myArray = new object[1];
                        if (_Int_Count > _Int_46)
                        {_Bol_SwTimbre = true;}
                        if (_Pnl_Contenedor.Controls.Find("_Ctrl46", false).Length > 0)
                        {
                            myArray[0] = ((_Ctrl_Tabs)(_Pnl_Contenedor.Controls.Find("_Ctrl46", false)[0]));
                            this.Invoke(new MyDelegate_Ctrl_Tabs_Del(DelegateMethod_Ctrl_Tabs_Del), myArray);
                            _Int_46 = _Int_Count; 
                        }
                        if (_Int_Count > 0)
                        {
                            _Ctrl_Tabs _Ctrl = new _Ctrl_Tabs();
                            _Ctrl.Name = "_Ctrl46";
                            _Ctrl._Descripcion = "PEDIDOS EN BACKORDER  ( " + _Int_Count.ToString() + " )";
                            _Ctrl._Formulario = "T3.Frm_EstatusBackOrder";
                            _Ctrl._FormularioMdi = _Frm_MdiParent;
                            _Ctrl._Parametros = null;
                            _Ctrl.Dock = DockStyle.Top;
                            myArray[0] = _Ctrl;
                            this.Invoke(new MyDelegate_Ctrl_Tabs(DelegateMethod_Ctrl_Tabs), myArray);
                            _Int_46 = _Int_Count;
                        }
                    }
                }
                //---------------------TABS NÚMERO 46
                //---------------------------------------------------------------------------------------------------------
                //---------------------TABS NÚMERO 47
                //_Str_expression = "ctabs = 47";
                //_Drow_found = _Ds_FrmTabs.Tables[0].Select(_Str_expression);
                //try
                //{
                //    if (_Drow_found.Length > 0)
                //    {
                //        _Str_TabActual = "RELACIONES DE CxC PENDIENTES";
                //        _Int_Count = 0;
                //        _Str_Sql = "Select count(cidrelacobro) from VST_T3TRELACCOBMCOBPENDIENTES where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and ccompany='" + Frm_Padre._Str_Comp + "'";
                //        _Ds_AuxTabs = _Mtd_GetDataSetWeb2012(_Str_Sql);
                //        if (Convert.ToString(_Ds_AuxTabs.Tables[0].Rows[0][0]) != "")
                //        {
                //            _Int_Count = Convert.ToInt32(_Ds_AuxTabs.Tables[0].Rows[0][0]);
                //        }
                //        if (_Int_Count != _Int_47)
                //        {
                //            object[] myArray = new object[1];
                //            if (_Int_Count > _Int_47)
                //            { _Bol_SwTimbre = true; }
                //            if (_Pnl_Contenedor.Controls.Find("_Ctrl47", false).Length > 0)
                //            {
                //                myArray[0] = ((_Ctrl_Tabs)(_Pnl_Contenedor.Controls.Find("_Ctrl47", false)[0]));
                //                this.Invoke(new MyDelegate_Ctrl_Tabs_Del(DelegateMethod_Ctrl_Tabs_Del), myArray);
                //                _Int_47 = _Int_Count;
                //            }
                //            if (_Int_Count > 0)
                //            {
                //                _Str_Url = CLASES._Cls_Varios_Metodos._Str_Servidor_Web + "mrelacionaprob.aspx?" + osio.encriptar("usuario") + "=" + osio.encriptar(Frm_Padre._Str_Use) + "&" + osio.encriptar("compania") + "=" + osio.encriptar(Frm_Padre._Str_Comp);
                //                _Ctrl_Tabs _Ctrl = new _Ctrl_Tabs();
                //                _Ctrl.Name = "_Ctrl47";
                //                _Ctrl._Descripcion = "RELACIONES DE CxC PENDIENTES  ( " + _Int_Count.ToString() + " )";
                //                _Ctrl._Formulario = "T3.Frm_Navegador";
                //                _Ctrl._FormularioMdi = _Frm_MdiParent;
                //                _Ctrl._Parametros = new object[] { _Str_Url, true };
                //                _Ctrl.Dock = DockStyle.Top;
                //                myArray[0] = _Ctrl;
                //                this.Invoke(new MyDelegate_Ctrl_Tabs(DelegateMethod_Ctrl_Tabs), myArray);
                //                _Int_47 = _Int_Count;
                //            }
                //        }
                //    }
                //}
                //catch
                //{ }
                //---------------------TABS NÚMERO 47
                //---------------------------------------------------------------------------------------------------------
                //---------------------TABS NÚMERO 48
                _Str_expression = "ctabs = 48";
                _Drow_found = _Ds_FrmTabs.Tables[0].Select(_Str_expression);
                if (_Drow_found.Length > 0)
                {
                    _Str_TabActual = "FACTURAS SIN NÚMERO DE CONTROL";
                    _Int_Count = 0;
                    _Str_Sql = "Select count(*) from TFACTURAM where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and ccompany='" + Frm_Padre._Str_Comp + "' and c_impresa='1' and c_numerocontrol='0'";
                    _Ds_AuxTabs = _Mtd_GetDataSet(_Str_Sql);
                    if (Convert.ToString(_Ds_AuxTabs.Tables[0].Rows[0][0]) != "")
                    {
                        _Int_Count = Convert.ToInt32(_Ds_AuxTabs.Tables[0].Rows[0][0]);
                    }
                    if (_Int_Count != _Int_48)
                    {
                        object[] myArray = new object[1];
                        if (_Int_Count > _Int_48)
                        {_Bol_SwTimbre = true;}
                        if (_Pnl_Contenedor.Controls.Find("_Ctrl48", false).Length > 0)
                        {
                            myArray[0] = ((_Ctrl_Tabs)(_Pnl_Contenedor.Controls.Find("_Ctrl48", false)[0]));
                            this.Invoke(new MyDelegate_Ctrl_Tabs_Del(DelegateMethod_Ctrl_Tabs_Del), myArray);
                            _Int_48 = _Int_Count;
                        }
                        if (_Int_Count > 0)
                        {
                            _Ctrl_Tabs _Ctrl = new _Ctrl_Tabs();
                            _Ctrl.Name = "_Ctrl48";
                            _Ctrl._Descripcion = "FACTURAS SIN NÚMERO DE CONTROL  ( " + _Int_Count.ToString() + " )";
                            _Ctrl._Formulario = "T3.Frm_ImpresionLote";
                            _Ctrl._FormularioMdi = _Frm_MdiParent;
                            _Ctrl._Parametros = new object[] { "3", true, Frm_Padre._Str_Comp };
                            _Ctrl.Dock = DockStyle.Top;
                            myArray[0] = _Ctrl;
                            this.Invoke(new MyDelegate_Ctrl_Tabs(DelegateMethod_Ctrl_Tabs), myArray);
                            _Int_48 = _Int_Count;
                        }
                    }
                }
                //---------------------TABS NÚMERO 48
                //---------------------------------------------------------------------------------------------------------
                //---------------------TABS NÚMERO 49
                _Str_expression = "ctabs = 49";
                _Drow_found = _Ds_FrmTabs.Tables[0].Select(_Str_expression);
                if (_Drow_found.Length > 0)
                {
                    _Str_TabActual = "FACTURAS POR IMPRIMIR";
                    _Int_Count = 0;
                    _Str_Sql = "SELECT COUNT(*) FROM TFACTURAM WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND c_impresa='0' AND cpfactura<>'0'";
                    _Ds_AuxTabs = _Mtd_GetDataSet(_Str_Sql);
                    if (Convert.ToString(_Ds_AuxTabs.Tables[0].Rows[0][0]) != "")
                    {
                        _Int_Count = Convert.ToInt32(_Ds_AuxTabs.Tables[0].Rows[0][0]);
                    }
                    if (_Int_Count != _Int_49)
                    {
                        object[] myArray = new object[1];
                        if (_Int_Count > _Int_49)
                        {_Bol_SwTimbre = true;}
                        if (_Pnl_Contenedor.Controls.Find("_Ctrl49", false).Length > 0)
                        {
                            myArray[0] = ((_Ctrl_Tabs)(_Pnl_Contenedor.Controls.Find("_Ctrl49", false)[0]));
                            this.Invoke(new MyDelegate_Ctrl_Tabs_Del(DelegateMethod_Ctrl_Tabs_Del), myArray);
                            _Int_49 = _Int_Count; 
                        }
                        if (_Int_Count > 0)
                        {
                            _Ctrl_Tabs _Ctrl = new _Ctrl_Tabs();
                            _Ctrl.Name = "_Ctrl49";
                            _Ctrl._Descripcion = "FACTURAS POR IMPRIMIR  ( " + _Int_Count.ToString() + " )";
                            _Ctrl._Formulario = "T3.Frm_ControlFactura";
                            _Ctrl._FormularioMdi = _Frm_MdiParent;
                            _Ctrl._Parametros = null;
                            _Ctrl.Dock = DockStyle.Top;
                            myArray[0] = _Ctrl;
                            this.Invoke(new MyDelegate_Ctrl_Tabs(DelegateMethod_Ctrl_Tabs), myArray);
                            _Int_49 = _Int_Count;
                        }
                    }
                }
                //---------------------TABS NÚMERO 49
                //---------------------------------------------------------------------------------------------------------
                //---------------------TABS NÚMERO 50
                _Str_expression = "ctabs = 50";
                _Drow_found = _Ds_FrmTabs.Tables[0].Select(_Str_expression);
                try
                {
                    if (_Drow_found.Length > 0)
                    {
                        _Str_TabActual = "CAJA PENDIENTE POR CERRAR";
                        _Int_Count = 0;
                        _Str_Sql = "Select count(*) from TCAJACXC where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and ccompany='" + Frm_Padre._Str_Comp + "' and ccerrada='0'";
                        _Ds_AuxTabs = _Mtd_GetDataSet(_Str_Sql);
                        if (Convert.ToString(_Ds_AuxTabs.Tables[0].Rows[0][0]) != "")
                        {
                            _Int_Count = Convert.ToInt32(_Ds_AuxTabs.Tables[0].Rows[0][0]);
                        }
                        if (_Int_Count != _Int_50)
                        {
                            object[] myArray = new object[1];
                            if (_Int_Count > _Int_50)
                            { _Bol_SwTimbre = true; }
                            if (_Pnl_Contenedor.Controls.Find("_Ctrl50", false).Length > 0)
                            {
                                myArray[0] = ((_Ctrl_Tabs)(_Pnl_Contenedor.Controls.Find("_Ctrl50", false)[0]));
                                this.Invoke(new MyDelegate_Ctrl_Tabs_Del(DelegateMethod_Ctrl_Tabs_Del), myArray);
                                _Int_50 = _Int_Count;
                            }
                            if (_Int_Count > 0)
                            {
                                _Ctrl_Tabs _Ctrl = new _Ctrl_Tabs();
                                _Ctrl.Name = "_Ctrl50";
                                _Ctrl._Descripcion = "CAJA PENDIENTE POR CERRAR  ( " + _Int_Count.ToString() + " )";
                                _Ctrl._Formulario = "T3.Frm_Busqueda2";
                                _Ctrl._FormularioMdi = _Frm_MdiParent;
                                _Ctrl._Parametros = new object[] { 23 };
                                _Ctrl.Dock = DockStyle.Top;
                                myArray[0] = _Ctrl;
                                this.Invoke(new MyDelegate_Ctrl_Tabs(DelegateMethod_Ctrl_Tabs), myArray);
                                _Int_50 = _Int_Count;
                            }
                        }
                    }
                }
                catch
                { }
                //---------------------TABS NÚMERO 50
                //---------------------------------------------------------------------------------------------------------
                //---------------------TABS NÚMERO 51
                _Str_expression = "ctabs = 51";
                _Drow_found = _Ds_FrmTabs.Tables[0].Select(_Str_expression);
                if (_Drow_found.Length > 0)
                {
                    _Str_TabActual = "RELACION DE DESPACHO POR IMPRIMIR";
                    _Int_Count = 0;
                    _Str_Sql = "Select count(*) from TPRECARGAM where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and cimprimeguiadesp='0' and cimprimefactura='1'";
                    _Ds_AuxTabs = _Mtd_GetDataSet(_Str_Sql);
                    if (Convert.ToString(_Ds_AuxTabs.Tables[0].Rows[0][0]) != "")
                    {
                        _Int_Count = Convert.ToInt32(_Ds_AuxTabs.Tables[0].Rows[0][0]);
                    }
                    if (_Int_Count != _Int_51)
                    {
                        object[] myArray = new object[1];
                        if (_Int_Count > _Int_51)
                        {_Bol_SwTimbre = true;}
                        if (_Pnl_Contenedor.Controls.Find("_Ctrl51", false).Length > 0)
                        {
                            myArray[0] = ((_Ctrl_Tabs)(_Pnl_Contenedor.Controls.Find("_Ctrl51", false)[0]));
                            this.Invoke(new MyDelegate_Ctrl_Tabs_Del(DelegateMethod_Ctrl_Tabs_Del), myArray);
                            _Int_51 = _Int_Count; 
                        }
                        if (_Int_Count > 0)
                        {
                            _Ctrl_Tabs _Ctrl = new _Ctrl_Tabs();
                            _Ctrl.Name = "_Ctrl51";
                            _Ctrl._Descripcion = "RELACION DE DESPACHO POR IMPRIMIR  ( " + _Int_Count.ToString() + " )";
                            _Ctrl._Formulario = "T3.Frm_ControlFactura";
                            _Ctrl._FormularioMdi = _Frm_MdiParent;
                            _Ctrl._Parametros = null;
                            _Ctrl.Dock = DockStyle.Top;
                            myArray[0] = _Ctrl;
                            this.Invoke(new MyDelegate_Ctrl_Tabs(DelegateMethod_Ctrl_Tabs), myArray);
                            _Int_51 = _Int_Count;
                        }
                    }
                }
                //---------------------TABS NÚMERO 51
                //---------------------------------------------------------------------------------------------------------
                //---------------------TABS NÚMERO 52
                _Str_expression = "ctabs = 52";
                _Drow_found = _Ds_FrmTabs.Tables[0].Select(_Str_expression);
                if (_Drow_found.Length > 0)
                {
                    _Str_TabActual = "CLIENTES SIN ENRUTAR";
                    _Int_Count = 0;
                    _Str_Sql = "SELECT COUNT(DISTINCT TCLIENTE.ccliente) FROM TCLIENTE INNER JOIN TZONACLIENTE ON TCLIENTE.ccliente=TZONACLIENTE.ccliente WHERE NOT EXISTS (SELECT TRUTAVISITAD.ccliente FROM TRUTAVISITAD WHERE TRUTAVISITAD.ccliente=TZONACLIENTE.ccliente AND TRUTAVISITAD.ccompany=TZONACLIENTE.ccompany AND ISNULL(TRUTAVISITAD.cdelete,0)=ISNULL(TZONACLIENTE.cdelete,0)) AND TCLIENTE.cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND TZONACLIENTE.ccompany='" + Frm_Padre._Str_Comp + "' AND TZONACLIENTE.cdelete='0' AND TCLIENTE.cdelete='0' and TCLIENTE.c_activo='1'";
                    _Ds_AuxTabs = _Mtd_GetDataSet(_Str_Sql);
                    if (Convert.ToString(_Ds_AuxTabs.Tables[0].Rows[0][0]) != "")
                    {
                        _Int_Count = Convert.ToInt32(_Ds_AuxTabs.Tables[0].Rows[0][0]);
                    }
                    if (_Int_Count != _Int_52)
                    {
                        object[] myArray = new object[1];
                        if (_Int_Count > _Int_52)
                        {_Bol_SwTimbre = true;}
                        if (_Pnl_Contenedor.Controls.Find("_Ctrl52", false).Length > 0)
                        {
                            myArray[0] = ((_Ctrl_Tabs)(_Pnl_Contenedor.Controls.Find("_Ctrl52", false)[0]));
                            this.Invoke(new MyDelegate_Ctrl_Tabs_Del(DelegateMethod_Ctrl_Tabs_Del), myArray);
                            _Int_52 = _Int_Count; 
                        }
                        if (_Int_Count > 0)
                        {
                            _Ctrl_Tabs _Ctrl = new _Ctrl_Tabs();
                            _Ctrl.Name = "_Ctrl52";
                            _Ctrl._Descripcion = "CLIENTES SIN ENRUTAR  ( " + _Int_Count.ToString() + " )";
                            _Ctrl._Formulario = "T3.Frm_Busqueda2";
                            _Ctrl._FormularioMdi = _Frm_MdiParent;
                            _Ctrl._Parametros = new object[] { 26 };
                            _Ctrl.Dock = DockStyle.Top;
                            myArray[0] = _Ctrl;
                            this.Invoke(new MyDelegate_Ctrl_Tabs(DelegateMethod_Ctrl_Tabs), myArray);
                            _Int_52 = _Int_Count;
                        }
                    }
                }
                //---------------------TABS NÚMERO 52
                //---------------------------------------------------------------------------------------------------------
                //---------------------TABS NÚMERO 53
                _Str_expression = "ctabs = 53";
                _Drow_found = _Ds_FrmTabs.Tables[0].Select(_Str_expression);
                if (_Drow_found.Length > 0)
                {
                    _Str_TabActual = "CHEQUES EN TRANSITO PENDIENTES";
                    _Int_Count = 0;
                    _Str_Sql = "SELECT count(*) FROM VST_RELACCOBDCHEQ WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and ccompany='" + Frm_Padre._Str_Comp + "' and (cegresotransito=0 or cegresotransito is null)";
                    _Ds_AuxTabs = _Mtd_GetDataSet(_Str_Sql);
                    if (Convert.ToString(_Ds_AuxTabs.Tables[0].Rows[0][0]) != "")
                    {
                        _Int_Count = Convert.ToInt32(_Ds_AuxTabs.Tables[0].Rows[0][0]);
                    }
                    if (_Int_Count != _Int_53)
                    {
                        object[] myArray = new object[1];
                        if (_Int_Count > _Int_53)
                        {_Bol_SwTimbre = true;}
                        if (_Pnl_Contenedor.Controls.Find("_Ctrl53", false).Length > 0)
                        {
                            myArray[0] = ((_Ctrl_Tabs)(_Pnl_Contenedor.Controls.Find("_Ctrl53", false)[0]));
                            this.Invoke(new MyDelegate_Ctrl_Tabs_Del(DelegateMethod_Ctrl_Tabs_Del), myArray);
                            _Int_53 = _Int_Count;
                        }
                        if (_Int_Count > 0)
                        {
                            _Ctrl_Tabs _Ctrl = new _Ctrl_Tabs();
                            _Ctrl.Name = "_Ctrl53";
                            _Ctrl._Descripcion = "CHEQUES EN TRANSITO PENDIENTES  ( " + _Int_Count.ToString() + " )";
                            _Ctrl._Formulario = "T3.Frm_EgreCheqTrans";
                            _Ctrl._FormularioMdi = _Frm_MdiParent;
                            _Ctrl._Parametros = null;
                            _Ctrl.Dock = DockStyle.Top;
                            myArray[0] = _Ctrl;
                            this.Invoke(new MyDelegate_Ctrl_Tabs(DelegateMethod_Ctrl_Tabs), myArray);
                            _Int_53 = _Int_Count;
                        }
                    }
                }
                //---------------------TABS NÚMERO 53
                //---------------------------------------------------------------------------------------------------------
                //---------------------TABS NÚMERO 54
                _Str_expression = "ctabs = 54";
                _Drow_found = _Ds_FrmTabs.Tables[0].Select(_Str_expression);
                if (_Drow_found.Length > 0)
                {
                    _Str_TabActual = "PRE-CARGAS SIN CULMINAR";
                    _Int_Count = 0;
                    _Str_Sql = "SELECT count(*) FROM TPRECARGAM WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND cimprimeprecarga=0 OR cverificascanpalm=0";
                    _Ds_AuxTabs = _Mtd_GetDataSet(_Str_Sql);
                    if (Convert.ToString(_Ds_AuxTabs.Tables[0].Rows[0][0]) != "")
                    {
                        _Int_Count = Convert.ToInt32(_Ds_AuxTabs.Tables[0].Rows[0][0]);
                    }
                    if (_Int_Count != _Int_54)
                    {
                        object[] myArray = new object[1];
                        if (_Int_Count > _Int_54)
                        { _Bol_SwTimbre = true; }
                        if (_Pnl_Contenedor.Controls.Find("_Ctrl54", false).Length > 0)
                        {
                            myArray[0] = ((_Ctrl_Tabs)(_Pnl_Contenedor.Controls.Find("_Ctrl54", false)[0]));
                            this.Invoke(new MyDelegate_Ctrl_Tabs_Del(DelegateMethod_Ctrl_Tabs_Del), myArray);
                            _Int_54 = _Int_Count;
                        }
                        if (_Int_Count > 0)
                        {
                            _Ctrl_Tabs _Ctrl = new _Ctrl_Tabs();
                            _Ctrl.Name = "_Ctrl54";
                            _Ctrl._Descripcion = "PRE-CARGAS SIN CULMINAR  (" + _Int_Count.ToString() + ")";
                            _Ctrl._Formulario = "T3.Frm_ControlDespacho";
                            _Ctrl._FormularioMdi = _Frm_MdiParent;
                            _Ctrl._Parametros = new object[] { "PS" };
                            _Ctrl.Dock = DockStyle.Top;
                            myArray[0] = _Ctrl;
                            this.Invoke(new MyDelegate_Ctrl_Tabs(DelegateMethod_Ctrl_Tabs), myArray);
                            _Int_54 = _Int_Count;
                        }
                    }
                }
                //---------------------TABS NÚMERO 54
                //---------------------------------------------------------------------------------------------------------
                //---------------------TABS NÚMERO 55
                _Str_expression = "ctabs = 55";
                _Drow_found = _Ds_FrmTabs.Tables[0].Select(_Str_expression);
                if (_Drow_found.Length > 0)
                {
                    _Str_TabActual = "DEBE REVISAR LAS CUOTAS DE COBRANZA";
                    _Int_Count = 0;
                    _Str_Sql = "SELECT count(*) FROM TCUOTACOB WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cdetallesta=1";
                    _Ds_AuxTabs = _Mtd_GetDataSet(_Str_Sql);
                    if (Convert.ToString(_Ds_AuxTabs.Tables[0].Rows[0][0]) != "")
                    {
                        _Int_Count = Convert.ToInt32(_Ds_AuxTabs.Tables[0].Rows[0][0]);
                    }
                    if (_Int_Count != _Int_55)
                    {
                        object[] myArray = new object[1];
                        if (_Int_Count > _Int_55)
                        { _Bol_SwTimbre = true; }
                        if (_Pnl_Contenedor.Controls.Find("_Ctrl55", false).Length > 0)
                        {
                            myArray[0] = ((_Ctrl_Tabs)(_Pnl_Contenedor.Controls.Find("_Ctrl55", false)[0]));
                            this.Invoke(new MyDelegate_Ctrl_Tabs_Del(DelegateMethod_Ctrl_Tabs_Del), myArray);
                            _Int_55 = _Int_Count;
                        }
                        if (_Int_Count > 0)
                        {
                            _Ctrl_Tabs _Ctrl = new _Ctrl_Tabs();
                            _Ctrl.Name = "_Ctrl55";
                            _Ctrl._Descripcion = _Str_TabActual;
                            _Ctrl._Formulario = "T3.Frm_CuotaCobranza";
                            _Ctrl._FormularioMdi = _Frm_MdiParent;
                            _Ctrl._Parametros = null;
                            _Ctrl.Dock = DockStyle.Top;
                            myArray[0] = _Ctrl;
                            this.Invoke(new MyDelegate_Ctrl_Tabs(DelegateMethod_Ctrl_Tabs), myArray);
                            _Int_55 = _Int_Count;
                        }
                    }
                }
                //---------------------------------------------------------------------------------------------------------
                //---------------------TABS NÚMERO 56
                //---------------------------------------------------------------------------------------------------------
                _Str_expression = "ctabs = 56";
                _Drow_found = _Ds_FrmTabs.Tables[0].Select(_Str_expression);
                if (_Drow_found.Length > 0)
                {
                    _Str_TabActual = "PROVEEDORES SIN COMPAÑÍA";
                    _Int_Count = 0;
                    _Str_Sql = "SELECT COUNT(*) FROM TPROVEEDOR WHERE NOT EXISTS(SELECT cproveedor FROM TPROVEEDOR AS TPROV WHERE TPROV.ccompany='" + Frm_Padre._Str_Comp + "' AND TPROV.cproveedor=TPROVEEDOR.cproveedor) AND cglobal<>'1'";
                    _Ds_AuxTabs = _Mtd_GetDataSet(_Str_Sql);
                    if (Convert.ToString(_Ds_AuxTabs.Tables[0].Rows[0][0]) != "")
                    {
                        _Int_Count = Convert.ToInt32(_Ds_AuxTabs.Tables[0].Rows[0][0]);
                    }
                    if (_Int_Count != _Int_56)
                    {
                        object[] myArray = new object[1];
                        if (_Int_Count > _Int_56)
                        { _Bol_SwTimbre = true; }
                        if (_Pnl_Contenedor.Controls.Find("_Ctrl56", false).Length > 0)
                        {
                            myArray[0] = ((_Ctrl_Tabs)(_Pnl_Contenedor.Controls.Find("_Ctrl56", false)[0]));
                            this.Invoke(new MyDelegate_Ctrl_Tabs_Del(DelegateMethod_Ctrl_Tabs_Del), myArray);
                            _Int_56 = _Int_Count;
                        }
                        if (_Int_Count > 0)
                        {
                            _Ctrl_Tabs _Ctrl = new _Ctrl_Tabs();
                            _Ctrl.Name = "_Ctrl56";
                            _Ctrl._Descripcion = _Str_TabActual + "(" + _Int_Count.ToString() + ")";
                            _Ctrl._Formulario = "T3.Frm_ProveedorSerOtrComp";
                            _Ctrl._FormularioMdi = _Frm_MdiParent;
                            _Ctrl._Parametros = null;
                            _Ctrl.Dock = DockStyle.Top;
                            myArray[0] = _Ctrl;
                            this.Invoke(new MyDelegate_Ctrl_Tabs(DelegateMethod_Ctrl_Tabs), myArray);
                            _Int_56 = _Int_Count;
                        }
                    }
                }
                //---------------------------------------------------------------------------------------------------------
                //---------------------TABS NÚMERO 57
                //---------------------------------------------------------------------------------------------------------
                _Str_expression = "ctabs = 57";
                _Drow_found = _Ds_FrmTabs.Tables[0].Select(_Str_expression);
                if (_Drow_found.Length > 0)
                {
                    _Str_TabActual = "NR DE DEVOLUCIONES EN VENTAS POR IMPRIMIR";
                    _Int_Count = 0;
                    _Str_Sql = "SELECT count(*) FROM VST_NOTARECEPC_DEVOL WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cimpreso=0 AND cdelete=0";
                    _Ds_AuxTabs = _Mtd_GetDataSet(_Str_Sql);
                    if (Convert.ToString(_Ds_AuxTabs.Tables[0].Rows[0][0]) != "")
                    {
                        _Int_Count = Convert.ToInt32(_Ds_AuxTabs.Tables[0].Rows[0][0]);
                    }
                    if (_Int_Count != _Int_57)
                    {
                        object[] myArray = new object[1];
                        if (_Int_Count > _Int_57)
                        { _Bol_SwTimbre = true; }
                        if (_Pnl_Contenedor.Controls.Find("_Ctrl57", false).Length > 0)
                        {
                            myArray[0] = ((_Ctrl_Tabs)(_Pnl_Contenedor.Controls.Find("_Ctrl57", false)[0]));
                            this.Invoke(new MyDelegate_Ctrl_Tabs_Del(DelegateMethod_Ctrl_Tabs_Del), myArray);
                            _Int_57 = _Int_Count;
                        }
                        if (_Int_Count > 0)
                        {
                            _Ctrl_Tabs _Ctrl = new _Ctrl_Tabs();
                            _Ctrl.Name = "_Ctrl57";
                            _Ctrl._Descripcion = _Str_TabActual +"(" + _Int_Count.ToString() + ")";
                            _Ctrl._Formulario = "T3.Frm_ImpresionLote";
                            _Ctrl._FormularioMdi = _Frm_MdiParent;
                            _Ctrl._Parametros = new object[] { 9 };
                            _Ctrl.Dock = DockStyle.Top;
                            myArray[0] = _Ctrl;
                            this.Invoke(new MyDelegate_Ctrl_Tabs(DelegateMethod_Ctrl_Tabs), myArray);
                            _Int_57 = _Int_Count;
                        }
                    }
                }
                //---------------------------------------------------------------------------------------------------------
                //---------------------TABS NÚMERO 58
                //---------------------------------------------------------------------------------------------------------
                _Str_expression = "ctabs = 58";
                _Drow_found = _Ds_FrmTabs.Tables[0].Select(_Str_expression);
                if (_Drow_found.Length > 0)
                {
                    if (myUtilidad._Mtd_ObtenerUsuarioFirma(Frm_Padre._Str_Use) == "1" & myUtilidad._Mtd_UsuarioProceso(Frm_Padre._Str_Use, "F_N2_DEVOLVENTA"))
                    {
                        _Str_TabActual = "DEVOLUCIONES EN VENTAS POR APROBAR";
                        _Int_Count = 0;
                        _Str_Sql = "SELECT count(*) FROM VST_TDEVVENTAM WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cfimarnivel=1 AND canuladan=0";
                        _Ds_AuxTabs = _Mtd_GetDataSet(_Str_Sql);
                        if (Convert.ToString(_Ds_AuxTabs.Tables[0].Rows[0][0]) != "")
                        {
                            _Int_Count = Convert.ToInt32(_Ds_AuxTabs.Tables[0].Rows[0][0]);
                        }
                        if (_Int_Count != _Int_58)
                        {
                            object[] myArray = new object[1];
                            if (_Int_Count > _Int_58)
                            { _Bol_SwTimbre = true; }
                            if (_Pnl_Contenedor.Controls.Find("_Ctrl58", false).Length > 0)
                            {
                                myArray[0] = ((_Ctrl_Tabs)(_Pnl_Contenedor.Controls.Find("_Ctrl58", false)[0]));
                                this.Invoke(new MyDelegate_Ctrl_Tabs_Del(DelegateMethod_Ctrl_Tabs_Del), myArray);
                                _Int_58 = _Int_Count;
                            }
                            if (_Int_Count > 0)
                            {
                                _Ctrl_Tabs _Ctrl = new _Ctrl_Tabs();
                                _Ctrl.Name = "_Ctrl58";
                                _Ctrl._Descripcion = _Str_TabActual + "(" + _Int_Count.ToString() + ")";
                                _Ctrl._Formulario = "T3.Frm_DevolVenta";
                                _Ctrl._FormularioMdi = _Frm_MdiParent;
                                _Ctrl._Parametros = new object[] { 1 };
                                _Ctrl.Dock = DockStyle.Top;
                                myArray[0] = _Ctrl;
                                this.Invoke(new MyDelegate_Ctrl_Tabs(DelegateMethod_Ctrl_Tabs), myArray);
                                _Int_58 = _Int_Count;
                            }
                        }
                    }
                }
                //---------------------------------------------------------------------------------------------------------
                //---------------------TABS NÚMERO 59
                //---------------------------------------------------------------------------------------------------------
                _Str_expression = "ctabs = 59";
                _Drow_found = _Ds_FrmTabs.Tables[0].Select(_Str_expression);
                if (_Drow_found.Length > 0)
                {
                    if (myUtilidad._Mtd_ObtenerUsuarioFirma(Frm_Padre._Str_Use) == "1" & myUtilidad._Mtd_UsuarioProceso(Frm_Padre._Str_Use, "F_N1_ANULFACTURA"))
                    {
                        _Str_TabActual = "FACTURAS PENDIENTES POR ANULAR";
                        _Int_Count = 0;
                        _Str_Sql = "SELECT count(ccompany) FROM TFACTURANUL WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cactivo=0 AND cestatusfirma=2 AND cdelete=0";
                        _Ds_AuxTabs = _Mtd_GetDataSet(_Str_Sql);
                        if (Convert.ToString(_Ds_AuxTabs.Tables[0].Rows[0][0]) != "")
                        {
                            _Int_Count = Convert.ToInt32(_Ds_AuxTabs.Tables[0].Rows[0][0]);
                        }
                        if (_Int_Count != _Int_59)
                        {
                            object[] myArray = new object[1];
                            if (_Int_Count > _Int_59)
                            { _Bol_SwTimbre = true; }
                            if (_Pnl_Contenedor.Controls.Find("_Ctrl59", false).Length > 0)
                            {
                                myArray[0] = ((_Ctrl_Tabs)(_Pnl_Contenedor.Controls.Find("_Ctrl59", false)[0]));
                                this.Invoke(new MyDelegate_Ctrl_Tabs_Del(DelegateMethod_Ctrl_Tabs_Del), myArray);
                                _Int_59 = _Int_Count;
                            }
                            if (_Int_Count > 0)
                            {
                                _Ctrl_Tabs _Ctrl = new _Ctrl_Tabs();
                                _Ctrl.Name = "_Ctrl59";
                                _Ctrl._Descripcion = _Str_TabActual + "(" + _Int_Count.ToString() + ")";
                                _Ctrl._Formulario = "T3.Frm_AprobAnulFactura";
                                _Ctrl._FormularioMdi = _Frm_MdiParent;
                                _Ctrl._Parametros = new object[] { 2 };
                                _Ctrl.Dock = DockStyle.Top;
                                myArray[0] = _Ctrl;
                                this.Invoke(new MyDelegate_Ctrl_Tabs(DelegateMethod_Ctrl_Tabs), myArray);
                                _Int_59 = _Int_Count;
                            }
                        }
                    }
                }
                //---------------------------------------------------------------------------------------------------------
                //---------------------TABS NÚMERO 60
                //---------------------------------------------------------------------------------------------------------
                _Str_expression = "ctabs = 60";
                _Drow_found = _Ds_FrmTabs.Tables[0].Select(_Str_expression);
                if (_Drow_found.Length > 0)
                {
                    if (myUtilidad._Mtd_ObtenerUsuarioFirma(Frm_Padre._Str_Use) == "1" & myUtilidad._Mtd_UsuarioProceso(Frm_Padre._Str_Use, "F_N2_ANULFACTURA"))
                    {
                        _Str_TabActual = "FACTURAS ANULADAS POR APROBAR";
                        _Int_Count = 0;
                        _Str_Sql = "SELECT count(ccompany) FROM TFACTURANUL WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cactivo=0 AND cestatusfirma=1 AND cdelete=0";
                        _Ds_AuxTabs = _Mtd_GetDataSet(_Str_Sql);
                        if (Convert.ToString(_Ds_AuxTabs.Tables[0].Rows[0][0]) != "")
                        {
                            _Int_Count = Convert.ToInt32(_Ds_AuxTabs.Tables[0].Rows[0][0]);
                        }
                        if (_Int_Count != _Int_60)
                        {
                            object[] myArray = new object[1];
                            if (_Int_Count > _Int_60)
                            { _Bol_SwTimbre = true; }
                            if (_Pnl_Contenedor.Controls.Find("_Ctrl60", false).Length > 0)
                            {
                                myArray[0] = ((_Ctrl_Tabs)(_Pnl_Contenedor.Controls.Find("_Ctrl60", false)[0]));
                                this.Invoke(new MyDelegate_Ctrl_Tabs_Del(DelegateMethod_Ctrl_Tabs_Del), myArray);
                                _Int_60 = _Int_Count;
                            }
                            if (_Int_Count > 0)
                            {
                                _Ctrl_Tabs _Ctrl = new _Ctrl_Tabs();
                                _Ctrl.Name = "_Ctrl60";
                                _Ctrl._Descripcion = _Str_TabActual + "(" + _Int_Count.ToString() + ")";
                                _Ctrl._Formulario = "T3.Frm_AprobAnulFactura";
                                _Ctrl._FormularioMdi = _Frm_MdiParent;
                                _Ctrl._Parametros = new object[] { 1 };
                                _Ctrl.Dock = DockStyle.Top;
                                myArray[0] = _Ctrl;
                                this.Invoke(new MyDelegate_Ctrl_Tabs(DelegateMethod_Ctrl_Tabs), myArray);
                                _Int_60 = _Int_Count;
                            }
                        }
                    }
                }
                //---------------------------------------------------------------------------------------------------------
                //---------------------TABS NÚMERO 61
                //---------------------------------------------------------------------------------------------------------
                _Str_expression = "ctabs = 61";
                _Drow_found = _Ds_FrmTabs.Tables[0].Select(_Str_expression);
                if (_Drow_found.Length > 0)
                {
                    _Str_TabActual = "CHEQUES DEVUELTOS INGRESADOS";
                    _Int_Count = 0;
                    _Str_Sql = "SELECT COUNT(*) FROM VST_CHEQUEDEVUELTO WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and ccompany='" + Frm_Padre._Str_Comp + "' and cactivo='1' AND EXISTS(SELECT csaldofactura FROM TSALDOCLIENTED WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND ctipodocument=(SELECT TCONFIGCXC.ctipdoccheqdev FROM TCONFIGCXC WHERE TCONFIGCXC.ccompany='" + Frm_Padre._Str_Comp + "') AND cnumdocu=VST_CHEQUEDEVUELTO.cnumcheque AND cactivo=1 AND cdelete=0 AND csaldofactura>0 AND TSALDOCLIENTED.CCLIENTE=VST_CHEQUEDEVUELTO.CCLIENTE)";
                    _Ds_AuxTabs = _Mtd_GetDataSet(_Str_Sql);
                    if (Convert.ToString(_Ds_AuxTabs.Tables[0].Rows[0][0]) != "")
                    {
                        _Int_Count = Convert.ToInt32(_Ds_AuxTabs.Tables[0].Rows[0][0]);
                    }
                    if (_Int_Count != _Int_61)
                    {
                        object[] myArray = new object[1];
                        if (_Int_Count > _Int_61)
                        { _Bol_SwTimbre = true; }
                        if (_Pnl_Contenedor.Controls.Find("_Ctrl61", false).Length > 0)
                        {
                            myArray[0] = ((_Ctrl_Tabs)(_Pnl_Contenedor.Controls.Find("_Ctrl61", false)[0]));
                            this.Invoke(new MyDelegate_Ctrl_Tabs_Del(DelegateMethod_Ctrl_Tabs_Del), myArray);
                            _Int_61 = _Int_Count;
                        }
                        if (_Int_Count > 0)
                        {
                            _Ctrl_Tabs _Ctrl = new _Ctrl_Tabs();
                            _Ctrl.Name = "_Ctrl61";
                            _Ctrl._Descripcion = _Str_TabActual + "(" + _Int_Count.ToString() + ")";
                            _Ctrl._Formulario = "T3.Frm_IngCheqDevuelto";
                            _Ctrl._FormularioMdi = _Frm_MdiParent;
                            _Ctrl._Parametros = null;
                            _Ctrl.Dock = DockStyle.Top;
                            myArray[0] = _Ctrl;
                            this.Invoke(new MyDelegate_Ctrl_Tabs(DelegateMethod_Ctrl_Tabs), myArray);
                            _Int_61 = _Int_Count;
                        }
                    }
                }
                //---------------------------------------------------------------------------------------------------------
                //---------------------TABS NÚMERO 62
                //---------------------------------------------------------------------------------------------------------
                _Str_expression = "ctabs = 62";
                _Drow_found = _Ds_FrmTabs.Tables[0].Select(_Str_expression);
                if (_Drow_found.Length > 0)
                {
                    if (myUtilidad._Mtd_ObtenerUsuarioFirma(Frm_Padre._Str_Use) == "1" & myUtilidad._Mtd_UsuarioProceso(Frm_Padre._Str_Use, "F_N2_NC_CXC"))
                    {
                        _Str_TabActual = "N.C. PENDIENTES POR APROBAR";
                        _Int_Count = 0;
                        _Str_Sql = "SELECT count(cidnotcredicctemp) FROM TNOTACREDICCTEMP WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and ccompany='" + Frm_Padre._Str_Comp + "' AND cestatusfirma=1";
                        _Ds_AuxTabs = _Mtd_GetDataSet(_Str_Sql);
                        if (Convert.ToString(_Ds_AuxTabs.Tables[0].Rows[0][0]) != "")
                        {
                            _Int_Count = Convert.ToInt32(_Ds_AuxTabs.Tables[0].Rows[0][0]);
                        }
                        if (_Int_Count != _Int_62)
                        {
                            object[] myArray = new object[1];
                            if (_Int_Count > _Int_62)
                            { _Bol_SwTimbre = true; }
                            if (_Pnl_Contenedor.Controls.Find("_Ctrl62", false).Length > 0)
                            {
                                myArray[0] = ((_Ctrl_Tabs)(_Pnl_Contenedor.Controls.Find("_Ctrl62", false)[0]));
                                this.Invoke(new MyDelegate_Ctrl_Tabs_Del(DelegateMethod_Ctrl_Tabs_Del), myArray);
                                _Int_62 = _Int_Count;
                            }
                            if (_Int_Count > 0)
                            {
                                _Ctrl_Tabs _Ctrl = new _Ctrl_Tabs();
                                _Ctrl.Name = "_Ctrl62";
                                _Ctrl._Descripcion = _Str_TabActual + "(" + _Int_Count.ToString() + ")";
                                _Ctrl._Formulario = "T3.Frm_ImpresionLote";
                                _Ctrl._FormularioMdi = _Frm_MdiParent;
                                _Ctrl._Parametros = new object[] { 4 };
                                _Ctrl.Dock = DockStyle.Top;
                                myArray[0] = _Ctrl;
                                this.Invoke(new MyDelegate_Ctrl_Tabs(DelegateMethod_Ctrl_Tabs), myArray);
                                _Int_62 = _Int_Count;
                            }
                        }
                    }
                }
                //---------------------------------------------------------------------------------------------------------
                //---------------------TABS NÚMERO 63
                //---------------------------------------------------------------------------------------------------------
                _Str_expression = "ctabs = 63";
                _Drow_found = _Ds_FrmTabs.Tables[0].Select(_Str_expression);
                if (_Drow_found.Length > 0)
                {
                    _Str_TabActual = "AJUSTES DE ENTRADA POR IMPRIMIR";
                    _Int_Count = 0;
                    _Str_Sql = "SELECT count(*) FROM TAJUSENTC WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cimpreso=0 AND cdelete=0 AND cejecutada=1 AND ISNULL(cajusteintegrado,0)='0'";
                    _Ds_AuxTabs = _Mtd_GetDataSet(_Str_Sql);
                    if (Convert.ToString(_Ds_AuxTabs.Tables[0].Rows[0][0]) != "")
                    {
                        _Int_Count = Convert.ToInt32(_Ds_AuxTabs.Tables[0].Rows[0][0]);
                    }
                    if (_Int_Count != _Int_63)
                    {
                        object[] myArray = new object[1];
                        if (_Int_Count > _Int_63)
                        { _Bol_SwTimbre = true; }
                        if (_Pnl_Contenedor.Controls.Find("_Ctrl63", false).Length > 0)
                        {
                            myArray[0] = ((_Ctrl_Tabs)(_Pnl_Contenedor.Controls.Find("_Ctrl63", false)[0]));
                            this.Invoke(new MyDelegate_Ctrl_Tabs_Del(DelegateMethod_Ctrl_Tabs_Del), myArray);
                            _Int_63 = _Int_Count;
                        }
                        if (_Int_Count > 0)
                        {
                            _Ctrl_Tabs _Ctrl = new _Ctrl_Tabs();
                            _Ctrl.Name = "_Ctrl63";
                            _Ctrl._Descripcion = _Str_TabActual + "(" + _Int_Count.ToString() + ")";
                            _Ctrl._Formulario = "T3.Frm_AjusteEntrada";
                            _Ctrl._FormularioMdi = _Frm_MdiParent;
                            _Ctrl._Parametros = new object[] { 1 };
                            _Ctrl.Dock = DockStyle.Top;
                            myArray[0] = _Ctrl;
                            this.Invoke(new MyDelegate_Ctrl_Tabs(DelegateMethod_Ctrl_Tabs), myArray);
                            _Int_63 = _Int_Count;
                        }
                    }
                }
                //---------------------------------------------------------------------------------------------------------
                //---------------------TABS NÚMERO 64
                //---------------------------------------------------------------------------------------------------------
                _Str_expression = "ctabs = 64";
                _Drow_found = _Ds_FrmTabs.Tables[0].Select(_Str_expression);
                if (_Drow_found.Length > 0)
                {
                    _Str_TabActual = "AJUSTES DE SALIDA POR IMPRIMIR";
                    _Int_Count = 0;
                    _Str_Sql = "SELECT count(*) FROM TAJUSSALC WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cimpreso=0 AND cdelete=0 AND cejecutada=1 AND ISNULL(cajusteintegrado,0)='0'";
                    _Ds_AuxTabs = _Mtd_GetDataSet(_Str_Sql);
                    if (Convert.ToString(_Ds_AuxTabs.Tables[0].Rows[0][0]) != "")
                    {
                        _Int_Count = Convert.ToInt32(_Ds_AuxTabs.Tables[0].Rows[0][0]);
                    }
                    if (_Int_Count != _Int_64)
                    {
                        object[] myArray = new object[1];
                        if (_Int_Count > _Int_64)
                        { _Bol_SwTimbre = true; }
                        if (_Pnl_Contenedor.Controls.Find("_Ctrl64", false).Length > 0)
                        {
                            myArray[0] = ((_Ctrl_Tabs)(_Pnl_Contenedor.Controls.Find("_Ctrl64", false)[0]));
                            this.Invoke(new MyDelegate_Ctrl_Tabs_Del(DelegateMethod_Ctrl_Tabs_Del), myArray);
                            _Int_64 = _Int_Count;
                        }
                        if (_Int_Count > 0)
                        {
                            _Ctrl_Tabs _Ctrl = new _Ctrl_Tabs();
                            _Ctrl.Name = "_Ctrl64";
                            _Ctrl._Descripcion = _Str_TabActual + "(" + _Int_Count.ToString() + ")";
                            _Ctrl._Formulario = "T3.Frm_AjusteSalida";
                            _Ctrl._FormularioMdi = _Frm_MdiParent;
                            _Ctrl._Parametros = new object[] { 1 };
                            _Ctrl.Dock = DockStyle.Top;
                            myArray[0] = _Ctrl;
                            this.Invoke(new MyDelegate_Ctrl_Tabs(DelegateMethod_Ctrl_Tabs), myArray);
                            _Int_64 = _Int_Count;
                        }
                    }
                }
                //---------------------------------------------------------------------------------------------------------
                //---------------------TABS NÚMERO 65
                //---------------------------------------------------------------------------------------------------------
                _Str_expression = "ctabs = 65";
                _Drow_found = _Ds_FrmTabs.Tables[0].Select(_Str_expression);
                if (_Drow_found.Length > 0)
                {
                    if (myUtilidad._Mtd_ObtenerUsuarioFirma(Frm_Padre._Str_Use) == "1" & myUtilidad._Mtd_UsuarioProceso(Frm_Padre._Str_Use, "F_N2_ANC_CXC"))
                    {
                        _Str_TabActual = "ANULACION DE N.C. DE CxC POR APROBAR";
                        _Int_Count = 0;
                        _Str_Sql = "SELECT count(*) FROM TNCANUL WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cactivo=0 AND cestatusfirma=1 AND cdelete=0";
                        _Ds_AuxTabs = _Mtd_GetDataSet(_Str_Sql);
                        if (Convert.ToString(_Ds_AuxTabs.Tables[0].Rows[0][0]) != "")
                        {
                            _Int_Count = Convert.ToInt32(_Ds_AuxTabs.Tables[0].Rows[0][0]);
                        }
                        if (_Int_Count != _Int_65)
                        {
                            object[] myArray = new object[1];
                            if (_Int_Count > _Int_65)
                            { _Bol_SwTimbre = true; }
                            if (_Pnl_Contenedor.Controls.Find("_Ctrl65", false).Length > 0)
                            {
                                myArray[0] = ((_Ctrl_Tabs)(_Pnl_Contenedor.Controls.Find("_Ctrl65", false)[0]));
                                this.Invoke(new MyDelegate_Ctrl_Tabs_Del(DelegateMethod_Ctrl_Tabs_Del), myArray);
                                _Int_65 = _Int_Count;
                            }
                            if (_Int_Count > 0)
                            {
                                _Ctrl_Tabs _Ctrl = new _Ctrl_Tabs();
                                _Ctrl.Name = "_Ctrl65";
                                _Ctrl._Descripcion = _Str_TabActual + "(" + _Int_Count.ToString() + ")";
                                _Ctrl._Formulario = "T3.Frm_ImpresionLote";
                                _Ctrl._FormularioMdi = _Frm_MdiParent;
                                _Ctrl._Parametros = new object[] { 13 };
                                _Ctrl.Dock = DockStyle.Top;
                                myArray[0] = _Ctrl;
                                this.Invoke(new MyDelegate_Ctrl_Tabs(DelegateMethod_Ctrl_Tabs), myArray);
                                _Int_65 = _Int_Count;
                            }
                        }
                    }
                }
                //---------------------------------------------------------------------------------------------------------
                //---------------------TABS NÚMERO 66
                //---------------------------------------------------------------------------------------------------------
                _Str_expression = "ctabs = 66";
                _Drow_found = _Ds_FrmTabs.Tables[0].Select(_Str_expression);
                if (_Drow_found.Length > 0)
                {
                    _Str_TabActual = "N.C. SIN NUMERO DE CONTROL";
                    _Int_Count = 0;
                    _Str_Sql = "SELECT count(*) FROM TNOTACREDICC WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and ccompany='" + Frm_Padre._Str_Comp + "' AND cactivo=1 AND cimpresa=1 AND cdelete=0 AND canulado=0 AND (cnumcontrolnc=0 or cnumcontrolnc is null)";
                    _Ds_AuxTabs = _Mtd_GetDataSet(_Str_Sql);
                    if (Convert.ToString(_Ds_AuxTabs.Tables[0].Rows[0][0]) != "")
                    {
                        _Int_Count = Convert.ToInt32(_Ds_AuxTabs.Tables[0].Rows[0][0]);
                    }
                    if (_Int_Count != _Int_66)
                    {
                        object[] myArray = new object[1];
                        if (_Int_Count > _Int_66)
                        { _Bol_SwTimbre = true; }
                        if (_Pnl_Contenedor.Controls.Find("_Ctrl66", false).Length > 0)
                        {
                            myArray[0] = ((_Ctrl_Tabs)(_Pnl_Contenedor.Controls.Find("_Ctrl66", false)[0]));
                            this.Invoke(new MyDelegate_Ctrl_Tabs_Del(DelegateMethod_Ctrl_Tabs_Del), myArray);
                            _Int_66 = _Int_Count;
                        }
                        if (_Int_Count > 0)
                        {
                            _Ctrl_Tabs _Ctrl = new _Ctrl_Tabs();
                            _Ctrl.Name = "_Ctrl66";
                            _Ctrl._Descripcion = _Str_TabActual + "(" + _Int_Count.ToString() + ")";
                            _Ctrl._Formulario = "T3.Frm_ImpresionLote";
                            _Ctrl._FormularioMdi = _Frm_MdiParent;
                            _Ctrl._Parametros = new object[] { 5 };
                            _Ctrl.Dock = DockStyle.Top;
                            myArray[0] = _Ctrl;
                            this.Invoke(new MyDelegate_Ctrl_Tabs(DelegateMethod_Ctrl_Tabs), myArray);
                            _Int_66 = _Int_Count;
                        }
                    }
                }
                //---------------------------------------------------------------------------------------------------------
                //---------------------TABS NÚMERO 67
                //---------------------------------------------------------------------------------------------------------
                _Str_expression = "ctabs = 67";
                _Drow_found = _Ds_FrmTabs.Tables[0].Select(_Str_expression);
                if (_Drow_found.Length > 0)
                {
                    if (myUtilidad._Mtd_ObtenerUsuarioFirma(Frm_Padre._Str_Use) == "1" & myUtilidad._Mtd_UsuarioProceso(Frm_Padre._Str_Use, "F_N2_ND_CXC"))
                    {
                        _Str_TabActual = "N.D. PENDIENTES POR APROBAR";
                        _Int_Count = 0;
                        _Str_Sql = "SELECT count(cidnotadebitocctemp) FROM TNOTADEBICCTEMP WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and ccompany='" + Frm_Padre._Str_Comp + "' AND cestatusfirma=1";
                        _Ds_AuxTabs = _Mtd_GetDataSet(_Str_Sql);
                        if (Convert.ToString(_Ds_AuxTabs.Tables[0].Rows[0][0]) != "")
                        {
                            _Int_Count = Convert.ToInt32(_Ds_AuxTabs.Tables[0].Rows[0][0]);
                        }
                        if (_Int_Count != _Int_67)
                        {
                            object[] myArray = new object[1];
                            if (_Int_Count > _Int_67)
                            { _Bol_SwTimbre = true; }
                            if (_Pnl_Contenedor.Controls.Find("_Ctrl67", false).Length > 0)
                            {
                                myArray[0] = ((_Ctrl_Tabs)(_Pnl_Contenedor.Controls.Find("_Ctrl67", false)[0]));
                                this.Invoke(new MyDelegate_Ctrl_Tabs_Del(DelegateMethod_Ctrl_Tabs_Del), myArray);
                                _Int_67 = _Int_Count;
                            }
                            if (_Int_Count > 0)
                            {
                                _Ctrl_Tabs _Ctrl = new _Ctrl_Tabs();
                                _Ctrl.Name = "_Ctrl67";
                                _Ctrl._Descripcion = _Str_TabActual + "(" + _Int_Count.ToString() + ")";
                                _Ctrl._Formulario = "T3.Frm_ImpresionLote";
                                _Ctrl._FormularioMdi = _Frm_MdiParent;
                                _Ctrl._Parametros = new object[] { 6 };
                                _Ctrl.Dock = DockStyle.Top;
                                myArray[0] = _Ctrl;
                                this.Invoke(new MyDelegate_Ctrl_Tabs(DelegateMethod_Ctrl_Tabs), myArray);
                                _Int_67 = _Int_Count;
                            }
                        }
                    }
                }
                //---------------------------------------------------------------------------------------------------------
                //---------------------TABS NÚMERO 68
                //---------------------------------------------------------------------------------------------------------
                _Str_expression = "ctabs = 68";
                _Drow_found = _Ds_FrmTabs.Tables[0].Select(_Str_expression);
                if (_Drow_found.Length > 0)
                {
                    _Str_TabActual = "N.D. SIN NUMERO DE CONTROL";
                    _Int_Count = 0;
                    _Str_Sql = "SELECT count(*) FROM TNOTADEBICC WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and ccompany='" + Frm_Padre._Str_Comp + "' AND cactivo=1 AND cimpresa=1 AND cdelete=0 AND canulado=0 AND (cnumcontrolnd=0 or cnumcontrolnd is null)";
                    _Ds_AuxTabs = _Mtd_GetDataSet(_Str_Sql);
                    if (Convert.ToString(_Ds_AuxTabs.Tables[0].Rows[0][0]) != "")
                    {
                        _Int_Count = Convert.ToInt32(_Ds_AuxTabs.Tables[0].Rows[0][0]);
                    }
                    if (_Int_Count != _Int_68)
                    {
                        object[] myArray = new object[1];
                        if (_Int_Count > _Int_68)
                        { _Bol_SwTimbre = true; }
                        if (_Pnl_Contenedor.Controls.Find("_Ctrl68", false).Length > 0)
                        {
                            myArray[0] = ((_Ctrl_Tabs)(_Pnl_Contenedor.Controls.Find("_Ctrl68", false)[0]));
                            this.Invoke(new MyDelegate_Ctrl_Tabs_Del(DelegateMethod_Ctrl_Tabs_Del), myArray);
                            _Int_68 = _Int_Count;
                        }
                        if (_Int_Count > 0)
                        {
                            _Ctrl_Tabs _Ctrl = new _Ctrl_Tabs();
                            _Ctrl.Name = "_Ctrl68";
                            _Ctrl._Descripcion = _Str_TabActual + "(" + _Int_Count.ToString() + ")";
                            _Ctrl._Formulario = "T3.Frm_ImpresionLote";
                            _Ctrl._FormularioMdi = _Frm_MdiParent;
                            _Ctrl._Parametros = new object[] { 7 };
                            _Ctrl.Dock = DockStyle.Top;
                            myArray[0] = _Ctrl;
                            this.Invoke(new MyDelegate_Ctrl_Tabs(DelegateMethod_Ctrl_Tabs), myArray);
                            _Int_68 = _Int_Count;
                        }
                    }
                }
                //---------------------------------------------------------------------------------------------------------
                //---------------------TABS NÚMERO 69
                //---------------------------------------------------------------------------------------------------------
                _Str_expression = "ctabs = 69";
                _Drow_found = _Ds_FrmTabs.Tables[0].Select(_Str_expression);
                if (_Drow_found.Length > 0)
                {
                    if (myUtilidad._Mtd_ObtenerUsuarioFirma(Frm_Padre._Str_Use) == "1" & myUtilidad._Mtd_UsuarioProceso(Frm_Padre._Str_Use, "F_N3_NC_CXC"))
                    {
                        _Str_TabActual = "N.C. GENERADAS EN EL CIERRE DE CAJA";
                        _Int_Count = 0;
                        _Str_Sql = "Select count(*) from TNOTACREDICC where cdelete='0' and ccompany='" + Frm_Padre._Str_Comp + "' and cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and cimpresa='0' and cactivo='0' AND cestatusfirma=3";
                        _Ds_AuxTabs = _Mtd_GetDataSet(_Str_Sql);
                        if (Convert.ToString(_Ds_AuxTabs.Tables[0].Rows[0][0]) != "")
                        {
                            _Int_Count = Convert.ToInt32(_Ds_AuxTabs.Tables[0].Rows[0][0]);
                        }
                        if (_Int_Count != _Int_69)
                        {
                            object[] myArray = new object[1];
                            if (_Int_Count > _Int_69)
                            { _Bol_SwTimbre = true; }
                            if (_Pnl_Contenedor.Controls.Find("_Ctrl69", false).Length > 0)
                            {
                                myArray[0] = ((_Ctrl_Tabs)(_Pnl_Contenedor.Controls.Find("_Ctrl69", false)[0]));
                                this.Invoke(new MyDelegate_Ctrl_Tabs_Del(DelegateMethod_Ctrl_Tabs_Del), myArray);
                                _Int_69 = _Int_Count;
                            }
                            if (_Int_Count > 0)
                            {
                                _Ctrl_Tabs _Ctrl = new _Ctrl_Tabs();
                                _Ctrl.Name = "_Ctrl69";
                                _Ctrl._Descripcion = "N.C. GENERADAS EN EL CIERRE DE CAJA ( " + _Int_Count.ToString() + " )";
                                _Ctrl._Formulario = "T3.Frm_Busqueda2";
                                _Ctrl._FormularioMdi = _Frm_MdiParent;
                                _Ctrl._Parametros = new object[] { 30 };
                                _Ctrl.Dock = DockStyle.Top;
                                myArray[0] = _Ctrl;
                                this.Invoke(new MyDelegate_Ctrl_Tabs(DelegateMethod_Ctrl_Tabs), myArray);
                                _Int_69 = _Int_Count;
                            }
                        }
                    }
                }
                //---------------------------------------------------------------------------------------------------------
                //---------------------TABS NÚMERO 70
                //---------------------------------------------------------------------------------------------------------
                _Str_expression = "ctabs = 70";
                _Drow_found = _Ds_FrmTabs.Tables[0].Select(_Str_expression);
                if (_Drow_found.Length > 0)
                {
                    if (myUtilidad._Mtd_ObtenerUsuarioFirma(Frm_Padre._Str_Use) == "1" & myUtilidad._Mtd_UsuarioProceso(Frm_Padre._Str_Use, "F_N2_AND_CXC"))
                    {
                        _Str_TabActual = "ANULACION DE N.D. DE CxC POR APROBAR";
                        _Int_Count = 0;
                        _Str_Sql = "SELECT count(*) FROM TNDANUL WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cactivo=0 AND cestatusfirma=1 AND cdelete=0";
                        _Ds_AuxTabs = _Mtd_GetDataSet(_Str_Sql);
                        if (Convert.ToString(_Ds_AuxTabs.Tables[0].Rows[0][0]) != "")
                        {
                            _Int_Count = Convert.ToInt32(_Ds_AuxTabs.Tables[0].Rows[0][0]);
                        }
                        if (_Int_Count != _Int_70)
                        {
                            object[] myArray = new object[1];
                            if (_Int_Count > _Int_70)
                            { _Bol_SwTimbre = true; }
                            if (_Pnl_Contenedor.Controls.Find("_Ctrl70", false).Length > 0)
                            {
                                myArray[0] = ((_Ctrl_Tabs)(_Pnl_Contenedor.Controls.Find("_Ctrl70", false)[0]));
                                this.Invoke(new MyDelegate_Ctrl_Tabs_Del(DelegateMethod_Ctrl_Tabs_Del), myArray);
                                _Int_70 = _Int_Count;
                            }
                            if (_Int_Count > 0)
                            {
                                _Ctrl_Tabs _Ctrl = new _Ctrl_Tabs();
                                _Ctrl.Name = "_Ctrl70";
                                _Ctrl._Descripcion = _Str_TabActual + "(" + _Int_Count.ToString() + ")";
                                _Ctrl._Formulario = "T3.Frm_NotaDebitoCxCAnul";
                                _Ctrl._FormularioMdi = _Frm_MdiParent;
                                _Ctrl._Parametros = new object[] { 1 };
                                _Ctrl.Dock = DockStyle.Top;
                                myArray[0] = _Ctrl;
                                this.Invoke(new MyDelegate_Ctrl_Tabs(DelegateMethod_Ctrl_Tabs), myArray);
                                _Int_70 = _Int_Count;
                            }
                        }
                    }
                }
                //---------------------------------------------------------------------------------------------------------
                //---------------------TABS NÚMERO 71
                //---------------------------------------------------------------------------------------------------------
                _Str_expression = "ctabs = 71";
                _Drow_found = _Ds_FrmTabs.Tables[0].Select(_Str_expression);
                if (_Drow_found.Length > 0)
                {
                    _Str_TabActual = "AJUSTE POR CONTEO DE INVENTARIO";
                    _Int_Count = 0;
                    _Str_Sql = "SELECT COUNT(DISTINCT id_conteohist) FROM TINVFISICOTEOHIST WHERE cajustado = 0 AND ccompany='" + Frm_Padre._Str_Comp + "'";
                    _Ds_AuxTabs = _Mtd_GetDataSet(_Str_Sql);
                    if (Convert.ToString(_Ds_AuxTabs.Tables[0].Rows[0][0]) != "")
                    {
                        _Int_Count = Convert.ToInt32(_Ds_AuxTabs.Tables[0].Rows[0][0]);
                    }
                    if (_Int_Count != _Int_71)
                    {
                        object[] myArray = new object[1];
                        if (_Int_Count > _Int_71)
                        { _Bol_SwTimbre = true; }
                        if (_Pnl_Contenedor.Controls.Find("_Ctrl71", false).Length > 0)
                        {
                            myArray[0] = ((_Ctrl_Tabs)(_Pnl_Contenedor.Controls.Find("_Ctrl71", false)[0]));
                            this.Invoke(new MyDelegate_Ctrl_Tabs_Del(DelegateMethod_Ctrl_Tabs_Del), myArray);
                            _Int_71 = _Int_Count;
                        }
                        if (_Int_Count > 0)
                        {
                            _Ctrl_Tabs _Ctrl = new _Ctrl_Tabs();
                            _Ctrl.Name = "_Ctrl71";
                            _Ctrl._Descripcion = _Str_TabActual + " ( " + _Int_Count.ToString() + " )";
                            _Ctrl._Formulario = "T3.Frm_Busqueda2";
                            _Ctrl._FormularioMdi = _Frm_MdiParent;
                            _Ctrl._Parametros = new object[] { 31 };
                            _Ctrl.Dock = DockStyle.Top;
                            myArray[0] = _Ctrl;
                            this.Invoke(new MyDelegate_Ctrl_Tabs(DelegateMethod_Ctrl_Tabs), myArray);
                            _Int_71 = _Int_Count;
                        }
                    }
                }
                //---------------------TABS NÚMERO 71
                //---------------------------------------------------------------------------------------------------------
                //---------------------TABS NÚMERO 72
                _Str_expression = "ctabs = 72";
                _Drow_found = _Ds_FrmTabs.Tables[0].Select(_Str_expression);
                if (_Drow_found.Length > 0)
                {
                    if (myUtilidad._Mtd_ObtenerUsuarioFirma(Frm_Padre._Str_Use) == "1" & myUtilidad._Mtd_UsuarioProceso(Frm_Padre._Str_Use, "F_N2_LIQUIDGUIA"))
                    {
                        _Str_TabActual = "GUÍAS POR APROBAR";
                        _Int_Count = 0;
                        _Str_Sql = "Select count(cguiadesp) from TGUIADESPACHOM AS TABLA where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and ((cestatusfirma=1)) AND (SELECT COUNT(cfactura) FROM TGUIADESPACHOD INNER JOIN TGUIADESPACHOM ON TGUIADESPACHOD.cgroupcomp = TGUIADESPACHOM.cgroupcomp AND TGUIADESPACHOD.cguiadesp = TGUIADESPACHOM.cguiadesp WHERE TGUIADESPACHOD.cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ((TGUIADESPACHOD.c_estatus='FIR' AND TGUIADESPACHOD.c_tipdevolparcial='0') OR (TGUIADESPACHOD.c_estatus='PAG' AND (TGUIADESPACHOD.c_cancelaciontot='0' OR TGUIADESPACHOD.c_cancelaciontot='3'))) AND TGUIADESPACHOM.cestatusfirma='1' AND TGUIADESPACHOD.cguiadesp=TABLA.cguiadesp AND NOT EXISTS(SELECT cfactura FROM TDEVVENTAM WHERE TDEVVENTAM.cgroupcomp=TGUIADESPACHOD.cgroupcomp AND TDEVVENTAM.ccompany=TGUIADESPACHOD.ccompany AND TDEVVENTAM.cfactura=TGUIADESPACHOD.cfactura))=0 and cliqguidespacho='0'";
                        _Ds_AuxTabs = _Mtd_GetDataSet(_Str_Sql);
                        if (Convert.ToString(_Ds_AuxTabs.Tables[0].Rows[0][0]) != "")
                        {
                            _Int_Count = Convert.ToInt32(_Ds_AuxTabs.Tables[0].Rows[0][0]);
                        }
                        if (_Int_Count != _Int_72)
                        {
                            object[] myArray = new object[1];
                            if (_Int_Count > _Int_72)
                            { _Bol_SwTimbre = true; }
                            if (_Pnl_Contenedor.Controls.Find("_Ctrl72", false).Length > 0)
                            {
                                myArray[0] = ((_Ctrl_Tabs)(_Pnl_Contenedor.Controls.Find("_Ctrl72", false)[0]));
                                this.Invoke(new MyDelegate_Ctrl_Tabs_Del(DelegateMethod_Ctrl_Tabs_Del), myArray);
                                _Int_72 = _Int_Count;
                            }
                            if (_Int_Count > 0)
                            {
                                _Ctrl_Tabs _Ctrl = new _Ctrl_Tabs();
                                _Ctrl.Name = "_Ctrl72";
                                _Ctrl._Descripcion = "GUÍAS POR APROBAR  ( " + _Int_Count.ToString() + " )";
                                _Ctrl._Formulario = "T3.Frm_GuiaDespacho";
                                _Ctrl._FormularioMdi = _Frm_MdiParent;
                                _Ctrl._Parametros = new object[] { 1 };
                                _Ctrl.Dock = DockStyle.Top;
                                myArray[0] = _Ctrl;
                                this.Invoke(new MyDelegate_Ctrl_Tabs(DelegateMethod_Ctrl_Tabs), myArray);
                                _Int_72 = _Int_Count;
                            }
                        }
                    }
                }
                //---------------------TABS NÚMERO 72
                //---------------------------------------------------------------------------------------------------------
                //---------------------------------------------------------------------------------------------------------
                //---------------------TABS NÚMERO 73
                _Str_expression = "ctabs = 73";
                _Drow_found = _Ds_FrmTabs.Tables[0].Select(_Str_expression);
                if (_Drow_found.Length > 0)
                {
                    _Str_TabActual = "DEVOLUCIONES EN DESPACHO";
                    _Int_Count = 0;
                    _Str_Sql = "SELECT CFACTURA FROM VST_FACTURADEVMAESTRATAB where ccompany='" + Frm_Padre._Str_Comp + "'";
                    _Ds_AuxTabs = _Mtd_GetDataSet(_Str_Sql);
                    //_Str_Sql = "Select count(*) from VST_FACTURADEVREPETIDAS where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and ccompany='" + Frm_Padre._Str_Comp + "' and ((cestatusfirma=1))";
                    //_Ds_AuxTabs = _Mtd_GetDataSet(_Str_Sql);
                    _Int_Count = _Ds_AuxTabs.Tables[0].Rows.Count;
                    if (_Int_Count != _Int_73)
                    {
                        object[] myArray = new object[1];
                        if (_Int_Count > _Int_73)
                        { _Bol_SwTimbre = true; }
                        if (_Pnl_Contenedor.Controls.Find("_Ctrl73", false).Length > 0)
                        {
                            myArray[0] = ((_Ctrl_Tabs)(_Pnl_Contenedor.Controls.Find("_Ctrl73", false)[0]));
                            this.Invoke(new MyDelegate_Ctrl_Tabs_Del(DelegateMethod_Ctrl_Tabs_Del), myArray);
                            _Int_73 = _Int_Count;
                        }
                        if (_Int_Count > 0)
                        {
                            _Ctrl_Tabs _Ctrl = new _Ctrl_Tabs();
                            _Ctrl.Name = "_Ctrl73";
                            _Ctrl._Descripcion = "DEVOLUCIONES EN DESPACHO  ( " + _Int_Count.ToString() + " )";
                            _Ctrl._Formulario = "T3.Frm_Busqueda2";
                            _Ctrl._FormularioMdi = _Frm_MdiParent;
                            _Ctrl._Parametros = new object[] { 41 };
                            _Ctrl.Dock = DockStyle.Top;
                            myArray[0] = _Ctrl;
                            this.Invoke(new MyDelegate_Ctrl_Tabs(DelegateMethod_Ctrl_Tabs), myArray);
                            _Int_73 = _Int_Count;
                        }
                    }
                }
                //---------------------TABS NÚMERO 73
                //---------------------------------------------------------------------------------------------------------
                //---------------------TABS NÚMERO 74
                _Str_expression = "ctabs = 74";
                _Drow_found = _Ds_FrmTabs.Tables[0].Select(_Str_expression);
                if (_Drow_found.Length > 0)
                {
                    _Str_TabActual = "PEDIDOS EN BACKORDER BLOQUEADO POR CRÉDITO";
                    _Int_Count = 0;
                    _Str_Sql = "SELECT CPEDIDO FROM VST_PEDIDOSBACKORDER where ccompany='" + Frm_Padre._Str_Comp + "'";
                    _Ds_AuxTabs = _Mtd_GetDataSet(_Str_Sql);
                    //_Str_Sql = "Select count(*) from VST_FACTURADEVREPETIDAS where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and ccompany='" + Frm_Padre._Str_Comp + "' and ((cestatusfirma=1))";
                    //_Ds_AuxTabs = _Mtd_GetDataSet(_Str_Sql);
                    _Int_Count = _Ds_AuxTabs.Tables[0].Rows.Count;
                    if (_Int_Count != _Int_74)
                    {
                        object[] myArray = new object[1];
                        if (_Int_Count > _Int_74)
                        { _Bol_SwTimbre = true; }
                        if (_Pnl_Contenedor.Controls.Find("_Ctrl74", false).Length > 0)
                        {
                            myArray[0] = ((_Ctrl_Tabs)(_Pnl_Contenedor.Controls.Find("_Ctrl74", false)[0]));
                            this.Invoke(new MyDelegate_Ctrl_Tabs_Del(DelegateMethod_Ctrl_Tabs_Del), myArray);
                            _Int_74 = _Int_Count;
                        }
                        if (_Int_Count > 0)
                        {
                            _Ctrl_Tabs _Ctrl = new _Ctrl_Tabs();
                            _Ctrl.Name = "_Ctrl74";
                            _Ctrl._Descripcion = "BACKORDER BLOQUEADOS POR CRÉDITO  ( " + _Int_Count.ToString() + " )";
                            _Ctrl._Formulario = "T3.Frm_Busqueda2";
                            _Ctrl._FormularioMdi = _Frm_MdiParent;
                            _Ctrl._Parametros = new object[] { 43 };
                            _Ctrl.Dock = DockStyle.Top;                  


                            myArray[0] = _Ctrl;
                            this.Invoke(new MyDelegate_Ctrl_Tabs(DelegateMethod_Ctrl_Tabs), myArray);
                            _Int_74 = _Int_Count;
                        }
                    }
                }
                //---------------------TABS NÚMERO 74
                //---------------------------------------------------------------------------------------------------------
                //---------------------TABS NÚMERO 75
                _Str_expression = "ctabs = 75";
                _Drow_found = _Ds_FrmTabs.Tables[0].Select(_Str_expression);
                if (_Drow_found.Length > 0)
                {
                    if (myUtilidad._Mtd_ObtenerUsuarioFirma(Frm_Padre._Str_Use) == "1" & myUtilidad._Mtd_UsuarioProceso(Frm_Padre._Str_Use, "F_N2_ND_CXP"))
                    {
                        _Str_TabActual = "N.D. POR APROBAR A PROVEEDORES";
                        _Int_Count = 0;
                        _Str_Sql = "SELECT count(cidnotadebitocxptemp) FROM TNOTADEBITOCPTEMP WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and ccompany='" + Frm_Padre._Str_Comp + "' AND cestatusfirma=1";
                        _Ds_AuxTabs = _Mtd_GetDataSet(_Str_Sql);
                        if (Convert.ToString(_Ds_AuxTabs.Tables[0].Rows[0][0]) != "")
                        {
                            _Int_Count = Convert.ToInt32(_Ds_AuxTabs.Tables[0].Rows[0][0]);
                        }
                        if (_Int_Count != _Int_75)
                        {
                            object[] myArray = new object[1];
                            if (_Int_Count > _Int_75)
                            { _Bol_SwTimbre = true; }
                            if (_Pnl_Contenedor.Controls.Find("_Ctrl75", false).Length > 0)
                            {
                                myArray[0] = ((_Ctrl_Tabs)(_Pnl_Contenedor.Controls.Find("_Ctrl75", false)[0]));
                                this.Invoke(new MyDelegate_Ctrl_Tabs_Del(DelegateMethod_Ctrl_Tabs_Del), myArray);
                                _Int_75 = _Int_Count;
                            }
                            if (_Int_Count > 0)
                            {
                                _Ctrl_Tabs _Ctrl = new _Ctrl_Tabs();
                                _Ctrl.Name = "_Ctrl75";
                                _Ctrl._Descripcion = _Str_TabActual + "(" + _Int_Count.ToString() + ")";
                                _Ctrl._Formulario = "T3.Frm_ImpresionLote";
                                _Ctrl._FormularioMdi = _Frm_MdiParent;
                                _Ctrl._Parametros = new object[] { 10 };
                                _Ctrl.Dock = DockStyle.Top;
                                myArray[0] = _Ctrl;
                                this.Invoke(new MyDelegate_Ctrl_Tabs(DelegateMethod_Ctrl_Tabs), myArray);
                                _Int_75 = _Int_Count;
                            }
                        }
                    }
                }
                //---------------------TABS NÚMERO 75
                //---------------------------------------------------------------------------------------------------------
                //---------------------TABS NÚMERO 76
                _Str_expression = "ctabs = 76";
                _Drow_found = _Ds_FrmTabs.Tables[0].Select(_Str_expression);
                if (_Drow_found.Length > 0)
                {
                    _Str_TabActual = "ZONAS SIN CUOTAS";
                    _Int_Count = 0;
                    _Str_Sql = "SELECT COUNT(*) FROM VST_ZONASSINCUOTAS WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND NOT EXISTS(SELECT c_zona from TCUOTAVTA WHERE TCUOTAVTA.ccompany=VST_ZONASSINCUOTAS.ccompany AND TCUOTAVTA.c_zona=VST_ZONASSINCUOTAS.c_zona AND canocuota='" + Clases._Cls_ProcesosCont._Mtd_ContableAno(_G_Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate())) + "' AND cmescuota='" + Clases._Cls_ProcesosCont._Mtd_ContableMes(_G_Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate())) + "')";
                    string _Str_Param1 = " AND NOT EXISTS(SELECT c_zona from TCUOTAVTA WHERE TCUOTAVTA.ccompany=VST_ZONASSINCUOTAS.ccompany AND TCUOTAVTA.c_zona=VST_ZONASSINCUOTAS.c_zona AND canocuota='" + Clases._Cls_ProcesosCont._Mtd_ContableAno(_G_Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate())) + "' AND cmescuota='" + Clases._Cls_ProcesosCont._Mtd_ContableMes(_G_Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate())) + "')";
                    _Ds_AuxTabs = _Mtd_GetDataSet(_Str_Sql);
                    if (Convert.ToString(_Ds_AuxTabs.Tables[0].Rows[0][0]) != "")
                    {
                        _Int_Count = Convert.ToInt32(_Ds_AuxTabs.Tables[0].Rows[0][0]);
                    }
                    if (_Int_Count != _Int_76)
                    {
                        object[] myArray = new object[1];
                        if (_Int_Count > _Int_76)
                        { _Bol_SwTimbre = true; }
                        if (_Pnl_Contenedor.Controls.Find("_Ctrl76", false).Length > 0)
                        {
                            myArray[0] = ((_Ctrl_Tabs)(_Pnl_Contenedor.Controls.Find("_Ctrl76", false)[0]));
                            this.Invoke(new MyDelegate_Ctrl_Tabs_Del(DelegateMethod_Ctrl_Tabs_Del), myArray);
                            _Int_76 = _Int_Count;
                        }
                        if (_Int_Count > 0)
                        {
                            _Ctrl_Tabs _Ctrl = new _Ctrl_Tabs();
                            _Ctrl.Name = "_Ctrl76";
                            _Ctrl._Descripcion = _Str_TabActual + "(" + _Int_Count.ToString() + ")";
                            _Ctrl._Formulario = "T3.Frm_Busqueda2";
                            _Ctrl._FormularioMdi = _Frm_MdiParent;
                            _Ctrl._Parametros = new object[] { 44, _Str_Param1 };
                            _Ctrl.Dock = DockStyle.Top;
                            myArray[0] = _Ctrl;
                            this.Invoke(new MyDelegate_Ctrl_Tabs(DelegateMethod_Ctrl_Tabs), myArray);
                            _Int_76 = _Int_Count;
                        }
                    }
                }
                //---------------------TABS NÚMERO 76
                //---------------------------------------------------------------------------------------------------------
                //---------------------TABS NÚMERO 77
                _Str_expression = "ctabs = 77";
                _Drow_found = _Ds_FrmTabs.Tables[0].Select(_Str_expression);
                if (_Drow_found.Length > 0)
                {
                    if (myUtilidad._Mtd_ObtenerUsuarioFirma(Frm_Padre._Str_Use) == "1" & myUtilidad._Mtd_UsuarioProceso(Frm_Padre._Str_Use, "F_N1_COMPROBC"))
                    {
                        _Str_TabActual = "COMPROBANTES INCOMPLETOS";//Este tabs es para el usuario que carga los comprobantes
                        _Int_Count = 0;
                        _Str_Sql = "SELECT count(*) FROM TCOMPROBANC WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cstatus='0' AND csistema='0' AND ((ccuadrado='0' AND cestatusfirma='1') OR cestatusfirma='4')";//4 es cuando el contador devuelve el comprobante al que lo cargó para que lo modifique. Esto sucede cuando el contador rechaza el comprobante.
                        _Ds_AuxTabs = _Mtd_GetDataSet(_Str_Sql);
                        if (Convert.ToString(_Ds_AuxTabs.Tables[0].Rows[0][0]) != "")
                        {
                            _Int_Count = Convert.ToInt32(_Ds_AuxTabs.Tables[0].Rows[0][0]);
                        }
                        if (_Int_Count != _Int_77)
                        {
                            object[] myArray = new object[1];
                            if (_Int_Count > _Int_77)
                            { _Bol_SwTimbre = true; }
                            if (_Pnl_Contenedor.Controls.Find("_Ctrl77", false).Length > 0)
                            {
                                myArray[0] = ((_Ctrl_Tabs)(_Pnl_Contenedor.Controls.Find("_Ctrl77", false)[0]));
                                this.Invoke(new MyDelegate_Ctrl_Tabs_Del(DelegateMethod_Ctrl_Tabs_Del), myArray);
                                _Int_77 = _Int_Count;
                            }
                            if (_Int_Count > 0)
                            {
                                _Ctrl_Tabs _Ctrl = new _Ctrl_Tabs();
                                _Ctrl.Name = "_Ctrl77";
                                _Ctrl._Descripcion = _Str_TabActual + "(" + _Int_Count.ToString() + ")";
                                _Ctrl._Formulario = "T3.Frm_Busqueda2";
                                _Ctrl._FormularioMdi = _Frm_MdiParent;
                                _Ctrl._Parametros = new object[] { 46 };
                                _Ctrl.Dock = DockStyle.Top;
                                myArray[0] = _Ctrl;
                                this.Invoke(new MyDelegate_Ctrl_Tabs(DelegateMethod_Ctrl_Tabs), myArray);
                                _Int_77 = _Int_Count;
                            }
                        }
                    }
                }
                //---------------------TABS NÚMERO 77
                //---------------------------------------------------------------------------------------------------------
                //---------------------TABS NÚMERO 78
                _Str_expression = "ctabs = 78";
                _Drow_found = _Ds_FrmTabs.Tables[0].Select(_Str_expression);
                if (_Drow_found.Length > 0)
                {
                    if (myUtilidad._Mtd_ObtenerUsuarioFirma(Frm_Padre._Str_Use) == "1" & myUtilidad._Mtd_UsuarioProceso(Frm_Padre._Str_Use, "F_N2_COMPROBC"))
                    {
                        _Str_TabActual = "COMPROBANTES INCOMPLETOS";//Este tabs es para el usuario que aprueba los comprobantes
                        _Int_Count = 0;
                        _Str_Sql = "SELECT count(*) FROM TCOMPROBANC WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cstatus='0' AND csistema='0' AND ccuadrado='0' AND cestatusfirma='2'";
                        _Ds_AuxTabs = _Mtd_GetDataSet(_Str_Sql);
                        if (Convert.ToString(_Ds_AuxTabs.Tables[0].Rows[0][0]) != "")
                        {
                            _Int_Count = Convert.ToInt32(_Ds_AuxTabs.Tables[0].Rows[0][0]);
                        }
                        if (_Int_Count != _Int_78)
                        {
                            object[] myArray = new object[1];
                            if (_Int_Count > _Int_78)
                            { _Bol_SwTimbre = true; }
                            if (_Pnl_Contenedor.Controls.Find("_Ctrl78", false).Length > 0)
                            {
                                myArray[0] = ((_Ctrl_Tabs)(_Pnl_Contenedor.Controls.Find("_Ctrl78", false)[0]));
                                this.Invoke(new MyDelegate_Ctrl_Tabs_Del(DelegateMethod_Ctrl_Tabs_Del), myArray);
                                _Int_78 = _Int_Count;
                            }
                            if (_Int_Count > 0)
                            {
                                _Ctrl_Tabs _Ctrl = new _Ctrl_Tabs();
                                _Ctrl.Name = "_Ctrl78";
                                _Ctrl._Descripcion = _Str_TabActual + "(" + _Int_Count.ToString() + ")";
                                _Ctrl._Formulario = "T3.Frm_Busqueda2";
                                _Ctrl._FormularioMdi = _Frm_MdiParent;
                                _Ctrl._Parametros = new object[] { 47 };
                                _Ctrl.Dock = DockStyle.Top;
                                myArray[0] = _Ctrl;
                                this.Invoke(new MyDelegate_Ctrl_Tabs(DelegateMethod_Ctrl_Tabs), myArray);
                                _Int_78 = _Int_Count;
                            }
                        }
                    }
                }
                //---------------------TABS NÚMERO 78
                //---------------------------------------------------------------------------------------------------------
                //---------------------TABS NÚMERO 79
                _Str_expression = "ctabs = 79";
                _Drow_found = _Ds_FrmTabs.Tables[0].Select(_Str_expression);
                if (_Drow_found.Length > 0)
                {
                    if (myUtilidad._Mtd_ObtenerUsuarioFirma(Frm_Padre._Str_Use) == "1" & myUtilidad._Mtd_UsuarioProceso(Frm_Padre._Str_Use, "F_N2_COMPROBC"))
                    {
                        _Str_TabActual = "COMPROBANTES POR APROBAR";
                        _Int_Count = 0;
                        _Str_Sql = "SELECT count(*) FROM TCOMPROBANC WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cstatus='0' AND csistema='0' AND ccuadrado='1' AND (cestatusfirma='1' OR cestatusfirma='2')";
                        _Ds_AuxTabs = _Mtd_GetDataSet(_Str_Sql);
                        if (Convert.ToString(_Ds_AuxTabs.Tables[0].Rows[0][0]) != "")
                        {
                            _Int_Count = Convert.ToInt32(_Ds_AuxTabs.Tables[0].Rows[0][0]);
                        }
                        if (_Int_Count != _Int_79)
                        {
                            object[] myArray = new object[1];
                            if (_Int_Count > _Int_79)
                            { _Bol_SwTimbre = true; }
                            if (_Pnl_Contenedor.Controls.Find("_Ctrl79", false).Length > 0)
                            {
                                myArray[0] = ((_Ctrl_Tabs)(_Pnl_Contenedor.Controls.Find("_Ctrl79", false)[0]));
                                this.Invoke(new MyDelegate_Ctrl_Tabs_Del(DelegateMethod_Ctrl_Tabs_Del), myArray);
                                _Int_79 = _Int_Count;
                            }
                            if (_Int_Count > 0)
                            {
                                _Ctrl_Tabs _Ctrl = new _Ctrl_Tabs();
                                _Ctrl.Name = "_Ctrl79";
                                _Ctrl._Descripcion = _Str_TabActual + "(" + _Int_Count.ToString() + ")";
                                _Ctrl._Formulario = "T3.Frm_Busqueda2";
                                _Ctrl._FormularioMdi = _Frm_MdiParent;
                                _Ctrl._Parametros = new object[] { 48 };
                                _Ctrl.Dock = DockStyle.Top;
                                myArray[0] = _Ctrl;
                                this.Invoke(new MyDelegate_Ctrl_Tabs(DelegateMethod_Ctrl_Tabs), myArray);
                                _Int_79 = _Int_Count;
                            }
                        }
                    }
                }
                //---------------------TABS NÚMERO 79
                //---------------------------------------------------------------------------------------------------------
                //---------------------TABS NÚMERO 80
                try
                {
                    _Str_expression = "ctabs = 80";
                    _Drow_found = _Ds_FrmTabs.Tables[0].Select(_Str_expression);
                    if (_Drow_found.Length > 0)
                    {
                        if (myUtilidad._Mtd_ObtenerUsuarioFirma(Frm_Padre._Str_Use) == "1" & myUtilidad._Mtd_UsuarioProceso(Frm_Padre._Str_Use, "F_CIERRE_MESCONTA"))
                        {
                            _Str_TabActual = "CIERRE CONTABLE PENDIENTE";
                            _Int_Count = 0;
                            _Str_Sql = "SELECT COUNT(*) FROM TMESCONTABLE WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND ccerrado='0' AND creabierto='0' AND convert(datetime,'1/" + Clases._Cls_ProcesosCont._Mtd_ContableMes(_G_Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate())) + "/" + Clases._Cls_ProcesosCont._Mtd_ContableAno(_G_Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate())) + "')>convert(datetime,'1/'+ convert(varchar,cmontacco)+'/'+convert(varchar,cyearacco))";
                            //_Str_Sql = "SELECT COUNT(*) FROM TMESCONTABLE WHERE ccerrado='0' AND cmontacco<'" + Clases._Cls_ProcesosCont._Mtd_ContableMes(_G_Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate())) + "'";
                            _Ds_AuxTabs = _Mtd_GetDataSet(_Str_Sql);
                            if (Convert.ToString(_Ds_AuxTabs.Tables[0].Rows[0][0]) != "")
                            {
                                _Int_Count = Convert.ToInt32(_Ds_AuxTabs.Tables[0].Rows[0][0]);
                            }
                            if (_Int_Count != _Int_80)
                            {
                                object[] myArray = new object[1];
                                if (_Int_Count > _Int_80)
                                { _Bol_SwTimbre = true; }
                                if (_Pnl_Contenedor.Controls.Find("_Ctrl80", false).Length > 0)
                                {
                                    myArray[0] = ((_Ctrl_Tabs)(_Pnl_Contenedor.Controls.Find("_Ctrl80", false)[0]));
                                    this.Invoke(new MyDelegate_Ctrl_Tabs_Del(DelegateMethod_Ctrl_Tabs_Del), myArray);
                                    _Int_80 = _Int_Count;
                                }
                                if (_Int_Count > 0)
                                {
                                    _Ctrl_Tabs _Ctrl = new _Ctrl_Tabs();
                                    _Ctrl.Name = "_Ctrl80";
                                    _Ctrl._Descripcion = _Str_TabActual + "(" + _Int_Count.ToString() + ")";
                                    _Ctrl._Formulario = "T3.Frm_Busqueda2";
                                    _Ctrl._FormularioMdi = _Frm_MdiParent;
                                    _Ctrl._Parametros = new object[] { 49 };
                                    _Ctrl.Dock = DockStyle.Top;
                                    myArray[0] = _Ctrl;
                                    this.Invoke(new MyDelegate_Ctrl_Tabs(DelegateMethod_Ctrl_Tabs), myArray);
                                    _Int_80 = _Int_Count;
                                }
                            }
                        }
                    }
                }
                catch { }
                //---------------------TABS NÚMERO 80
                //---------------------------------------------------------------------------------------------------------
                //---------------------TABS NÚMERO 81
                _Str_expression = "ctabs = 81";
                _Drow_found = _Ds_FrmTabs.Tables[0].Select(_Str_expression);
                if (_Drow_found.Length > 0)
                {
                    if (myUtilidad._Mtd_ObtenerUsuarioFirma(Frm_Padre._Str_Use) == "1" & myUtilidad._Mtd_UsuarioProceso(Frm_Padre._Str_Use, "F_N2_NC_CXP"))
                    {
                        _Str_TabActual = "N.C. POR APROBAR A PROVEEDORES";
                        _Int_Count = 0;
                        _Str_Sql = "SELECT count(cidnotacreditocxptemp) FROM TNOTACREDICPTEMP WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and ccompany='" + Frm_Padre._Str_Comp + "' AND cestatusfirma=1";
                        _Ds_AuxTabs = _Mtd_GetDataSet(_Str_Sql);
                        if (Convert.ToString(_Ds_AuxTabs.Tables[0].Rows[0][0]) != "")
                        {
                            _Int_Count = Convert.ToInt32(_Ds_AuxTabs.Tables[0].Rows[0][0]);
                        }
                        if (_Int_Count != _Int_81)
                        {
                            object[] myArray = new object[1];
                            if (_Int_Count > _Int_81)
                            { _Bol_SwTimbre = true; }
                            if (_Pnl_Contenedor.Controls.Find("_Ctrl81", false).Length > 0)
                            {
                                myArray[0] = ((_Ctrl_Tabs)(_Pnl_Contenedor.Controls.Find("_Ctrl81", false)[0]));
                                this.Invoke(new MyDelegate_Ctrl_Tabs_Del(DelegateMethod_Ctrl_Tabs_Del), myArray);
                                _Int_81 = _Int_Count;
                            }
                            if (_Int_Count > 0)
                            {
                                _Ctrl_Tabs _Ctrl = new _Ctrl_Tabs();
                                _Ctrl.Name = "_Ctrl81";
                                _Ctrl._Descripcion = _Str_TabActual + "(" + _Int_Count.ToString() + ")";
                                _Ctrl._Formulario = "T3.Frm_ImpresionLote";
                                _Ctrl._FormularioMdi = _Frm_MdiParent;
                                _Ctrl._Parametros = new object[] { 11 };
                                _Ctrl.Dock = DockStyle.Top;
                                myArray[0] = _Ctrl;
                                this.Invoke(new MyDelegate_Ctrl_Tabs(DelegateMethod_Ctrl_Tabs), myArray);
                                _Int_81 = _Int_Count;
                            }
                        }
                    }
                }
                //---------------------TABS NÚMERO 81
                //---------------------------------------------------------------------------------------------------------
                //---------------------TABS NÚMERO 82
                _Str_expression = "ctabs = 82";
                _Drow_found = _Ds_FrmTabs.Tables[0].Select(_Str_expression);
                if (_Drow_found.Length > 0)
                {
                    if (myUtilidad._Mtd_ObtenerUsuarioFirma(Frm_Padre._Str_Use) == "1" & myUtilidad._Mtd_UsuarioProceso(Frm_Padre._Str_Use, "F_N2_ANULFACTURACXP"))
                    {
                        _Str_TabActual = "FACTURAS ANULADAS POR APROBAR CxP ";
                        _Int_Count = 0;
                        _Str_Sql = "SELECT COUNT(*) FROM VST_FACTURA_ANUL_CXP INNER JOIN TCONFIGCXP ON VST_FACTURA_ANUL_CXP.ccompany=TCONFIGCXP.ccompany AND VST_FACTURA_ANUL_CXP.ctipodocument=TCONFIGCXP.ctipdocfact WHERE VST_FACTURA_ANUL_CXP.cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND VST_FACTURA_ANUL_CXP.ccompany='" + Frm_Padre._Str_Comp + "' AND cestatusfirma=1 AND (cidcomprobanul<>'0' AND NOT cidcomprobanul IS NULL)";
                        _Ds_AuxTabs = _Mtd_GetDataSet(_Str_Sql);
                        if (Convert.ToString(_Ds_AuxTabs.Tables[0].Rows[0][0]) != "")
                        {
                            _Int_Count = Convert.ToInt32(_Ds_AuxTabs.Tables[0].Rows[0][0]);
                        }
                        if (_Int_Count != _Int_82)
                        {
                            object[] myArray = new object[1];
                            if (_Int_Count > _Int_82)
                            { _Bol_SwTimbre = true; }
                            if (_Pnl_Contenedor.Controls.Find("_Ctrl82", false).Length > 0)
                            {
                                myArray[0] = ((_Ctrl_Tabs)(_Pnl_Contenedor.Controls.Find("_Ctrl82", false)[0]));
                                this.Invoke(new MyDelegate_Ctrl_Tabs_Del(DelegateMethod_Ctrl_Tabs_Del), myArray);
                                _Int_82 = _Int_Count;
                            }
                            if (_Int_Count > 0)
                            {
                                _Ctrl_Tabs _Ctrl = new _Ctrl_Tabs();
                                _Ctrl.Name = "_Ctrl82";
                                _Ctrl._Descripcion = _Str_TabActual + "(" + _Int_Count.ToString() + ")";
                                _Ctrl._Formulario = "T3.Frm_AnulacionFacturaCxP";
                                _Ctrl._FormularioMdi = _Frm_MdiParent;
                                _Ctrl._Parametros = new object[] { "FACT", true };
                                _Ctrl.Dock = DockStyle.Top;
                                myArray[0] = _Ctrl;
                                this.Invoke(new MyDelegate_Ctrl_Tabs(DelegateMethod_Ctrl_Tabs), myArray);
                                _Int_82 = _Int_Count;
                            }
                        }
                    }
                }
                //---------------------TABS NÚMERO 82
                //---------------------------------------------------------------------------------------------------------
                //---------------------TABS NÚMERO 83
                _Str_expression = "ctabs = 83";
                _Drow_found = _Ds_FrmTabs.Tables[0].Select(_Str_expression);
                if (_Drow_found.Length > 0)
                {
                    _Str_TabActual = "N.C. EXCEDENTE POR IMPRIMIR";
                    _Int_Count = 0;
                    _Str_Sql = "SELECT count(*) from TNOTACREDICC where cdelete='0' and ccompany='" + Frm_Padre._Str_Comp + "' and cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and cexedentecobro='1' and cimpresa='0' and cactivo='0' AND cestatusfirma=2 AND (cidnotrecepc=0 or cidnotrecepc is null)";
                    _Ds_AuxTabs = _Mtd_GetDataSet(_Str_Sql);
                    if (Convert.ToString(_Ds_AuxTabs.Tables[0].Rows[0][0]) != "")
                    {
                        _Int_Count = Convert.ToInt32(_Ds_AuxTabs.Tables[0].Rows[0][0]);
                    }
                    if (_Int_Count != _Int_83)
                    {
                        object[] myArray = new object[1];
                        if (_Int_Count > _Int_83)
                        { _Bol_SwTimbre = true; }
                        if (_Pnl_Contenedor.Controls.Find("_Ctrl83", false).Length > 0)
                        {
                            myArray[0] = ((_Ctrl_Tabs)(_Pnl_Contenedor.Controls.Find("_Ctrl83", false)[0]));
                            this.Invoke(new MyDelegate_Ctrl_Tabs_Del(DelegateMethod_Ctrl_Tabs_Del), myArray);
                            _Int_83 = _Int_Count;
                        }
                        if (_Int_Count > 0)
                        {
                            _Ctrl_Tabs _Ctrl = new _Ctrl_Tabs();
                            _Ctrl.Name = "_Ctrl83";
                            _Ctrl._Descripcion = _Str_TabActual + "(" + _Int_Count.ToString() + ")";
                            _Ctrl._Formulario = "T3.Frm_Busqueda2";
                            _Ctrl._FormularioMdi = _Frm_MdiParent;
                            _Ctrl._Parametros = new object[] { 53 };
                            _Ctrl.Dock = DockStyle.Top;
                            myArray[0] = _Ctrl;
                            this.Invoke(new MyDelegate_Ctrl_Tabs(DelegateMethod_Ctrl_Tabs), myArray);
                            _Int_83 = _Int_Count;
                        }
                    }
                }
                //---------------------TABS NÚMERO 83
                //---------------------------------------------------------------------------------------------------------
                //---------------------TABS NÚMERO 84
                _Str_expression = "ctabs = 84";
                _Drow_found = _Ds_FrmTabs.Tables[0].Select(_Str_expression);
                if (_Drow_found.Length > 0)
                {
                    _Str_TabActual = "CLIENTES SIN LÍMITE DE CRÉDITO";
                    _Int_Count = 0;
                    _Str_Sql = "SELECT COUNT(*) FROM TCLIENTE WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND cdelete='0' and c_activo='1' and c_limt_credit='0'";
                    _Ds_AuxTabs = _Mtd_GetDataSet(_Str_Sql);
                    if (Convert.ToString(_Ds_AuxTabs.Tables[0].Rows[0][0]) != "")
                    {
                        _Int_Count = Convert.ToInt32(_Ds_AuxTabs.Tables[0].Rows[0][0]);
                    }
                    if (_Int_Count != _Int_84)
                    {
                        object[] myArray = new object[1];
                        if (_Int_Count > _Int_84)
                        { _Bol_SwTimbre = true; }
                        if (_Pnl_Contenedor.Controls.Find("_Ctrl84", false).Length > 0)
                        {
                            myArray[0] = ((_Ctrl_Tabs)(_Pnl_Contenedor.Controls.Find("_Ctrl84", false)[0]));
                            this.Invoke(new MyDelegate_Ctrl_Tabs_Del(DelegateMethod_Ctrl_Tabs_Del), myArray);
                            _Int_84 = _Int_Count;
                        }
                        if (_Int_Count > 0)
                        {
                            _Ctrl_Tabs _Ctrl = new _Ctrl_Tabs();
                            _Ctrl.Name = "_Ctrl84";
                            _Ctrl._Descripcion = _Str_TabActual + "(" + _Int_Count.ToString() + ")";
                            _Ctrl._Formulario = "T3.Frm_Clientes_VC_1";
                            _Ctrl._FormularioMdi = _Frm_MdiParent;
                            _Ctrl._Parametros = new object[] { true };
                            _Ctrl.Dock = DockStyle.Top;
                            myArray[0] = _Ctrl;
                            this.Invoke(new MyDelegate_Ctrl_Tabs(DelegateMethod_Ctrl_Tabs), myArray);
                            _Int_84 = _Int_Count;
                        }
                    }
                }
                //---------------------TABS NÚMERO 84
                //---------------------------------------------------------------------------------------------------------
                //---------------------TABS NÚMERO 85
                
                
                _Str_expression = "ctabs = 85";
                _Drow_found = _Ds_FrmTabs.Tables[0].Select(_Str_expression);
                if (_Drow_found.Length > 0)
                {
                    if (myUtilidad._Mtd_ObtenerUsuarioFirma(Frm_Padre._Str_Use) == "1" & myUtilidad._Mtd_UsuarioProceso(Frm_Padre._Str_Use, "F_PREC_SIN_TRANS"))
                    {
                        _Str_TabActual = "PRECARGAS SIN TRANSPORTE ASIGNADO";
                        _Int_Count = 0;
                        _Str_Sql = "SELECT COUNT(*) FROM TPRECARGAM WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND (cimprimeprecarga='1' and cverificascanpalm='1' and cimprimefactura='0' and cimprimeguiadesp='0' AND cplaca='0' AND ccedula='0')";
                        _Ds_AuxTabs = _Mtd_GetDataSet(_Str_Sql);
                        if (Convert.ToString(_Ds_AuxTabs.Tables[0].Rows[0][0]) != "")
                        {
                            _Int_Count = Convert.ToInt32(_Ds_AuxTabs.Tables[0].Rows[0][0]);
                        }
                        if (_Int_Count != _Int_85)
                        {
                            object[] myArray = new object[1];
                            if (_Int_Count > _Int_85)
                            { _Bol_SwTimbre = true; }
                            if (_Pnl_Contenedor.Controls.Find("_Ctrl85", false).Length > 0)
                            {
                                myArray[0] = ((_Ctrl_Tabs)(_Pnl_Contenedor.Controls.Find("_Ctrl85", false)[0]));
                                this.Invoke(new MyDelegate_Ctrl_Tabs_Del(DelegateMethod_Ctrl_Tabs_Del), myArray);
                                _Int_85 = _Int_Count;
                            }
                            if (_Int_Count > 0)
                            {
                                _Ctrl_Tabs _Ctrl = new _Ctrl_Tabs();
                                _Ctrl.Name = "_Ctrl85";
                                _Ctrl._Descripcion = _Str_TabActual + "(" + _Int_Count.ToString() + ")";
                                _Ctrl._Formulario = "T3.Frm_PrecargaSinTransp";
                                _Ctrl._FormularioMdi = _Frm_MdiParent;
                                _Ctrl._Parametros = null;
                                _Ctrl.Dock = DockStyle.Top;
                                myArray[0] = _Ctrl;
                                this.Invoke(new MyDelegate_Ctrl_Tabs(DelegateMethod_Ctrl_Tabs), myArray);
                                _Int_85 = _Int_Count;
                            }
                        }
                    }
                }
                //---------------------TABS NÚMERO 85
                //---------------------------------------------------------------------------------------------------------
                //---------------------TABS NÚMERO 86
                _Str_expression = "ctabs = 86";
                _Drow_found = _Ds_FrmTabs.Tables[0].Select(_Str_expression);
                if (_Drow_found.Length > 0)
                {
                    if (myUtilidad._Mtd_ObtenerUsuarioFirma(Frm_Padre._Str_Use) == "1" & myUtilidad._Mtd_UsuarioProceso(Frm_Padre._Str_Use, "F_GUIA_CON_DEVOL"))
                    {
                        _Str_TabActual = "GUÍA CON DEVOLUCIONES PARCIALES";
                        _Int_Count = 0;
                        _Str_Sql = "SELECT COUNT(cfactura) FROM TGUIADESPACHOD INNER JOIN TGUIADESPACHOM ON TGUIADESPACHOD.cgroupcomp = TGUIADESPACHOM.cgroupcomp  AND TGUIADESPACHOD.cguiadesp = TGUIADESPACHOM.cguiadesp WHERE TGUIADESPACHOD.cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND TGUIADESPACHOD.ccompany='" + Frm_Padre._Str_Comp + "' AND ((TGUIADESPACHOD.c_estatus='FIR' AND TGUIADESPACHOD.c_tipdevolparcial='0') OR (TGUIADESPACHOD.c_estatus='PAG' AND (TGUIADESPACHOD.c_cancelaciontot='0' OR TGUIADESPACHOD.c_cancelaciontot='3'))) AND TGUIADESPACHOM.cestatusfirma='1' AND NOT EXISTS(SELECT cfactura FROM TDEVVENTAM WHERE TDEVVENTAM.cgroupcomp=TGUIADESPACHOD.cgroupcomp AND TDEVVENTAM.ccompany=TGUIADESPACHOD.ccompany AND TDEVVENTAM.cfactura=TGUIADESPACHOD.cfactura)";
                        _Ds_AuxTabs = _Mtd_GetDataSet(_Str_Sql);
                        if (Convert.ToString(_Ds_AuxTabs.Tables[0].Rows[0][0]) != "")
                        {
                            _Int_Count = Convert.ToInt32(_Ds_AuxTabs.Tables[0].Rows[0][0]);
                        }
                        if (_Int_Count != _Int_86)
                        {
                            object[] myArray = new object[1];
                            if (_Int_Count > _Int_86)
                            { _Bol_SwTimbre = true; }
                            if (_Pnl_Contenedor.Controls.Find("_Ctrl86", false).Length > 0)
                            {
                                myArray[0] = ((_Ctrl_Tabs)(_Pnl_Contenedor.Controls.Find("_Ctrl86", false)[0]));
                                this.Invoke(new MyDelegate_Ctrl_Tabs_Del(DelegateMethod_Ctrl_Tabs_Del), myArray);
                                _Int_86 = _Int_Count;
                            }
                            if (_Int_Count > 0)
                            {
                                _Ctrl_Tabs _Ctrl = new _Ctrl_Tabs();
                                _Ctrl.Name = "_Ctrl86";
                                _Ctrl._Descripcion = _Str_TabActual + "(" + _Int_Count.ToString() + ")";
                                _Ctrl._Formulario = "T3.Frm_Busqueda2";
                                _Ctrl._FormularioMdi = _Frm_MdiParent;
                                _Ctrl._Parametros = new object[] { 58 };
                                _Ctrl.Dock = DockStyle.Top;
                                myArray[0] = _Ctrl;
                                this.Invoke(new MyDelegate_Ctrl_Tabs(DelegateMethod_Ctrl_Tabs), myArray);
                                _Int_86 = _Int_Count;
                            }
                        }
                    }
                }
                //---------------------TABS NÚMERO 86
                //---------------------------------------------------------------------------------------------------------
                //---------------------TABS NÚMERO 87
                _Str_expression = "ctabs = 87";
                _Drow_found = _Ds_FrmTabs.Tables[0].Select(_Str_expression);
                if (_Drow_found.Length > 0)
                {
                    _Str_TabActual = "COMPROBANTES POR ACTUALIZAR";
                    _Int_Count = 0;
                    _Str_Sql = "SELECT COUNT(CIDCOMPROB) FROM TCOMPROBANC INNER JOIN TMESCONTABLE ON TCOMPROBANC.cyearacco = TMESCONTABLE.cyearacco AND " +
                               "TCOMPROBANC.cmontacco = TMESCONTABLE.cmontacco AND TCOMPROBANC.ccompany = TMESCONTABLE.ccompany  WHERE TCOMPROBANC.ccompany='" + Frm_Padre._Str_Comp + "' AND TCOMPROBANC.cstatus<>'9' AND TMESCONTABLE.ccerrado='0' AND TCOMPROBANC.cstatus<>'1' AND csistema='1' AND ccuadrado='1' AND ctotdebe>0 AND NOT EXISTS(SELECT cidcomprob FROM TPAGOSCXPM WHERE TPAGOSCXPM.cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND TPAGOSCXPM.ccompany=TCOMPROBANC.ccompany AND TPAGOSCXPM.cidcomprob=TCOMPROBANC.cidcomprob) AND NOT EXISTS(SELECT cidcomprob FROM TCOMPROBANRETC WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND TCOMPROBANRETC.cidcomprob=TCOMPROBANC.cidcomprob) AND NOT EXISTS(SELECT cidcomprob FROM TCOMPROBANISLRC WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND TCOMPROBANISLRC.cidcomprob=TCOMPROBANC.cidcomprob) AND NOT EXISTS(SELECT cidcomprob FROM TNOTARECEPC WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND TNOTARECEPC.cidcomprob=TCOMPROBANC.cidcomprob)";
                    _Ds_AuxTabs = _Mtd_GetDataSet(_Str_Sql);
                    if (Convert.ToString(_Ds_AuxTabs.Tables[0].Rows[0][0]) != "")
                    {
                        _Int_Count = Convert.ToInt32(_Ds_AuxTabs.Tables[0].Rows[0][0]);
                    }
                    if (_Int_Count != _Int_87)
                    {
                        object[] myArray = new object[1];
                        if (_Int_Count > _Int_87)
                        { _Bol_SwTimbre = true; }
                        if (_Pnl_Contenedor.Controls.Find("_Ctrl87", false).Length > 0)
                        {
                            myArray[0] = ((_Ctrl_Tabs)(_Pnl_Contenedor.Controls.Find("_Ctrl87", false)[0]));
                            this.Invoke(new MyDelegate_Ctrl_Tabs_Del(DelegateMethod_Ctrl_Tabs_Del), myArray);
                            _Int_87 = _Int_Count;
                        }
                        if (_Int_Count > 0)
                        {
                            _Ctrl_Tabs _Ctrl = new _Ctrl_Tabs();
                            _Ctrl.Name = "_Ctrl87";
                            _Ctrl._Descripcion = _Str_TabActual + "(" + _Int_Count.ToString() + ")";
                            _Ctrl._Formulario = "T3.Frm_ConsultaComprobante";
                            _Ctrl._FormularioMdi = _Frm_MdiParent;
                            _Ctrl._Parametros = new object[] { true };
                            _Ctrl.Dock = DockStyle.Top;
                            myArray[0] = _Ctrl;
                            this.Invoke(new MyDelegate_Ctrl_Tabs(DelegateMethod_Ctrl_Tabs), myArray);
                            _Int_87 = _Int_Count;
                        }
                    }
                }
                //---------------------TABS NÚMERO 87
                //---------------------------------------------------------------------------------------------------------
                //---------------------TABS NÚMERO 88
                _Str_expression = "ctabs = 88";
                _Drow_found = _Ds_FrmTabs.Tables[0].Select(_Str_expression);
                if (_Drow_found.Length > 0)
                {
                    _Str_TabActual = "COMPROBANTES DE CHEQ/TRANS POR IMPRIMIR";
                    _Int_Count = 0;
                    _Str_Sql = "SELECT COUNT(TEMICHEQTRANSM.cgroupcomp) " +
                    "FROM TEMICHEQTRANSM INNER JOIN " +
                    "TPAGOSCXPM ON TEMICHEQTRANSM.cgroupcomp = TPAGOSCXPM.cgroupcomp AND " +
                    "TEMICHEQTRANSM.ccompany = TPAGOSCXPM.ccompany AND " +
                    "TEMICHEQTRANSM.cidcomprob = TPAGOSCXPM.cidcomprob INNER JOIN " +
                    "TCOMPROBANC ON TPAGOSCXPM.ccompany = TCOMPROBANC.ccompany AND " +
                    "TPAGOSCXPM.cidcomprob = TCOMPROBANC.cidcomprob INNER JOIN "+
					"TBANCO ON TBANCO.ccompany = TEMICHEQTRANSM.ccompany AND TBANCO.cbanco = TEMICHEQTRANSM.cbanco "+
                    "WHERE  (TEMICHEQTRANSM.cimpimiocheq = 1) AND (TPAGOSCXPM.ccancelado = 1) AND (TCOMPROBANC.cstatus = '0') AND " +
                    "(TEMICHEQTRANSM.cgroupcomp = '" + Frm_Padre._Str_GroupComp + "') AND (TEMICHEQTRANSM.ccompany = '" + Frm_Padre._Str_Comp + "')";
                    _Ds_AuxTabs = _Mtd_GetDataSet(_Str_Sql);
                    if (Convert.ToString(_Ds_AuxTabs.Tables[0].Rows[0][0]) != "")
                    {
                        _Int_Count = Convert.ToInt32(_Ds_AuxTabs.Tables[0].Rows[0][0]);
                    }
                    if (_Int_Count != _Int_88)
                    {
                        object[] myArray = new object[1];
                        if (_Int_Count > _Int_88)
                        { _Bol_SwTimbre = true; }
                        if (_Pnl_Contenedor.Controls.Find("_Ctrl88", false).Length > 0)
                        {
                            myArray[0] = ((_Ctrl_Tabs)(_Pnl_Contenedor.Controls.Find("_Ctrl88", false)[0]));
                            this.Invoke(new MyDelegate_Ctrl_Tabs_Del(DelegateMethod_Ctrl_Tabs_Del), myArray);
                            _Int_88 = _Int_Count;
                        }
                        if (_Int_Count > 0)
                        {
                            _Ctrl_Tabs _Ctrl = new _Ctrl_Tabs();
                            _Ctrl.Name = "_Ctrl88";
                            _Ctrl._Descripcion = _Str_TabActual + "(" + _Int_Count.ToString() + ")";
                            _Ctrl._Formulario = "T3.Frm_Busqueda2";
                            _Ctrl._FormularioMdi = _Frm_MdiParent;
                            _Ctrl._Parametros = new object[] { 60 };
                            _Ctrl.Dock = DockStyle.Top;
                            myArray[0] = _Ctrl;
                            this.Invoke(new MyDelegate_Ctrl_Tabs(DelegateMethod_Ctrl_Tabs), myArray);
                            _Int_88 = _Int_Count;
                        }
                    }
                }
                //---------------------TABS NÚMERO 88
                //---------------------------------------------------------------------------------------------------------
                //---------------------TABS NÚMERO 89
                _Str_expression = "ctabs = 89";
                _Drow_found = _Ds_FrmTabs.Tables[0].Select(_Str_expression);
                if (_Drow_found.Length > 0)
                {
                    _Str_TabActual = "PRODUCTOS - COSTO BRUTO MENOR A COSTO NETO";
                    _Int_Count = 0;
                    _Str_Sql = "SELECT COUNT(DISTINCT TPRODUCTO.cproducto) FROM TPRODUCTO INNER JOIN TPROVEEDOR ON TPRODUCTO.cproveedor=TPROVEEDOR.cproveedor LEFT JOIN TGRUPPROVEE ON TPROVEEDOR.cproveedor = TGRUPPROVEE.cproveedor WHERE ISNULL(TPROVEEDOR.cdelete,0)='0' AND ISNULL(TGRUPPROVEE.cdelete,0)='0' AND TPROVEEDOR.c_activo='1' AND ((TPROVEEDOR.cglobal='1' AND TGRUPPROVEE.ccompany='" + Frm_Padre._Str_Comp + "')) AND TPRODUCTO.ccostobruto_u1<TPRODUCTO.ccostoneto_u1 AND TPRODUCTO.cactivate='1'";
                    _Ds_AuxTabs = _Mtd_GetDataSet(_Str_Sql);
                    if (Convert.ToString(_Ds_AuxTabs.Tables[0].Rows[0][0]) != "")
                    {
                        _Int_Count = Convert.ToInt32(_Ds_AuxTabs.Tables[0].Rows[0][0]);
                    }
                    if (_Int_Count != _Int_89)
                    {
                        object[] myArray = new object[1];
                        if (_Int_Count > _Int_89)
                        { _Bol_SwTimbre = true; }
                        if (_Pnl_Contenedor.Controls.Find("_Ctrl89", false).Length > 0)
                        {
                            myArray[0] = ((_Ctrl_Tabs)(_Pnl_Contenedor.Controls.Find("_Ctrl89", false)[0]));
                            this.Invoke(new MyDelegate_Ctrl_Tabs_Del(DelegateMethod_Ctrl_Tabs_Del), myArray);
                            _Int_89 = _Int_Count;
                        }
                        if (_Int_Count > 0)
                        {
                            _Ctrl_Tabs _Ctrl = new _Ctrl_Tabs();
                            _Ctrl.Name = "_Ctrl89";
                            _Ctrl._Descripcion = _Str_TabActual + "(" + _Int_Count.ToString() + ")";
                            _Ctrl._Formulario = "T3.Frm_Busqueda2";
                            _Ctrl._FormularioMdi = _Frm_MdiParent;
                            _Ctrl._Parametros = new object[] { 61 };
                            _Ctrl.Dock = DockStyle.Top;
                            myArray[0] = _Ctrl;
                            this.Invoke(new MyDelegate_Ctrl_Tabs(DelegateMethod_Ctrl_Tabs), myArray);
                            _Int_89 = _Int_Count;
                        }
                    }
                }
                //---------------------TABS NÚMERO 89
                //---------------------------------------------------------------------------------------------------------
                //---------------------TABS NÚMERO 90
                _Str_expression = "ctabs = 90";
                _Drow_found = _Ds_FrmTabs.Tables[0].Select(_Str_expression);
                if (_Drow_found.Length > 0)
                {
                    //if (myUtilidad._Mtd_ObtenerUsuarioFirma(Frm_Padre._Str_Use) == "1" & myUtilidad._Mtd_UsuarioProceso(Frm_Padre._Str_Use, "F_FACT_COMPRA"))
                    //{
                        _Str_TabActual = "NOTAS DE RECEPCIÓN POR GENERAR";
                        _Int_Count = 0;
                        _Str_Sql = "SELECT COUNT(TRECEPCIONM.cidrecepcion) FROM  TRECEPCIONM INNER JOIN TRECEPCIONDFM ON TRECEPCIONM.cgroupcomp = TRECEPCIONDFM.cgroupcomp AND TRECEPCIONM.cidrecepcion = TRECEPCIONDFM.cidrecepcion AND TRECEPCIONM.cproveedor = TRECEPCIONDFM.cproveedor WHERE (TRECEPCIONM.cgroupcomp='" + Frm_Padre._Str_GroupComp + "') AND (TRECEPCIONM.cdescargo='1') AND (TRECEPCIONM.cevaluado='1') AND (TRECEPCIONDFM.ccomparafactdes='1') AND (TRECEPCIONDFM.cnotarecepcion='0')";
                        _Ds_AuxTabs = _Mtd_GetDataSet(_Str_Sql);
                        if (Convert.ToString(_Ds_AuxTabs.Tables[0].Rows[0][0]) != "")
                        {
                            _Int_Count = Convert.ToInt32(_Ds_AuxTabs.Tables[0].Rows[0][0]);
                        }
                        if (_Int_Count != _Int_90)
                        {
                            object[] myArray = new object[1];
                            if (_Int_Count > _Int_90)
                            { _Bol_SwTimbre = true; }
                            if (_Pnl_Contenedor.Controls.Find("_Ctrl90", false).Length > 0)
                            {
                                myArray[0] = ((_Ctrl_Tabs)(_Pnl_Contenedor.Controls.Find("_Ctrl90", false)[0]));
                                this.Invoke(new MyDelegate_Ctrl_Tabs_Del(DelegateMethod_Ctrl_Tabs_Del), myArray);
                                _Int_90 = _Int_Count;
                            }
                            if (_Int_Count > 0)
                            {
                                _Ctrl_Tabs _Ctrl = new _Ctrl_Tabs();
                                _Ctrl.Name = "_Ctrl90";
                                _Ctrl._Descripcion = _Str_TabActual + "(" + _Int_Count.ToString() + ")";
                                _Ctrl._Formulario = "T3.Frm_Busqueda2";
                                _Ctrl._FormularioMdi = _Frm_MdiParent;
                                _Ctrl._Parametros = new object[] { 63 };
                                _Ctrl.Dock = DockStyle.Top;
                                myArray[0] = _Ctrl;
                                this.Invoke(new MyDelegate_Ctrl_Tabs(DelegateMethod_Ctrl_Tabs), myArray);
                                _Int_90 = _Int_Count;
                            }
                        }
                    //}
                }
                //---------------------TABS NÚMERO 90
                //---------------------------------------------------------------------------------------------------------
                //---------------------TABS NÚMERO 91
                _Str_expression = "ctabs = 91";
                _Drow_found = _Ds_FrmTabs.Tables[0].Select(_Str_expression);
                if (_Drow_found.Length > 0)
                {
                    _Str_TabActual = "EGRE-CHEQ-TRANS POR IMPRIMIR SEGÚN CAJA";
                    _Int_Count = 0;
                    _Str_Sql = "SELECT DISTINCT ccaja FROM VST_TEGRECHEQGTRAN_RELCOB WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cimpreso=0 AND NOT ccaja IS NULL";
                    _Ds_AuxTabs = _Mtd_GetDataSet(_Str_Sql);
                    if (_Ds_AuxTabs.Tables[0].Rows.Count > 0)
                    {
                        _Int_Count = _Ds_AuxTabs.Tables[0].Rows.Count;
                    }
                    if (_Int_Count != _Int_91)
                    {
                        object[] myArray = new object[1];
                        if (_Int_Count > _Int_91)
                        { _Bol_SwTimbre = true; }
                        if (_Pnl_Contenedor.Controls.Find("_Ctrl91", false).Length > 0)
                        {
                            myArray[0] = ((_Ctrl_Tabs)(_Pnl_Contenedor.Controls.Find("_Ctrl91", false)[0]));
                            this.Invoke(new MyDelegate_Ctrl_Tabs_Del(DelegateMethod_Ctrl_Tabs_Del), myArray);
                            _Int_91 = _Int_Count;
                        }
                        if (_Int_Count > 0)
                        {
                            _Ctrl_Tabs _Ctrl = new _Ctrl_Tabs();
                            _Ctrl.Name = "_Ctrl91";
                            _Ctrl._Descripcion = _Str_TabActual + "(" + _Int_Count.ToString() + ")";
                            _Ctrl._Formulario = "T3.Frm_Busqueda2";
                            _Ctrl._FormularioMdi = _Frm_MdiParent;
                            _Ctrl._Parametros = new object[] { 62 };
                            _Ctrl.Dock = DockStyle.Top;
                            myArray[0] = _Ctrl;
                            this.Invoke(new MyDelegate_Ctrl_Tabs(DelegateMethod_Ctrl_Tabs), myArray);
                            _Int_91 = _Int_Count;
                        }
                    }
                }
                //---------------------TABS NÚMERO 91
                //---------------------------------------------------------------------------------------------------------
                //---------------------TABS NÚMERO 92
                _Str_expression = "ctabs = 92";
                _Drow_found = _Ds_FrmTabs.Tables[0].Select(_Str_expression);
                if (_Drow_found.Length > 0)
                {
                    _Str_TabActual = "CHEQUES DEVUELTOS SIN COMPROBANTE";
                    _Int_Count = 0;
                    //_Str_Sql = "SELECT COUNT(cgroupcomp) FROM TCHEQDEVUELT WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND (cidcomprob='0' OR (cidcomprob>0 AND EXISTS(SELECT cidcomprob FROM TCOMPROBANC WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cidcomprob=TCHEQDEVUELT.cidcomprob AND clvalidado='0')))";
                    _Str_Sql = "SELECT COUNT(TCHEQDEVUELT.cgroupcomp) FROM TCHEQDEVUELT LEFT OUTER JOIN TCOMPROBANC ON TCHEQDEVUELT.cidcomprob = TCOMPROBANC.cidcomprob AND TCHEQDEVUELT.ccompany = TCOMPROBANC.ccompany AND TCHEQDEVUELT.cidcomprob > 0 AND TCOMPROBANC.clvalidado = '0' WHERE TCHEQDEVUELT.cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND TCHEQDEVUELT.ccompany='" + Frm_Padre._Str_Comp + "' AND TCHEQDEVUELT.cidcomprob='0'";
                    _Ds_AuxTabs = _Mtd_GetDataSet(_Str_Sql);
                    if (Convert.ToString(_Ds_AuxTabs.Tables[0].Rows[0][0]) != "")
                    {
                        _Int_Count = Convert.ToInt32(_Ds_AuxTabs.Tables[0].Rows[0][0]);
                    }
                    if (_Int_Count != _Int_92)
                    {
                        object[] myArray = new object[1];
                        if (_Int_Count > _Int_92)
                        { _Bol_SwTimbre = true; }
                        if (_Pnl_Contenedor.Controls.Find("_Ctrl92", false).Length > 0)
                        {
                            myArray[0] = ((_Ctrl_Tabs)(_Pnl_Contenedor.Controls.Find("_Ctrl92", false)[0]));
                            this.Invoke(new MyDelegate_Ctrl_Tabs_Del(DelegateMethod_Ctrl_Tabs_Del), myArray);
                            _Int_92 = _Int_Count;
                        }
                        if (_Int_Count > 0)
                        {
                            _Ctrl_Tabs _Ctrl = new _Ctrl_Tabs();
                            _Ctrl.Name = "_Ctrl92";
                            _Ctrl._Descripcion = _Str_TabActual + "(" + _Int_Count.ToString() + ")";
                            _Ctrl._Formulario = "T3.Frm_ImpresionLote";
                            _Ctrl._FormularioMdi = _Frm_MdiParent;
                            _Ctrl._Parametros = new object[] { 12 };
                            _Ctrl.Dock = DockStyle.Top;
                            myArray[0] = _Ctrl;
                            this.Invoke(new MyDelegate_Ctrl_Tabs(DelegateMethod_Ctrl_Tabs), myArray);
                            _Int_92 = _Int_Count;
                        }
                    }
                }
                //---------------------TABS NÚMERO 92
                //---------------------------------------------------------------------------------------------------------
                //---------------------TABS NÚMERO 93
                _Str_expression = "ctabs = 93";
                _Drow_found = _Ds_FrmTabs.Tables[0].Select(_Str_expression);
                if (_Drow_found.Length > 0)
                {
                    if (myUtilidad._Mtd_ObtenerUsuarioFirma(Frm_Padre._Str_Use) == "1" & myUtilidad._Mtd_UsuarioProceso(Frm_Padre._Str_Use, "F_N2_ANC_CXP"))
                    {
                        _Str_TabActual = "ANULACION DE N.C. DE CxP POR APROBAR";
                        _Int_Count = 0;
                        _Str_Sql = "SELECT count(cgroupcomp) FROM TNOTACREDICP WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cactivo='1' AND cimpresa='1' AND cidcomprob>'0' AND (cmotivoanulacion<>'0' AND NOT cmotivoanulacion IS NULL) AND (canulado='0' OR canulado IS NULL)";
                        _Ds_AuxTabs = _Mtd_GetDataSet(_Str_Sql);
                        if (Convert.ToString(_Ds_AuxTabs.Tables[0].Rows[0][0]) != "")
                        {
                            _Int_Count = Convert.ToInt32(_Ds_AuxTabs.Tables[0].Rows[0][0]);
                        }
                        if (_Int_Count != _Int_93)
                        {
                            object[] myArray = new object[1];
                            if (_Int_Count > _Int_93)
                            { _Bol_SwTimbre = true; }
                            if (_Pnl_Contenedor.Controls.Find("_Ctrl93", false).Length > 0)
                            {
                                myArray[0] = ((_Ctrl_Tabs)(_Pnl_Contenedor.Controls.Find("_Ctrl93", false)[0]));
                                this.Invoke(new MyDelegate_Ctrl_Tabs_Del(DelegateMethod_Ctrl_Tabs_Del), myArray);
                                _Int_93 = _Int_Count;
                            }
                            if (_Int_Count > 0)
                            {
                                _Ctrl_Tabs _Ctrl = new _Ctrl_Tabs();
                                _Ctrl.Name = "_Ctrl93";
                                _Ctrl._Descripcion = _Str_TabActual + "(" + _Int_Count.ToString() + ")";
                                _Ctrl._Formulario = "T3.Frm_AnulNotaCredito";
                                _Ctrl._FormularioMdi = _Frm_MdiParent;
                                _Ctrl._Parametros = new object[] { true };
                                _Ctrl.Dock = DockStyle.Top;
                                myArray[0] = _Ctrl;
                                this.Invoke(new MyDelegate_Ctrl_Tabs(DelegateMethod_Ctrl_Tabs), myArray);
                                _Int_93 = _Int_Count;
                            }
                        }
                    }
                }
                //---------------------TABS NÚMERO 93
                //---------------------------------------------------------------------------------------------------------
                //---------------------TABS NÚMERO 94
                _Str_expression = "ctabs = 94";
                _Drow_found = _Ds_FrmTabs.Tables[0].Select(_Str_expression);
                if (_Drow_found.Length > 0)
                {
                    if (myUtilidad._Mtd_ObtenerUsuarioFirma(Frm_Padre._Str_Use) == "1" & myUtilidad._Mtd_UsuarioProceso(Frm_Padre._Str_Use, "F_N2_AND_CXP"))
                    {
                        _Str_TabActual = "ANULACION DE N.D. DE CxP POR APROBAR";
                        _Int_Count = 0;
                        _Str_Sql = "SELECT count(cgroupcomp) FROM TNOTADEBITOCP WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cactivo='1' AND cimpresa='1' AND cidcomprob>'0' AND (cmotivoanulacion<>'0' AND NOT cmotivoanulacion IS NULL) AND (canulado='0' OR canulado IS NULL)";
                        _Ds_AuxTabs = _Mtd_GetDataSet(_Str_Sql);
                        if (Convert.ToString(_Ds_AuxTabs.Tables[0].Rows[0][0]) != "")
                        {
                            _Int_Count = Convert.ToInt32(_Ds_AuxTabs.Tables[0].Rows[0][0]);
                        }
                        if (_Int_Count != _Int_94)
                        {
                            object[] myArray = new object[1];
                            if (_Int_Count > _Int_94)
                            { _Bol_SwTimbre = true; }
                            if (_Pnl_Contenedor.Controls.Find("_Ctrl94", false).Length > 0)
                            {
                                myArray[0] = ((_Ctrl_Tabs)(_Pnl_Contenedor.Controls.Find("_Ctrl94", false)[0]));
                                this.Invoke(new MyDelegate_Ctrl_Tabs_Del(DelegateMethod_Ctrl_Tabs_Del), myArray);
                                _Int_94 = _Int_Count;
                            }
                            if (_Int_Count > 0)
                            {
                                _Ctrl_Tabs _Ctrl = new _Ctrl_Tabs();
                                _Ctrl.Name = "_Ctrl94";
                                _Ctrl._Descripcion = _Str_TabActual + "(" + _Int_Count.ToString() + ")";
                                _Ctrl._Formulario = "T3.Frm_AnulNotaDebito";
                                _Ctrl._FormularioMdi = _Frm_MdiParent;
                                _Ctrl._Parametros = new object[] { true };
                                _Ctrl.Dock = DockStyle.Top;
                                myArray[0] = _Ctrl;
                                this.Invoke(new MyDelegate_Ctrl_Tabs(DelegateMethod_Ctrl_Tabs), myArray);
                                _Int_94 = _Int_Count;
                            }
                        }
                    }
                }
                //---------------------TABS NÚMERO 94
                //---------------------------------------------------------------------------------------------------------
                //---------------------TABS NÚMERO 95
                _Str_expression = "ctabs = 95";
                _Drow_found = _Ds_FrmTabs.Tables[0].Select(_Str_expression);
                if (_Drow_found.Length > 0)
                {
                    if (myUtilidad._Mtd_ObtenerUsuarioFirma(Frm_Padre._Str_Use) == "1" & myUtilidad._Mtd_UsuarioProceso(Frm_Padre._Str_Use, "F_RE_ABRIR_MES"))
                    {
                        _Str_TabActual = "MES CONTABLE RE-ABIERTO";
                        _Int_Count = 0;
                        _Str_Sql = "SELECT COUNT(ccompany) FROM TMESCONTABLE WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND creabierto='1' AND ccerrado='0'";
                        _Ds_AuxTabs = _Mtd_GetDataSet(_Str_Sql);
                        if (Convert.ToString(_Ds_AuxTabs.Tables[0].Rows[0][0]) != "")
                        {
                            _Int_Count = Convert.ToInt32(_Ds_AuxTabs.Tables[0].Rows[0][0]);
                        }
                        if (_Int_Count != _Int_95)
                        {
                            object[] myArray = new object[1];
                            if (_Int_Count > _Int_95)
                            { _Bol_SwTimbre = true; }
                            if (_Pnl_Contenedor.Controls.Find("_Ctrl95", false).Length > 0)
                            {
                                myArray[0] = ((_Ctrl_Tabs)(_Pnl_Contenedor.Controls.Find("_Ctrl95", false)[0]));
                                this.Invoke(new MyDelegate_Ctrl_Tabs_Del(DelegateMethod_Ctrl_Tabs_Del), myArray);
                                _Int_95 = _Int_Count;
                            }
                            if (_Int_Count > 0)
                            {
                                _Ctrl_Tabs _Ctrl = new _Ctrl_Tabs();
                                _Ctrl.Name = "_Ctrl95";
                                _Ctrl._Descripcion = _Str_TabActual + "(" + _Int_Count.ToString() + ")";
                                _Ctrl._Formulario = "T3.Frm_ReAbrirMesCont";
                                _Ctrl._FormularioMdi = _Frm_MdiParent;
                                _Ctrl._Parametros = new object[] { true };
                                _Ctrl.Dock = DockStyle.Top;
                                myArray[0] = _Ctrl;
                                this.Invoke(new MyDelegate_Ctrl_Tabs(DelegateMethod_Ctrl_Tabs), myArray);
                                _Int_95 = _Int_Count;
                            }
                        }
                    }
                }
                //---------------------TABS NÚMERO 95
                //---------------------------------------------------------------------------------------------------------
                //---------------------TABS NÚMERO 96
                _Str_expression = "ctabs = 96";
                _Drow_found = _Ds_FrmTabs.Tables[0].Select(_Str_expression);
                if (_Drow_found.Length > 0)
                {
                    _Str_TabActual = "EGRESOS DE CHEQUE SIN COMPROBANTE";
                    _Int_Count = 0;
                    //_Str_Sql = "SELECT COUNT(cgroupcomp) FROM TEGRECHEQTRAN WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND (cidcomprob='0' OR (cidcomprob>0 AND EXISTS(SELECT cidcomprob FROM TCOMPROBANC WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cidcomprob=TEGRECHEQTRAN.cidcomprob AND clvalidado='0')))";
                    _Str_Sql = "SELECT COUNT(TEGRECHEQTRAN.cgroupcomp) FROM TEGRECHEQTRAN LEFT OUTER JOIN TCOMPROBANC ON TEGRECHEQTRAN.ccompany = TCOMPROBANC.ccompany AND TEGRECHEQTRAN.cidcomprob = TCOMPROBANC.cidcomprob AND TCOMPROBANC.clvalidado = '0' AND TEGRECHEQTRAN.cidcomprob > 0 WHERE TEGRECHEQTRAN.cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND TEGRECHEQTRAN.ccompany='" + Frm_Padre._Str_Comp + "' AND TEGRECHEQTRAN.cidcomprob='0'";
                    _Ds_AuxTabs = _Mtd_GetDataSet(_Str_Sql);
                    if (Convert.ToString(_Ds_AuxTabs.Tables[0].Rows[0][0]) != "")
                    {
                        _Int_Count = Convert.ToInt32(_Ds_AuxTabs.Tables[0].Rows[0][0]);
                    }
                    if (_Int_Count != _Int_96)
                    {
                        object[] myArray = new object[1];
                        if (_Int_Count > _Int_96)
                        { _Bol_SwTimbre = true; }
                        if (_Pnl_Contenedor.Controls.Find("_Ctrl96", false).Length > 0)
                        {
                            myArray[0] = ((_Ctrl_Tabs)(_Pnl_Contenedor.Controls.Find("_Ctrl96", false)[0]));
                            this.Invoke(new MyDelegate_Ctrl_Tabs_Del(DelegateMethod_Ctrl_Tabs_Del), myArray);
                            _Int_96 = _Int_Count;
                        }
                        if (_Int_Count > 0)
                        {
                            _Ctrl_Tabs _Ctrl = new _Ctrl_Tabs();
                            _Ctrl.Name = "_Ctrl96";
                            _Ctrl._Descripcion = _Str_TabActual + "(" + _Int_Count.ToString() + ")";
                            _Ctrl._Formulario = "T3.Frm_ImpresionLote";
                            _Ctrl._FormularioMdi = _Frm_MdiParent;
                            _Ctrl._Parametros = new object[] { 14 };
                            _Ctrl.Dock = DockStyle.Top;
                            myArray[0] = _Ctrl;
                            this.Invoke(new MyDelegate_Ctrl_Tabs(DelegateMethod_Ctrl_Tabs), myArray);
                            _Int_96 = _Int_Count;
                        }
                    }
                }
                //---------------------TABS NÚMERO 96
                //---------------------------------------------------------------------------------------------------------
                //---------------------TABS NÚMERO 97
                _Str_expression = "ctabs = 97";
                _Drow_found = _Ds_FrmTabs.Tables[0].Select(_Str_expression);
                if (_Drow_found.Length > 0)
                {
                    _Str_TabActual = "COMPROBANTES DE ANTICIPOS POR IMPRIMIR";
                    _Int_Count = 0;
                    _Str_Sql = "SELECT COUNT(DISTINCT TPAGOSCXPM.cidordpago) FROM TPAGOSCXPM INNER JOIN TCOMPROBANC ON TPAGOSCXPM.ccompany = TCOMPROBANC.ccompany AND TPAGOSCXPM.cidcomprob = TCOMPROBANC.cidcomprob INNER JOIN TPAGOSCXPANT ON TPAGOSCXPM.cgroupcomp = TPAGOSCXPANT.cgroupcomp AND TPAGOSCXPM.ccompany = TPAGOSCXPANT.ccompany AND TPAGOSCXPM.cidordpago = TPAGOSCXPANT.cidordpago WHERE (TPAGOSCXPM.cgroupcomp='" + Frm_Padre._Str_GroupComp + "') AND (TPAGOSCXPM.ccompany='" + Frm_Padre._Str_Comp + "') AND (TPAGOSCXPM.ccancelado = '1') AND (TPAGOSCXPM.canulado = '0') AND (TCOMPROBANC.cstatus = '0') AND (TPAGOSCXPM.cotrospago = '0') AND NOT EXISTS(SELECT cidordpago FROM TEMICHEQTRANSM WHERE TEMICHEQTRANSM.cgroupcomp=TPAGOSCXPM.cgroupcomp AND TEMICHEQTRANSM.ccompany=TPAGOSCXPM.ccompany AND TEMICHEQTRANSM.cidordpago=TPAGOSCXPM.cidordpago)";
                    _Ds_AuxTabs = _Mtd_GetDataSet(_Str_Sql);
                    if (Convert.ToString(_Ds_AuxTabs.Tables[0].Rows[0][0]) != "")
                    {
                        _Int_Count = Convert.ToInt32(_Ds_AuxTabs.Tables[0].Rows[0][0]);
                    }
                    if (_Int_Count != _Int_97)
                    {
                        object[] myArray = new object[1];
                        if (_Int_Count > _Int_97)
                        { _Bol_SwTimbre = true; }
                        if (_Pnl_Contenedor.Controls.Find("_Ctrl97", false).Length > 0)
                        {
                            myArray[0] = ((_Ctrl_Tabs)(_Pnl_Contenedor.Controls.Find("_Ctrl97", false)[0]));
                            this.Invoke(new MyDelegate_Ctrl_Tabs_Del(DelegateMethod_Ctrl_Tabs_Del), myArray);
                            _Int_97 = _Int_Count;
                        }
                        if (_Int_Count > 0)
                        {
                            _Ctrl_Tabs _Ctrl = new _Ctrl_Tabs();
                            _Ctrl.Name = "_Ctrl97";
                            _Ctrl._Descripcion = _Str_TabActual + "(" + _Int_Count.ToString() + ")";
                            _Ctrl._Formulario = "T3.Frm_Busqueda2";
                            _Ctrl._FormularioMdi = _Frm_MdiParent;
                            _Ctrl._Parametros = new object[] { 73 };
                            _Ctrl.Dock = DockStyle.Top;
                            myArray[0] = _Ctrl;
                            this.Invoke(new MyDelegate_Ctrl_Tabs(DelegateMethod_Ctrl_Tabs), myArray);
                            _Int_97 = _Int_Count;
                        }
                    }
                }
                //---------------------TABS NÚMERO 97
                //---------------------------------------------------------------------------------------------------------
                //---------------------TABS NÚMERO 98
                _Str_expression = "ctabs = 98";
                _Drow_found = _Ds_FrmTabs.Tables[0].Select(_Str_expression);
                if (_Drow_found.Length > 0)
                {
                    _Str_TabActual = "CLIENTES BLOQUEADOS MANUALMENTE";
                    _Int_Count = 0;
                    _Str_Sql = "Select COUNT(cgroupcomp) from TCLIENTE where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and c_bloqueo_manual='1' and cdelete='0'";
                    _Ds_AuxTabs = _Mtd_GetDataSet(_Str_Sql);
                    if (Convert.ToString(_Ds_AuxTabs.Tables[0].Rows[0][0]) != "")
                    {
                        _Int_Count = Convert.ToInt32(_Ds_AuxTabs.Tables[0].Rows[0][0]);
                    }
                    if (_Int_Count != _Int_98)
                    {
                        object[] myArray = new object[1];
                        if (_Int_Count > _Int_98)
                        { _Bol_SwTimbre = true; }
                        if (_Pnl_Contenedor.Controls.Find("_Ctrl98", false).Length > 0)
                        {
                            myArray[0] = ((_Ctrl_Tabs)(_Pnl_Contenedor.Controls.Find("_Ctrl98", false)[0]));
                            this.Invoke(new MyDelegate_Ctrl_Tabs_Del(DelegateMethod_Ctrl_Tabs_Del), myArray);
                            _Int_98 = _Int_Count;
                        }
                        if (_Int_Count > 0)
                        {
                            _Ctrl_Tabs _Ctrl = new _Ctrl_Tabs();
                            _Ctrl.Name = "_Ctrl98";
                            _Ctrl._Descripcion = _Str_TabActual + "(" + _Int_Count.ToString() + ")";
                            _Ctrl._Formulario = "T3.Frm_EstatusClientes";
                            _Ctrl._FormularioMdi = _Frm_MdiParent;
                            _Ctrl._Parametros = new object[] { true };
                            _Ctrl.Dock = DockStyle.Top;
                            myArray[0] = _Ctrl;
                            this.Invoke(new MyDelegate_Ctrl_Tabs(DelegateMethod_Ctrl_Tabs), myArray);
                            _Int_98 = _Int_Count;
                        }
                    }
                }
                //---------------------TABS NÚMERO 98
                //---------------------------------------------------------------------------------------------------------
                //---------------------TABS NÚMERO 99
                _Str_expression = "ctabs = 99";
                _Drow_found = _Ds_FrmTabs.Tables[0].Select(_Str_expression);
                if (_Drow_found.Length > 0)
                {
                    _Str_TabActual = "CLIENTES ZONIFICADOS";
                    _Int_Count = 0;
                    _Str_Sql = "SELECT COUNT(DISTINCT TCLIENTE.ccliente) FROM TCLIENTE INNER JOIN TZONACLIENTE ON TCLIENTE.ccliente=TZONACLIENTE.ccliente WHERE TCLIENTE.cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND TZONACLIENTE.ccompany='" + Frm_Padre._Str_Comp + "' AND TZONACLIENTE.cdelete='0' AND TCLIENTE.cdelete='0' and TCLIENTE.c_activo='1'";
                    _Ds_AuxTabs = _Mtd_GetDataSet(_Str_Sql);
                    if (Convert.ToString(_Ds_AuxTabs.Tables[0].Rows[0][0]) != "")
                    {
                        _Int_Count = Convert.ToInt32(_Ds_AuxTabs.Tables[0].Rows[0][0]);
                    }
                    if (_Int_Count != _Int_99)
                    {
                        object[] myArray = new object[1];
                        if (_Int_Count > _Int_99)
                        { _Bol_SwTimbre = true; }
                        if (_Pnl_Contenedor.Controls.Find("_Ctrl99", false).Length > 0)
                        {
                            myArray[0] = ((_Ctrl_Tabs)(_Pnl_Contenedor.Controls.Find("_Ctrl99", false)[0]));
                            this.Invoke(new MyDelegate_Ctrl_Tabs_Del(DelegateMethod_Ctrl_Tabs_Del), myArray);
                            _Int_99 = _Int_Count;
                        }
                        if (_Int_Count > 0)
                        {
                            _Ctrl_Tabs _Ctrl = new _Ctrl_Tabs();
                            _Ctrl.Name = "_Ctrl99";
                            _Ctrl._Descripcion = "CLIENTES ZONIFICADOS  ( " + _Int_Count.ToString() + " )";
                            _Ctrl._Formulario = "T3.Frm_Busqueda2";
                            _Ctrl._FormularioMdi = _Frm_MdiParent;
                            _Ctrl._Parametros = new object[] { 77 };
                            _Ctrl.Dock = DockStyle.Top;
                            myArray[0] = _Ctrl;
                            this.Invoke(new MyDelegate_Ctrl_Tabs(DelegateMethod_Ctrl_Tabs), myArray);
                            _Int_99 = _Int_Count;
                        }
                    }
                }
                //---------------------TABS NÚMERO 99
                //---------------------------------------------------------------------------------------------------------
                //---------------------TABS NÚMERO 100
                _Str_expression = "ctabs = 100";
                _Drow_found = _Ds_FrmTabs.Tables[0].Select(_Str_expression);
                if (_Drow_found.Length > 0)
                {
                    _Str_TabActual = "CLIENTES ENRUTADOS";
                    _Int_Count = 0;
                    _Str_Sql = "SELECT COUNT(DISTINCT TCLIENTE.ccliente) FROM TCLIENTE INNER JOIN TZONACLIENTE ON TCLIENTE.ccliente = TZONACLIENTE.ccliente INNER JOIN TRUTAVISITAD ON TZONACLIENTE.ccompany = TRUTAVISITAD.ccompany AND TZONACLIENTE.ccliente = TRUTAVISITAD.ccliente AND ISNULL(TZONACLIENTE.cdelete, 0) = ISNULL(TRUTAVISITAD.cdelete, 0) WHERE TCLIENTE.cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND TZONACLIENTE.ccompany='" + Frm_Padre._Str_Comp + "' AND TZONACLIENTE.cdelete='0' AND TCLIENTE.cdelete='0' and TCLIENTE.c_activo='1'";
                    _Ds_AuxTabs = _Mtd_GetDataSet(_Str_Sql);
                    if (Convert.ToString(_Ds_AuxTabs.Tables[0].Rows[0][0]) != "")
                    {
                        _Int_Count = Convert.ToInt32(_Ds_AuxTabs.Tables[0].Rows[0][0]);
                    }
                    if (_Int_Count != _Int_100)
                    {
                        object[] myArray = new object[1];
                        if (_Int_Count > _Int_100)
                        { _Bol_SwTimbre = true; }
                        if (_Pnl_Contenedor.Controls.Find("_Ctrl100", false).Length > 0)
                        {
                            myArray[0] = ((_Ctrl_Tabs)(_Pnl_Contenedor.Controls.Find("_Ctrl100", false)[0]));
                            this.Invoke(new MyDelegate_Ctrl_Tabs_Del(DelegateMethod_Ctrl_Tabs_Del), myArray);
                            _Int_100 = _Int_Count;
                        }
                        if (_Int_Count > 0)
                        {
                            _Ctrl_Tabs _Ctrl = new _Ctrl_Tabs();
                            _Ctrl.Name = "_Ctrl100";
                            _Ctrl._Descripcion = "CLIENTES ENRUTADOS  ( " + _Int_Count.ToString() + " )";
                            _Ctrl._Formulario = "T3.Frm_Busqueda2";
                            _Ctrl._FormularioMdi = _Frm_MdiParent;
                            _Ctrl._Parametros = new object[] { 78 };
                            _Ctrl.Dock = DockStyle.Top;
                            myArray[0] = _Ctrl;
                            this.Invoke(new MyDelegate_Ctrl_Tabs(DelegateMethod_Ctrl_Tabs), myArray);
                            _Int_100 = _Int_Count;
                        }
                    }
                }
                //---------------------TABS NÚMERO 100
                //---------------------------------------------------------------------------------------------------------
                //---------------------TABS NÚMERO 101
                _Str_expression = "ctabs = 101";
                _Drow_found = _Ds_FrmTabs.Tables[0].Select(_Str_expression);
                if (_Drow_found.Length > 0)
                {
                    if (myUtilidad._Mtd_ObtenerUsuarioFirma(Frm_Padre._Str_Use) == "1")
                    {
                        if (myUtilidad._Mtd_UsuarioProceso(Frm_Padre._Str_Use, "F_EMISION_TRANSF_IMP"))
                        {
                            _Str_TabActual = "TRANSFERENCIAS POR IMPRIMIR";
                            _Int_Count = 0;
                            _Str_Sql = "select count(cgroupcomp) from VST_EMICHEQTRANSM WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' and cfusersolicitante=1 AND cfuserfirmante1=1 AND cfuseraprobador=1 AND cimpimiocheq=0 AND canulado='0' AND cfpago='TRANSF'";
                            _Ds_AuxTabs = _Mtd_GetDataSet(_Str_Sql);
                            if (Convert.ToString(_Ds_AuxTabs.Tables[0].Rows[0][0]) != "")
                            {
                                _Int_Count = Convert.ToInt32(_Ds_AuxTabs.Tables[0].Rows[0][0]);
                            }
                            if (_Int_Count != _Int_101)
                            {
                                object[] myArray = new object[1];
                                if (_Int_Count > _Int_101)
                                { _Bol_SwTimbre = true; }
                                if (_Pnl_Contenedor.Controls.Find("_Ctrl101", false).Length > 0)
                                {
                                    myArray[0] = ((_Ctrl_Tabs)(_Pnl_Contenedor.Controls.Find("_Ctrl101", false)[0]));
                                    this.Invoke(new MyDelegate_Ctrl_Tabs_Del(DelegateMethod_Ctrl_Tabs_Del), myArray);
                                    _Int_101 = _Int_Count;
                                }
                                if (_Int_Count > 0)
                                {
                                    _Ctrl_Tabs _Ctrl = new _Ctrl_Tabs();
                                    _Ctrl.Name = "_Ctrl101";
                                    _Ctrl._Descripcion = "TRANSFERENCIAS POR IMPRIMIR  ( " + _Int_Count.ToString() + " )";
                                    _Ctrl._Formulario = "T3.Frm_EmisionCheque";
                                    _Ctrl._FormularioMdi = _Frm_MdiParent;
                                    _Ctrl._Parametros = new object[] { "1", "TRANSF" };
                                    _Ctrl.Dock = DockStyle.Top;
                                    myArray[0] = _Ctrl;
                                    this.Invoke(new MyDelegate_Ctrl_Tabs(DelegateMethod_Ctrl_Tabs), myArray);
                                    _Int_101 = _Int_Count;
                                }
                            }
                        }
                    }
                }
                //---------------------TABS NÚMERO 101
                //---------------------------------------------------------------------------------------------------------
                //---------------------TABS NÚMERO 102
                _Str_expression = "ctabs = 102";
                _Drow_found = _Ds_FrmTabs.Tables[0].Select(_Str_expression);
                if (_Drow_found.Length > 0)
                {
                    if (myUtilidad._Mtd_ObtenerUsuarioFirma(Frm_Padre._Str_Use) == "1" & myUtilidad._Mtd_UsuarioProceso(Frm_Padre._Str_Use, "F_N1_REPOSICIONES"))
                    {
                        _Str_TabActual = "REPOSICIONES INCOMPLETAS";
                        _Int_Count = 0;
                        _Str_Sql = "SELECT count(cidreposiciones) FROM TREPOSICIONESM WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND ISNULL(cestatusreposicion,0)=0";
                        _Ds_AuxTabs = _Mtd_GetDataSet(_Str_Sql);
                        if (Convert.ToString(_Ds_AuxTabs.Tables[0].Rows[0][0]) != "")
                        {
                            _Int_Count = Convert.ToInt32(_Ds_AuxTabs.Tables[0].Rows[0][0]);
                        }
                        if (_Int_Count != _Int_102)
                        {
                            object[] myArray = new object[1];
                            if (_Int_Count > _Int_102)
                            { _Bol_SwTimbre = true; }
                            if (_Pnl_Contenedor.Controls.Find("_Ctrl102", false).Length > 0)
                            {
                                myArray[0] = ((_Ctrl_Tabs)(_Pnl_Contenedor.Controls.Find("_Ctrl102", false)[0]));
                                this.Invoke(new MyDelegate_Ctrl_Tabs_Del(DelegateMethod_Ctrl_Tabs_Del), myArray);
                                _Int_102 = _Int_Count;
                            }
                            if (_Int_Count > 0)
                            {
                                _Ctrl_Tabs _Ctrl = new _Ctrl_Tabs();
                                _Ctrl.Name = "_Ctrl102";
                                _Ctrl._Descripcion = _Str_TabActual + "(" + _Int_Count.ToString() + ")";
                                _Ctrl._Formulario = "T3.Frm_ReposicionCxP";
                                _Ctrl._FormularioMdi = _Frm_MdiParent;
                                _Ctrl._Parametros = new object[] { 1 };
                                _Ctrl.Dock = DockStyle.Top;
                                myArray[0] = _Ctrl;
                                this.Invoke(new MyDelegate_Ctrl_Tabs(DelegateMethod_Ctrl_Tabs), myArray);
                                _Int_102 = _Int_Count;
                            }
                        }
                    }
                }
                //---------------------TABS NÚMERO 102
                //---------------------------------------------------------------------------------------------------------
                //---------------------TABS NÚMERO 103
                _Str_expression = "ctabs = 103";
                _Drow_found = _Ds_FrmTabs.Tables[0].Select(_Str_expression);
                if (_Drow_found.Length > 0)
                {
                    if (myUtilidad._Mtd_ObtenerUsuarioFirma(Frm_Padre._Str_Use) == "1" & myUtilidad._Mtd_UsuarioProceso(Frm_Padre._Str_Use, "F_N2_REPOSICIONES"))
                    {
                        _Str_TabActual = "REPOSICIONES POR APROBAR";
                        _Int_Count = 0;
                        _Str_Sql = "SELECT count(cidreposiciones) FROM TREPOSICIONESM WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND ISNULL(cestatusreposicion,0)=1 AND ISNULL(cestatusfirma,0)=0";
                        _Ds_AuxTabs = _Mtd_GetDataSet(_Str_Sql);
                        if (Convert.ToString(_Ds_AuxTabs.Tables[0].Rows[0][0]) != "")
                        {
                            _Int_Count = Convert.ToInt32(_Ds_AuxTabs.Tables[0].Rows[0][0]);
                        }
                        if (_Int_Count != _Int_103)
                        {
                            object[] myArray = new object[1];
                            if (_Int_Count > _Int_103)
                            { _Bol_SwTimbre = true; }
                            if (_Pnl_Contenedor.Controls.Find("_Ctrl103", false).Length > 0)
                            {
                                myArray[0] = ((_Ctrl_Tabs)(_Pnl_Contenedor.Controls.Find("_Ctrl103", false)[0]));
                                this.Invoke(new MyDelegate_Ctrl_Tabs_Del(DelegateMethod_Ctrl_Tabs_Del), myArray);
                                _Int_103 = _Int_Count;
                            }
                            if (_Int_Count > 0)
                            {
                                _Ctrl_Tabs _Ctrl = new _Ctrl_Tabs();
                                _Ctrl.Name = "_Ctrl103";
                                _Ctrl._Descripcion = _Str_TabActual + "(" + _Int_Count.ToString() + ")";
                                _Ctrl._Formulario = "T3.Frm_ReposicionCxP";
                                _Ctrl._FormularioMdi = _Frm_MdiParent;
                                _Ctrl._Parametros = new object[] { 2 };
                                _Ctrl.Dock = DockStyle.Top;
                                myArray[0] = _Ctrl;
                                this.Invoke(new MyDelegate_Ctrl_Tabs(DelegateMethod_Ctrl_Tabs), myArray);
                                _Int_103 = _Int_Count;
                            }
                        }
                    }
                }
                //---------------------TABS NÚMERO 103
                //---------------------------------------------------------------------------------------------------------
                //---------------------TABS NÚMERO 104
                _Str_expression = "ctabs = 104";
                _Drow_found = _Ds_FrmTabs.Tables[0].Select(_Str_expression);
                if (_Drow_found.Length > 0)
                {
                    _Str_TabActual = "PRODUCTOS POR VENCER";
                    _Int_Count = 0;
                    _Str_Sql = "SELECT TPRODUCTOVENCIMIENTO.cproducto FROM TPRODUCTOVENCIMIENTO INNER JOIN TPRODUCTO ON TPRODUCTO.CPRODUCTO=TPRODUCTOVENCIMIENTO.CPRODUCTO WHERE TPRODUCTOVENCIMIENTO.ccompany='" + Frm_Padre._Str_Comp + "' and DATEDIFF(d,GETDATE(),TPRODUCTOVENCIMIENTO.cfechavencimiento) between 0 and (SELECT ISNULL(cdiasvencproduc,0) FROM TCONFIGCOMP WHERE ccompany='" + Frm_Padre._Str_Comp + "') AND (TPRODUCTO.cactivate = 1) AND (TPRODUCTOVENCIMIENTO.cempaques>0 OR TPRODUCTOVENCIMIENTO.cunidades>0)";
                    _Ds_AuxTabs = _Mtd_GetDataSet(_Str_Sql);
                    _Int_Count = _Ds_AuxTabs.Tables[0].Rows.Count;
                    if (_Int_Count != _Int_104)
                    {
                        object[] myArray = new object[1];
                        if (_Int_Count > _Int_104)
                        { _Bol_SwTimbre = true; }
                        if (_Pnl_Contenedor.Controls.Find("_Ctrl104", false).Length > 0)
                        {
                            myArray[0] = ((_Ctrl_Tabs)(_Pnl_Contenedor.Controls.Find("_Ctrl104", false)[0]));
                            this.Invoke(new MyDelegate_Ctrl_Tabs_Del(DelegateMethod_Ctrl_Tabs_Del), myArray);
                            _Int_104 = _Int_Count;
                        }
                        if (_Int_Count > 0)
                        {
                            _Ctrl_Tabs _Ctrl = new _Ctrl_Tabs();
                            _Ctrl.Name = "_Ctrl104";
                            _Ctrl._Descripcion = _Str_TabActual + "(" + _Int_Count.ToString() + ")";
                            _Ctrl._Formulario = "T3.Frm_Busqueda2";
                            _Ctrl._FormularioMdi = _Frm_MdiParent;
                            _Ctrl._Parametros = new object[] { 82 };
                            _Ctrl.Dock = DockStyle.Top;
                            myArray[0] = _Ctrl;
                            this.Invoke(new MyDelegate_Ctrl_Tabs(DelegateMethod_Ctrl_Tabs), myArray);
                            _Int_104 = _Int_Count;
                        }
                    }
                }
                //---------------------TABS NÚMERO 104
                //---------------------------------------------------------------------------------------------------------
                //---------------------TABS NÚMERO 105
                _Str_expression = "ctabs = 105";
                _Drow_found = _Ds_FrmTabs.Tables[0].Select(_Str_expression);
                if (_Drow_found.Length > 0)
                {
                    if (myUtilidad._Mtd_ObtenerUsuarioFirma(Frm_Padre._Str_Use) == "1" & myUtilidad._Mtd_UsuarioProceso(Frm_Padre._Str_Use, "F_VERIF_RECEPCIONES"))
                    {
                        _Str_TabActual = "RECEPCIONES POR VERIFICAR";
                        _Int_Count = 0;
                        _Str_Sql = "SELECT count(cidrecepcion) " +
    "FROM TRECEPCIONM INNER JOIN " +
    "TPROVEEDOR ON TRECEPCIONM.cproveedor = TPROVEEDOR.cproveedor " +
    "WHERE (TRECEPCIONM.cgroupcomp = '" + Frm_Padre._Str_GroupComp + "') AND (TPROVEEDOR.cdelete = 0) AND (TRECEPCIONM.ccerrada = 0) AND (TRECEPCIONM.ccargfactura = 2) AND (SELECT COUNT(cnfacturapro) FROM TRECEPCIONDFM WHERE cgroupcomp=TRECEPCIONM.cgroupcomp AND cidrecepcion=TRECEPCIONM.cidrecepcion AND cfactverif='0')>0";
                        _Ds_AuxTabs = _Mtd_GetDataSet(_Str_Sql);
                        if (Convert.ToString(_Ds_AuxTabs.Tables[0].Rows[0][0]) != "")
                        {
                            _Int_Count = Convert.ToInt32(_Ds_AuxTabs.Tables[0].Rows[0][0]);
                        }
                        if (_Int_Count != _Int_105)
                        {
                            object[] myArray = new object[1];
                            if (_Int_Count > _Int_105)
                            { _Bol_SwTimbre = true; }
                            if (_Pnl_Contenedor.Controls.Find("_Ctrl105", false).Length > 0)
                            {
                                myArray[0] = ((_Ctrl_Tabs)(_Pnl_Contenedor.Controls.Find("_Ctrl105", false)[0]));
                                this.Invoke(new MyDelegate_Ctrl_Tabs_Del(DelegateMethod_Ctrl_Tabs_Del), myArray);
                                _Int_105 = _Int_Count;
                            }
                            if (_Int_Count > 0)
                            {
                                _Ctrl_Tabs _Ctrl = new _Ctrl_Tabs();
                                _Ctrl.Name = "_Ctrl105";
                                _Ctrl._Descripcion = _Str_TabActual + "(" + _Int_Count.ToString() + ")";
                                _Ctrl._Formulario = "T3.Frm_Busqueda2";
                                _Ctrl._FormularioMdi = _Frm_MdiParent;
                                _Ctrl._Parametros = new object[] { 84 };
                                _Ctrl.Dock = DockStyle.Top;
                                myArray[0] = _Ctrl;
                                this.Invoke(new MyDelegate_Ctrl_Tabs(DelegateMethod_Ctrl_Tabs), myArray);
                                _Int_105 = _Int_Count;
                            }
                        }
                    }
                }
                //---------------------TABS NÚMERO 105
                //---------------------------------------------------------------------------------------------------------
                //---------------------TABS NÚMERO 106
                _Str_expression = "ctabs = 106";
                _Drow_found = _Ds_FrmTabs.Tables[0].Select(_Str_expression);
                if (_Drow_found.Length > 0)
                {
                    _Str_TabActual = "RECEPCIONES MAL CARGADAS";
                    _Int_Count = 0;
                    _Str_Sql = "SELECT count(cidrecepcion) " +
"FROM TRECEPCIONM INNER JOIN " +
"TPROVEEDOR ON TRECEPCIONM.cproveedor = TPROVEEDOR.cproveedor " +
"WHERE (TRECEPCIONM.cgroupcomp = '" + Frm_Padre._Str_GroupComp + "') AND (TPROVEEDOR.cdelete = 0) AND (TRECEPCIONM.ccerrada = 0) AND (TRECEPCIONM.ccargfactura = 2) AND (SELECT COUNT(cnfacturapro) FROM TRECEPCIONDFM WHERE cgroupcomp=TRECEPCIONM.cgroupcomp AND cidrecepcion=TRECEPCIONM.cidrecepcion AND cfactverif='2')>0";
                    _Ds_AuxTabs = _Mtd_GetDataSet(_Str_Sql);
                    if (Convert.ToString(_Ds_AuxTabs.Tables[0].Rows[0][0]) != "")
                    {
                        _Int_Count = Convert.ToInt32(_Ds_AuxTabs.Tables[0].Rows[0][0]);
                    }
                    if (_Int_Count != _Int_106)
                    {
                        object[] myArray = new object[1];
                        if (_Int_Count > _Int_106)
                        { _Bol_SwTimbre = true; }
                        if (_Pnl_Contenedor.Controls.Find("_Ctrl106", false).Length > 0)
                        {
                            myArray[0] = ((_Ctrl_Tabs)(_Pnl_Contenedor.Controls.Find("_Ctrl106", false)[0]));
                            this.Invoke(new MyDelegate_Ctrl_Tabs_Del(DelegateMethod_Ctrl_Tabs_Del), myArray);
                            _Int_106 = _Int_Count;
                        }
                        if (_Int_Count > 0)
                        {
                            _Ctrl_Tabs _Ctrl = new _Ctrl_Tabs();
                            _Ctrl.Name = "_Ctrl106";
                            _Ctrl._Descripcion = _Str_TabActual + "(" + _Int_Count.ToString() + ")";
                            _Ctrl._Formulario = "T3.Frm_Busqueda2";
                            _Ctrl._FormularioMdi = _Frm_MdiParent;
                            _Ctrl._Parametros = new object[] { 85 };
                            _Ctrl.Dock = DockStyle.Top;
                            myArray[0] = _Ctrl;
                            this.Invoke(new MyDelegate_Ctrl_Tabs(DelegateMethod_Ctrl_Tabs), myArray);
                            _Int_106 = _Int_Count;
                        }
                    }
                }
                //---------------------TABS NÚMERO 106
                //---------------------------------------------------------------------------------------------------------
                //---------------------TABS NÚMERO 107
                _Str_expression = "ctabs = 107";
                _Drow_found = _Ds_FrmTabs.Tables[0].Select(_Str_expression);
                if (_Drow_found.Length > 0)
                {
                    _Str_TabActual = "RECEPCIONES APROBADAS";
                    _Int_Count = 0;
                    _Str_Sql = "SELECT count(cidrecepcion) " +
"FROM TRECEPCIONM INNER JOIN " +
"TPROVEEDOR ON TRECEPCIONM.cproveedor = TPROVEEDOR.cproveedor " +
"WHERE (TRECEPCIONM.cgroupcomp = '" + Frm_Padre._Str_GroupComp + "') AND (TPROVEEDOR.cdelete = 0) AND (TRECEPCIONM.ccerrada = 0) AND (TRECEPCIONM.ccargfactura = 1) AND (TRECEPCIONM.cevaluado = 0)";
                    _Ds_AuxTabs = _Mtd_GetDataSet(_Str_Sql);
                    if (Convert.ToString(_Ds_AuxTabs.Tables[0].Rows[0][0]) != "")
                    {
                        _Int_Count = Convert.ToInt32(_Ds_AuxTabs.Tables[0].Rows[0][0]);
                    }
                    if (_Int_Count != _Int_107)
                    {
                        object[] myArray = new object[1];
                        if (_Int_Count > _Int_107)
                        { _Bol_SwTimbre = true; }
                        if (_Pnl_Contenedor.Controls.Find("_Ctrl107", false).Length > 0)
                        {
                            myArray[0] = ((_Ctrl_Tabs)(_Pnl_Contenedor.Controls.Find("_Ctrl107", false)[0]));
                            this.Invoke(new MyDelegate_Ctrl_Tabs_Del(DelegateMethod_Ctrl_Tabs_Del), myArray);
                            _Int_107 = _Int_Count;
                        }
                        if (_Int_Count > 0)
                        {
                            _Ctrl_Tabs _Ctrl = new _Ctrl_Tabs();
                            _Ctrl.Name = "_Ctrl107";
                            _Ctrl._Descripcion = _Str_TabActual + "(" + _Int_Count.ToString() + ")";
                            _Ctrl._Formulario = "T3.Frm_Busqueda2";
                            _Ctrl._FormularioMdi = _Frm_MdiParent;
                            _Ctrl._Parametros = new object[] { 86 };
                            _Ctrl.Dock = DockStyle.Top;
                            myArray[0] = _Ctrl;
                            this.Invoke(new MyDelegate_Ctrl_Tabs(DelegateMethod_Ctrl_Tabs), myArray);
                            _Int_107 = _Int_Count;
                        }
                    }
                }
                //---------------------TABS NÚMERO 107
                //---------------------------------------------------------------------------------------------------------
                //---------------------TABS NÚMERO 108
                _Str_expression = "ctabs = 108";
                _Drow_found = _Ds_FrmTabs.Tables[0].Select(_Str_expression);
                if (_Drow_found.Length > 0)
                {
                    _Str_TabActual = "REPORTES UNITICKET PENDIENTE";
                    _Int_Count = 0;
                    // INICIO --- actualiza la tabla de empleados spi, utilizando el 'retraso' de cada 4 horas, sólo si el usuario es local
                    if (!CLASES._Cls_Conexion._Bol_UsuarioRemoto)
                    {
                        CLASES._Cls_Empleados_SPI _Cls_Empleados_SPI = new CLASES._Cls_Empleados_SPI();
                        _Cls_Empleados_SPI._Mtd_ActualizarTablaEmpleadosSPI(false, false, true);
                    }
                    // FIN --- actualiza la tabla de empleados spi, utilizando el 'retraso' de cada 4 horas
                    _Str_Sql = "SELECT COUNT(ccedula) FROM VST_EMPLEADOS_SPI_UNITICKET WHERE ((cingreso_reportado = 'NO') OR (cegreso_reportado = 'NO' AND cfecha_egreso <> '')) AND ccompany = '" + Frm_Padre._Str_Comp + "'";
                    _Ds_AuxTabs = _Mtd_GetDataSet(_Str_Sql);
                    if (Convert.ToString(_Ds_AuxTabs.Tables[0].Rows[0][0]) != "")
                    {
                        _Int_Count = Convert.ToInt32(_Ds_AuxTabs.Tables[0].Rows[0][0]);
                    }
                    if (_Int_Count != _Int_108)
                    {
                        object[] myArray = new object[1];
                        if (_Int_Count > _Int_108)
                        { _Bol_SwTimbre = true; }
                        if (_Pnl_Contenedor.Controls.Find("_Ctrl108", false).Length > 0)
                        {
                            myArray[0] = ((_Ctrl_Tabs)(_Pnl_Contenedor.Controls.Find("_Ctrl108", false)[0]));
                            this.Invoke(new MyDelegate_Ctrl_Tabs_Del(DelegateMethod_Ctrl_Tabs_Del), myArray);
                            _Int_108 = _Int_Count;
                        }
                        if (_Int_Count > 0)
                        {
                            _Ctrl_Tabs _Ctrl = new _Ctrl_Tabs();
                            _Ctrl.Name = "_Ctrl108";
                            _Ctrl._Descripcion = _Str_TabActual + "(" + _Int_Count.ToString() + ")";
                            _Ctrl._Formulario = "T3.Frm_Uniticket";
                            _Ctrl._FormularioMdi = _Frm_MdiParent;
                            _Ctrl._Parametros = null;
                            _Ctrl.Dock = DockStyle.Top;
                            myArray[0] = _Ctrl;
                            this.Invoke(new MyDelegate_Ctrl_Tabs(DelegateMethod_Ctrl_Tabs), myArray);
                            _Int_108 = _Int_Count;
                        }
                    }
                }
                //---------------------TABS NÚMERO 108
                //---------------------------------------------------------------------------------------------------------
                //---------------------TABS NÚMERO 109
                _Str_expression = "ctabs = 109";
                _Drow_found = _Ds_FrmTabs.Tables[0].Select(_Str_expression);
                if (_Drow_found.Length > 0)
                {
                    if (myUtilidad._Mtd_ObtenerUsuarioFirma(Frm_Padre._Str_Use) == "1" & myUtilidad._Mtd_UsuarioProceso(Frm_Padre._Str_Use, "F_N2_ANULFACTURACXP"))
                    {
                        _Str_TabActual = "NDP ANULADAS POR APROBAR CxP ";
                        _Int_Count = 0;
                        _Str_Sql = "SELECT COUNT(VST_FACTURA_ANUL_CXP.ccompany) FROM VST_FACTURA_ANUL_CXP INNER JOIN TCONFIGCXP ON VST_FACTURA_ANUL_CXP.ccompany=TCONFIGCXP.ccompany AND VST_FACTURA_ANUL_CXP.ctipodocument=TCONFIGCXP.ctipodocndp WHERE VST_FACTURA_ANUL_CXP.cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND VST_FACTURA_ANUL_CXP.ccompany='" + Frm_Padre._Str_Comp + "' AND cestatusfirma=1 AND (cidcomprobanul<>'0' AND NOT cidcomprobanul IS NULL)";
                        _Ds_AuxTabs = _Mtd_GetDataSet(_Str_Sql);
                        if (Convert.ToString(_Ds_AuxTabs.Tables[0].Rows[0][0]) != "")
                        {
                            _Int_Count = Convert.ToInt32(_Ds_AuxTabs.Tables[0].Rows[0][0]);
                        }
                        if (_Int_Count != _Int_109)
                        {
                            object[] myArray = new object[1];
                            if (_Int_Count > _Int_109)
                            { _Bol_SwTimbre = true; }
                            if (_Pnl_Contenedor.Controls.Find("_Ctrl109", false).Length > 0)
                            {
                                myArray[0] = ((_Ctrl_Tabs)(_Pnl_Contenedor.Controls.Find("_Ctrl109", false)[0]));
                                this.Invoke(new MyDelegate_Ctrl_Tabs_Del(DelegateMethod_Ctrl_Tabs_Del), myArray);
                                _Int_109 = _Int_Count;
                            }
                            if (_Int_Count > 0)
                            {
                                _Ctrl_Tabs _Ctrl = new _Ctrl_Tabs();
                                _Ctrl.Name = "_Ctrl109";
                                _Ctrl._Descripcion = _Str_TabActual + "(" + _Int_Count.ToString() + ")";
                                _Ctrl._Formulario = "T3.Frm_AnulacionFacturaCxP";
                                _Ctrl._FormularioMdi = _Frm_MdiParent;
                                _Ctrl._Parametros = new object[] { "NDP", true };
                                _Ctrl.Dock = DockStyle.Top;
                                myArray[0] = _Ctrl;
                                this.Invoke(new MyDelegate_Ctrl_Tabs(DelegateMethod_Ctrl_Tabs), myArray);
                                _Int_109 = _Int_Count;
                            }
                        }
                    }
                }
                //---------------------TABS NÚMERO 109
                //---------------------------------------------------------------------------------------------------------
                //---------------------TABS NÚMERO 110
                _Str_expression = "ctabs = 110";
                _Drow_found = _Ds_FrmTabs.Tables[0].Select(_Str_expression);
                if (_Drow_found.Length > 0)
                {
                    if (myUtilidad._Mtd_ObtenerUsuarioFirma(Frm_Padre._Str_Use) == "1" & myUtilidad._Mtd_UsuarioProceso(Frm_Padre._Str_Use, "F_N2_ANULFACTURACXP"))
                    {
                        _Str_TabActual = "NCP ANULADAS POR APROBAR CxP ";
                        _Int_Count = 0;
                        _Str_Sql = "SELECT COUNT(VST_FACTURA_ANUL_CXP.ccompany) FROM VST_FACTURA_ANUL_CXP INNER JOIN TCONFIGCXP ON VST_FACTURA_ANUL_CXP.ccompany=TCONFIGCXP.ccompany AND VST_FACTURA_ANUL_CXP.ctipodocument=TCONFIGCXP.ctipodocncp WHERE VST_FACTURA_ANUL_CXP.cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND VST_FACTURA_ANUL_CXP.ccompany='" + Frm_Padre._Str_Comp + "' AND cestatusfirma=1 AND (cidcomprobanul<>'0' AND NOT cidcomprobanul IS NULL)";
                        _Ds_AuxTabs = _Mtd_GetDataSet(_Str_Sql);
                        if (Convert.ToString(_Ds_AuxTabs.Tables[0].Rows[0][0]) != "")
                        {
                            _Int_Count = Convert.ToInt32(_Ds_AuxTabs.Tables[0].Rows[0][0]);
                        }
                        if (_Int_Count != _Int_110)
                        {
                            object[] myArray = new object[1];
                            if (_Int_Count > _Int_110)
                            { _Bol_SwTimbre = true; }
                            if (_Pnl_Contenedor.Controls.Find("_Ctrl110", false).Length > 0)
                            {
                                myArray[0] = ((_Ctrl_Tabs)(_Pnl_Contenedor.Controls.Find("_Ctrl110", false)[0]));
                                this.Invoke(new MyDelegate_Ctrl_Tabs_Del(DelegateMethod_Ctrl_Tabs_Del), myArray);
                                _Int_110 = _Int_Count;
                            }
                            if (_Int_Count > 0)
                            {
                                _Ctrl_Tabs _Ctrl = new _Ctrl_Tabs();
                                _Ctrl.Name = "_Ctrl110";
                                _Ctrl._Descripcion = _Str_TabActual + "(" + _Int_Count.ToString() + ")";
                                _Ctrl._Formulario = "T3.Frm_AnulacionFacturaCxP";
                                _Ctrl._FormularioMdi = _Frm_MdiParent;
                                _Ctrl._Parametros = new object[] { "NCP", true };
                                _Ctrl.Dock = DockStyle.Top;
                                myArray[0] = _Ctrl;
                                this.Invoke(new MyDelegate_Ctrl_Tabs(DelegateMethod_Ctrl_Tabs), myArray);
                                _Int_110 = _Int_Count;
                            }
                        }
                    }
                }
                ////---------------------TABS NÚMERO 110
                ////---------------------------------------------------------------------------------------------------------
                ////---------------------TABS NÚMERO _Int_ControlFalla-------------SALE PARA TODOS LOS USUARIOS
                //_Str_TabActual = "CONSSA - CONTROL DE FALLAS";
                //_Int_Count = 0;
                ////_Str_Sql = "SELECT COUNT(id) FROM VST_T3_REPORTEFALLAFULL WHERE cuser='" + Frm_Padre._Str_Use + "'";
                ////_Ds_AuxTabs = _Mtd_GetDataSetWebLocal(_Str_Sql);
                ////if (Convert.ToString(_Ds_AuxTabs.Tables[0].Rows[0][0]) != "")
                ////{
                ////    _Int_Count = Convert.ToInt32(_Ds_AuxTabs.Tables[0].Rows[0][0]);
                ////}
                //if (_Int_Count != _Int_ControlFalla)
                //{
                //    object[] myArray = new object[1];
                //    if (_Int_Count > _Int_ControlFalla)
                //    { _Bol_SwTimbre = true; }
                //    if (_Pnl_Contenedor.Controls.Find("_Ctrl_Int_ControlFalla", false).Length > 0)
                //    {
                //        myArray[0] = ((_Ctrl_Tabs)(_Pnl_Contenedor.Controls.Find("_Ctrl_Int_ControlFalla", false)[0]));
                //        this.Invoke(new MyDelegate_Ctrl_Tabs_Del(DelegateMethod_Ctrl_Tabs_Del), myArray);
                //        _Int_ControlFalla = _Int_Count;
                //    }
                //    if (_Int_Count >= 0)
                //    {
                //        _Ctrl_Tabs _Ctrl = new _Ctrl_Tabs();
                //        _Ctrl.Name = "_Ctrl_Int_ControlFalla";
                //        _Ctrl._Color = Color.Navy;
                //        //_Ctrl._Descripcion = "CONSSA - CONTROL DE FALLAS ( " + _Int_Count.ToString() + " )";
                //        _Ctrl._Descripcion = "CONSSA - CONTROL DE FALLAS";
                //        _Ctrl._Formulario = "T3.Frm_ConsultaSolicitudes";
                //        _Ctrl._FormularioMdi = _Frm_MdiParent;
                //        _Ctrl._Parametros = null;
                //        _Ctrl.Dock = DockStyle.Top;
                //        myArray[0] = _Ctrl;
                //        this.Invoke(new MyDelegate_Ctrl_Tabs(DelegateMethod_Ctrl_Tabs), myArray);
                //        _Int_ControlFalla = _Int_Count;
                //    }
                //}
                //---------------------TABS NÚMERO _Int_ControlFalla-------------SALE PARA TODOS LOS USUARIOS
                //---------------------------------------------------------------------------------------------------------
                //---------------------TABS NÚMERO 111
                _Str_expression = "ctabs = 111";
                _Drow_found = _Ds_FrmTabs.Tables[0].Select(_Str_expression);
                if (_Drow_found.Length > 0)
                {
                    _Str_TabActual = "PEDIDOS APROBADOS POR LA DIRECCIÓN FINANCIERA";
                    _Int_Count = 0;
                    _Str_Sql = "SELECT count(CPEDIDO) FROM TCOTPEDFACM INNER JOIN TCLIENTE ON TCOTPEDFACM.ccliente = TCLIENTE.ccliente INNER JOIN TVENDEDOR ON TCOTPEDFACM.ccompany = TVENDEDOR.ccompany AND TCOTPEDFACM.cvendedor = TVENDEDOR.cvendedor WHERE (TCOTPEDFACM.cstatus = 3) AND (TCLIENTE.cgroupcomp ='" + Frm_Padre._Str_GroupComp + "') AND cexclimaprob='1' and isnull(caprobadocredito,0)=0";
                    //_Str_Sql = "SELECT COUNT(CPEDIDO) from TCOTPEDFACM where cexclimaprob='1' AND CSTATUS='3'";
                    //_Str_Sql = "Select count(*) from TCLIENTE where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and exists(select ccliente from TCOTPEDFACM where ccompany='" + Frm_Padre._Str_Comp + "' and TCOTPEDFACM.ccliente=TCLIENTE.ccliente and cstatus='3') AND ISNULL(c_bloqueo_manual,0) = 0 AND cdelete='0'";
                    _Ds_AuxTabs = _Mtd_GetDataSet(_Str_Sql);
                    if (_Ds_AuxTabs.Tables[0].Rows.Count > 0)
                    {
                        if (Convert.ToString(_Ds_AuxTabs.Tables[0].Rows[0][0]) != "")
                        {
                            _Int_Count = Convert.ToInt32(_Ds_AuxTabs.Tables[0].Rows[0][0]);
                        }
                    }
                    if (_Int_Count != _Int_111)
                    {
                        object[] myArray = new object[1];
                        if (_Int_Count > _Int_111)
                        { _Bol_SwTimbre = true; }
                        if (_Pnl_Contenedor.Controls.Find("_Ctrl111", false).Length > 0)
                        {
                            myArray[0] = ((_Ctrl_Tabs)(_Pnl_Contenedor.Controls.Find("_Ctrl111", false)[0]));
                            this.Invoke(new MyDelegate_Ctrl_Tabs_Del(DelegateMethod_Ctrl_Tabs_Del), myArray);
                            _Int_111 = _Int_Count;
                        }
                        if (_Int_Count > 0)
                        {
                            _Ctrl_Tabs _Ctrl = new _Ctrl_Tabs();
                            _Ctrl.Name = "_Ctrl111";
                            _Ctrl._Descripcion = "PEDIDOS APROBADOS POR LA DIRECCIÓN ( " + _Int_Count.ToString() + " )";
                            _Ctrl._Formulario = "T3.Frm_EstatusClientes";
                            _Ctrl._FormularioMdi = _Frm_MdiParent;
                            _Ctrl._Parametros = new object[] { null };
                            _Ctrl.Dock = DockStyle.Top;
                            myArray[0] = _Ctrl;
                            this.Invoke(new MyDelegate_Ctrl_Tabs(DelegateMethod_Ctrl_Tabs), myArray);
                            _Int_111 = _Int_Count;
                        }
                    }
                }
                //---------------------TABS NÚMERO 111---------------------------------------------------------------------
                //---------------------------------------------------------------------------------------------------------
                //---------------------TABS NÚMERO 112---------------------------------------------------------------------
                _Str_expression = "ctabs = 112";
                _Drow_found = _Ds_FrmTabs.Tables[0].Select(_Str_expression);
                if (_Drow_found.Length > 0)
                {
                    _Str_TabActual = "LOTES NO AUTORIZADOS";
                    _Int_Count = 0;
                    _Str_Sql = "SELECT COUNT(cidproductod) AS Lotes FROM VST_CONSULTASLOTES GROUP BY cautorizado HAVING (cautorizado = 0)";
                    //_Str_Sql = "SELECT COUNT(CPEDIDO) from TCOTPEDFACM where cexclimaprob='1' AND CSTATUS='3'";
                    //_Str_Sql = "Select count(*) from TCLIENTE where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and exists(select ccliente from TCOTPEDFACM where ccompany='" + Frm_Padre._Str_Comp + "' and TCOTPEDFACM.ccliente=TCLIENTE.ccliente and cstatus='3') AND ISNULL(c_bloqueo_manual,0) = 0 AND cdelete='0'";
                   _Ds_AuxTabs = _Mtd_GetDataSet(_Str_Sql);
                    if (_Ds_AuxTabs.Tables[0].Rows.Count > 0)
                    {
                        if (Convert.ToString(_Ds_AuxTabs.Tables[0].Rows[0][0]) != "")
                        {
                            _Int_Count = Convert.ToInt32(_Ds_AuxTabs.Tables[0].Rows[0][0]);
                        }
                    }
                    if (_Int_Count != _Int_112)
                    {
                        object[] myArray = new object[1];
                        if (_Int_Count > _Int_112)
                        { _Bol_SwTimbre = true; }
                        if (_Pnl_Contenedor.Controls.Find("_Ctrl112", false).Length > 0)
                        {
                            myArray[0] = ((_Ctrl_Tabs)(_Pnl_Contenedor.Controls.Find("_Ctrl112", false)[0]));
                            this.Invoke(new MyDelegate_Ctrl_Tabs_Del(DelegateMethod_Ctrl_Tabs_Del), myArray);
                            _Int_112 = _Int_Count;
                        }
                        if (_Int_Count > 0)
                        {
                            _Ctrl_Tabs _Ctrl = new _Ctrl_Tabs();
                            _Ctrl.Name = "_Ctrl112";
                            _Ctrl._Descripcion = "LOTES NO AUTORIZADOS ( " + _Int_Count.ToString() + " )";
                            _Ctrl._Formulario = "T3.Frm_AutorizacionLote";
                            _Ctrl._FormularioMdi = _Frm_MdiParent;
                            _Ctrl._Parametros = new object[] { true };
                            _Ctrl.Dock = DockStyle.Top;
                            myArray[0] = _Ctrl;
                            this.Invoke(new MyDelegate_Ctrl_Tabs(DelegateMethod_Ctrl_Tabs), myArray);
                            _Int_112 = _Int_Count;
                        }
                    }
                }
                //---------------------TABS NÚMERO 112---------------------------------------------------------------------
                //---------------------------------------------------------------------------------------------------------
                //---------------------TABS NÚMERO 113---------------------------------------------------------------------
                _Str_expression = "ctabs = 113";
                _Drow_found = _Ds_FrmTabs.Tables[0].Select(_Str_expression);
                if (_Drow_found.Length > 0)
                {
                    if (myUtilidad._Mtd_ObtenerUsuarioFirma(Frm_Padre._Str_Use) == "1" & myUtilidad._Mtd_UsuarioProceso(Frm_Padre._Str_Use, "F_N1_ND_CXP"))
                    {
                        _Str_TabActual = "ND POR GENERAR POR DIFERENCIA DE PMV";
                        _Int_Count = 0;
                        _Str_Sql = "SELECT COUNT(DISTINCT cidnotrecepc) FROM VST_PMVNOTIFICADOR WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND ISNULL(cndgenerado,0)=0";
                        _Ds_AuxTabs = _Mtd_GetDataSet(_Str_Sql);
                        if (Convert.ToString(_Ds_AuxTabs.Tables[0].Rows[0][0]) != "")
                        {
                            _Int_Count = Convert.ToInt32(_Ds_AuxTabs.Tables[0].Rows[0][0]);
                        }
                        if (_Int_Count != _Int_113)
                        {
                            object[] myArray = new object[1];
                            if (_Int_Count > _Int_113)
                            { _Bol_SwTimbre = true; }
                            if (_Pnl_Contenedor.Controls.Find("_Ctrl113", false).Length > 0)
                            {
                                myArray[0] = ((_Ctrl_Tabs)(_Pnl_Contenedor.Controls.Find("_Ctrl113", false)[0]));
                                this.Invoke(new MyDelegate_Ctrl_Tabs_Del(DelegateMethod_Ctrl_Tabs_Del), myArray);
                                _Int_113 = _Int_Count;
                            }
                            if (_Int_Count > 0)
                            {
                                _Ctrl_Tabs _Ctrl = new _Ctrl_Tabs();
                                _Ctrl.Name = "_Ctrl113";
                                _Ctrl._Descripcion = _Str_TabActual + "(" + _Int_Count.ToString() + ")";
                                _Ctrl._Formulario = "T3.Frm_DifPmvComp";
                                _Ctrl._FormularioMdi = _Frm_MdiParent;
                                _Ctrl._Parametros = null;
                                _Ctrl.Dock = DockStyle.Top;
                                myArray[0] = _Ctrl;
                                this.Invoke(new MyDelegate_Ctrl_Tabs(DelegateMethod_Ctrl_Tabs), myArray);
                                _Int_113 = _Int_Count;
                            }
                        }
                    }
                }
                //---------------------TABS NÚMERO 113---------------------------------------------------------------------
                //---------------------------------------------------------------------------------------------------------
                //---------------------TABS NÚMERO 114---------------------------------------------------------------------
                _Str_expression = "ctabs = 114";
                _Drow_found = _Ds_FrmTabs.Tables[0].Select(_Str_expression);
                if (_Drow_found.Length > 0)
                {
                    _Str_TabActual = "PEDIDOS AUTORIZADOS POR PREFACTURAR";
                    _Int_Count = 0;
                    _Str_Sql = "SELECT COUNT(cpedido) FROM TCOTPEDFACM WHERE CSTATUS='3' AND caprobadocredito='1'";
                    _Ds_AuxTabs = _Mtd_GetDataSet(_Str_Sql);
                    if (Convert.ToString(_Ds_AuxTabs.Tables[0].Rows[0][0]) != "")
                    {
                        _Int_Count = Convert.ToInt32(_Ds_AuxTabs.Tables[0].Rows[0][0]);
                    }
                    if (_Int_Count != _Int_114)
                    {
                        object[] myArray = new object[1];
                        if (_Int_Count > _Int_114)
                        { _Bol_SwTimbre = true; }
                        if (_Pnl_Contenedor.Controls.Find("_Ctrl114", false).Length > 0)
                        {
                            myArray[0] = ((_Ctrl_Tabs)(_Pnl_Contenedor.Controls.Find("_Ctrl114", false)[0]));
                            this.Invoke(new MyDelegate_Ctrl_Tabs_Del(DelegateMethod_Ctrl_Tabs_Del), myArray);
                            _Int_114 = _Int_Count;
                        }
                        if (_Int_Count > 0)
                        {
                            _Ctrl_Tabs _Ctrl = new _Ctrl_Tabs();
                            _Ctrl.Name = "_Ctrl114";
                            _Ctrl._Descripcion = _Str_TabActual + "(" + _Int_Count.ToString() + ")";
                            _Ctrl._Formulario = "T3.Frm_PedidosAutCredito";
                            _Ctrl._FormularioMdi = _Frm_MdiParent;
                            _Ctrl._Parametros = null;
                            _Ctrl.Dock = DockStyle.Top;
                            myArray[0] = _Ctrl;
                            this.Invoke(new MyDelegate_Ctrl_Tabs(DelegateMethod_Ctrl_Tabs), myArray);
                            _Int_114 = _Int_Count;
                        }
                    }
                }
                //---------------------------------------------------------------------------------------------------------
                //---------------------TABS NÚMERO 115---------------------------------------------------------------------
                _Str_expression = "ctabs = 115";
                _Drow_found = _Ds_FrmTabs.Tables[0].Select(_Str_expression);
                if (_Drow_found.Length > 0)
                {
                    _Str_TabActual = "CONCILIACIONES POR IMPRIMIR";
                    _Int_Count = 0;
                    _Str_Sql = "SELECT COUNT(cidconciliacion) FROM TCONCILIACION WHERE CIMPRESO='0' AND CCOMPANY='" + Frm_Padre._Str_Comp + "' AND cfinalizado=1";
                    _Ds_AuxTabs = _Mtd_GetDataSet(_Str_Sql);
                    if (Convert.ToString(_Ds_AuxTabs.Tables[0].Rows[0][0]) != "")
                    {
                        _Int_Count = Convert.ToInt32(_Ds_AuxTabs.Tables[0].Rows[0][0]);
                    }
                    if (_Int_Count != _Int_115)
                    {
                        object[] myArray = new object[1];
                        if (_Int_Count > _Int_115)
                        { _Bol_SwTimbre = true; }
                        if (_Pnl_Contenedor.Controls.Find("_Ctrl115", false).Length > 0)
                        {
                            myArray[0] = ((_Ctrl_Tabs)(_Pnl_Contenedor.Controls.Find("_Ctrl115", false)[0]));
                            this.Invoke(new MyDelegate_Ctrl_Tabs_Del(DelegateMethod_Ctrl_Tabs_Del), myArray);
                            _Int_115 = _Int_Count;
                        }
                        if (_Int_Count > 0)
                        {
                            _Ctrl_Tabs _Ctrl = new _Ctrl_Tabs();
                            _Ctrl.Name = "_Ctrl115";
                            _Ctrl._Descripcion = _Str_TabActual + "(" + _Int_Count.ToString() + ")";
                            _Ctrl._Formulario = "T3.Frm_ConciliacionBancariaV2";
                            _Ctrl._FormularioMdi = _Frm_MdiParent;
                            _Ctrl._Parametros = new object[] { "1" };
                            _Ctrl.Dock = DockStyle.Top;
                            myArray[0] = _Ctrl;
                            this.Invoke(new MyDelegate_Ctrl_Tabs(DelegateMethod_Ctrl_Tabs), myArray);
                            _Int_115 = _Int_Count;
                        }
                    }
                }
                //---------------------------------------------------------------------------------------------------------
                //---------------------TABS NÚMERO 116---------------------------------------------------------------------
                _Str_expression = "ctabs = 116";
                _Drow_found = _Ds_FrmTabs.Tables[0].Select(_Str_expression);
                if (_Drow_found.Length > 0)
                {
                    _Str_TabActual = "AVISO DE COBRO POR IMPRIMIR";
                    _Int_Count = 0;
                    _Str_Sql = "SELECT COUNT(ccodavisocob) FROM TAVISOCOBM WHERE CIMPRESO='0' AND CCOMPANY='" + Frm_Padre._Str_Comp + "'";
                    _Ds_AuxTabs = _Mtd_GetDataSet(_Str_Sql);
                    if (Convert.ToString(_Ds_AuxTabs.Tables[0].Rows[0][0]) != "")
                    {
                        _Int_Count = Convert.ToInt32(_Ds_AuxTabs.Tables[0].Rows[0][0]);
                    }
                    if (_Int_Count != _Int_116)
                    {
                        object[] myArray = new object[1];
                        if (_Int_Count > _Int_116)
                        { _Bol_SwTimbre = true; }
                        if (_Pnl_Contenedor.Controls.Find("_Ctrl116", false).Length > 0)
                        {
                            myArray[0] = ((_Ctrl_Tabs)(_Pnl_Contenedor.Controls.Find("_Ctrl116", false)[0]));
                            this.Invoke(new MyDelegate_Ctrl_Tabs_Del(DelegateMethod_Ctrl_Tabs_Del), myArray);
                            _Int_115 = _Int_Count;
                        }
                        if (_Int_Count > 0)
                        {
                            _Ctrl_Tabs _Ctrl = new _Ctrl_Tabs();
                            _Ctrl.Name = "_Ctrl116";
                            _Ctrl._Descripcion = _Str_TabActual + "(" + _Int_Count.ToString() + ")";
                            _Ctrl._Formulario = "T3.Frm_AvisoCobro";
                            _Ctrl._FormularioMdi = _Frm_MdiParent;
                            _Ctrl._Parametros = new object[] { 2,0 };
                            _Ctrl.Dock = DockStyle.Top;
                            myArray[0] = _Ctrl;
                            this.Invoke(new MyDelegate_Ctrl_Tabs(DelegateMethod_Ctrl_Tabs), myArray);
                            _Int_116 = _Int_Count;
                        }
                    }
                }

                //---------------------TABS NÚMERO 117---------------------------------------------------------------------
                _Str_expression = "ctabs = 117";
                _Drow_found = _Ds_FrmTabs.Tables[0].Select(_Str_expression);
                if (_Drow_found.Length > 0)
                {
                    _Str_TabActual = "CÁLCULO AUTOMÁTICO DEL LÍMITE DE CRÉDITO";
                    _Int_Count = 0;
                    _Str_Sql = "SELECT COUNT(generacionId) FROM TGENLIMCREDM WHERE generado=1;";
                    _Ds_AuxTabs = _Mtd_GetDataSet(_Str_Sql);
                    if (Convert.ToString(_Ds_AuxTabs.Tables[0].Rows[0][0]) != "")
                    {
                        _Int_Count = Convert.ToInt32(_Ds_AuxTabs.Tables[0].Rows[0][0]);
                    }
                    if (_Int_Count != _Int_117)
                    {
                        object[] myArray = new object[1];
                        if (_Int_Count > _Int_117)
                        { _Bol_SwTimbre = true; }
                        if (_Pnl_Contenedor.Controls.Find("_Ctrl117", false).Length > 0)
                        {
                            myArray[0] = ((_Ctrl_Tabs)(_Pnl_Contenedor.Controls.Find("_Ctrl117", false)[0]));
                            this.Invoke(new MyDelegate_Ctrl_Tabs_Del(DelegateMethod_Ctrl_Tabs_Del), myArray);
                            _Int_117 = _Int_Count;
                        }
                        if (_Int_Count > 0)
                        {
                            _Ctrl_Tabs _Ctrl = new _Ctrl_Tabs();
                            _Ctrl.Name = "_Ctrl117";
                            _Ctrl._Descripcion = "CÁLCULO AUTOMÁTICO DEL LÍMITE DE CRÉDITO  ( " + _Int_Count.ToString() + " )";
                            _Ctrl._Formulario = "T3.Frm_ConsultaMultiple";
                            _Ctrl._FormularioMdi = _Frm_MdiParent;
                            _Ctrl._Parametros = new object[] { _Enu_TiposConsultas.LimiteCreditoClientes };
                            _Ctrl.Dock = DockStyle.Top;
                            myArray[0] = _Ctrl;
                            this.Invoke(new MyDelegate_Ctrl_Tabs(DelegateMethod_Ctrl_Tabs), myArray);
                            _Int_37 = _Int_Count;
                        }
                    }
                }
                //---------------------TABS NÚMERO 117
                //---------------------------------------------------------------------------------------------------------
                //---------------------TABS NÚMERO 118
                _Str_expression = "ctabs = 118";
                _Drow_found = _Ds_FrmTabs.Tables[0].Select(_Str_expression);
                if (_Drow_found.Length > 0)
                {
                    _Str_TabActual = "N.C. INTERCOMPAÑÍAS POR IMPRIMIR";
                    _Int_Count = 0;
                    _Str_Sql = "SELECT count(*) from TNOTACREDICC INNER JOIN TICRELAPROCLI ON TNOTACREDICC.ccliente=TICRELAPROCLI.ccliente where TNOTACREDICC.cdelete='0' and ccompany='" + Frm_Padre._Str_Comp + "' and TNOTACREDICC.cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and cexedentecobro<>1 and cimpresa='0' and cactivo='0' AND (cestatusfirma=2 OR cidnotrecepc>0) AND ISNULL(TICRELAPROCLI.cdelete,0)=0";
                    _Ds_AuxTabs = _Mtd_GetDataSet(_Str_Sql);
                    if (Convert.ToString(_Ds_AuxTabs.Tables[0].Rows[0][0]) != "")
                    {
                        _Int_Count = Convert.ToInt32(_Ds_AuxTabs.Tables[0].Rows[0][0]);
                    }
                    if (_Int_Count != _Int_118)
                    {
                        object[] myArray = new object[1];
                        if (_Int_Count > _Int_118)
                        { _Bol_SwTimbre = true; }
                        if (_Pnl_Contenedor.Controls.Find("_Ctrl118", false).Length > 0)
                        {
                            myArray[0] = ((_Ctrl_Tabs)(_Pnl_Contenedor.Controls.Find("_Ctrl118", false)[0]));
                            this.Invoke(new MyDelegate_Ctrl_Tabs_Del(DelegateMethod_Ctrl_Tabs_Del), myArray);
                            _Int_118 = _Int_Count;
                        }
                        if (_Int_Count > 0)
                        {
                            _Ctrl_Tabs _Ctrl = new _Ctrl_Tabs();
                            _Ctrl.Name = "_Ctrl118";
                            _Ctrl._Descripcion = _Str_TabActual + "(" + _Int_Count.ToString() + ")";
                            _Ctrl._Formulario = "T3.Frm_Busqueda2";
                            _Ctrl._FormularioMdi = _Frm_MdiParent;
                            _Ctrl._Parametros = new object[] { 89 };
                            _Ctrl.Dock = DockStyle.Top;
                            myArray[0] = _Ctrl;
                            this.Invoke(new MyDelegate_Ctrl_Tabs(DelegateMethod_Ctrl_Tabs), myArray);
                            _Int_118 = _Int_Count;
                        }
                    }
                }
                //---------------------TABS NÚMERO 118
                //---------------------------------------------------------------------------------------------------------
                //---------------------TABS NÚMERO 119
                _Str_expression = "ctabs = 119";
                _Drow_found = _Ds_FrmTabs.Tables[0].Select(_Str_expression);
                if (_Drow_found.Length > 0)
                {
                    _Str_TabActual = "N.D. INTERCOMPAÑÍAS POR IMPRIMIR";
                    _Int_Count = 0;
                    _Str_Sql = "Select count(cidnotadebitocc) from TNOTADEBICC INNER JOIN TICRELAPROCLI ON TNOTADEBICC.ccliente=TICRELAPROCLI.ccliente where TNOTADEBICC.cdelete='0' and ccompany='" + Frm_Padre._Str_Comp + "' and TNOTADEBICC.cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and cimpresa='0' and cactivo='0' AND cestatusfirma=2 AND ISNULL(TICRELAPROCLI.cdelete,0)=0";
                    _Ds_AuxTabs = _Mtd_GetDataSet(_Str_Sql);
                    if (Convert.ToString(_Ds_AuxTabs.Tables[0].Rows[0][0]) != "")
                    {
                        _Int_Count = Convert.ToInt32(_Ds_AuxTabs.Tables[0].Rows[0][0]);
                    }
                    if (_Int_Count != _Int_119)
                    {
                        object[] myArray = new object[1];
                        if (_Int_Count > _Int_119)
                        { _Bol_SwTimbre = true; }
                        if (_Pnl_Contenedor.Controls.Find("_Ctrl119", false).Length > 0)
                        {
                            myArray[0] = ((_Ctrl_Tabs)(_Pnl_Contenedor.Controls.Find("_Ctrl119", false)[0]));
                            this.Invoke(new MyDelegate_Ctrl_Tabs_Del(DelegateMethod_Ctrl_Tabs_Del), myArray);
                            _Int_119 = _Int_Count;
                        }
                        if (_Int_Count > 0)
                        {
                            _Ctrl_Tabs _Ctrl = new _Ctrl_Tabs();
                            _Ctrl.Name = "_Ctrl119";
                            _Ctrl._Descripcion = _Str_TabActual + "(" + _Int_Count.ToString() + ")";
                            _Ctrl._Formulario = "T3.Frm_Busqueda2";
                            _Ctrl._FormularioMdi = _Frm_MdiParent;
                            _Ctrl._Parametros = new object[] { 90 };
                            _Ctrl.Dock = DockStyle.Top;
                            myArray[0] = _Ctrl;
                            this.Invoke(new MyDelegate_Ctrl_Tabs(DelegateMethod_Ctrl_Tabs), myArray);
                            _Int_119 = _Int_Count;
                        }
                    }
                }
                //---------------------TABS NÚMERO 119
                //---------------------------------------------------------------------------------------------------------
                //---------------------TABS NÚMERO 120
                _Str_expression = "ctabs = 120";
                _Drow_found = _Ds_FrmTabs.Tables[0].Select(_Str_expression);
                if (_Drow_found.Length > 0)
                {
                    _Str_TabActual = "COBRANZAS INTERCOMPAÑÍA POR APROBAR";
                    _Int_Count = 0;
                    _Str_Sql = "";
                    _Str_Sql += "SELECT ";
                    _Str_Sql += "COUNT(cidiccobram) ";
                    _Str_Sql += "FROM TICCOBRAM ";
                    _Str_Sql += "WHERE ";
                    _Str_Sql += "cdelete=0 ";
                    _Str_Sql += "AND ";
                    _Str_Sql += "ccompany='" + Frm_Padre._Str_Comp + "' ";
                    _Str_Sql += "AND ";
                    _Str_Sql += "cestado=0 ";
                    _Str_Sql += "AND ";
                    _Str_Sql += "ISNULL(cdelete,0)=0";
                    _Ds_AuxTabs = _Mtd_GetDataSet(_Str_Sql);
                    if (Convert.ToString(_Ds_AuxTabs.Tables[0].Rows[0][0]) != "")
                    {
                        _Int_Count = Convert.ToInt32(_Ds_AuxTabs.Tables[0].Rows[0][0]);
                    }
                    if (_Int_Count != _Int_120)
                    {
                        object[] myArray = new object[1];
                        if (_Int_Count > _Int_120)
                        { _Bol_SwTimbre = true; }
                        if (_Pnl_Contenedor.Controls.Find("_Ctrl120", false).Length > 0)
                        {
                            myArray[0] = ((_Ctrl_Tabs)(_Pnl_Contenedor.Controls.Find("_Ctrl120", false)[0]));
                            this.Invoke(new MyDelegate_Ctrl_Tabs_Del(DelegateMethod_Ctrl_Tabs_Del), myArray);
                            _Int_120 = _Int_Count;
                        }
                        if (_Int_Count > 0)
                        {
                            _Ctrl_Tabs _Ctrl = new _Ctrl_Tabs();
                            _Ctrl.Name = "_Ctrl120";
                            _Ctrl._Descripcion = _Str_TabActual + "(" + _Int_Count.ToString() + ")";
                            _Ctrl._Formulario = "T3.Frm_IC_Cobranza";
                            _Ctrl._FormularioMdi = _Frm_MdiParent;
                            _Ctrl._Parametros = new object[] { 1 };
                            _Ctrl.Dock = DockStyle.Top;
                            myArray[0] = _Ctrl;
                            this.Invoke(new MyDelegate_Ctrl_Tabs(DelegateMethod_Ctrl_Tabs), myArray);
                            _Int_120 = _Int_Count;
                        }
                    }
                }
                //---------------------TABS NÚMERO 120
                //---------------------------------------------------------------------------------------------------------
                //---------------------TABS NÚMERO 121
                _Str_expression = "ctabs = 121";
                _Drow_found = _Ds_FrmTabs.Tables[0].Select(_Str_expression);
                if (_Drow_found.Length > 0)
                {
                    _Str_TabActual = "COBRANZAS INTERCOMPAÑÍA DEVUELTAS";
                    _Int_Count = 0;
                    _Str_Sql = "";
                    _Str_Sql += "SELECT ";
                    _Str_Sql += "COUNT(cidiccobram) ";
                    _Str_Sql += "FROM TICCOBRAM ";
                    _Str_Sql += "WHERE ";
                    _Str_Sql += "cdelete=0 ";
                    _Str_Sql += "AND ";
                    _Str_Sql += "ccompany='" + Frm_Padre._Str_Comp + "' ";
                    _Str_Sql += "AND ";
                    _Str_Sql += "cestado=2 ";
                    _Str_Sql += "AND ";
                    _Str_Sql += "ISNULL(cdelete,0)=0";
                    _Ds_AuxTabs = _Mtd_GetDataSet(_Str_Sql);
                    if (Convert.ToString(_Ds_AuxTabs.Tables[0].Rows[0][0]) != "")
                    {
                        _Int_Count = Convert.ToInt32(_Ds_AuxTabs.Tables[0].Rows[0][0]);
                    }
                    if (_Int_Count != _Int_121)
                    {
                        object[] myArray = new object[1];
                        if (_Int_Count > _Int_121)
                        { _Bol_SwTimbre = true; }
                        if (_Pnl_Contenedor.Controls.Find("_Ctrl121", false).Length > 0)
                        {
                            myArray[0] = ((_Ctrl_Tabs)(_Pnl_Contenedor.Controls.Find("_Ctrl121", false)[0]));
                            this.Invoke(new MyDelegate_Ctrl_Tabs_Del(DelegateMethod_Ctrl_Tabs_Del), myArray);
                            _Int_121 = _Int_Count;
                        }
                        if (_Int_Count > 0)
                        {
                            _Ctrl_Tabs _Ctrl = new _Ctrl_Tabs();
                            _Ctrl.Name = "_Ctrl121";
                            _Ctrl._Descripcion = _Str_TabActual + "(" + _Int_Count.ToString() + ")";
                            _Ctrl._Formulario = "T3.Frm_IC_Cobranza";
                            _Ctrl._FormularioMdi = _Frm_MdiParent;
                            _Ctrl._Parametros = new object[] { 3 };
                            _Ctrl.Dock = DockStyle.Top;
                            myArray[0] = _Ctrl;
                            this.Invoke(new MyDelegate_Ctrl_Tabs(DelegateMethod_Ctrl_Tabs), myArray);
                            _Int_120 = _Int_Count;
                        }
                    }
                }
                //---------------------TABS NÚMERO 121
                //---------------------------------------------------------------------------------------------------------
                //---------------------TABS NÚMERO 122
                _Str_expression = "ctabs = 122";
                _Drow_found = _Ds_FrmTabs.Tables[0].Select(_Str_expression);
                if (_Drow_found.Length > 0)
                {
                    _Str_TabActual = "CONCILIACIONES MANUALES POR APROBAR";
                    _Int_Count = 0;
                  //_Str_Sql = "SELECT COUNT(DISTINCT TCONCILIACION.cnumcuenta) FROM TCONCILIACION INNER JOIN TCONCILIACIOND_MANUAL ON TCONCILIACION.cidconciliacion=TCONCILIACIOND_MANUAL.cidconciliacion AND TCONCILIACION.ccompany=TCONCILIACIOND_MANUAL.ccompany WHERE TCONCILIACION.ccompany='" + Frm_Padre._Str_Comp + "'  AND ISNULL(TCONCILIACIOND_MANUAL.caprobado,0)=0";
                    _Str_Sql = "SELECT COUNT(DISTINCT TCONCILIACION.cnumcuenta) FROM TCONCILIACION INNER JOIN TCONCILIACIOND_MANUALV2 ON TCONCILIACION.cidconciliacion=TCONCILIACIOND_MANUALV2.cidconciliacion AND TCONCILIACION.ccompany=TCONCILIACIOND_MANUALV2.ccompany WHERE TCONCILIACION.ccompany='" + Frm_Padre._Str_Comp + "' AND ISNULL(TCONCILIACIOND_MANUALV2.caprobado,0)=0"; _Ds_AuxTabs = _Mtd_GetDataSet(_Str_Sql);
                    if (Convert.ToString(_Ds_AuxTabs.Tables[0].Rows[0][0]) != "")
                    {
                        _Int_Count = Convert.ToInt32(_Ds_AuxTabs.Tables[0].Rows[0][0]);
                    }
                    if (_Int_Count != _Int_122)
                    {
                        object[] myArray = new object[1];
                        if (_Int_Count > _Int_122)
                        { _Bol_SwTimbre = true; }
                        if (_Pnl_Contenedor.Controls.Find("_Ctrl122", false).Length > 0)
                        {
                            myArray[0] = ((_Ctrl_Tabs)(_Pnl_Contenedor.Controls.Find("_Ctrl122", false)[0]));
                            this.Invoke(new MyDelegate_Ctrl_Tabs_Del(DelegateMethod_Ctrl_Tabs_Del), myArray);
                            _Int_122 = _Int_Count;
                        }
                        if (_Int_Count > 0)
                        {
                            _Ctrl_Tabs _Ctrl = new _Ctrl_Tabs();
                            _Ctrl.Name = "_Ctrl122";
                            _Ctrl._Descripcion = _Str_TabActual + "(" + _Int_Count.ToString() + ")";
                            _Ctrl._Formulario = "T3.Frm_Busqueda2";
                            _Ctrl._FormularioMdi = _Frm_MdiParent;
                            _Ctrl._Parametros = new object[] { 98 };
                            _Ctrl.Dock = DockStyle.Top;
                            myArray[0] = _Ctrl;
                            this.Invoke(new MyDelegate_Ctrl_Tabs(DelegateMethod_Ctrl_Tabs), myArray);
                            _Int_122 = _Int_Count;
                        }
                    }
                }
                //---------------------TABS NÚMERO 122
                //---------------------------------------------------------------------------------------------------------
                //---------------------TABS NÚMERO 123
                _Str_expression = "ctabs = 123";
                _Drow_found = _Ds_FrmTabs.Tables[0].Select(_Str_expression);
                if (_Drow_found.Length > 0)
                {
                    _Str_TabActual = "APROBACIÓN DE CONC. MANUALES TERMINADAS";
                    _Int_Count = 0;
                    _Str_Sql = "SELECT COUNT(DISTINCT TCONCILIACION.cidconciliacion) FROM TCONCILIACION INNER JOIN TCONCILIACIOND_MANUALV2 ON TCONCILIACION.cidconciliacion=TCONCILIACIOND_MANUALV2.cidconciliacion AND TCONCILIACION.ccompany=TCONCILIACIOND_MANUALV2.ccompany AND TCONCILIACION.cfinalizado = 0 WHERE TCONCILIACION.ccompany='" + Frm_Padre._Str_Comp + "' AND NOT EXISTS(SELECT cidconciliacion FROM TCONCILIACIOND_MANUALV2 AS DETALLE_MANUAL WHERE DETALLE_MANUAL.cidconciliacion=TCONCILIACIOND_MANUALV2.cidconciliacion AND DETALLE_MANUAL.ccompany=TCONCILIACIOND_MANUALV2.ccompany AND ISNULL(DETALLE_MANUAL.caprobado,0)=0)";
                    _Ds_AuxTabs = _Mtd_GetDataSet(_Str_Sql);
                    if (Convert.ToString(_Ds_AuxTabs.Tables[0].Rows[0][0]) != "")
                    {
                        _Int_Count = Convert.ToInt32(_Ds_AuxTabs.Tables[0].Rows[0][0]);
                    }
                    if (_Int_Count != _Int_123)
                    {
                        object[] myArray = new object[1];
                        if (_Int_Count > _Int_123)
                        { _Bol_SwTimbre = true; }
                        if (_Pnl_Contenedor.Controls.Find("_Ctrl123", false).Length > 0)
                        {
                            myArray[0] = ((_Ctrl_Tabs)(_Pnl_Contenedor.Controls.Find("_Ctrl123", false)[0]));
                            this.Invoke(new MyDelegate_Ctrl_Tabs_Del(DelegateMethod_Ctrl_Tabs_Del), myArray);
                            _Int_123 = _Int_Count;
                        }
                        if (_Int_Count > 0)
                        {
                            _Ctrl_Tabs _Ctrl = new _Ctrl_Tabs();
                            _Ctrl.Name = "_Ctrl123";
                            _Ctrl._Descripcion = _Str_TabActual + "(" + _Int_Count.ToString() + ")";
                            _Ctrl._Formulario = "T3.Frm_Busqueda2";
                            _Ctrl._FormularioMdi = _Frm_MdiParent;
                            _Ctrl._Parametros = new object[] { 97 };
                            _Ctrl.Dock = DockStyle.Top;
                            myArray[0] = _Ctrl;
                            this.Invoke(new MyDelegate_Ctrl_Tabs(DelegateMethod_Ctrl_Tabs), myArray);
                            _Int_123 = _Int_Count;
                        }
                    }
                }
                //---------------------TABS NÚMERO 123
                //---------------------------------------------------------------------------------------------------------
                //---------------------TABS NÚMERO 124
                _Str_expression = "ctabs = 124";
                _Drow_found = _Ds_FrmTabs.Tables[0].Select(_Str_expression);
                if (_Drow_found.Length > 0)
                {
                    _Str_TabActual = "COMPROBANTES DE AJUS. DE ENTRADA INCOMPLETOS";
                    _Int_Count = 0;
                    _Str_Sql = "SELECT COUNT(cidcomprob) FROM TAJUSENTC WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cidcomprob='0' AND cimpreso='1'";
                    _Ds_AuxTabs = _Mtd_GetDataSet(_Str_Sql);
                    if (Convert.ToString(_Ds_AuxTabs.Tables[0].Rows[0][0]) != "")
                    {
                        _Int_Count = Convert.ToInt32(_Ds_AuxTabs.Tables[0].Rows[0][0]);
                    }
                    if (_Int_Count != _Int_124)
                    {
                        object[] myArray = new object[1];
                        if (_Int_Count > _Int_124)
                        { _Bol_SwTimbre = true; }
                        if (_Pnl_Contenedor.Controls.Find("_Ctrl124", false).Length > 0)
                        {
                            myArray[0] = ((_Ctrl_Tabs)(_Pnl_Contenedor.Controls.Find("_Ctrl124", false)[0]));
                            this.Invoke(new MyDelegate_Ctrl_Tabs_Del(DelegateMethod_Ctrl_Tabs_Del), myArray);
                            _Int_124 = _Int_Count;
                        }
                        if (_Int_Count > 0)
                        {
                            _Ctrl_Tabs _Ctrl = new _Ctrl_Tabs();
                            _Ctrl.Name = "_Ctrl124";
                            _Ctrl._Descripcion = _Str_TabActual + "(" + _Int_Count.ToString() + ")";
                            _Ctrl._Formulario = "T3.Frm_ComprobAjusInv";
                            _Ctrl._FormularioMdi = _Frm_MdiParent;
                            _Ctrl._Parametros = new object[] { 1 };
                            _Ctrl.Dock = DockStyle.Top;
                            myArray[0] = _Ctrl;
                            this.Invoke(new MyDelegate_Ctrl_Tabs(DelegateMethod_Ctrl_Tabs), myArray);
                            _Int_124 = _Int_Count;
                        }
                    }
                }
                //---------------------TABS NÚMERO 124
                //---------------------------------------------------------------------------------------------------------
                //---------------------TABS NÚMERO 125
                _Str_expression = "ctabs = 125";
                _Drow_found = _Ds_FrmTabs.Tables[0].Select(_Str_expression);
                if (_Drow_found.Length > 0)
                {
                    _Str_TabActual = "COMPROBANTES DE AJUS. DE SALIDA INCOMPLETOS";
                    _Int_Count = 0;
                    _Str_Sql = "SELECT COUNT(cidcomprob) FROM TAJUSSALC WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cidcomprob='0' AND cimpreso='1'";
                    _Ds_AuxTabs = _Mtd_GetDataSet(_Str_Sql);
                    if (Convert.ToString(_Ds_AuxTabs.Tables[0].Rows[0][0]) != "")
                    {
                        _Int_Count = Convert.ToInt32(_Ds_AuxTabs.Tables[0].Rows[0][0]);
                    }
                    if (_Int_Count != _Int_125)
                    {
                        object[] myArray = new object[1];
                        if (_Int_Count > _Int_125)
                        { _Bol_SwTimbre = true; }
                        if (_Pnl_Contenedor.Controls.Find("_Ctrl125", false).Length > 0)
                        {
                            myArray[0] = ((_Ctrl_Tabs)(_Pnl_Contenedor.Controls.Find("_Ctrl125", false)[0]));
                            this.Invoke(new MyDelegate_Ctrl_Tabs_Del(DelegateMethod_Ctrl_Tabs_Del), myArray);
                            _Int_125 = _Int_Count;
                        }
                        if (_Int_Count > 0)
                        {
                            _Ctrl_Tabs _Ctrl = new _Ctrl_Tabs();
                            _Ctrl.Name = "_Ctrl125";
                            _Ctrl._Descripcion = _Str_TabActual + "(" + _Int_Count.ToString() + ")";
                            _Ctrl._Formulario = "T3.Frm_ComprobAjusInv";
                            _Ctrl._FormularioMdi = _Frm_MdiParent;
                            _Ctrl._Parametros = new object[] { 2 };
                            _Ctrl.Dock = DockStyle.Top;
                            myArray[0] = _Ctrl;
                            this.Invoke(new MyDelegate_Ctrl_Tabs(DelegateMethod_Ctrl_Tabs), myArray);
                            _Int_125 = _Int_Count;
                        }
                    }
                }
                //---------------------TABS NÚMERO 125
                //---------------------------------------------------------------------------------------------------------
                //---------------------TABS NÚMERO 126
                _Str_expression = "ctabs = 126";
                _Drow_found = _Ds_FrmTabs.Tables[0].Select(_Str_expression);
                if (_Drow_found.Length > 0)
                {
                    _Str_TabActual = "COBROS CONTRA CAMION";
                    _Int_Count = 0;
                    _Str_Sql = "SELECT COUNT(*) AS Cantidad FROM ( SELECT COUNT(TGUIADESPACHOM.cguiadesp) AS Cantidad FROM TGUIADESPACHOM INNER JOIN TPRECARGAM ON TGUIADESPACHOM.cgroupcomp = TPRECARGAM.cgroupcomp AND TGUIADESPACHOM.cprecarga = TPRECARGAM.cprecarga INNER JOIN TGUIADESPACHOD ON TGUIADESPACHOM.cgroupcomp = TGUIADESPACHOD.cgroupcomp AND TGUIADESPACHOM.cguiadesp = TGUIADESPACHOD.cguiadesp AND TGUIADESPACHOM.cprecarga = TGUIADESPACHOD.cprecarga WHERE (TGUIADESPACHOM.cguiacobrada = '0') AND (TGUIADESPACHOM.cliqguidespacho = '1') AND (TGUIADESPACHOM.cfinalizado = '1') AND ((TGUIADESPACHOD.c_estatus='PAG' AND TGUIADESPACHOD.c_cancelaciontot='1') OR (TGUIADESPACHOD.c_estatus='PAG' AND TGUIADESPACHOD.c_cancelaciontot='0')) AND (ISNULL(TGUIADESPACHOD.csinretencion,0)=0) AND (TGUIADESPACHOD.cgroupcomp = '" + Frm_Padre._Str_GroupComp + "') AND (TPRECARGAM.cimprimeguiadesp = 1) AND (TPRECARGAM.cimprimefactura = 1) GROUP BY TGUIADESPACHOM.cguiadesp ,TGUIADESPACHOM.cgroupcomp ) AS CONSULTITA ";
                    _Ds_AuxTabs = _Mtd_GetDataSet(_Str_Sql);
                    if (Convert.ToString(_Ds_AuxTabs.Tables[0].Rows[0][0]) != "")
                    {
                        _Int_Count = Convert.ToInt32(_Ds_AuxTabs.Tables[0].Rows[0][0]);
                    }
                    if (_Int_Count != _Int_126)
                    {
                        object[] myArray = new object[1];
                        if (_Int_Count > _Int_126)
                        { _Bol_SwTimbre = true; }
                        if (_Pnl_Contenedor.Controls.Find("_Ctrl126", false).Length > 0)
                        {
                            myArray[0] = ((_Ctrl_Tabs)(_Pnl_Contenedor.Controls.Find("_Ctrl126", false)[0]));
                            this.Invoke(new MyDelegate_Ctrl_Tabs_Del(DelegateMethod_Ctrl_Tabs_Del), myArray);
                            _Int_126 = _Int_Count;
                        }
                        if (_Int_Count > 0)
                        {
                            _Ctrl_Tabs _Ctrl = new _Ctrl_Tabs();
                            _Ctrl.Name = "_Ctrl126";
                            _Ctrl._Descripcion = _Str_TabActual + "(" + _Int_Count.ToString() + ")";
                            _Ctrl._Formulario = "T3.Frm_RC_CobrosContraCamion";
                            _Ctrl._FormularioMdi = _Frm_MdiParent;
                            _Ctrl._Parametros = null;
                            _Ctrl.Dock = DockStyle.Top;
                            myArray[0] = _Ctrl;
                            this.Invoke(new MyDelegate_Ctrl_Tabs(DelegateMethod_Ctrl_Tabs), myArray);
                            _Int_126 = _Int_Count;
                        }
                    }
                }
                //---------------------TABS NÚMERO 126
                //---------------------------------------------------------------------------------------------------------
                //---------------------TABS NÚMERO 127
                _Str_expression = "ctabs = 127";
                _Drow_found = _Ds_FrmTabs.Tables[0].Select(_Str_expression);
                if (_Drow_found.Length > 0)
                {
                    _Str_TabActual = "REL.COB. POR APROBAR";
                    _Int_Count = 0;

                    //Contamos las Relaciones de Cobranza Descargadas de la Web
                    _Str_Sql = "SELECT COUNT(*) AS Cantidad FROM ( SELECT cidrelacobro FROM T3TRELACCOBM WHERE (caprobado = '1') AND (caprobadocredito = '0') AND (cgroupcomp = '" + Frm_Padre._Str_GroupComp + "') AND (cdelete = '0') GROUP BY cidrelacobro ) AS CONSULTITA";
                    var _Ds_T3Web = Program._MyClsCnn._mtd_conexion_T3WEB_Local._Mtd_RetornarDataset(_Str_Sql);
                    if (Convert.ToString(_Ds_T3Web.Tables[0].Rows[0][0]) != "")
                    {
                        _Int_Count += Convert.ToInt32(_Ds_T3Web.Tables[0].Rows[0][0]);
                    }

                    //Contamos los Cobros contra Camion Cobrados Por Aprobar
                    _Str_Sql = "SELECT COUNT(*) AS Cantidad FROM ( SELECT COUNT(TGUIADESPACHOM.cguiadesp) AS Cantidad ,TRELACCOBM.caprobadocredito FROM TGUIADESPACHOM INNER JOIN TPRECARGAM ON TGUIADESPACHOM.cgroupcomp = TPRECARGAM.cgroupcomp AND TGUIADESPACHOM.cprecarga = TPRECARGAM.cprecarga INNER JOIN TGUIADESPACHOD ON TGUIADESPACHOM.cgroupcomp = TGUIADESPACHOD.cgroupcomp AND TGUIADESPACHOM.cguiadesp = TGUIADESPACHOD.cguiadesp AND TGUIADESPACHOM.cprecarga = TGUIADESPACHOD.cprecarga INNER JOIN TRELACCOBM ON TGUIADESPACHOM.cgroupcomp = TRELACCOBM.cgroupcomp AND TGUIADESPACHOM.cguiadesp = TRELACCOBM.cguiacobro WHERE (TGUIADESPACHOM.cguiacobrada = '1') AND (TGUIADESPACHOM.cliqguidespacho = '1') AND (TGUIADESPACHOM.cfinalizado = '1') AND ((TGUIADESPACHOD.c_estatus='PAG' AND TGUIADESPACHOD.c_cancelaciontot='1') OR (TGUIADESPACHOD.c_estatus='PAG' AND TGUIADESPACHOD.c_cancelaciontot='0')) AND (ISNULL(TGUIADESPACHOD.csinretencion,0)=0)  AND (TGUIADESPACHOD.cgroupcomp = '" + Frm_Padre._Str_GroupComp + "') AND (TPRECARGAM.cimprimeguiadesp = '1') AND (TPRECARGAM.cimprimefactura = '1') AND (TRELACCOBM.ccobrooficina = '1') AND (TRELACCOBM.caprobado = 1) AND (TRELACCOBM.caprobadocredito = '0') AND (TRELACCOBM.cdelete = '0') GROUP BY TGUIADESPACHOM.cguiadesp ,TGUIADESPACHOM.cgroupcomp ,TRELACCOBM.caprobadocredito ) AS CONSULTITA";
                    _Ds_AuxTabs = _Mtd_GetDataSet(_Str_Sql);
                    if (Convert.ToString(_Ds_AuxTabs.Tables[0].Rows[0][0]) != "")
                    {
                        _Int_Count += Convert.ToInt32(_Ds_AuxTabs.Tables[0].Rows[0][0]);
                    }

                    if (_Int_Count != _Int_127)
                    {
                        object[] myArray = new object[1];
                        if (_Int_Count > _Int_127)
                        { _Bol_SwTimbre = true; }
                        if (_Pnl_Contenedor.Controls.Find("_Ctrl127", false).Length > 0)
                        {
                            myArray[0] = ((_Ctrl_Tabs)(_Pnl_Contenedor.Controls.Find("_Ctrl127", false)[0]));
                            this.Invoke(new MyDelegate_Ctrl_Tabs_Del(DelegateMethod_Ctrl_Tabs_Del), myArray);
                            _Int_127 = _Int_Count;
                        }
                        if (_Int_Count > 0)
                        {
                            _Ctrl_Tabs _Ctrl = new _Ctrl_Tabs();
                            _Ctrl.Name = "_Ctrl127";
                            _Ctrl._Descripcion = _Str_TabActual + "(" + _Int_Count.ToString() + ")";
                            _Ctrl._Formulario = "T3.Frm_RC_Verificacion";
                            _Ctrl._FormularioMdi = _Frm_MdiParent;
                            _Ctrl._Parametros = null;
                            _Ctrl.Dock = DockStyle.Top;
                            myArray[0] = _Ctrl;
                            this.Invoke(new MyDelegate_Ctrl_Tabs(DelegateMethod_Ctrl_Tabs), myArray);
                            _Int_127 = _Int_Count;
                        }
                    }
                }
                //---------------------TABS NÚMERO 127
                //---------------------------------------------------------------------------------------------------------
                //---------------------TABS NÚMERO 129
                _Str_expression = "ctabs = 129";
                _Drow_found = _Ds_FrmTabs.Tables[0].Select(_Str_expression);
                if (_Drow_found.Length > 0)
                {
                    _Str_TabActual = "CONCILIACIONES PENDIENTES";
                    _Int_Count = 0;
                    _Str_Sql = "SELECT COUNT(*) AS TotalCuentasSinConciliar FROM( SELECT DATEDIFF(day, MAX(TCONCILIACION.cfechahasta), GETDATE() - 1) AS DiasSinConciliar FROM TCONCILIACION INNER JOIN TBANCO ON TCONCILIACION.cbanco = TBANCO.cbanco AND TCONCILIACION.ccompany = TBANCO.ccompany INNER JOIN TCUENTBANC ON TCONCILIACION.ccompany = TCUENTBANC.ccompany AND TBANCO.cbanco = TCUENTBANC.cbanco WHERE (TCONCILIACION.ccompany = '" + Frm_Padre._Str_Comp + "') AND (ISNULL(TCONCILIACION.cdelete, 0) = 0) AND (TCONCILIACION.cfinalizado = 1) ) AS Consultita";
                    _Ds_AuxTabs = _Mtd_GetDataSet(_Str_Sql);
                    if (Convert.ToString(_Ds_AuxTabs.Tables[0].Rows[0][0]) != "")
                    {
                        _Int_Count = Convert.ToInt32(_Ds_AuxTabs.Tables[0].Rows[0][0]);
                    }
                    if (_Int_Count != _Int_129)
                    {
                        object[] myArray = new object[1];
                        if (_Int_Count > _Int_129)
                        { _Bol_SwTimbre = true; }
                        if (_Pnl_Contenedor.Controls.Find("_Ctrl129", false).Length > 0)
                        {
                            myArray[0] = ((_Ctrl_Tabs)(_Pnl_Contenedor.Controls.Find("_Ctrl129", false)[0]));
                            this.Invoke(new MyDelegate_Ctrl_Tabs_Del(DelegateMethod_Ctrl_Tabs_Del), myArray);
                            _Int_129 = _Int_Count;
                        }
                        if (_Int_Count > 0)
                        {
                            _Ctrl_Tabs _Ctrl = new _Ctrl_Tabs();
                            _Ctrl.Name = "_Ctrl129";
                            _Ctrl._Descripcion = _Str_TabActual + "(" + _Int_Count.ToString() + ")";
                            _Ctrl._Formulario = "T3.Frm_Busqueda2";
                            _Ctrl._FormularioMdi = _Frm_MdiParent;
                            _Ctrl._Parametros = new object[] { 101 };
                            _Ctrl.Dock = DockStyle.Top;
                            myArray[0] = _Ctrl;
                            this.Invoke(new MyDelegate_Ctrl_Tabs(DelegateMethod_Ctrl_Tabs), myArray);
                            _Int_129 = _Int_Count;
                        }
                    }
                }
                //---------------------TABS NÚMERO 129
                //---------------------------------------------------------------------------------------------------------
                //---------------------TABS NÚMERO 130
                _Str_expression = "ctabs = 130";
                _Drow_found = _Ds_FrmTabs.Tables[0].Select(_Str_expression);
                if (_Drow_found.Length > 0)
                {
                    if (myUtilidad._Mtd_ObtenerUsuarioFirma(Frm_Padre._Str_Use) == "1")
                    {
                        if (myUtilidad._Mtd_UsuarioProceso(Frm_Padre._Str_Use, "F_ENTRASALIDA_AJUSTE_2"))
                        {
                            _Str_TabActual = "AJUSTE DE ENT. POR APROBAR";
                            _Int_Count = 0;
                            _Str_Sql = "Select count(*) from TAJUSENTC where ccompany='" + Frm_Padre._Str_Comp + "' and cdelete='0' and cejecutada='0' AND canulado='0' and isnull(cfuseraprobador1,0)=1 and isnull(cfuseraprobador2,0)=0 AND ISNULL(cajusteintegrado,0)='0'";
                            _Ds_AuxTabs = _Mtd_GetDataSet(_Str_Sql);
                            if (Convert.ToString(_Ds_AuxTabs.Tables[0].Rows[0][0]) != "")
                            {
                                _Int_Count = Convert.ToInt32(_Ds_AuxTabs.Tables[0].Rows[0][0]);
                            }
                            if (_Int_Count != _Int_130)
                            {
                                object[] myArray = new object[1];
                                if (_Int_Count > _Int_130)
                                { _Bol_SwTimbre = true; }
                                if (_Pnl_Contenedor.Controls.Find("_Ctrl130", false).Length > 0)
                                {
                                    myArray[0] = ((_Ctrl_Tabs)(_Pnl_Contenedor.Controls.Find("_Ctrl130", false)[0]));
                                    this.Invoke(new MyDelegate_Ctrl_Tabs_Del(DelegateMethod_Ctrl_Tabs_Del), myArray);
                                    _Int_130 = _Int_Count;
                                }
                                if (_Int_Count > 0)
                                {
                                    _Ctrl_Tabs _Ctrl = new _Ctrl_Tabs();
                                    _Ctrl.Name = "_Ctrl130";
                                    _Ctrl._Descripcion = _Str_TabActual + " ( " + _Int_Count.ToString() + " )";
                                    _Ctrl._Formulario = "T3.Frm_AjusteEntrada";
                                    _Ctrl._FormularioMdi = _Frm_MdiParent;
                                    _Ctrl._Parametros = new object[] { true, 2 };
                                    _Ctrl.Dock = DockStyle.Top;
                                    myArray[0] = _Ctrl;
                                    this.Invoke(new MyDelegate_Ctrl_Tabs(DelegateMethod_Ctrl_Tabs), myArray);
                                    _Int_130 = _Int_Count;
                                }
                            }
                        }
                    }
                }
                //---------------------TABS NÚMERO 130
                //---------------------------------------------------------------------------------------------------------
                //---------------------TABS NÚMERO 131
                _Str_expression = "ctabs = 131";
                _Drow_found = _Ds_FrmTabs.Tables[0].Select(_Str_expression);
                if (_Drow_found.Length > 0)
                {
                    if (myUtilidad._Mtd_ObtenerUsuarioFirma(Frm_Padre._Str_Use) == "1")
                    {
                        if (myUtilidad._Mtd_UsuarioProceso(Frm_Padre._Str_Use, "F_ENTRASALIDA_AJUSTE_2"))
                        {
                            _Str_TabActual = "AJUSTE DE SAL. POR APROBAR";
                            _Int_Count = 0;
                            _Str_Sql = "Select count(*) from TAJUSSALC where ccompany='" + Frm_Padre._Str_Comp + "' and cdelete='0' and cejecutada='0' AND canulado='0' and isnull(cfuseraprobador1,0)=1 and isnull(cfuseraprobador2,0)=0 AND ISNULL(cajusteintegrado,0)='0'";
                            _Ds_AuxTabs = _Mtd_GetDataSet(_Str_Sql);
                            if (Convert.ToString(_Ds_AuxTabs.Tables[0].Rows[0][0]) != "")
                            {
                                _Int_Count = Convert.ToInt32(_Ds_AuxTabs.Tables[0].Rows[0][0]);
                            }
                            if (_Int_Count != _Int_131)
                            {
                                object[] myArray = new object[1];
                                if (_Int_Count > _Int_131)
                                { _Bol_SwTimbre = true; }
                                if (_Pnl_Contenedor.Controls.Find("_Ctrl131", false).Length > 0)
                                {
                                    myArray[0] = ((_Ctrl_Tabs)(_Pnl_Contenedor.Controls.Find("_Ctrl131", false)[0]));
                                    this.Invoke(new MyDelegate_Ctrl_Tabs_Del(DelegateMethod_Ctrl_Tabs_Del), myArray);
                                    _Int_131 = _Int_Count;
                                }
                                if (_Int_Count > 0)
                                {
                                    _Ctrl_Tabs _Ctrl = new _Ctrl_Tabs();
                                    _Ctrl.Name = "_Ctrl131";
                                    _Ctrl._Descripcion = _Str_TabActual + " ( " + _Int_Count.ToString() + " )";
                                    _Ctrl._Formulario = "T3.Frm_AjusteSalida";
                                    _Ctrl._FormularioMdi = _Frm_MdiParent;
                                    _Ctrl._Parametros = new object[] { true, 2 };
                                    _Ctrl.Dock = DockStyle.Top;
                                    myArray[0] = _Ctrl;
                                    this.Invoke(new MyDelegate_Ctrl_Tabs(DelegateMethod_Ctrl_Tabs), myArray);
                                    _Int_131 = _Int_Count;
                                }
                            }
                        }
                    }
                }
                //---------------------TABS NÚMERO 131
                //---------------------------------------------------------------------------------------------------------
                //---------------------TABS NÚMERO 132
                _Str_expression = "ctabs = 132";
                _Drow_found = _Ds_FrmTabs.Tables[0].Select(_Str_expression);
                if (_Drow_found.Length > 0)
                {
                    _Str_TabActual = "ROTACIÓN A MAS DE 180 DÍAS";
                    _Int_Count = 0;
                    _Str_Sql = "SELECT COUNT(*) AS TOTAL FROM TPRODUCTOROTACION WHERE CCOMPANY='"+Frm_Padre._Str_Comp+"'";
                    _Ds_AuxTabs = _Mtd_GetDataSet(_Str_Sql);
                    if (Convert.ToString(_Ds_AuxTabs.Tables[0].Rows[0][0]) != "")
                    {
                        _Int_Count = Convert.ToInt32(_Ds_AuxTabs.Tables[0].Rows[0][0]);
                    }
                    if (_Int_Count != _Int_132)
                    {
                        object[] myArray = new object[1];
                        if (_Int_Count > _Int_132)
                        { _Bol_SwTimbre = true; }
                        if (_Pnl_Contenedor.Controls.Find("_Ctrl132", false).Length > 0)
                        {
                            myArray[0] = ((_Ctrl_Tabs)(_Pnl_Contenedor.Controls.Find("_Ctrl132", false)[0]));
                            this.Invoke(new MyDelegate_Ctrl_Tabs_Del(DelegateMethod_Ctrl_Tabs_Del), myArray);
                            _Int_132 = _Int_Count;
                        }
                        if (_Int_Count > 0)
                        {
                            _Ctrl_Tabs _Ctrl = new _Ctrl_Tabs();
                            _Ctrl.Name = "_Ctrl132";
                            _Ctrl._Descripcion = _Str_TabActual + "(" + _Int_Count.ToString() + ")";
                            _Ctrl._Formulario = "T3.Frm_Inf_Varios";
                            _Ctrl._FormularioMdi = _Frm_MdiParent;
                            _Ctrl._Parametros = new object[] { 11,Frm_Padre._Str_Comp };
                            _Ctrl.Dock = DockStyle.Top;
                            myArray[0] = _Ctrl;
                            this.Invoke(new MyDelegate_Ctrl_Tabs(DelegateMethod_Ctrl_Tabs), myArray);
                            _Int_132 = _Int_Count;
                        }
                    }
                }
                //---------------------TABS NÚMERO 132
                //---------------------------------------------------------------------------------------------------------
                //---------------------TABS NÚMERO 133
                _Str_expression = "ctabs = 133";
                _Drow_found = _Ds_FrmTabs.Tables[0].Select(_Str_expression);
                if (_Drow_found.Length > 0)
                {
                    if (myUtilidad._Mtd_ObtenerUsuarioFirma(Frm_Padre._Str_Use) == "1" && myUtilidad._Mtd_UsuarioProceso(Frm_Padre._Str_Use, "F_REEMPLAZO_CUENTAS"))
                    {
                        _Str_TabActual = "CUENTAS CONTABLES INACTIVAS POR REEMPLAZAR";
                        _Int_Count = 0;
                        _Str_Sql = "Select count(ccountinactiva) from TCOUNTINAC where ccompany='" + Frm_Padre._Str_Comp + "' and ccountactiva IS NULL";
                        _Ds_AuxTabs = _Mtd_GetDataSet(_Str_Sql);
                        if (Convert.ToString(_Ds_AuxTabs.Tables[0].Rows[0][0]) != "")
                        {
                            _Int_Count = Convert.ToInt32(_Ds_AuxTabs.Tables[0].Rows[0][0]);
                        }
                        if (_Int_Count != _Int_133)
                        {
                            object[] myArray = new object[1];
                            if (_Int_Count > _Int_133)
                            { _Bol_SwTimbre = true; }
                            if (_Pnl_Contenedor.Controls.Find("_Ctrl133", false).Length > 0)
                            {
                                myArray[0] = ((_Ctrl_Tabs)(_Pnl_Contenedor.Controls.Find("_Ctrl133", false)[0]));
                                this.Invoke(new MyDelegate_Ctrl_Tabs_Del(DelegateMethod_Ctrl_Tabs_Del), myArray);
                                _Int_133 = _Int_Count;
                            }
                            if (_Int_Count > 0)
                            {
                                _Ctrl_Tabs _Ctrl = new _Ctrl_Tabs();
                                _Ctrl.Name = "_Ctrl133";
                                _Ctrl._Descripcion = _Str_TabActual + " ( " + _Int_Count.ToString() + " )";
                                _Ctrl._Formulario = "T3.Frm_ReemplazoCuentas";
                                _Ctrl._FormularioMdi = _Frm_MdiParent;
                                _Ctrl._Parametros = null;
                                _Ctrl.Dock = DockStyle.Top;
                                myArray[0] = _Ctrl;
                                this.Invoke(new MyDelegate_Ctrl_Tabs(DelegateMethod_Ctrl_Tabs), myArray);
                                _Int_133 = _Int_Count;
                            }
                        }
                    }
                }
                //---------------------TABS NÚMERO 133
                //---------------------------------------------------------------------------------------------------------
                //---------------------TABS NÚMERO 134
                _Str_expression = "ctabs = 134";
                _Drow_found = _Ds_FrmTabs.Tables[0].Select(_Str_expression);
                if (_Drow_found.Length > 0)
                {
                    if (myUtilidad._Mtd_ObtenerUsuarioFirma(Frm_Padre._Str_Use) == "1")
                    {
                        if (myUtilidad._Mtd_UsuarioProceso(Frm_Padre._Str_Use, "F_AJUSTE_INTEGRADO_APROB"))
                        {
                            _Str_TabActual = "AJUSTES INTEGRADOS POR APROBAR";
                            _Int_Count = 0;
                            _Str_Sql = "SELECT COUNT(cidajuste) FROM TAJUSTEINTEGRADO WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND canulado='0' AND ISNULL(cfuseraprobador1,0)=0 AND ISNULL(cfuseraprobador2,0)=0";
                            _Ds_AuxTabs = _Mtd_GetDataSet(_Str_Sql);
                            if (Convert.ToString(_Ds_AuxTabs.Tables[0].Rows[0][0]) != "")
                            {
                                _Int_Count = Convert.ToInt32(_Ds_AuxTabs.Tables[0].Rows[0][0]);
                            }
                            if (_Int_Count != _Int_134)
                            {
                                object[] myArray = new object[1];
                                if (_Int_Count > _Int_134)
                                { _Bol_SwTimbre = true; }
                                if (_Pnl_Contenedor.Controls.Find("_Ctrl134", false).Length > 0)
                                {
                                    myArray[0] = ((_Ctrl_Tabs)(_Pnl_Contenedor.Controls.Find("_Ctrl134", false)[0]));
                                    this.Invoke(new MyDelegate_Ctrl_Tabs_Del(DelegateMethod_Ctrl_Tabs_Del), myArray);
                                    _Int_134 = _Int_Count;
                                }
                                if (_Int_Count > 0)
                                {
                                    _Ctrl_Tabs _Ctrl = new _Ctrl_Tabs();
                                    _Ctrl.Name = "_Ctrl134";
                                    _Ctrl._Descripcion = _Str_TabActual + " ( " + _Int_Count.ToString() + " )";
                                    _Ctrl._Formulario = "T3.Frm_AjusteIntegrado";
                                    _Ctrl._FormularioMdi = _Frm_MdiParent;
                                    _Ctrl._Parametros = new object[] { 1 };
                                    _Ctrl.Dock = DockStyle.Top;
                                    myArray[0] = _Ctrl;
                                    this.Invoke(new MyDelegate_Ctrl_Tabs(DelegateMethod_Ctrl_Tabs), myArray);
                                    _Int_134 = _Int_Count;
                                }
                            }
                        }
                    }
                }
                //---------------------TABS NÚMERO 134
                //---------------------------------------------------------------------------------------------------------
                //---------------------TABS NÚMERO 135
                _Str_expression = "ctabs = 135";
                _Drow_found = _Ds_FrmTabs.Tables[0].Select(_Str_expression);
                if (_Drow_found.Length > 0)
                {
                    if (myUtilidad._Mtd_ObtenerUsuarioFirma(Frm_Padre._Str_Use) == "1")
                    {
                        if (myUtilidad._Mtd_UsuarioProceso(Frm_Padre._Str_Use, "F_AJUSTE_INTEGRADO_APROB_2"))
                        {
                            _Str_TabActual = "AJUSTES INTEGRADOS POR APROBAR";
                            _Int_Count = 0;
                            _Str_Sql = "SELECT COUNT(cidajuste) FROM TAJUSTEINTEGRADO WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND canulado='0' AND cfuseraprobador1=1 AND ISNULL(cfuseraprobador2,0)=0";
                            _Ds_AuxTabs = _Mtd_GetDataSet(_Str_Sql);
                            if (Convert.ToString(_Ds_AuxTabs.Tables[0].Rows[0][0]) != "")
                            {
                                _Int_Count = Convert.ToInt32(_Ds_AuxTabs.Tables[0].Rows[0][0]);
                            }
                            if (_Int_Count != _Int_135)
                            {
                                object[] myArray = new object[1];
                                if (_Int_Count > _Int_135)
                                { _Bol_SwTimbre = true; }
                                if (_Pnl_Contenedor.Controls.Find("_Ctrl135", false).Length > 0)
                                {
                                    myArray[0] = ((_Ctrl_Tabs)(_Pnl_Contenedor.Controls.Find("_Ctrl135", false)[0]));
                                    this.Invoke(new MyDelegate_Ctrl_Tabs_Del(DelegateMethod_Ctrl_Tabs_Del), myArray);
                                    _Int_135 = _Int_Count;
                                }
                                if (_Int_Count > 0)
                                {
                                    _Ctrl_Tabs _Ctrl = new _Ctrl_Tabs();
                                    _Ctrl.Name = "_Ctrl135";
                                    _Ctrl._Descripcion = _Str_TabActual + " ( " + _Int_Count.ToString() + " )";
                                    _Ctrl._Formulario = "T3.Frm_AjusteIntegrado";
                                    _Ctrl._FormularioMdi = _Frm_MdiParent;
                                    _Ctrl._Parametros = new object[] { 2 };
                                    _Ctrl.Dock = DockStyle.Top;
                                    myArray[0] = _Ctrl;
                                    this.Invoke(new MyDelegate_Ctrl_Tabs(DelegateMethod_Ctrl_Tabs), myArray);
                                    _Int_135 = _Int_Count;
                                }
                            }
                        }
                    }
                }
                //---------------------TABS NÚMERO 135
                //---------------------------------------------------------------------------------------------------------
                //---------------------TABS NÚMERO 136
                _Str_expression = "ctabs = 136";
                _Drow_found = _Ds_FrmTabs.Tables[0].Select(_Str_expression);
                if (_Drow_found.Length > 0)
                {
                    _Str_TabActual = "AJUSTES INTEGRADOS POR IMPRIMIR";
                    _Int_Count = 0;
                    _Str_Sql = "SELECT count(cidajuste) FROM TAJUSTEINTEGRADO WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cfuseraprobador2=1 AND cimpreso=0";
                    _Ds_AuxTabs = _Mtd_GetDataSet(_Str_Sql);
                    if (Convert.ToString(_Ds_AuxTabs.Tables[0].Rows[0][0]) != "")
                    {
                        _Int_Count = Convert.ToInt32(_Ds_AuxTabs.Tables[0].Rows[0][0]);
                    }
                    if (_Int_Count != _Int_136)
                    {
                        object[] myArray = new object[1];
                        if (_Int_Count > _Int_136)
                        { _Bol_SwTimbre = true; }
                        if (_Pnl_Contenedor.Controls.Find("_Ctrl136", false).Length > 0)
                        {
                            myArray[0] = ((_Ctrl_Tabs)(_Pnl_Contenedor.Controls.Find("_Ctrl136", false)[0]));
                            this.Invoke(new MyDelegate_Ctrl_Tabs_Del(DelegateMethod_Ctrl_Tabs_Del), myArray);
                            _Int_136 = _Int_Count;
                        }
                        if (_Int_Count > 0)
                        {
                            _Ctrl_Tabs _Ctrl = new _Ctrl_Tabs();
                            _Ctrl.Name = "_Ctrl136";
                            _Ctrl._Descripcion = _Str_TabActual + "(" + _Int_Count.ToString() + ")";
                            _Ctrl._Formulario = "T3.Frm_AjusteIntegrado";
                            _Ctrl._FormularioMdi = _Frm_MdiParent;
                            _Ctrl._Parametros = new object[] { 3 };
                            _Ctrl.Dock = DockStyle.Top;
                            myArray[0] = _Ctrl;
                            this.Invoke(new MyDelegate_Ctrl_Tabs(DelegateMethod_Ctrl_Tabs), myArray);
                            _Int_136 = _Int_Count;
                        }
                    }
                }
                //---------------------TABS NÚMERO 136
                //---------------------------------------------------------------------------------------------------------
                //---------------------TABS NÚMERO 137
                _Str_expression = "ctabs = 137";
                _Drow_found = _Ds_FrmTabs.Tables[0].Select(_Str_expression);
                if (_Drow_found.Length > 0)
                {
                    _Str_TabActual = "PRODUCTOS CON MARGEN ERRADO";
                    _Int_Count = 0;
                    _Str_Sql = "Select count(clogid) FROM TLOGMARGENEXCEDENTE INNER JOIN TCLIENTE ON TLOGMARGENEXCEDENTE.ccliente = TCLIENTE.ccliente INNER JOIN TPRODUCTO ON TLOGMARGENEXCEDENTE.cproducto = TPRODUCTO.cproducto WHERE TLOGMARGENEXCEDENTE.ccompany='" + Frm_Padre._Str_Comp + "' and cvistonotificador=0 ";
                    _Ds_AuxTabs = _Mtd_GetDataSet(_Str_Sql);
                    if (Convert.ToString(_Ds_AuxTabs.Tables[0].Rows[0][0]) != "")
                    {
                        _Int_Count = Convert.ToInt32(_Ds_AuxTabs.Tables[0].Rows[0][0]);
                    }
                    if (_Int_Count != _Int_137)
                    {
                        object[] myArray = new object[1];
                        if (_Int_Count > _Int_137)
                        {
                            _Bol_SwTimbre = true;
                        }
                        if (_Pnl_Contenedor.Controls.Find("_Ctrl137", false).Length > 0)
                        {
                            myArray[0] = ((_Ctrl_Tabs)(_Pnl_Contenedor.Controls.Find("_Ctrl137", false)[0]));
                            this.Invoke(new MyDelegate_Ctrl_Tabs_Del(DelegateMethod_Ctrl_Tabs_Del), myArray);
                            _Int_137 = _Int_Count;
                        }
                        if (_Int_Count > 0)
                        {
                            _Ctrl_Tabs _Ctrl = new _Ctrl_Tabs();
                            _Ctrl.Name = "_Ctrl137";
                            _Ctrl._Descripcion = _Str_TabActual + " ( " + _Int_Count.ToString() + " )";
                            _Ctrl._Formulario = "T3.Frm_ProducExcedMargenGub";
                            _Ctrl._FormularioMdi = _Frm_MdiParent;
                            _Ctrl._Parametros = null;
                            _Ctrl.Dock = DockStyle.Top;
                            myArray[0] = _Ctrl;
                            this.Invoke(new MyDelegate_Ctrl_Tabs(DelegateMethod_Ctrl_Tabs), myArray);
                            _Int_137 = _Int_Count;
                        }
                    }
                }
                //---------------------TABS NÚMERO 137
                //---------------------------------------------------------------------------------------------------------
                //---------------------TABS NÚMERO 138
                _Str_expression = "ctabs = 138";
                _Drow_found = _Ds_FrmTabs.Tables[0].Select(_Str_expression);
                if (_Drow_found.Length > 0)
                {
                    if (myUtilidad._Mtd_ObtenerUsuarioFirma(Frm_Padre._Str_Use) == "1" & myUtilidad._Mtd_UsuarioProceso(Frm_Padre._Str_Use, "F_APROB_LIBROCOMPRAS"))
                    {
                        _Str_TabActual = "COMPLEMENTO DE LIBRO DE COMPRAS POR APROBAR";
                        _Int_Count = 0;
                        _Str_Sql = "SELECT COUNT(cidcomplemento) FROM TCOMPLEMENTOLCOMPRAS WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cstatus='0' AND cdelete='0'";
                        _Ds_AuxTabs = _Mtd_GetDataSet(_Str_Sql);
                        if (Convert.ToString(_Ds_AuxTabs.Tables[0].Rows[0][0]) != "")
                        {
                            _Int_Count = Convert.ToInt32(_Ds_AuxTabs.Tables[0].Rows[0][0]);
                        }
                        if (_Int_Count != _Int_138)
                        {
                            object[] myArray = new object[1];
                            if (_Int_Count > _Int_138)
                            { _Bol_SwTimbre = true; }
                            if (_Pnl_Contenedor.Controls.Find("_Ctrl138", false).Length > 0)
                            {
                                myArray[0] = ((_Ctrl_Tabs)(_Pnl_Contenedor.Controls.Find("_Ctrl138", false)[0]));
                                this.Invoke(new MyDelegate_Ctrl_Tabs_Del(DelegateMethod_Ctrl_Tabs_Del), myArray);
                                _Int_138 = _Int_Count;
                            }
                            if (_Int_Count > 0)
                            {
                                _Ctrl_Tabs _Ctrl = new _Ctrl_Tabs();
                                _Ctrl.Name = "_Ctrl138";
                                _Ctrl._Descripcion = _Str_TabActual + "(" + _Int_Count.ToString() + ")";
                                _Ctrl._Formulario = "T3.Frm_ComplementoLibroCompras";
                                _Ctrl._FormularioMdi = _Frm_MdiParent;
                                _Ctrl._Parametros = new object[] { true };
                                _Ctrl.Dock = DockStyle.Top;
                                myArray[0] = _Ctrl;
                                this.Invoke(new MyDelegate_Ctrl_Tabs(DelegateMethod_Ctrl_Tabs), myArray);
                                _Int_138 = _Int_Count;
                            }
                        }
                    }
                }
                //---------------------TABS NÚMERO 138
                //---------------------------------------------------------------------------------------------------------
                //---------------------TABS NÚMERO 139
                _Str_expression = "ctabs = 139";
                _Drow_found = _Ds_FrmTabs.Tables[0].Select(_Str_expression);
                if (_Drow_found.Length > 0)
                {
                    if (myUtilidad._Mtd_ObtenerUsuarioFirma(Frm_Padre._Str_Use) == "1" & myUtilidad._Mtd_UsuarioProceso(Frm_Padre._Str_Use, "F_ANUL_CHEQEMIT"))
                    {
                        _Str_TabActual = "ANULACIÓN DE CHEQUES POR APROBAR";
                        _Int_Count = 0;
                        _Str_Sql = "SELECT COUNT(cidordpago) FROM TANULCHEQEMITIDO WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND ISNULL(cidcomprobanul,0)='0'";
                        _Ds_AuxTabs = _Mtd_GetDataSet(_Str_Sql);
                        if (Convert.ToString(_Ds_AuxTabs.Tables[0].Rows[0][0]) != "")
                        {
                            _Int_Count = Convert.ToInt32(_Ds_AuxTabs.Tables[0].Rows[0][0]);
                        }
                        if (_Int_Count != _Int_139)
                        {
                            object[] myArray = new object[1];
                            if (_Int_Count > _Int_139)
                            { _Bol_SwTimbre = true; }
                            if (_Pnl_Contenedor.Controls.Find("_Ctrl139", false).Length > 0)
                            {
                                myArray[0] = ((_Ctrl_Tabs)(_Pnl_Contenedor.Controls.Find("_Ctrl139", false)[0]));
                                this.Invoke(new MyDelegate_Ctrl_Tabs_Del(DelegateMethod_Ctrl_Tabs_Del), myArray);
                                _Int_139 = _Int_Count;
                            }
                            if (_Int_Count > 0)
                            {
                                _Ctrl_Tabs _Ctrl = new _Ctrl_Tabs();
                                _Ctrl.Name = "_Ctrl139";
                                _Ctrl._Descripcion = _Str_TabActual + "(" + _Int_Count.ToString() + ")";
                                _Ctrl._Formulario = "T3.Frm_AnulaChequeEmitido";
                                _Ctrl._FormularioMdi = _Frm_MdiParent;
                                _Ctrl._Parametros = new object[] { 1 };
                                _Ctrl.Dock = DockStyle.Top;
                                myArray[0] = _Ctrl;
                                this.Invoke(new MyDelegate_Ctrl_Tabs(DelegateMethod_Ctrl_Tabs), myArray);
                                _Int_139 = _Int_Count;
                            }
                        }
                    }
                }
                //---------------------TABS NÚMERO 139
                //---------------------------------------------------------------------------------------------------------
                //---------------------TABS NÚMERO 140
                _Str_expression = "ctabs = 140";
                _Drow_found = _Ds_FrmTabs.Tables[0].Select(_Str_expression);
                if (_Drow_found.Length > 0)
                {
                    if (myUtilidad._Mtd_ObtenerUsuarioFirma(Frm_Padre._Str_Use) == "1" & myUtilidad._Mtd_UsuarioProceso(Frm_Padre._Str_Use, "F_ANUL_CHEQEMIT_SOL"))
                    {
                        _Str_TabActual = "ANULACIÓN DE CHEQUES POR IMPRIMIR";
                        _Int_Count = 0;
                        _Str_Sql = "SELECT COUNT(cidordpago) FROM TANULCHEQEMITIDO INNER JOIN TCOMPROBANC ON TANULCHEQEMITIDO.ccompany=TCOMPROBANC.ccompany AND TANULCHEQEMITIDO.cidcomprobanul=TCOMPROBANC.cidcomprob WHERE TANULCHEQEMITIDO.cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND TANULCHEQEMITIDO.ccompany='" + Frm_Padre._Str_Comp + "' AND ISNULL(TCOMPROBANC.cstatus,0)='0'";
                        _Ds_AuxTabs = _Mtd_GetDataSet(_Str_Sql);
                        if (Convert.ToString(_Ds_AuxTabs.Tables[0].Rows[0][0]) != "")
                        {
                            _Int_Count = Convert.ToInt32(_Ds_AuxTabs.Tables[0].Rows[0][0]);
                        }
                        if (_Int_Count != _Int_140)
                        {
                            object[] myArray = new object[1];
                            if (_Int_Count > _Int_140)
                            { _Bol_SwTimbre = true; }
                            if (_Pnl_Contenedor.Controls.Find("_Ctrl140", false).Length > 0)
                            {
                                myArray[0] = ((_Ctrl_Tabs)(_Pnl_Contenedor.Controls.Find("_Ctrl140", false)[0]));
                                this.Invoke(new MyDelegate_Ctrl_Tabs_Del(DelegateMethod_Ctrl_Tabs_Del), myArray);
                                _Int_140 = _Int_Count;
                            }
                            if (_Int_Count > 0)
                            {
                                _Ctrl_Tabs _Ctrl = new _Ctrl_Tabs();
                                _Ctrl.Name = "_Ctrl140";
                                _Ctrl._Descripcion = _Str_TabActual + "(" + _Int_Count.ToString() + ")";
                                _Ctrl._Formulario = "T3.Frm_AnulaChequeEmitido";
                                _Ctrl._FormularioMdi = _Frm_MdiParent;
                                _Ctrl._Parametros = new object[] { 2 };
                                _Ctrl.Dock = DockStyle.Top;
                                myArray[0] = _Ctrl;
                                this.Invoke(new MyDelegate_Ctrl_Tabs(DelegateMethod_Ctrl_Tabs), myArray);
                                _Int_140 = _Int_Count;
                            }
                        }
                    }
                }
                //---------------------TABS NÚMERO 140
                //---------------------------------------------------------------------------------------------------------
                //---------------------TABS NÚMERO 141
                _Str_expression = "ctabs = 141";
                _Drow_found = _Ds_FrmTabs.Tables[0].Select(_Str_expression);
                if (_Drow_found.Length > 0)
                {
                    if (myUtilidad._Mtd_ObtenerUsuarioFirma(Frm_Padre._Str_Use) == "1" & myUtilidad._Mtd_UsuarioProceso(Frm_Padre._Str_Use, "F_N1_ANULFACTURACXP"))
                    {
                        _Str_TabActual = "FACTURAS ANULADAS POR IMPRIMIR CxP ";
                        _Int_Count = 0;
                        _Str_Sql = "SELECT COUNT(VST_FACTURA_ANUL_CXP.ccompany) FROM VST_FACTURA_ANUL_CXP INNER JOIN TCONFIGCXP ON VST_FACTURA_ANUL_CXP.ccompany=TCONFIGCXP.ccompany AND VST_FACTURA_ANUL_CXP.ctipodocument=TCONFIGCXP.ctipdocfact WHERE VST_FACTURA_ANUL_CXP.cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND VST_FACTURA_ANUL_CXP.ccompany='" + Frm_Padre._Str_Comp + "' AND cidcomprobanul>0 AND cstatus='0'";
                        _Ds_AuxTabs = _Mtd_GetDataSet(_Str_Sql);
                        if (Convert.ToString(_Ds_AuxTabs.Tables[0].Rows[0][0]) != "")
                        {
                            _Int_Count = Convert.ToInt32(_Ds_AuxTabs.Tables[0].Rows[0][0]);
                        }
                        if (_Int_Count != _Int_141)
                        {
                            object[] myArray = new object[1];
                            if (_Int_Count > _Int_141)
                            { _Bol_SwTimbre = true; }
                            if (_Pnl_Contenedor.Controls.Find("_Ctrl141", false).Length > 0)
                            {
                                myArray[0] = ((_Ctrl_Tabs)(_Pnl_Contenedor.Controls.Find("_Ctrl141", false)[0]));
                                this.Invoke(new MyDelegate_Ctrl_Tabs_Del(DelegateMethod_Ctrl_Tabs_Del), myArray);
                                _Int_141 = _Int_Count;
                            }
                            if (_Int_Count > 0)
                            {
                                _Ctrl_Tabs _Ctrl = new _Ctrl_Tabs();
                                _Ctrl.Name = "_Ctrl141";
                                _Ctrl._Descripcion = _Str_TabActual + "(" + _Int_Count.ToString() + ")";
                                _Ctrl._Formulario = "T3.Frm_AnulacionFacturaCxP";
                                _Ctrl._FormularioMdi = _Frm_MdiParent;
                                _Ctrl._Parametros = new object[] { "FACT", false };
                                _Ctrl.Dock = DockStyle.Top;
                                myArray[0] = _Ctrl;
                                this.Invoke(new MyDelegate_Ctrl_Tabs(DelegateMethod_Ctrl_Tabs), myArray);
                                _Int_141 = _Int_Count;
                            }
                        }
                    }
                }
                //---------------------TABS NÚMERO 141
                //---------------------------------------------------------------------------------------------------------
                //---------------------TABS NÚMERO 142
                _Str_expression = "ctabs = 142";
                _Drow_found = _Ds_FrmTabs.Tables[0].Select(_Str_expression);
                if (_Drow_found.Length > 0)
                {
                    if (myUtilidad._Mtd_ObtenerUsuarioFirma(Frm_Padre._Str_Use) == "1" & myUtilidad._Mtd_UsuarioProceso(Frm_Padre._Str_Use, "F_N1_ANULFACTURACXP"))
                    {
                        _Str_TabActual = "NDP ANULADAS POR IMPRIMIR CxP ";
                        _Int_Count = 0;
                        _Str_Sql = "SELECT COUNT(VST_FACTURA_ANUL_CXP.ccompany) FROM VST_FACTURA_ANUL_CXP INNER JOIN TCONFIGCXP ON VST_FACTURA_ANUL_CXP.ccompany=TCONFIGCXP.ccompany AND VST_FACTURA_ANUL_CXP.ctipodocument=TCONFIGCXP.ctipodocndp WHERE VST_FACTURA_ANUL_CXP.cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND VST_FACTURA_ANUL_CXP.ccompany='" + Frm_Padre._Str_Comp + "' AND cidcomprobanul>0 AND cstatus='0'";
                        _Ds_AuxTabs = _Mtd_GetDataSet(_Str_Sql);
                        if (Convert.ToString(_Ds_AuxTabs.Tables[0].Rows[0][0]) != "")
                        {
                            _Int_Count = Convert.ToInt32(_Ds_AuxTabs.Tables[0].Rows[0][0]);
                        }
                        if (_Int_Count != _Int_142)
                        {
                            object[] myArray = new object[1];
                            if (_Int_Count > _Int_142)
                            { _Bol_SwTimbre = true; }
                            if (_Pnl_Contenedor.Controls.Find("_Ctrl142", false).Length > 0)
                            {
                                myArray[0] = ((_Ctrl_Tabs)(_Pnl_Contenedor.Controls.Find("_Ctrl142", false)[0]));
                                this.Invoke(new MyDelegate_Ctrl_Tabs_Del(DelegateMethod_Ctrl_Tabs_Del), myArray);
                                _Int_142 = _Int_Count;
                            }
                            if (_Int_Count > 0)
                            {
                                _Ctrl_Tabs _Ctrl = new _Ctrl_Tabs();
                                _Ctrl.Name = "_Ctrl142";
                                _Ctrl._Descripcion = _Str_TabActual + "(" + _Int_Count.ToString() + ")";
                                _Ctrl._Formulario = "T3.Frm_AnulacionFacturaCxP";
                                _Ctrl._FormularioMdi = _Frm_MdiParent;
                                _Ctrl._Parametros = new object[] { "NDP", false };
                                _Ctrl.Dock = DockStyle.Top;
                                myArray[0] = _Ctrl;
                                this.Invoke(new MyDelegate_Ctrl_Tabs(DelegateMethod_Ctrl_Tabs), myArray);
                                _Int_142 = _Int_Count;
                            }
                        }
                    }
                }
                
                
                //---------------------TABS NÚMERO 142
                //---------------------------------------------------------------------------------------------------------
                //---------------------TABS NÚMERO 143
                _Str_expression = "ctabs = 143";
                _Drow_found = _Ds_FrmTabs.Tables[0].Select(_Str_expression);
                if (_Drow_found.Length > 0)
                {
                    if (myUtilidad._Mtd_ObtenerUsuarioFirma(Frm_Padre._Str_Use) == "1" & myUtilidad._Mtd_UsuarioProceso(Frm_Padre._Str_Use, "F_N1_ANULFACTURACXP"))
                    {
                        _Str_TabActual = "NCP ANULADAS POR IMPRIMIR CxP ";
                        _Int_Count = 0;
                        _Str_Sql = "SELECT COUNT(VST_FACTURA_ANUL_CXP.ccompany) FROM VST_FACTURA_ANUL_CXP INNER JOIN TCONFIGCXP ON VST_FACTURA_ANUL_CXP.ccompany=TCONFIGCXP.ccompany AND VST_FACTURA_ANUL_CXP.ctipodocument=TCONFIGCXP.ctipodocncp WHERE VST_FACTURA_ANUL_CXP.cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND VST_FACTURA_ANUL_CXP.ccompany='" + Frm_Padre._Str_Comp + "' AND cidcomprobanul>0 AND cstatus='0'";
                        _Ds_AuxTabs = _Mtd_GetDataSet(_Str_Sql);
                        if (Convert.ToString(_Ds_AuxTabs.Tables[0].Rows[0][0]) != "")
                        {
                            _Int_Count = Convert.ToInt32(_Ds_AuxTabs.Tables[0].Rows[0][0]);
                        }
                        if (_Int_Count != _Int_143)
                        {
                            object[] myArray = new object[1];
                            if (_Int_Count > _Int_143)
                            { _Bol_SwTimbre = true; }
                            if (_Pnl_Contenedor.Controls.Find("_Ctrl143", false).Length > 0)
                            {
                                myArray[0] = ((_Ctrl_Tabs)(_Pnl_Contenedor.Controls.Find("_Ctrl143", false)[0]));
                                this.Invoke(new MyDelegate_Ctrl_Tabs_Del(DelegateMethod_Ctrl_Tabs_Del), myArray);
                                _Int_143 = _Int_Count;
                            }
                            if (_Int_Count > 0)
                            {
                                _Ctrl_Tabs _Ctrl = new _Ctrl_Tabs();
                                _Ctrl.Name = "_Ctrl143";
                                _Ctrl._Descripcion = _Str_TabActual + "(" + _Int_Count.ToString() + ")";
                                _Ctrl._Formulario = "T3.Frm_AnulacionFacturaCxP";
                                _Ctrl._FormularioMdi = _Frm_MdiParent;
                                _Ctrl._Parametros = new object[] { "NCP", false };
                                _Ctrl.Dock = DockStyle.Top;
                                myArray[0] = _Ctrl;
                                this.Invoke(new MyDelegate_Ctrl_Tabs(DelegateMethod_Ctrl_Tabs), myArray);
                                _Int_143 = _Int_Count;
                            }
                        }
                    }
                }
                ////---------------------TABS NÚMERO 143
                //---------------------------------------------------------------------------------------------------------
                //---------------------TABS NÚMERO 144
                _Str_expression = "ctabs = 144";
                _Drow_found = _Ds_FrmTabs.Tables[0].Select(_Str_expression);
                if (_Drow_found.Length > 0)
                {                    
                    _Str_TabActual = "PEDIDOS PENDIENTES POR APROBAR - T3WEB";
                    _Int_Count = 0;
                    _Str_Sql = "EXEC PA_PEDIDOSPORAPROBARNOTIFICADORT3 '"+Frm_Padre._Str_Comp+"'";
                    _Ds_AuxTabs = _Mtd_GetDataSetWeb2012(_Str_Sql);
                    _Int_Count = _Ds_AuxTabs.Tables[0].Rows.Count;
                    //if (Convert.ToString(_Ds_AuxTabs.Tables[0].Rows[0][0]) != "")
                    //{
                    //    _Int_Count = Convert.ToInt32(_Ds_AuxTabs.Tables[0].Rows[0][0]);
                    //}
                    if (_Int_Count != _Int_144)
                    {
                        object[] myArray = new object[1];
                        if (_Int_Count > _Int_144)
                        { _Bol_SwTimbre = true; }
                        if (_Pnl_Contenedor.Controls.Find("_Ctrl144", false).Length > 0)
                        {
                            myArray[0] = ((_Ctrl_Tabs)(_Pnl_Contenedor.Controls.Find("_Ctrl144", false)[0]));
                            this.Invoke(new MyDelegate_Ctrl_Tabs_Del(DelegateMethod_Ctrl_Tabs_Del), myArray);
                            _Int_144 = _Int_Count;
                        }
                        if (_Int_Count > 0)
                        {
                            _Ctrl_Tabs _Ctrl = new _Ctrl_Tabs();
                            _Ctrl.Name = "_Ctrl144";
                            _Ctrl._Descripcion = _Str_TabActual + "(" + _Int_Count.ToString() + ")";
                            _Ctrl._Formulario = "T3.Frm_PedidosPAprobarWeb";
                            _Ctrl._FormularioMdi = _Frm_MdiParent;
                            _Ctrl._Parametros = null;
                            _Ctrl.Dock = DockStyle.Top;
                            myArray[0] = _Ctrl;
                            this.Invoke(new MyDelegate_Ctrl_Tabs(DelegateMethod_Ctrl_Tabs), myArray);
                            _Int_144 = _Int_Count;
                        }
                    }
                }
                ////---------------------------------------------------------------------------------------------------------
                //---------------------------------------------------------------------------------------------------------
                //---------------------TABS NÚMERO 145
                _Str_expression = "ctabs = 145";
                _Drow_found = _Ds_FrmTabs.Tables[0].Select(_Str_expression);
                if (_Drow_found.Length > 0)
                {
                    if (myUtilidad._Mtd_ObtenerUsuarioFirma(Frm_Padre._Str_Use) == "1")
                    {
                        if (myUtilidad._Mtd_UsuarioProceso(Frm_Padre._Str_Use, "F_APROB_COMPB_RET_PAT"))
                        {
                            _Str_TabActual = "RETENCIONES DE PATENTE POR APROBAR";
                            _Int_Count = 0;
                            //***Parametros de SP (Caso (INT) / Grupo de Compañìa (INT) / Compañìa (NVARCHAR) / @IdComprobanteRet (NUMERIC))****
                            _Str_Sql = "EXEC PA_GESTIONA_RETENCIONES_IAE 1," + Convert.ToInt32(Frm_Padre._Str_GroupComp.ToString().Trim()) + ",'" + Frm_Padre._Str_Comp.ToString().Trim() + "',0";
                            //_Str_Sql = "SELECT cidcomprobret FROM TCOMPROBANRETPAT where caprobado = '0' and canulado = '0' and cdelete = '0'";
                            _Ds_AuxTabs = _Mtd_GetDataSet(_Str_Sql);
                            _Int_Count = _Ds_AuxTabs.Tables[0].Rows.Count;
                            //if (Convert.ToString(_Ds_AuxTabs.Tables[0].Rows[0][0]) != "")
                            //{
                            //    _Int_Count = Convert.ToInt32(_Ds_AuxTabs.Tables[0].Rows[0][0]);
                            //}
                            if (_Int_Count != _Int_145)
                            {
                                object[] myArray = new object[1];
                                if (_Int_Count > _Int_145)
                                { _Bol_SwTimbre = true; }
                                if (_Pnl_Contenedor.Controls.Find("_Ctrl145", false).Length > 0)
                                {
                                    myArray[0] = ((_Ctrl_Tabs)(_Pnl_Contenedor.Controls.Find("_Ctrl145", false)[0]));
                                    this.Invoke(new MyDelegate_Ctrl_Tabs_Del(DelegateMethod_Ctrl_Tabs_Del), myArray);
                                    _Int_145 = _Int_Count;
                                }
                                if (_Int_Count > 0)
                                {
                                    _Ctrl_Tabs _Ctrl = new _Ctrl_Tabs();
                                    _Ctrl.Name = "_Ctrl145";
                                    _Ctrl._Descripcion = _Str_TabActual + " (" + _Int_Count.ToString() + ")";
                                    _Ctrl._Formulario = "T3.Frm_ComprobIAEManual";
                                    _Ctrl._FormularioMdi = _Frm_MdiParent;
                                    _Ctrl._Parametros = new object[] { true, false, false };
                                    _Ctrl.Dock = DockStyle.Top;
                                    myArray[0] = _Ctrl;
                                    this.Invoke(new MyDelegate_Ctrl_Tabs(DelegateMethod_Ctrl_Tabs), myArray);
                                    _Int_145 = _Int_Count;
                                }
                            }                                                    
                        }
                    }
                }
                ////---------------------------------------------------------------------------------------------------------
                 //---------------------------------------------------------------------------------------------------------
                //---------------------TABS NÚMERO 146
                _Str_expression = "ctabs = 146";
                _Drow_found = _Ds_FrmTabs.Tables[0].Select(_Str_expression);
                if (_Drow_found.Length > 0)
                {                    
                    _Str_TabActual = "RETENCIONES DE PATENTE POR IMPRIMIR";
                    _Int_Count = 0;
                    //***Parametros de SP (Caso (INT) / Grupo de Compañìa (INT) / Compañìa (NVARCHAR) / @IdComprobanteRet (NUMERIC))****
                    _Str_Sql = "EXEC PA_GESTIONA_RETENCIONES_IAE 3," + Convert.ToInt32(Frm_Padre._Str_GroupComp.ToString().Trim()) + ",'" + Frm_Padre._Str_Comp.ToString().Trim() + "',0";
                    _Ds_AuxTabs = _Mtd_GetDataSet(_Str_Sql);
                    _Int_Count = _Ds_AuxTabs.Tables[0].Rows.Count;
                    //if (Convert.ToString(_Ds_AuxTabs.Tables[0].Rows[0][0]) != "")
                    //{
                    //    _Int_Count = Convert.ToInt32(_Ds_AuxTabs.Tables[0].Rows[0][0]);
                    //}
                    if (_Int_Count != _Int_146)
                    {
                        object[] myArray = new object[1];
                        if (_Int_Count > _Int_146)
                        { _Bol_SwTimbre = true; }
                        if (_Pnl_Contenedor.Controls.Find("_Ctrl146", false).Length > 0)
                        {
                            myArray[0] = ((_Ctrl_Tabs)(_Pnl_Contenedor.Controls.Find("_Ctrl146", false)[0]));
                            this.Invoke(new MyDelegate_Ctrl_Tabs_Del(DelegateMethod_Ctrl_Tabs_Del), myArray);
                            _Int_146 = _Int_Count;
                        }
                        if (_Int_Count > 0)
                        {
                            _Ctrl_Tabs _Ctrl = new _Ctrl_Tabs();
                            _Ctrl.Name = "_Ctrl146";
                            _Ctrl._Descripcion = _Str_TabActual + " (" + _Int_Count.ToString() + ")";
                            _Ctrl._Formulario = "T3.Frm_ComprobIAEManual";
                            _Ctrl._FormularioMdi = _Frm_MdiParent;
                            _Ctrl._Parametros = new object[] { false, true, false };
                            _Ctrl.Dock = DockStyle.Top;
                            myArray[0] = _Ctrl;
                            this.Invoke(new MyDelegate_Ctrl_Tabs(DelegateMethod_Ctrl_Tabs), myArray);
                            _Int_146 = _Int_Count;
                        }
                    }
                }
                ////---------------------------------------------------------------------------------------------------------
                //---------------------------------------------------------------------------------------------------------
                //---------------------TABS NÚMERO 147
                _Str_expression = "ctabs = 147";
                _Drow_found = _Ds_FrmTabs.Tables[0].Select(_Str_expression);
                if (_Drow_found.Length > 0)
                {
                    _Str_TabActual = "RETENCIONES DE PATENTE RECHAZADAS";
                    _Int_Count = 0;
                    //***Parametros de SP (Caso (INT) / Grupo de Compañìa (INT) / Compañìa (NVARCHAR) / @IdComprobanteRet (NUMERIC))****
                    _Str_Sql = "EXEC PA_GESTIONA_RETENCIONES_IAE 5," + Convert.ToInt32(Frm_Padre._Str_GroupComp.ToString().Trim()) + ",'" + Frm_Padre._Str_Comp.ToString().Trim() + "',0";
                    _Ds_AuxTabs = _Mtd_GetDataSet(_Str_Sql);
                    _Int_Count = _Ds_AuxTabs.Tables[0].Rows.Count;
                    //if (Convert.ToString(_Ds_AuxTabs.Tables[0].Rows[0][0]) != "")
                    //{
                    //    _Int_Count = Convert.ToInt32(_Ds_AuxTabs.Tables[0].Rows[0][0]);
                    //}
                    if (_Int_Count != _Int_147)
                    {
                        object[] myArray = new object[1];
                        if (_Int_Count > _Int_147)
                        { _Bol_SwTimbre = true; }
                        if (_Pnl_Contenedor.Controls.Find("_Ctrl147", false).Length > 0)
                        {
                            myArray[0] = ((_Ctrl_Tabs)(_Pnl_Contenedor.Controls.Find("_Ctrl147", false)[0]));
                            this.Invoke(new MyDelegate_Ctrl_Tabs_Del(DelegateMethod_Ctrl_Tabs_Del), myArray);
                            _Int_147 = _Int_Count;
                        }
                        if (_Int_Count > 0)
                        {
                            _Ctrl_Tabs _Ctrl = new _Ctrl_Tabs();
                            _Ctrl.Name = "_Ctrl147";
                            _Ctrl._Descripcion = _Str_TabActual + " (" + _Int_Count.ToString() + ")";
                            _Ctrl._Formulario = "T3.Frm_ComprobIAEManual";
                            _Ctrl._FormularioMdi = _Frm_MdiParent;
                            _Ctrl._Parametros = new object[] { false, false, true };
                            _Ctrl.Dock = DockStyle.Top;
                            myArray[0] = _Ctrl;
                            this.Invoke(new MyDelegate_Ctrl_Tabs(DelegateMethod_Ctrl_Tabs), myArray);
                            _Int_147 = _Int_Count;
                        }
                    }
                }

                ////---------------------------------------------------------------------------------------------------------
                if (_Bol_SwTimbre)
                {
                    System.Media.SoundPlayer _MyPlayer = new System.Media.SoundPlayer(Application.StartupPath + "\\t3_timbre.wav");
                    _MyPlayer.Play();
                    _MyPlayer.Dispose();
                    _MyPlayer = null;
                    //Clases._Cls_Sound _My_ClsSound = new T3.Clases._Cls_Sound(Application.StartupPath + "\\Multimedia\\t3_timbre.wav");
                    //_My_ClsSound.Play();
                    //_My_ClsSound = null;
                }


            }
            catch
            {
                //((Frm_Padre)this.MdiParent).statusBar1.Panels[0].Text = "Problemas al cargar el tab: " + _Str_TabActual;
            }
            try
            {
                _myArrayHabilitar[1] = true;
                this.Invoke(new MyDelegate_Ctrl_Habilitar(DelegateMethod_Ctrl_Habilitar), _myArrayHabilitar);
            }
            catch
            {
                
            }
        }
        private bool _Mtd_Abierto(string _P_Str_FormName)
        {
            foreach (Form _Frm_Hijo in Application.OpenForms)
            {
                if (_Frm_Hijo.Name == _P_Str_FormName)
                {
                    return true;
                }
            }
            return false;
        }
        DataSet _Ds_CierreCaja;
        Frm_BloqueoPorCierreC _FrmBloqueoCierre;
        public bool _Bol_CierreCajaActivado = false;
        public void _Mtd_VerificarCierreCaja()
        {
            try
            {
                string _Str_cadena = "SELECT ccerrando FROM TCAJACXC WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND ccerrada='0' AND ccerrando='1'";
                _Ds_CierreCaja = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_cadena);
                if (_Ds_CierreCaja.Tables[0].Rows.Count > 0)
                {
                    if (!_Bol_CierreCajaActivado)
                    {
                        _Bol_CierreCajaActivado = true;
                    }
                    if (_Mtd_Abierto("Frm_Navegador") | _Mtd_Abierto("Frm_IngCheqDevuelto") | _Mtd_Abierto("Frm_EgreCheqTrans"))
                    {
                        if (!_Mtd_Abierto("Frm_BloqueoPorCierreC"))
                        {
                            _FrmBloqueoCierre = new Frm_BloqueoPorCierreC();
                            System.Drawing.Rectangle _rect = SystemInformation.VirtualScreen;
                            _FrmBloqueoCierre.Height = _rect.Height;
                            _FrmBloqueoCierre.Width = _rect.Width;
                            _FrmBloqueoCierre.Show();
                            _FrmBloqueoCierre.Focus();
                            _FrmBloqueoCierre.BringToFront();
                        }
                    }
                }
                else
                {
                    _Bol_CierreCajaActivado = false;
                    if (_FrmBloqueoCierre != null)
                    {
                        _FrmBloqueoCierre.Close();
                    }
                }
            }
            catch { }
        }
        private string _Mtd_OptenerVersionT3(string _P_Str_Company)
        {
            string _Str_Cadena = "SELECT cversiont3 FROM TCOMPANY WHERE ccompany='" + _P_Str_Company + "'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            return _Ds.Tables[0].Rows[0][0].ToString().Trim().ToUpper();
        }
        public bool _Mtd_IsNumeric(object Expression)
        {
            bool isNum;
            double retNum;
            isNum = Double.TryParse(Convert.ToString(Expression), System.Globalization.NumberStyles.Any, System.Globalization.NumberFormatInfo.InvariantInfo, out retNum);
            return isNum;
        }
        private int _Mtd_ConvertNumeric(string _P_Str_Cadena)
        {
            string _Str_Numero = "";
            for (int _Int_I = 0; _Int_I < _P_Str_Cadena.Length; _Int_I++)
            {
                if (_Mtd_IsNumeric(_P_Str_Cadena.Substring(_Int_I, 1)))
                { _Str_Numero += _P_Str_Cadena.Substring(_Int_I, 1); }
            }
            return Convert.ToInt32(_Str_Numero);
        }
        bool _Bol_DebeActualizar = false;
        Frm_Inicio _Frm_Inicio = new Frm_Inicio();
        private void _Mtd_VerificarVersionT3(string _P_Str_Company)
        {
            string _Str_Version = _Mtd_OptenerVersionT3(_P_Str_Company);
            int _Int_VersionActual = _Mtd_ConvertNumeric(_Frm_Inicio._Lbl_Version.Text.Trim());
            int _Int_VersionSistema = _Mtd_ConvertNumeric(_Mtd_OptenerVersionT3(_P_Str_Company));
            if (!CLASES._Cls_Conexion._Bol_Rdp)
            {
                if (_Int_VersionActual != _Int_VersionSistema)
                {
                    _Bol_DebeActualizar = true;
                    _Lbl_AlertaVersion.Text = "DEBE SALIR Y VOLVER A ENTRAR, PARA ACTUALIZAR LA VERSIÓN DEL SISTEMA A " + _Mtd_OptenerVersionT3(Frm_Padre._Str_Comp);
                    _Lbl_AlertaVersion.Visible = true;
                }
            }
        }
        int _G_Int_FormAdvertencia = 0;
        clslibraryconssa._Cls_Formato _G_Cls_Formato = new clslibraryconssa._Cls_Formato("es-VE");
        private void _Tm_Tiempo_Tick(object sender, EventArgs e)
        {
            if (_Tm_Tiempo.Interval == 1000)
            {
                _Tm_Tiempo.Interval = 30000;
            }
            //PRUEBO LA CNN
            try
            {
                _Mtd_DsTabs();
                _Mtd_VerificarCierreCaja();
                if (!_Bol_DebeActualizar) { _Mtd_VerificarVersionT3(Frm_Padre._Str_Comp); }
                _G_Int_FormAdvertencia++;
                ((Frm_Padre)this.MdiParent).statusBar1.Panels[0].Text = "Listo";
                ((Frm_Padre)this.MdiParent).statusBar1.Panels[5].Text = Clases._Cls_ProcesosCont._Mtd_ContableMes(_G_Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate())) + "-" + Clases._Cls_ProcesosCont._Mtd_ContableAno(_G_Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate()));

                if (myUtilidad._Mtd_UsuarioProceso(Frm_Padre._Str_Use, "F_CONTROL_IMP"))
                {
                    if (_G_Int_FormAdvertencia == 200)
                    {
                        ((Frm_Padre)this.MdiParent)._Mtd_ShowForm_Advertencia();
                        _G_Int_FormAdvertencia = 0;
                    }
                }
                _Pnl_Contenedor.Enabled = true;
                _Pnl_ContenedorF.Enabled = true;
                _Bol_CnnSw = true;
            }
            catch (Exception _Ex)
            {
                ((Frm_Padre)this.MdiParent).statusBar1.Panels[0].Text = "Problemas en la Conexión.";
                _Pnl_Contenedor.Enabled = false;
                _Pnl_ContenedorF.Enabled = false;
                _Bol_CnnSw = false;
            }
            if (_Bol_CnnSw)
            {
                if (_Bol_Inventario)
                {
                    if (_Frm_Conteo != null)
                    {
                        _Frm_Conteo._Mtd_Progress();
                    }
                }
                ThreadPool.QueueUserWorkItem(_async_Default);
                if (!_Bool_Boleano)
                {
                    ThreadPool.QueueUserWorkItem(_async_Favoritos);
                    _Bool_Boleano = true;
                }
            }
        }


        bool _Bool_Boleano = false;
        private void Frm_Contenedor_Load(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            try 
            {
                if (_Mtd_VerificarIp("www.twitter.com"))
                { _Mtd_MostrarActualizacionesTwitter(); }
                else
                {
                    _Mtd_CrearLinkLabel(_Pnl_NotCon, "Lo sentimos, esta información no está accesible.", Color.Black, false);
                    _Mtd_CrearLinkLabel(_Pnl_NotCorp, "Lo sentimos, esta información no está accesible.", Color.Black, false);
                    _Mtd_CrearLinkLabel(_Pnl_ActSis, "Lo sentimos, esta información no está accesible.", Color.Black, false);
                }
            } catch { }
            Cursor = Cursors.Default;
            _async_Favoritos = new WaitCallback(_Mtd_Cargar_Favoritos);
            _async_Default = new WaitCallback(_Mtd_Cargar_Tabs);
            this.BackColor = _Mtd_ColorFondoSegunCompania(Frm_Padre._Str_Comp);
        }
        private void _Mtd_ColocarLinks(LinkLabel _P_Lnk_Link,string _P_Str_Texto)
        {
            _P_Lnk_Link.LinkArea = new LinkArea(0, 0);
            string _Str_Cadena = _P_Str_Texto;
            int _Int_Desde = 0;
            int _Int_Index = 0;
            while (_Str_Cadena.IndexOf("http", _Int_Desde) > 0)
            {
                int _Int_Star = 0;
                int _Int_Length = 0;
                _Int_Star = _Str_Cadena.IndexOf("http", _Int_Desde);
                string _Str_Temp = _Str_Cadena.Substring(_Int_Star);
                if (_Str_Temp.IndexOf(" ") > 0)
                { _Int_Length = _Str_Temp.Substring(0, _Str_Temp.IndexOf(" ")).Trim().Length; }
                else
                { _Int_Length = _Str_Temp.Trim().Length; }
                _P_Lnk_Link.Links.Add(_Int_Star, _Int_Length);
                _P_Lnk_Link.Links[_Int_Index].LinkData = _Str_Cadena.Substring(_Int_Star, _Int_Length);
                if (_Int_Index == 0)
                {
                    _P_Lnk_Link.LinkClicked += new LinkLabelLinkClickedEventHandler(_P_Lnk_Link_LinkClicked);
                }
                _Int_Desde = _Int_Star + _Int_Length;
                _Int_Index += 1;
            }
        }

        void _P_Lnk_Link_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(e.Link.LinkData.ToString());
        }
        private string _Mtd_NombComp()
        {
            string _Str_Cadena = "Select RTRIM(cabreviado) COLLATE DATABASE_DEFAULT+' - '+LTRIM(cname) AS cname from dbo.TCOMPANY WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cdelete='0'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                return _Ds.Tables[0].Rows[0][0].ToString().ToUpper();
            }
            return "";
        }
        

        private void _Mtd_Desactivar()
        {
            foreach (Form _Frm in this.MdiParent.MdiChildren)
            {
                if (_Frm != this)
                {
                    if (!_Frm.Disposing)
                    {
                        _Frm.Activate();
                    }                   
                }
            }
        }
        private void Frm_Contenedor_Activated(object sender, EventArgs e)
        {
            _Mtd_Desactivar();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (CLASES._Cls_Varios_Metodos._Mtd_VerificarCnn())
            {
                _Bol_CnnSw = true;
                _Pnl_Contenedor.Enabled = true;
                _Pnl_ContenedorF.Enabled = true;
                ThreadPool.QueueUserWorkItem(_async_Default);
                ((Frm_Padre)this.MdiParent).statusBar1.Panels[0].Text = "Listo.";
            }
            else
            {
                _Bol_CnnSw = false;
                _Pnl_Contenedor.Enabled = false;
                _Pnl_ContenedorF.Enabled = false;
                ((Frm_Padre)this.MdiParent).statusBar1.Panels[0].Text = "Problemas en la Conexión.";
            }
        }
        System.Data.SqlClient.SqlDataAdapter _MyDa;
        private DataSet _Mtd_GetDataSet(string _Pr_Str_Sql)
        {
            DataSet _Ds = new DataSet();
            _MyDa = new SqlDataAdapter(_Pr_Str_Sql, Program._MyClsCnn._mtd_conexion._g_Str_Stringconex);
            _MyDa.Fill(_Ds);
            //_MyDa.Dispose();
            //_MyDa = null;
            return _Ds;
        }
        private DataSet _Mtd_GetDataSetWeb(string _Pr_Str_Sql)
        {
            DataSet _Ds = new DataSet();
            _MyDa = new SqlDataAdapter(_Pr_Str_Sql, Program._MyClsCnn._mtd_conexion2._g_Str_Stringconex);
            _MyDa.Fill(_Ds);
            //_MyDa.Dispose();
            //_MyDa = null;
            return _Ds;
        }
        private DataSet _Mtd_GetDataSetWeb2012(string _Pr_Str_Sql)
        {
            DataSet _Ds = new DataSet();
            _MyDa = new SqlDataAdapter(_Pr_Str_Sql, Program._MyClsCnn._mtd_conexionSQL2012._g_Str_Stringconex);
            _MyDa.Fill(_Ds);
            //_MyDa.Dispose();
            //_MyDa = null;
            return _Ds;
        }
        private DataSet _Mtd_GetDataSetWebLocal(string _Pr_Str_Sql)
        {
            DataSet _Ds = new DataSet();
            _MyDa = new SqlDataAdapter(_Pr_Str_Sql, Program._MyClsCnn._mtd_conexion4._g_Str_Stringconex);
            _MyDa.Fill(_Ds);
            //_MyDa.Dispose();
            //_MyDa = null;
            return _Ds;
        }
        
        /// <summary>
        /// Devuelve el color de fondo según la compañía activa.
        /// El estándar es como sigue:
        ///   - Sucursales con una sola compañía (sodica) : gris
        ///   - Sucursales con dos compañias (sodica, y morocho sodica) : sodica gris y morocho sodica gris
        ///   - Sucursales con dos compañias (sodica, mogosa) : sodica verde y mogosa azul
        ///   - Sucursales con tres compañias (sodica, mogosa y morocho sodica) : sodica verde y mogosa azul, y morocho sodica verde
        /// </summary>
        /// <param name="_Str_CodigoCompania">CCOMPANY, codigo de la compañía</param>
        /// <returns>Dato tipo Color - es el color que corresponde</returns>
        private Color _Mtd_ColorFondoSegunCompania(string _Str_CodigoCompania)
        {
            // casos no previstos: gris
            Color _Col_Color = Color.LightGray;


            // ccs
            if (_Str_CodigoCompania.Trim().ToUpper() == "S01") _Col_Color = Color.LightGray; // gris

            // bna
            if (_Str_CodigoCompania.Trim().ToUpper() == "S07") _Col_Color  = Color.LightGray; // gris
            if (_Str_CodigoCompania.Trim().ToUpper() == "S072") _Col_Color = Color.LightGray; // gris
            
            // pzo
            if (_Str_CodigoCompania.Trim().ToUpper() == "S06") _Col_Color  = Color.FromArgb(204, 255, 204); // verde
            if (_Str_CodigoCompania.Trim().ToUpper() == "S061") _Col_Color = Color.FromArgb(164, 196, 255); // azul
            
            // andina
            if (_Str_CodigoCompania.Trim().ToUpper() == "S03") _Col_Color = Color.FromArgb(204, 255, 204);  // verde
            if (_Str_CodigoCompania.Trim().ToUpper() == "S031") _Col_Color = Color.FromArgb(164, 196, 255); // azul

            // mcbo
            if (_Str_CodigoCompania.Trim().ToUpper() == "S02") _Col_Color = Color.FromArgb(204, 255, 204);  // verde
            if (_Str_CodigoCompania.Trim().ToUpper() == "S021") _Col_Color = Color.FromArgb(164, 196, 255); // azul

            // bqto
            if (_Str_CodigoCompania.Trim().ToUpper() == "S04") _Col_Color = Color.FromArgb(204, 255, 204);  // verde
            if (_Str_CodigoCompania.Trim().ToUpper() == "S041") _Col_Color = Color.FromArgb(164, 196, 255); // azul
            if (_Str_CodigoCompania.Trim().ToUpper() == "S042") _Col_Color = Color.FromArgb(204, 255, 204); // verde

            // mcy
            if (_Str_CodigoCompania.Trim().ToUpper() == "S05") _Col_Color = Color.FromArgb(204, 255, 204);  // verde
            if (_Str_CodigoCompania.Trim().ToUpper() == "S051") _Col_Color = Color.FromArgb(164, 196, 255); // azul
            if (_Str_CodigoCompania.Trim().ToUpper() == "S052") _Col_Color = Color.FromArgb(204, 255, 204); // verde


            // clz
            if (_Str_CodigoCompania.Trim().ToUpper() == "S08") _Col_Color = Color.LightGray; // gris

            return _Col_Color;
        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        public bool _Bol_CambioComp = false;
        private void Frm_Contenedor_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing & !_Bol_CambioComp)
            { e.Cancel = true; }
        }

        private void _Bt_CambiarComp_Click(object sender, EventArgs e)
        {
            _Ctrl_Comp _Ctrl_Com = new _Ctrl_Comp();
        }
        
        /// <summary>
        /// Ejecuta un web request, y devuelve un string con el resultado
        /// </summary>
        /// <param name="_Str_Metodo">GET o POST</param>
        /// <param name="_Str_URL">Dirección que obtiene el request</param>
        /// <param name="_Int_TimeoutEnSegundos">Tiempo en segundos que espera el recurso antes de dar TIMEOUT</param>
        /// <returns></returns>
        
        private string _Mtd_EjecutarRequestWeb(string _Str_Metodo, string _Str_URL, int _Int_TimeoutEnSegundos)
        {
            string _Str_UsuarioWindowsLocal = ConfigurationManager.AppSettings["user"];
            string _Str_ContrasenaUsuarioLocal = ConfigurationManager.AppSettings["password"];

            HttpWebRequest _WEB_Request = (HttpWebRequest)HttpWebRequest.Create(_Str_URL);
            _WEB_Request.Timeout = _Int_TimeoutEnSegundos * 1000;
            _WEB_Request.Method = _Str_Metodo;
            _WEB_Request.Credentials = new NetworkCredential(_Str_UsuarioWindowsLocal, _Str_ContrasenaUsuarioLocal);
            WebResponse _WEB_Response = _WEB_Request.GetResponse();

            StreamReader _WEB_SteamReader = new StreamReader(_WEB_Response.GetResponseStream());
            string _Str_Response = _WEB_SteamReader.ReadToEnd();
            _WEB_SteamReader.Close();

            return _Str_Response;
        }

        private string _Mtd_EjecutarRequestWeb_POST(string _Str_URL, int _Int_TimeoutEnSegundos)
        {
            return _Mtd_EjecutarRequestWeb("POST", _Str_URL, _Int_TimeoutEnSegundos);
        }

        private string _Mtd_EjecutarRequestWeb_GET(string _Str_URL, int _Int_TimeoutEnSegundos)
        {
            return _Mtd_EjecutarRequestWeb("GET", _Str_URL, _Int_TimeoutEnSegundos);
        }
        private void _Mtd_CrearLinkLabel(Control _P_Ctrl_Contenedor, string _P_Str_Text, Color _P_Color, bool _P_Bol_Resaltar)
        {
            GroupBox _Grb_Cont = new GroupBox();
            _Grb_Cont.Size = new Size(286, 54);
            _Grb_Cont.Dock = DockStyle.Top;
            _Grb_Cont.Location = new Point(0, 0);
            //-----------------------------
            LinkLabel _Link = new LinkLabel();
            _Link.Font = new Font("Verdana", 8F);
            _Link.Location = new Point(0, 0);
            _Link.Text = _P_Str_Text;
            if (_P_Bol_Resaltar)
            { _Link.ForeColor = Color.Red; }
            _Link.Dock = DockStyle.Fill;
            _Grb_Cont.Controls.Add(_Link);
            _P_Ctrl_Contenedor.Controls.Add(_Grb_Cont);
            _Grb_Cont.BringToFront();
            try
            {
                _Mtd_ColocarLinks(_Link, _Link.Text);
            }
            catch { }
        }
        private void _Mtd_MostrarActualizacionesTwitter()
        {
            string _Str_UsuarioTwitter;
            string _Str_URL;
            string _Str_Response;

            string _Str_dayOfWeek;
            string _Str_month;
            string _Str_dayInMonth;
            string _Str_time;
            string _Str_offset;
            string _Str_year;

            string _Str_FraseTwitterDiferenciaTiempo;

            DateTime _DT_FechaTweet;
            TimeSpan _TS_DiferenciaFecha;
            DataSet _Ds_Actualizaciones = new DataSet();
            DataSet _Ds_Noticias = new DataSet();
            DataSet _Ds_Conssa = new DataSet();

            // actualizaciones ===================================================================
            _Str_dayOfWeek = "";
            _Str_month = "";
            _Str_dayInMonth = "";
            _Str_time = "";
            _Str_offset = "";
            _Str_year = "";

            _Str_UsuarioTwitter = "noticonssa";
            _Str_URL = string.Format("http://twitter.com/favorites/{0}.xml?count=3", _Str_UsuarioTwitter);


            //_Lbl_LabelActualizaciones.Text = "";

            try
            {
                _Str_Response = _Mtd_EjecutarRequestWeb_GET(_Str_URL, 3);
                _Ds_Actualizaciones.ReadXml(new System.IO.StringReader(_Str_Response));
            }
            catch
            {
                //_Lbl_LabelActualizaciones.Text = "Lo sentimos, esta información no está disponible.";
                _Mtd_CrearLinkLabel(_Pnl_NotCon, "Lo sentimos, esta información no está disponible.", Color.Black, false);
            }

            if (_Ds_Actualizaciones.Tables.Count > 0)
            {
                string _Str_Texto = "";
                string _Str_Fecha = "";

                if (_Ds_Actualizaciones.Tables["status"].Rows.Count > 0)
                {
                    for (int _Int_I = 0; _Int_I < _Ds_Actualizaciones.Tables["status"].Rows.Count; _Int_I++)
                    {
                        _Str_Texto = _Ds_Actualizaciones.Tables["status"].Rows[_Int_I]["text"].ToString();
                        _Str_Fecha = _Ds_Actualizaciones.Tables["status"].Rows[_Int_I]["created_at"].ToString();


                        _Str_dayOfWeek = _Str_Fecha.Substring(0, 3).Trim();
                        _Str_month = _Str_Fecha.Substring(4, 3).Trim();
                        _Str_dayInMonth = _Str_Fecha.Substring(8, 2).Trim();
                        _Str_time = _Str_Fecha.Substring(11, 9).Trim();
                        _Str_offset = _Str_Fecha.Substring(20, 5).Trim();
                        _Str_year = _Str_Fecha.Substring(25, 5).Trim();
                        _Str_Fecha = string.Format("{0}-{1}-{2} {3}", _Str_dayInMonth, _Str_month, _Str_year, _Str_time);

                        _DT_FechaTweet = Convert.ToDateTime(_Str_Fecha);

                        // le resta 4 horas y media, para obtener la hora Venezuela
                        _DT_FechaTweet = _DT_FechaTweet.AddHours(-4.5);

                        _TS_DiferenciaFecha = DateTime.Now.Subtract(_DT_FechaTweet);

                        _Str_FraseTwitterDiferenciaTiempo = "";

                        if (_TS_DiferenciaFecha.Days != 0) // la diferencia es de días
                        {
                            if (_TS_DiferenciaFecha.Days > 1) _Str_FraseTwitterDiferenciaTiempo = _TS_DiferenciaFecha.Days.ToString() + " días atrás";
                            if (_TS_DiferenciaFecha.Days == 1) _Str_FraseTwitterDiferenciaTiempo = "hace 1 día";
                            _Mtd_CrearLinkLabel(_Pnl_NotCon, " \u25CF " + _Str_Texto + " - " + _Str_FraseTwitterDiferenciaTiempo, Color.Black, false);
                        }
                        else
                        {
                            if (_TS_DiferenciaFecha.Hours != 0) // la diferencia es de horas
                            {
                                _Str_FraseTwitterDiferenciaTiempo = _TS_DiferenciaFecha.Hours.ToString() + " horas atrás";
                            }
                            else
                            {
                                if (_TS_DiferenciaFecha.Minutes != 0) // la diferencia es de minutos
                                {
                                    _Str_FraseTwitterDiferenciaTiempo = "hace " + _TS_DiferenciaFecha.Minutes.ToString() + " minutos";
                                }
                                else // la diferencia es de segundos
                                {
                                    _Str_FraseTwitterDiferenciaTiempo = "hace menos de un minuto";
                                }
                            }
                            _Mtd_CrearLinkLabel(_Pnl_NotCon, " \u25CF " + _Str_Texto + " - " + _Str_FraseTwitterDiferenciaTiempo, Color.Black, true);
                        }
                        //_Lbl_LabelActualizaciones.Text += " \u25CF " + _Str_Texto + " - " + _Str_FraseTwitterDiferenciaTiempo + "\r\n\r\n";
                    }
                }
            }

            // noticias ====================================================================

            _Str_dayOfWeek = "";
            _Str_month = "";
            _Str_dayInMonth = "";
            _Str_time = "";
            _Str_offset = "";
            _Str_year = "";

            _Str_UsuarioTwitter = "twit3er";
            _Str_URL = string.Format("http://twitter.com/favorites/{0}.xml?count=3", _Str_UsuarioTwitter);

            //_Lbl_LabelNoticias.Text = "";

            try
            {
                _Str_Response = _Mtd_EjecutarRequestWeb_GET(_Str_URL, 3);
                _Ds_Noticias.ReadXml(new System.IO.StringReader(_Str_Response));
            }
            catch
            {
                //_Lbl_LabelNoticias.Text = "Lo sentimos, esta información no está disponible.";
                _Mtd_CrearLinkLabel(_Pnl_ActSis, "Lo sentimos, esta información no está disponible.", Color.Black, false);
            }

            if (_Ds_Noticias.Tables.Count > 0)
            {
                string _Str_Texto = "";
                string _Str_Fecha = "";

                if (_Ds_Noticias.Tables["status"].Rows.Count > 0)
                {
                    for (int _Int_I = 0; _Int_I < _Ds_Noticias.Tables["status"].Rows.Count; _Int_I++)
                    {
                        _Str_Texto = _Ds_Noticias.Tables["status"].Rows[_Int_I]["text"].ToString();
                        _Str_Fecha = _Ds_Noticias.Tables["status"].Rows[_Int_I]["created_at"].ToString();


                        _Str_dayOfWeek = _Str_Fecha.Substring(0, 3).Trim();
                        _Str_month = _Str_Fecha.Substring(4, 3).Trim();
                        _Str_dayInMonth = _Str_Fecha.Substring(8, 2).Trim();
                        _Str_time = _Str_Fecha.Substring(11, 9).Trim();
                        _Str_offset = _Str_Fecha.Substring(20, 5).Trim();
                        _Str_year = _Str_Fecha.Substring(25, 5).Trim();
                        _Str_Fecha = string.Format("{0}-{1}-{2} {3}", _Str_dayInMonth, _Str_month, _Str_year, _Str_time);

                        _DT_FechaTweet = Convert.ToDateTime(_Str_Fecha);

                        // le resta 4 horas y media, para obtener la hora Venezuela
                        _DT_FechaTweet = _DT_FechaTweet.AddHours(-4.5);

                        _TS_DiferenciaFecha = DateTime.Now.Subtract(_DT_FechaTweet);

                        _Str_FraseTwitterDiferenciaTiempo = "";

                        if (_TS_DiferenciaFecha.Days != 0) // la diferencia es de días
                        {
                            if (_TS_DiferenciaFecha.Days > 1) _Str_FraseTwitterDiferenciaTiempo = _TS_DiferenciaFecha.Days.ToString() + " días atrás";
                            if (_TS_DiferenciaFecha.Days == 1) _Str_FraseTwitterDiferenciaTiempo = "hace 1 día";
                            _Mtd_CrearLinkLabel(_Pnl_ActSis, " \u25CF " + _Str_Texto + " - " + _Str_FraseTwitterDiferenciaTiempo, Color.Black, false);
                        }
                        else
                        {
                            if (_TS_DiferenciaFecha.Hours != 0) // la diferencia es de horas
                            {
                                _Str_FraseTwitterDiferenciaTiempo = _TS_DiferenciaFecha.Hours.ToString() + " horas atrás";
                            }
                            else
                            {
                                if (_TS_DiferenciaFecha.Minutes != 0) // la diferencia es de minutos
                                {
                                    _Str_FraseTwitterDiferenciaTiempo = "hace " + _TS_DiferenciaFecha.Minutes.ToString() + " minutos";
                                }
                                else // la diferencia es de segundos
                                {
                                    _Str_FraseTwitterDiferenciaTiempo = "hace menos de un minuto";
                                }
                            }
                            _Mtd_CrearLinkLabel(_Pnl_ActSis, " \u25CF " + _Str_Texto + " - " + _Str_FraseTwitterDiferenciaTiempo, Color.Black, true);
                        }
                        //_Lbl_LabelNoticias.Text += " \u25CF " + _Str_Texto + " - " + _Str_FraseTwitterDiferenciaTiempo + "\r\n\r\n";
                    }
                }
            }

            // conssa ===================================================================
            _Str_dayOfWeek = "";
            _Str_month = "";
            _Str_dayInMonth = "";
            _Str_time = "";
            _Str_offset = "";
            _Str_year = "";

            _Str_UsuarioTwitter = "soditwitt";
            _Str_URL = string.Format("http://twitter.com/favorites/{0}.xml?count=3", _Str_UsuarioTwitter);


            //_Lbl_LabelConssa.Text = "";

            try
            {
                _Str_Response = _Mtd_EjecutarRequestWeb_GET(_Str_URL, 3);
                _Ds_Conssa.ReadXml(new System.IO.StringReader(_Str_Response));
            }
            catch
            {
                //_Lbl_LabelConssa.Text = "Lo sentimos, esta información no está disponible.";
                _Mtd_CrearLinkLabel(_Pnl_NotCorp, "Lo sentimos, esta información no está disponible.", Color.Black, false);
            }

            if (_Ds_Conssa.Tables.Count > 0)
            {
                string _Str_Texto = "";
                string _Str_Fecha = "";

                if (_Ds_Conssa.Tables["status"].Rows.Count > 0)
                {
                    for (int _Int_I = 0; _Int_I < _Ds_Conssa.Tables["status"].Rows.Count; _Int_I++)
                    {
                        _Str_Texto = _Ds_Conssa.Tables["status"].Rows[_Int_I]["text"].ToString();
                        _Str_Fecha = _Ds_Conssa.Tables["status"].Rows[_Int_I]["created_at"].ToString();


                        _Str_dayOfWeek = _Str_Fecha.Substring(0, 3).Trim();
                        _Str_month = _Str_Fecha.Substring(4, 3).Trim();
                        _Str_dayInMonth = _Str_Fecha.Substring(8, 2).Trim();
                        _Str_time = _Str_Fecha.Substring(11, 9).Trim();
                        _Str_offset = _Str_Fecha.Substring(20, 5).Trim();
                        _Str_year = _Str_Fecha.Substring(25, 5).Trim();
                        _Str_Fecha = string.Format("{0}-{1}-{2} {3}", _Str_dayInMonth, _Str_month, _Str_year, _Str_time);

                        _DT_FechaTweet = Convert.ToDateTime(_Str_Fecha);

                        // le resta 4 horas y media, para obtener la hora Venezuela
                        _DT_FechaTweet = _DT_FechaTweet.AddHours(-4.5);

                        _TS_DiferenciaFecha = DateTime.Now.Subtract(_DT_FechaTweet);

                        _Str_FraseTwitterDiferenciaTiempo = "";

                        if (_TS_DiferenciaFecha.Days != 0) // la diferencia es de días
                        {
                            if (_TS_DiferenciaFecha.Days > 1) _Str_FraseTwitterDiferenciaTiempo = _TS_DiferenciaFecha.Days.ToString() + " días atrás";
                            if (_TS_DiferenciaFecha.Days == 1) _Str_FraseTwitterDiferenciaTiempo = "hace 1 día";
                            _Mtd_CrearLinkLabel(_Pnl_NotCorp, " \u25CF " + _Str_Texto + " - " + _Str_FraseTwitterDiferenciaTiempo, Color.Black, false);
                        }
                        else
                        {
                            //_Lbl_LabelConssa.ForeColor = Color.RoyalBlue;
                            if (_TS_DiferenciaFecha.Hours != 0) // la diferencia es de horas
                            {
                                _Str_FraseTwitterDiferenciaTiempo = _TS_DiferenciaFecha.Hours.ToString() + " horas atrás";
                            }
                            else
                            {
                                if (_TS_DiferenciaFecha.Minutes != 0) // la diferencia es de minutos
                                {
                                    _Str_FraseTwitterDiferenciaTiempo = "hace " + _TS_DiferenciaFecha.Minutes.ToString() + " minutos";
                                }
                                else // la diferencia es de segundos
                                {
                                    _Str_FraseTwitterDiferenciaTiempo = "hace menos de un minuto";
                                }
                            }
                            _Mtd_CrearLinkLabel(_Pnl_NotCorp, " \u25CF " + _Str_Texto + " - " + _Str_FraseTwitterDiferenciaTiempo, Color.Black, true);
                        }
                        //_Lbl_LabelConssa.Text += " \u25CF " + _Str_Texto + " - " + _Str_FraseTwitterDiferenciaTiempo + "\r\n\r\n";
                    }
                }
            }
        }
    }
}