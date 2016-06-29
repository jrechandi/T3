using System;

namespace T3.CLASES
{
	/// <summary>
	/// Descripción breve de reorden.
	/// </summary>
	public class Cls_reorden
	{
        public Cls_reorden()
		{

		}
        public Cls_reorden(System.Windows.Forms.Form _P_Frm_Padre)
        {
            try
            {
                _P_Frm_Padre.Cursor = System.Windows.Forms.Cursors.WaitCursor;
                REPORTESS _Frm = new REPORTESS(new string[] { "vst_puntodereorden" }, "", "T3.Report.rReorden", "Section1", "cabecera", "rif", "nit", "cpuntoreorden >=cexisrealu1 AND cpuntoreorden>0");
                _Frm.MdiParent = _P_Frm_Padre;
                _Frm.Show();
                _P_Frm_Padre.Cursor = System.Windows.Forms.Cursors.Default;
            }
            catch { }
        }
	}
}
