using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace T3
{
    public partial class Frm_ComprobPendientes : Form
    {
        public Frm_ComprobPendientes()
        {
            InitializeComponent();
        }
        public Frm_ComprobPendientes(int _P_Int_Ano, int _P_Int_Mes)
        {
            InitializeComponent();
            MessageBox.Show("No es posible cerrar el mes ya que existen comprobantes del periodo seleccionado sin actualizar. Por favor verifique...", "Información", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            _Mtd_Actualizar(_P_Int_Ano, _P_Int_Mes);
        }

        private void _Mtd_Actualizar(int _P_Int_Ano, int _P_Int_Mes)
        {
            string _Str_Cadena = "SELECT CONVERT(VARCHAR,TCOMPROBANC.ctypcomp)+'-'+CONVERT(VARCHAR,TCOMPROBANC.cmontacco)+'-'+CONVERT(VARCHAR,TCOMPROBANC.cyearacco)+'-'+CONVERT(VARCHAR,TCOMPROBANC.cidcorrel) AS COMPROBANTE,CASE WHEN dbo.FNC_COMPROBANTE_TABS('" + Frm_Padre._Str_GroupComp + "','" + Frm_Padre._Str_Comp + "',cidcomprob)='1' THEN 'COMPROBANTES POR ACTUALIZAR' WHEN dbo.FNC_COMPROBANTE_TABS('" + Frm_Padre._Str_GroupComp + "','" + Frm_Padre._Str_Comp + "',cidcomprob)='2' THEN 'RETENCIONES DE IMPUESTO' WHEN dbo.FNC_COMPROBANTE_TABS('" + Frm_Padre._Str_GroupComp + "','" + Frm_Padre._Str_Comp + "',cidcomprob)='3' THEN 'RETENCIONES DE ISLR' WHEN dbo.FNC_COMPROBANTE_TABS('" + Frm_Padre._Str_GroupComp + "','" + Frm_Padre._Str_Comp + "',cidcomprob)='4' THEN 'COMPROBANTES POR APROBAR' WHEN dbo.FNC_COMPROBANTE_TABS('" + Frm_Padre._Str_GroupComp + "','" + Frm_Padre._Str_Comp + "',cidcomprob)='5' THEN 'COMPROBANTES INCOMPLETOS' WHEN dbo.FNC_COMPROBANTE_TABS('" + Frm_Padre._Str_GroupComp + "','" + Frm_Padre._Str_Comp + "',cidcomprob)='6' THEN 'COMPROBANTE NR' WHEN dbo.FNC_COMPROBANTE_TABS('" + Frm_Padre._Str_GroupComp + "','" + Frm_Padre._Str_Comp + "',cidcomprob)='0' THEN 'DESCONOCIDO' END AS NOTIFICADOR FROM TCOMPROBANC INNER JOIN TMESCONTABLE ON TCOMPROBANC.cyearacco = TMESCONTABLE.cyearacco AND TCOMPROBANC.cmontacco = TMESCONTABLE.cmontacco AND TCOMPROBANC.ccompany = TMESCONTABLE.ccompany  WHERE TCOMPROBANC.ccompany='" + Frm_Padre._Str_Comp + "' AND TCOMPROBANC.cstatus<>'9' AND TMESCONTABLE.ccerrado='0' AND TCOMPROBANC.cstatus<>'1' AND (csistema='1' OR (csistema='0' AND (cestatusfirma='1' OR cestatusfirma='2' OR cestatusfirma='4'))) AND (ccuadrado='1' OR cestatusfirma='4' OR (ccuadrado='0' AND cestatusfirma='1' OR cestatusfirma='2')) AND ctotdebe>0 AND TCOMPROBANC.cyearacco='" + _P_Int_Ano + "' AND TCOMPROBANC.cmontacco='" + _P_Int_Mes + "' AND NOT EXISTS(SELECT cidcomprob FROM TPAGOSCXPM WHERE TPAGOSCXPM.cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND TPAGOSCXPM.ccompany=TCOMPROBANC.ccompany AND TPAGOSCXPM.cidcomprob=TCOMPROBANC.cidcomprob) AND NOT EXISTS(SELECT TFACTPPAGARM.cestatusfirma FROM TFACTPPAGARM INNER JOIN TCOMPROBANRETC ON TFACTPPAGARM.cproveedor = TCOMPROBANRETC.cproveedor AND TFACTPPAGARM.ccompany = TCOMPROBANRETC.ccompany AND TFACTPPAGARM.cidcomprobret = TCOMPROBANRETC.cidcomprobret WHERE TFACTPPAGARM.cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND TFACTPPAGARM.ccompany=TCOMPROBANC.ccompany AND TCOMPROBANRETC.cidcomprob=TCOMPROBANC.cidcomprob AND TFACTPPAGARM.cestatusfirma = '1') AND NOT EXISTS(SELECT TFACTPPAGARM.cestatusfirma FROM TFACTPPAGARM INNER JOIN TCOMPROBANISLRC ON TFACTPPAGARM.cproveedor = TCOMPROBANISLRC.cproveedor AND TFACTPPAGARM.ccompany = TCOMPROBANISLRC.ccompany AND TFACTPPAGARM.cidcomprobislr = TCOMPROBANISLRC.cidcomprobislr WHERE TFACTPPAGARM.cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND TFACTPPAGARM.ccompany=TCOMPROBANC.ccompany AND TCOMPROBANISLRC.cidcomprob=TCOMPROBANC.cidcomprob AND TFACTPPAGARM.cestatusfirma = '1')";
            _Dg_Grid.DataSource = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena).Tables[0];
            _Dg_Grid.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _Dg_Grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }
        private void Frm_ComprobPendientes_Load(object sender, EventArgs e)
        {
            
        }
    }
}
