using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;

namespace T3
{
    class _Cls_CargarCombo
    {
        public List<_Cls_CargarCombo> _List_Lista = new List<_Cls_CargarCombo>();
        public _Cls_CargarCombo()
        { }
        public _Cls_CargarCombo(string _P_Str_Value, string _P_Str_Display)
        {
            Value = _P_Str_Value;
            Display = _P_Str_Display;
        }
        public string Value { get; set; }
        public string Display { get; set; }
    }
    class _Cls_Consecutivos
    {
        public _Cls_Consecutivos()
        { }
        public int _Mtd_Reposicion()
        {
            Program._Dat_Tablas =
  new DataContext._Dat_CntxTablasDataContext(Program._MyClsCnn._mtd_conexion._g_Str_Stringconex);
            if ((from Campos in Program._Dat_Tablas.TREPOSICIONESM
                 where Campos.ccompany == Frm_Padre._Str_Comp
                 select Campos.cidreposiciones).Count() == 0)
            {
                return 1;
            }
            else
            {
                return (from Campos in Program._Dat_Tablas.TREPOSICIONESM
                        where Campos.ccompany == Frm_Padre._Str_Comp
                        select Campos.cidreposiciones).Max() + 1;
            }
        }
        public int _Mtd_ReposicionDetalle(int _P_Int_Reposicion)
        {
            Program._Dat_Tablas =
  new DataContext._Dat_CntxTablasDataContext(Program._MyClsCnn._mtd_conexion._g_Str_Stringconex);
            if ((from Campos in Program._Dat_Tablas.TREPOSICIONESD
                 where Campos.ccompany == Frm_Padre._Str_Comp & Campos.cidreposiciones == _P_Int_Reposicion
                 select Campos.ciddreposiciones).Count() == 0)
            {
                return 1;
            }
            else
            {
                return (from Campos in Program._Dat_Tablas.TREPOSICIONESD
                        where Campos.ccompany == Frm_Padre._Str_Comp & Campos.cidreposiciones == _P_Int_Reposicion
                        select Campos.ciddreposiciones).Max() + 1;
            }
        }
        public int _Mtd_Comprobante()
        {
            Program._Dat_Tablas =
  new DataContext._Dat_CntxTablasDataContext(Program._MyClsCnn._mtd_conexion._g_Str_Stringconex);
            if ((from Campos in Program._Dat_Tablas.TCOMPROBANC
                 where Campos.ccompany == Frm_Padre._Str_Comp
                 select Campos.cidcomprob).Count() == 0)
            {
                return 1;
            }
            else
            {
                return (from Campos in Program._Dat_Tablas.TCOMPROBANC
                        where Campos.ccompany == Frm_Padre._Str_Comp
                        select Convert.ToInt32(Campos.cidcomprob)).Max() + 1;
            }
        }
        public int _Mtd_OrdenPago()
        {
            Program._Dat_Tablas =
  new DataContext._Dat_CntxTablasDataContext(Program._MyClsCnn._mtd_conexion._g_Str_Stringconex);
            if ((from Campos in Program._Dat_Tablas.TPAGOSCXPM
                 where Campos.cgroupcomp == Convert.ToInt32(Frm_Padre._Str_GroupComp)
                 select Campos.cidordpago).Count() == 0)
            {
                return 1;
            }
            else
            {
                return (from Campos in Program._Dat_Tablas.TPAGOSCXPM
                        where Campos.cgroupcomp == Convert.ToInt32(Frm_Padre._Str_GroupComp)
                        select Campos.cidordpago).Max() + 1;
            }
        }
        public int _Mtd_DispBanc()
        {
            Program._Dat_Tablas =
  new DataContext._Dat_CntxTablasDataContext(Program._MyClsCnn._mtd_conexion._g_Str_Stringconex);
            if ((from Campos in Program._Dat_Tablas.TDISPBANC
                 where Campos.ccompany == Frm_Padre._Str_Comp
                 select Convert.ToInt32(Campos.cdispbanc)).Count() == 0)
            {
                return 1;
            }
            else
            {
                return (from Campos in Program._Dat_Tablas.TDISPBANC
                        where Campos.ccompany == Frm_Padre._Str_Comp
                        select Convert.ToInt32(Campos.cdispbanc)).Max() + 1;
            }
        }
        public int _Mtd_IncCob()
        {
            Program._Dat_Tablas =
  new DataContext._Dat_CntxTablasDataContext(Program._MyClsCnn._mtd_conexion._g_Str_Stringconex);
            if ((from Campos in Program._Dat_Tablas.TINCCOB
                 where Campos.cgroupcomp == Convert.ToInt32(Frm_Padre._Str_GroupComp) & Campos.ccompany == Frm_Padre._Str_Comp
                 select Convert.ToInt32(Campos.cidinccob)).Count() == 0)
            {
                return 1;
            }
            else
            {
                return (from Campos in Program._Dat_Tablas.TINCCOB
                        where Campos.cgroupcomp == Convert.ToInt32(Frm_Padre._Str_GroupComp) & Campos.ccompany == Frm_Padre._Str_Comp
                        select Convert.ToInt32(Campos.cidinccob)).Max() + 1;
            }
        }
        public int _Mtd_IncVta()
        {
            Program._Dat_Tablas =
  new DataContext._Dat_CntxTablasDataContext(Program._MyClsCnn._mtd_conexion._g_Str_Stringconex);
            if ((from Campos in Program._Dat_Tablas.TINCVTAS
                 where Campos.cgroupcomp == Convert.ToInt32(Frm_Padre._Str_GroupComp) & Campos.ccompany == Frm_Padre._Str_Comp
                 select Convert.ToInt32(Campos.cidincvtas)).Count() == 0)
            {
                return 1;
            }
            else
            {
                return (from Campos in Program._Dat_Tablas.TINCVTAS
                        where Campos.cgroupcomp == Convert.ToInt32(Frm_Padre._Str_GroupComp) & Campos.ccompany == Frm_Padre._Str_Comp
                        select Convert.ToInt32(Campos.cidincvtas)).Max() + 1;
            }
        }
        public int _Mtd_IncDis()
        {
            Program._Dat_Tablas =
  new DataContext._Dat_CntxTablasDataContext(Program._MyClsCnn._mtd_conexion._g_Str_Stringconex);
            if ((from Campos in Program._Dat_Tablas.TINCDISTRIBU
                 where Campos.cgroupcomp == Convert.ToInt32(Frm_Padre._Str_GroupComp) & Campos.ccompany == Frm_Padre._Str_Comp
                 select Convert.ToInt32(Campos.cidincdistribu)).Count() == 0)
            {
                return 1;
            }
            else
            {
                return (from Campos in Program._Dat_Tablas.TINCDISTRIBU
                        where Campos.cgroupcomp == Convert.ToInt32(Frm_Padre._Str_GroupComp) & Campos.ccompany == Frm_Padre._Str_Comp
                        select Convert.ToInt32(Campos.cidincdistribu)).Max() + 1;
            }
        }
        public int _Mtd_IncDisDetalle(int _P_Int_IncDistrib)
        {
            Program._Dat_Tablas =
  new DataContext._Dat_CntxTablasDataContext(Program._MyClsCnn._mtd_conexion._g_Str_Stringconex);
            if ((from Campos in Program._Dat_Tablas.TINCDISTRIBUD
                 where Campos.cgroupcomp == Convert.ToInt32(Frm_Padre._Str_GroupComp) & Campos.ccompany == Frm_Padre._Str_Comp & Campos.cidincdistribu == _P_Int_IncDistrib
                 select Convert.ToInt32(Campos.cidincdistribud)).Count() == 0)
            {
                return 1;
            }
            else
            {
                return (from Campos in Program._Dat_Tablas.TINCDISTRIBUD
                        where Campos.cgroupcomp == Convert.ToInt32(Frm_Padre._Str_GroupComp) & Campos.ccompany == Frm_Padre._Str_Comp & Campos.cidincdistribu == _P_Int_IncDistrib
                        select Convert.ToInt32(Campos.cidincdistribud)).Max() + 1;
            }
        }
        public int _Mtd_IncVar()
        {
            Program._Dat_Tablas =
  new DataContext._Dat_CntxTablasDataContext(Program._MyClsCnn._mtd_conexion._g_Str_Stringconex);
            if ((from Campos in Program._Dat_Tablas.TINCVARIOS
                 where Campos.cgroupcomp == Convert.ToInt32(Frm_Padre._Str_GroupComp) & Campos.ccompany == Frm_Padre._Str_Comp
                 select Convert.ToInt32(Campos.cidincvarios)).Count() == 0)
            {
                return 1;
            }
            else
            {
                return (from Campos in Program._Dat_Tablas.TINCVARIOS
                        where Campos.cgroupcomp == Convert.ToInt32(Frm_Padre._Str_GroupComp) & Campos.ccompany == Frm_Padre._Str_Comp
                        select Convert.ToInt32(Campos.cidincvarios)).Max() + 1;
            }
        }
        public int _Mtd_IncMar()
        {
            Program._Dat_Tablas =
  new DataContext._Dat_CntxTablasDataContext(Program._MyClsCnn._mtd_conexion._g_Str_Stringconex);
            if ((from Campos in Program._Dat_Tablas.TINCMARCAFOCO
                 where Campos.cgroupcomp == Convert.ToInt32(Frm_Padre._Str_GroupComp) & Campos.ccompany == Frm_Padre._Str_Comp
                 select Convert.ToInt32(Campos.cidincmarcafoco)).Count() == 0)
            {
                return 1;
            }
            else
            {
                return (from Campos in Program._Dat_Tablas.TINCMARCAFOCO
                        where Campos.cgroupcomp == Convert.ToInt32(Frm_Padre._Str_GroupComp) & Campos.ccompany == Frm_Padre._Str_Comp
                        select Convert.ToInt32(Campos.cidincmarcafoco)).Max() + 1;
            }
        }
        public int _Mtd_IncMarDetalle(int _P_Int_IncMarcf)
        {
            Program._Dat_Tablas =
  new DataContext._Dat_CntxTablasDataContext(Program._MyClsCnn._mtd_conexion._g_Str_Stringconex);
            if ((from Campos in Program._Dat_Tablas.TINCMARCAFOCOD
                 where Campos.cgroupcomp == Convert.ToInt32(Frm_Padre._Str_GroupComp) & Campos.ccompany == Frm_Padre._Str_Comp & Campos.cidincmarcafoco == _P_Int_IncMarcf
                 select Convert.ToInt32(Campos.cidincmarcafocod)).Count() == 0)
            {
                return 1;
            }
            else
            {
                return (from Campos in Program._Dat_Tablas.TINCMARCAFOCOD
                        where Campos.cgroupcomp == Convert.ToInt32(Frm_Padre._Str_GroupComp) & Campos.ccompany == Frm_Padre._Str_Comp & Campos.cidincmarcafoco == _P_Int_IncMarcf
                        select Convert.ToInt32(Campos.cidincmarcafocod)).Max() + 1;
            }
        }
        public int _Mtd_IncConjunto()
        {
            Program._Dat_Tablas =
  new DataContext._Dat_CntxTablasDataContext(Program._MyClsCnn._mtd_conexion._g_Str_Stringconex);
            if ((from Campos in Program._Dat_Tablas.TINCMARCAFOCOD
                 where Convert.ToInt32(Campos.cconjunto) > 0
                 select Convert.ToInt32(Campos.cconjunto)).Count() == 0)
            {
                return 1;
            }
            else
            {
                return (from Campos in Program._Dat_Tablas.TINCMARCAFOCOD
                        select Convert.ToInt32(Campos.cconjunto)).Max() + 1;
            }
        }
    }
}
