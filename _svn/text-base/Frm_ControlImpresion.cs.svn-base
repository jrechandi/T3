using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace T3
{
    public partial class Frm_ControlImpresion : Form
    {
        Form _G_Pr_Frm_MdiParent;
        public Frm_ControlImpresion(Form _Pr_Frm_MdiParent)
        {
            InitializeComponent();
            _G_Pr_Frm_MdiParent = _Pr_Frm_MdiParent;
        }

        private int _Mtd_GetNCclientes_Print()
        {
            int _Int_Count=0;
            string _Str_Sql = "SELECT ((Select count(cidnotcredicc) from TNOTACREDICC where cdelete='0' and ccompany='" + Frm_Padre._Str_Comp + "' and cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and cexedentecobro<>'1' and cimpresa='0' and cactivo='0' AND cestatusfirma=2 AND (cidnotrecepc=0 or cidnotrecepc is null) AND NOT EXISTS(SELECT ccliente FROM TICRELAPROCLI WHERE TICRELAPROCLI.ccliente=TNOTACREDICC.ccliente AND ISNULL(TICRELAPROCLI.cdelete,0)=0)) + " +
                    "(Select count(cidnotcredicc) from TNOTACREDICC INNER JOIN TNOTARECEPC ON TNOTACREDICC.ccompany=TNOTARECEPC.ccompany AND TNOTACREDICC.cgroupcomp=TNOTARECEPC.cgroupcomp AND TNOTACREDICC.cidnotrecepc=TNOTARECEPC.cidnotrecepc where TNOTACREDICC.cdelete='0' and TNOTACREDICC.ccompany='" + Frm_Padre._Str_Comp + "' and TNOTACREDICC.cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and TNOTACREDICC.cimpresa='0' and TNOTACREDICC.cactivo='0' and TNOTARECEPC.cimpreso=1 AND NOT EXISTS(SELECT ccliente FROM TICRELAPROCLI WHERE TICRELAPROCLI.ccliente=TNOTACREDICC.ccliente AND ISNULL(TICRELAPROCLI.cdelete,0)=0)))";
            DataSet _Ds_AuxTabs = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
            if (Convert.ToString(_Ds_AuxTabs.Tables[0].Rows[0][0]) != "")
            {
                _Int_Count = Convert.ToInt32(_Ds_AuxTabs.Tables[0].Rows[0][0]);
            }
            return _Int_Count;
        }
        private int _Mtd_GetNCproveedores_Print()
        {
            int _Int_Count = 0;
            string _Str_Sql = "Select count(ccompany) from TNOTACREDICP where cdelete='0' and ccompany='" + Frm_Padre._Str_Comp + "' and cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and cimpresa='0' and cactivo='0' and cestatusfirma='2' and canulado='0' AND (cmanual='1' OR cidnotrecepc>0)";
            DataSet _Ds_AuxTabs = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
            if (Convert.ToString(_Ds_AuxTabs.Tables[0].Rows[0][0]) != "")
            {
                _Int_Count = Convert.ToInt32(_Ds_AuxTabs.Tables[0].Rows[0][0]);
            }
            return _Int_Count;
        }
        private int _Mtd_GetNDclientes_Print()
        {
            int _Int_Count = 0;
            string _Str_Sql = "Select count(ccompany) from TNOTADEBICC where cdelete='0' and ccompany='" + Frm_Padre._Str_Comp + "' and cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and cimpresa='0' and cactivo='0' AND cestatusfirma=2 AND NOT EXISTS(SELECT ccliente FROM TICRELAPROCLI WHERE TICRELAPROCLI.ccliente=TNOTADEBICC.ccliente AND ISNULL(TICRELAPROCLI.cdelete,0)=0)";
            DataSet _Ds_AuxTabs = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
            if (Convert.ToString(_Ds_AuxTabs.Tables[0].Rows[0][0]) != "")
            {
                _Int_Count = Convert.ToInt32(_Ds_AuxTabs.Tables[0].Rows[0][0]);
            }
            return _Int_Count;
        }
        private int _Mtd_GetNDproveedores_Print()
        {
            int _Int_Count = 0;
            string _Str_Sql = "Select count(ccompany) from TNOTADEBITOCP where cdelete='0' and ccompany='" + Frm_Padre._Str_Comp + "' and cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and cimpresa='0' and cactivo='0' and cestatusfirma='2' and canulado='0' AND (cmanual='1' OR cidnotrecepc>0 OR (cmanual='0' AND cidnotrecepc='0' AND cidcomprob>0 AND cdescontada='1'))";
            DataSet _Ds_AuxTabs = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
            if (Convert.ToString(_Ds_AuxTabs.Tables[0].Rows[0][0]) != "")
            {
                _Int_Count = Convert.ToInt32(_Ds_AuxTabs.Tables[0].Rows[0][0]);
            }
            return _Int_Count;
        }
        private int _Mtd_GetComprobISLR_Print()
        {
            int _Int_Count = 0;
            string _Str_Sql = "select count(ccompany) from TCOMPROBANISLRC WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cimpreso=0 AND canulado=0 AND NOT EXISTS(SELECT cidcomprobislr FROM TFACTPPAGARM WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND TFACTPPAGARM.cidcomprobislr=TCOMPROBANISLRC.cidcomprobislr AND cestatusfirma='1')";
            DataSet _Ds_AuxTabs = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
            if (Convert.ToString(_Ds_AuxTabs.Tables[0].Rows[0][0]) != "")
            {
                _Int_Count = Convert.ToInt32(_Ds_AuxTabs.Tables[0].Rows[0][0]);
            }
            return _Int_Count;
        }
        private int _Mtd_GetComprobIVA_Print()
        {
            int _Int_Count = 0;
            string _Str_Sql = "select count(ccompany) from TCOMPROBANRETC WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cimpreso=0 AND canulado=0 AND NOT EXISTS(SELECT cidcomprobret FROM TFACTPPAGARM WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND TFACTPPAGARM.cidcomprobret=TCOMPROBANRETC.cidcomprobret AND cestatusfirma='1')";
            DataSet _Ds_AuxTabs = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
            if (Convert.ToString(_Ds_AuxTabs.Tables[0].Rows[0][0]) != "")
            {
                _Int_Count = Convert.ToInt32(_Ds_AuxTabs.Tables[0].Rows[0][0]);
            }
            return _Int_Count;
        }
        private int _Mtd_GetComprob_Print()
        {
            int _Int_Count = 0;
            string _Str_Sql = "SELECT COUNT(CIDCOMPROB) FROM TCOMPROBANC INNER JOIN TMESCONTABLE ON TCOMPROBANC.cyearacco = TMESCONTABLE.cyearacco AND " +
                               "TCOMPROBANC.cmontacco = TMESCONTABLE.cmontacco AND TCOMPROBANC.ccompany = TMESCONTABLE.ccompany  WHERE TCOMPROBANC.ccompany='" + Frm_Padre._Str_Comp + "' AND TCOMPROBANC.cstatus<>'9' AND TMESCONTABLE.ccerrado='0' AND TCOMPROBANC.cstatus<>'1' AND csistema='1' AND ccuadrado='1' AND ctotdebe>0 AND NOT EXISTS(SELECT cidcomprob FROM TPAGOSCXPM WHERE TPAGOSCXPM.cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND TPAGOSCXPM.ccompany=TCOMPROBANC.ccompany AND TPAGOSCXPM.cidcomprob=TCOMPROBANC.cidcomprob) AND NOT EXISTS(SELECT cidcomprob FROM TCOMPROBANRETC WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND TCOMPROBANRETC.cidcomprob=TCOMPROBANC.cidcomprob) AND NOT EXISTS(SELECT cidcomprob FROM TCOMPROBANISLRC WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND TCOMPROBANISLRC.cidcomprob=TCOMPROBANC.cidcomprob) AND NOT EXISTS(SELECT cidcomprob FROM TNOTARECEPC WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND TNOTARECEPC.cidcomprob=TCOMPROBANC.cidcomprob)";
            DataSet _Ds_AuxTabs = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
            if (Convert.ToString(_Ds_AuxTabs.Tables[0].Rows[0][0]) != "")
            {
                _Int_Count = Convert.ToInt32(_Ds_AuxTabs.Tables[0].Rows[0][0]);
            }
            return _Int_Count;
        }
        private int _Mtd_GetNr_Devol()
        {
            int _Int_Count = 0;
            string _Str_Sql = "SELECT count(ccompany) FROM VST_NOTARECEPC_DEVOL WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cimpreso=0 AND cdelete=0";
            DataSet _Ds_AuxTabs = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
            if (Convert.ToString(_Ds_AuxTabs.Tables[0].Rows[0][0]) != "")
            {
                _Int_Count = Convert.ToInt32(_Ds_AuxTabs.Tables[0].Rows[0][0]);
            }
            return _Int_Count;
        }
        private bool _Mtd_DsTabs(int _P_Int_Tab)
        {
            string _Str_Sql = "SELECT TTABS.ctabs " +
                 "FROM TUSER INNER JOIN " +
                 "TTABS ON TUSER.cgroup = TTABS.cgroup " +
                 "WHERE TUSER.cdelete = 0 and TUSER.cuser='" + Frm_Padre._Str_Use + "' AND TTABS.ctabs='" + _P_Int_Tab + "'";
            return Program._MyClsCnn._mtd_conexion._Mtd_ExistenRegistros(_Str_Sql);
        }
        private void _Mtd_ActualizarBotones()
        {
            int _Int_NCclientes_Print = _Mtd_GetNCclientes_Print();
            int _Int_NCproveedores_Print = _Mtd_GetNCproveedores_Print();
            int _Int_NDclientes_Print = _Mtd_GetNDclientes_Print();
            int _Int_NDproveedores_Print = _Mtd_GetNDproveedores_Print();
            int _Int_ComprobISLR_Print = _Mtd_GetComprobISLR_Print();
            int _Int_ComprobIVA_Print = _Mtd_GetComprobIVA_Print();
            int _Int_Comprob_Print = _Mtd_GetComprob_Print();
            int _Int_Nr_Devol_Print = _Mtd_GetNr_Devol();
            if (_Int_NCclientes_Print > 0)
            {
                _Bt_NC_Cliente.Enabled = _Mtd_DsTabs(43);
            }
            if (_Int_NCproveedores_Print > 0)
            {
                _Bt_NC_Proveedor.Enabled = _Mtd_DsTabs(15);
            }
            if (_Int_NDclientes_Print > 0)
            {
                _Bt_ND_Cliente.Enabled = _Mtd_DsTabs(42);
            }
            if (_Int_NDproveedores_Print > 0)
            {
                _Bt_ND_Proveedores.Enabled = _Mtd_DsTabs(14);
            }
            if (_Int_ComprobISLR_Print > 0)
            {
                _Bt_ComproISLR.Enabled = _Mtd_DsTabs(30);
            }
            if (_Int_ComprobIVA_Print > 0)
            {
                _Bt_ComproIVA.Enabled = _Mtd_DsTabs(27);
            }
            if (_Int_Comprob_Print > 0)
            {
                _Bt_Comprobantes.Enabled = _Mtd_DsTabs(87);
            }
            if (_Int_Nr_Devol_Print > 0)
            {
                _Bt_NR_Devolucion.Enabled = _Mtd_DsTabs(57);
            }
            _Bt_NC_Cliente.Text = "NC Clientes (" + _Int_NCclientes_Print.ToString() + ")";
            _Bt_NC_Proveedor.Text = "NC Proveedores (" + _Int_NCproveedores_Print.ToString() + ")";
            _Bt_ND_Cliente.Text = "ND Clientes (" + _Int_NDclientes_Print.ToString() + ")";
            _Bt_ND_Proveedores.Text = "ND Proveedores (" + _Int_NDproveedores_Print.ToString() + ")";
            _Bt_ComproISLR.Text = "Ret. ISLR (" + _Int_ComprobISLR_Print.ToString() + ")";
            _Bt_ComproIVA.Text = "Ret. IVA (" + _Int_ComprobIVA_Print.ToString() + ")";
            _Bt_Comprobantes.Text = "Comprobantes (" + _Int_Comprob_Print.ToString() + ")";
            _Bt_NR_Devolucion.Text = "NR por Devol. (" + _Int_Nr_Devol_Print.ToString() + ")";
        }

        public bool _Mtd_MostrarFormulario()
        {
            return (_Mtd_DsTabs(43) && _Mtd_GetNCclientes_Print() > 0) ||
                   (_Mtd_DsTabs(15) && _Mtd_GetNCproveedores_Print() > 0) ||
                   (_Mtd_DsTabs(42) && _Mtd_GetNDclientes_Print() > 0) ||
                   (_Mtd_DsTabs(14) && _Mtd_GetNDproveedores_Print() > 0) ||
                   (_Mtd_DsTabs(30) && _Mtd_GetComprobISLR_Print() > 0) ||
                   (_Mtd_DsTabs(27) && _Mtd_GetComprobIVA_Print() > 0) ||
                   (_Mtd_DsTabs(87) && _Mtd_GetComprob_Print() > 0) ||
                   (_Mtd_DsTabs(57) && _Mtd_GetNr_Devol() > 0);
        }

        private void Frm_ControlImpresion_Load(object sender, EventArgs e)
        {
            _Mtd_ActualizarBotones();
        }

        private void _Bt_ImpriLuego_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void _Bt_NC_Cliente_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            Frm_ImpresionLote _Frm_ImpresionLote = new Frm_ImpresionLote(1);
            _Frm_ImpresionLote.MdiParent = _G_Pr_Frm_MdiParent;
            _Frm_ImpresionLote.Show();
            this.Cursor = Cursors.Default;
            this.Close();
        }

        private void _Bt_NC_Proveedor_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            ToolStripMenuItem[] _Tsm_Menu = new ToolStripMenuItem[2];
            _Tsm_Menu[0] = new ToolStripMenuItem("Código");
            _Tsm_Menu[1] = new ToolStripMenuItem("Descripción");
            string[] _Str_Campos = new string[2];
            _Str_Campos[0] = "cidnotacreditocxp";
            _Str_Campos[1] = "cdescripcion";
            string _Str_Sql = "Select cidnotacreditocxp as Código,cdescripcion as Descripción,ISNULL(cmontototsi,0)+ISNULL(cbaseexcenta,0) as Monto from TNOTACREDICP where cdelete='0' and ccompany='" + Frm_Padre._Str_Comp + "' and cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and cimpresa='0' and cactivo='0' and cestatusfirma='2' and canulado='0' AND (cmanual='1' OR cidnotrecepc>0)";
            Frm_NRNCND _Frm_NRNCND = new Frm_NRNCND(_Str_Sql, _Str_Campos, "N.C. por Imprimir - Proveedores", _Tsm_Menu,3);
            _Frm_NRNCND.MdiParent = _G_Pr_Frm_MdiParent;
            _Frm_NRNCND.Show();
            this.Cursor = Cursors.Default;
            this.Close();
        }

        private void _Bt_ND_Cliente_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            Frm_ImpresionLote _Frm_ImpresionLote = new Frm_ImpresionLote(2);
            _Frm_ImpresionLote.MdiParent = _G_Pr_Frm_MdiParent;
            _Frm_ImpresionLote.Show();
            this.Cursor = Cursors.Default;
            this.Close();
        }

        private void _Bt_ND_Proveedores_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            ToolStripMenuItem[] _Tsm_Menu = new ToolStripMenuItem[2];
            _Tsm_Menu[0] = new ToolStripMenuItem("Código");
            _Tsm_Menu[1] = new ToolStripMenuItem("Descripción");
            string[] _Str_Campos = new string[2];
            _Str_Campos[0] = "cidnotadebitocxp";
            _Str_Campos[1] = "cdescripcion";
            string _Str_Sql = "Select cidnotadebitocxp as Código,cdescripcion as Descripción,CASE WHEN cidnotrecepc>0 THEN ISNULL(cmontototsi,0) ELSE ISNULL(cmontototsi,0)+ISNULL(cbaseexcenta,0) END as Monto from TNOTADEBITOCP where cdelete='0' and ccompany='" + Frm_Padre._Str_Comp + "' and cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and cimpresa='0' and cactivo='0' and cestatusfirma='2' and canulado='0' AND (cmanual='1' OR cidnotrecepc>0 OR (cmanual='0' AND cidnotrecepc='0' AND cidcomprob>0 AND cdescontada='1'))";
            Frm_NRNCND _Frm_NRNCND = new Frm_NRNCND(_Str_Sql, _Str_Campos, "N.D. por Imprimir - Proveedores", _Tsm_Menu, 2);
            _Frm_NRNCND.MdiParent = _G_Pr_Frm_MdiParent;
            _Frm_NRNCND.Show();
            this.Cursor = Cursors.Default;
            this.Close();
        }

        private void _Bt_ComproISLR_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            Frm_Busqueda2 _Frm_Busqueda2 = new Frm_Busqueda2(6);
            _Frm_Busqueda2.MdiParent = _G_Pr_Frm_MdiParent;
            _Frm_Busqueda2.Show();
            this.Cursor = Cursors.Default;
            this.Close();
        }

        private void _Bt_Comprobantes_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            Frm_ConsultaComprobante _Frm = new Frm_ConsultaComprobante(true);
            Cursor = Cursors.Default;
            _Frm.MdiParent = _G_Pr_Frm_MdiParent;
            _Frm.Dock = DockStyle.Fill;
            _Frm.Show();
            this.Close();
        }

        private void _Bt_NR_Devolucion_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            Frm_ImpresionLote _Frm_ImpresionLote = new Frm_ImpresionLote(9);
            _Frm_ImpresionLote.MdiParent = _G_Pr_Frm_MdiParent;
            _Frm_ImpresionLote.Show();
            this.Cursor = Cursors.Default;
            this.Close();
        }

        private void _Bt_ComproIVA_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            Frm_Busqueda2 _Frm_Busqueda2 = new Frm_Busqueda2(4);
            _Frm_Busqueda2.MdiParent = _G_Pr_Frm_MdiParent;
            _Frm_Busqueda2.Show();
            this.Cursor = Cursors.Default;
            this.Close();
        }
    }
}