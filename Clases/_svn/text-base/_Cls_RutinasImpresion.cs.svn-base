using System;
using System.Data;
using System.Drawing.Printing;
using System.Windows.Forms;

namespace T3.Clases
{
    public class _Cls_RutinasImpresion
    {
        public enum _G_TiposDocumento
        {
            Factura = 1,
            Comprobante,
            GuiaDespacho,
            FacturasEmitidas
        }

        public bool _Mtd_EstaHabilitadoConfiguracionImpresion()
        {
            string _Str_Sql = "";
            bool _Bool_Retornar = false;

            try
            {
                _Str_Sql = "SELECT chabilitarconfigimpresion FROM TCONFIGVENT WHERE chabilitarconfigimpresion = 1";
                DataSet _Ds_DataSet = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
                if (_Ds_DataSet.Tables[0].Rows.Count > 0)
                {
                    _Bool_Retornar= true;
                }
            }
            catch
            {
                _Bool_Retornar= false;
            }
            return _Bool_Retornar;
        }

        public bool _Mtd_ExistenTodasLasImpresorasConfiguradas()
        {
            string _Str_Sql = "";
            bool _Bool_Retornar = true;
            string _Str_Mensaje = "";

            try
            {

                _Str_Mensaje = "La(s) configuración(es) de impresión : \n";
                //Recorro las Compañias
                _Str_Sql = "Select ccompany,cname from TCOMPANY where cdelete='0'";
                DataSet _Ds_Compañias = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
                //Recorro cada impresora configurada
                foreach (DataRow oFila in _Ds_Compañias.Tables[0].Rows)
                {
                    //Verifico que esten todas las impresoras para todos los documentos
                    foreach (int oTipo in Enum.GetValues(typeof(_G_TiposDocumento)))
                    {
                        //Verifico que existe la en la configuracion
                        _Str_Sql = "SELECT ctipodocument,ctipodocument FROM TCONFIGIMPRESION WHERE cdelete='0' and ctipodocument = '" + oTipo + "' AND ccompany = '" + oFila["ccompany"].ToString().Trim() + "'";
                        DataSet _Ds_ = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
                        if (_Ds_.Tables[0].Rows.Count == 0)
                        {
                            _Str_Mensaje += "\n" + ((_G_TiposDocumento)oTipo).ToString() + " para '" + oFila["cname"].ToString().Trim() + "'";
                            _Bool_Retornar = false;
                        }
                    }
                }
                _Str_Mensaje += "\n\nno está(n) en el sistema\n";

                //Solo si retorna verdadero verifico si existen
                if (_Bool_Retornar)
                {
                    _Str_Mensaje = "La(s) Impresora(s) : \n";
                    //Cargo las impresoras configuradas
                    _Str_Sql = "SELECT TCONFIGIMPRESION.cidimpresion AS Código, CASE TCONFIGIMPRESION.ctipodocument WHEN 1 THEN 'Factura' WHEN 2 THEN 'Comprobante' WHEN 3 THEN 'Guía despacho' END AS [Tipo Documento], TCONFIGIMPRESION.ccprinter_name AS Impresora, TCONFIGIMPRESION.cidimpresion, TCONFIGIMPRESION.ctipodocument,TCONFIGIMPRESION.ccprinter_name FROM TCONFIGIMPRESION WHERE cdelete='0'";
                    DataSet _Ds_ImpresorasConfiguradas = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
                    if (_Ds_ImpresorasConfiguradas.Tables[0].Rows.Count > 0)
                    {
                        //Recorro cada impresora configurada
                        foreach (DataRow oFila in _Ds_ImpresorasConfiguradas.Tables[0].Rows)
                        {
                            string _Str_ccprinter_name = oFila["ccprinter_name"].ToString();
                            //Si la impresora no existe en el computador
                            if (!_Mtd_ExisteImpresoraEnComputador(_Str_ccprinter_name))
                            {
                                _Str_Mensaje += "\n" + _Str_ccprinter_name + "";
                                _Bool_Retornar = false;
                            }
                        }
                    }
                    _Str_Mensaje += "\n\nno existe(n) en el computador\n";
                }
                //Si tiene error
                if (_Bool_Retornar == false)
                    MessageBox.Show(_Str_Mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch
            {
                MessageBox.Show("Lo sentimos, ha ocurrido un error inesperado. Por favor contacte al desarrollador.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                _Bool_Retornar = false;
            }
            return _Bool_Retornar;
        }

        public bool _Mtd_ExisteImpresoraEnComputador(string _P_Str_ccprinter_name)
        {
            string _Str_Sql = "";
            bool _Bool_Retornar = false;

            try
            {
                for (int _I = 0; _I < PrinterSettings.InstalledPrinters.Count; _I++)
                {
                    if (PrinterSettings.InstalledPrinters[_I].ToString().Trim().ToUpper() ==_P_Str_ccprinter_name.Trim().ToUpper())
                    {
                        _Bool_Retornar = true;
                        break;
                    }
                }
            }
            catch
            {
                MessageBox.Show("Lo sentimos, ha ocurrido un error inesperado. Por favor contacte al desarrollador.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                _Bool_Retornar = false;
            }
            return _Bool_Retornar;
        }

        public PrinterSettings _Mtd_ObjetoImpresion(_G_TiposDocumento _P_TipoDocumento, string _P_Str_ccompany)
        {
            string _Str_Sql = "";
            string _Str_ccprinter_name = "";
            PrinterSettings _Retornar = null;

            try
            {
                _Str_Sql = "SELECT ccprinter_name FROM TCONFIGIMPRESION WHERE ctipodocument = '" + (int)_P_TipoDocumento + "' AND ccompany = '" + _P_Str_ccompany + "'";
                DataSet _Ds_DataSet = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
                if (_Ds_DataSet.Tables[0].Rows.Count > 0)
                {
                    _Str_ccprinter_name = _Ds_DataSet.Tables[0].Rows[0]["ccprinter_name"].ToString();
                    _Retornar = new PrinterSettings();
                    _Retornar.DefaultPageSettings.PrinterSettings.PrinterName = _Str_ccprinter_name;
                }
            }
            catch
            {
                // en caso de que haya una excepcion, devuelve un valor y previene que se complete la cobranza
                MessageBox.Show("Lo sentimos, ha ocurrido un error inesperado. Por favor contacte al desarrollador.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                _Retornar = null;
            }
            return _Retornar;
        }

    }
}
