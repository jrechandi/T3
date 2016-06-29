using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using T3.Cobranza;

namespace T3
{
    namespace Cobranza
    {
        #region Tipos

        /// <summary>Tipos de estados del formulario de retención.</summary>
        public enum TiposEstadoRetencion
        {
            EstadoRetencionNuevo = 0,
            EstadoRetencionEditar
        }

        #endregion
    }

    public partial class Frm_RC_Retencion : Form
    {
        #region Variables

        /// <summary>Variable global utilizada como una bandera para la edición de la retención.</summary>
        private bool _G_Bol_Mostrar = true;

        /// <summary>Variable global utilizada en la edición de la retención.</summary>
        private string _G_Str_Compañia;
        private string _G_Str_cguia;

        /// <summary>Variable global utilizada en la edición de la retención.</summary>
        private string _G_Str_Factura;

        /// <summary>Variable global interna para alojar el grid de facturas del formulario de pago.</summary>
        private DataGridView _G_Obj_Facturas;

        /// <summary>Variable global interna para alojar el grid de notas de crédito del formulario de pago.</summary>
        private DataGridView _G_Obj_NotasCredito;

        /// <summary>Variable global interna para alojar el grid de retenciones del formulario de pago.</summary>
        private DataGridView _G_Obj_Retenciones;

        /// <summary>Variable global interna para alojar el id del pago.</summary>
        private string _G_Str_IdPago;

        /// <summary>Estados del formulario de retención.</summary>
        private TiposEstadoRetencion _G_Enum_EstadoRetencion;

        private string _G_Str_NumeroDeControl = "";

        #endregion

        #region Propiedades

        /// <summary>Se utiliza para asignarle el grid de facturas del formulario de pago.</summary>
        public DataGridView Facturas
        {
            set { _G_Obj_Facturas = value; }
        }

        /// <summary>Se utiliza para asignarle el grid de notas de crédito del formulario de pago.</summary>
        public DataGridView NotasCredito
        {
            set { _G_Obj_NotasCredito = value; }
        }

        /// <summary>Se utiliza para asignarle el grid de retenciones del formulario de pago.</summary>
        public DataGridView Retencion
        {
            set { _G_Obj_Retenciones = value; }
        }

        /// <summary>Se utiliza para asignarle el grid de retenciones del formulario de pago.</summary>
        public string IdPago
        {
            set { _G_Str_IdPago = value; }
        }

        #endregion

        #region Métodos

        /// <summary>Constructor del formulario.</summary>
        /// <param name="_P_Enum_Estado">Estado del formulario de retención.</param>
        /// <param name="_P_Str_Compañia">Compañía seleccionada en el formulario de pago.</param>
        public Frm_RC_Retencion(TiposEstadoRetencion _P_Enum_Estado, string _P_Str_Compañia, string _P_Str_Guia)
        {
            InitializeComponent();

            _G_Enum_EstadoRetencion = _P_Enum_Estado;
            _G_Str_Compañia = _P_Str_Compañia;
            _G_Str_cguia = _P_Str_Guia;
        }

        /// <summary>Sobrecarga del constructor del formulario.</summary>
        /// <param name="_P_Enum_Estado">Estado del formulario de retención.</param>
        /// <param name="_P_Str_Compañia">Compañía seleccionada en el formulario de pago.</param>
        /// <param name="_P_Str_Factura">Factura seleccionada al hacer doble clic en la fila.</param>
        /// <param name="_P_Str_Retencion">Número de retención seleccionada al hacer doble clic en la fila.</param>
        /// <param name="_P_Date_Fecha">Fecha de emisión de la retención.</param>
        /// <param name="_P_Str_Control">Número de control de la factura.</param>
        /// <param name="_P_Dbl_Monto">Monto de la retención.</param>
        public Frm_RC_Retencion(TiposEstadoRetencion _P_Enum_Estado, string _P_Str_Compañia, string _P_Str_Factura, string _P_Str_Retencion, DateTime _P_Date_Fecha, string _P_Str_Control, double _P_Dbl_Monto)
        {
            InitializeComponent();

            _G_Enum_EstadoRetencion = _P_Enum_Estado;

            _G_Str_Compañia = _P_Str_Compañia;

            _G_Str_Factura = _P_Str_Factura;

            _Mtd_CargarDetalleRelacion(_Cmb_Factura, _G_Str_Compañia, _G_Str_Factura);

            _Cmb_Factura.SelectedValue = _G_Str_Factura;
            _Cmb_Factura.Enabled = false;

            _Dtp_Fecha.Value = _P_Date_Fecha;

            _Txt_NumeroRetencion_Derecha.Text = _P_Str_Retencion.Substring(6);
            _Txt_NumeroControl.Text = _P_Str_Control;

            _Txt_Monto.Tag = _P_Dbl_Monto;
            _Txt_Monto.Text = _P_Dbl_Monto.ToString("c");
        }

        /// <summary>Este método permite cargar las facturas seleccionadas en el pago.</summary>
        /// <param name="_P_Obj_Combo">Combo donde se van a mostrar las facturas seleccionadas.</param>
        /// <param name="_P_Str_Compañia">Código de la compañía para efecutar el filtro.</param>
        private void _Mtd_CargarComboFacturas(ComboBox _P_Obj_Combo, string _P_Str_Compañia)
        {
            string _Str_SQL, _Str_WHERE = "";

            //Valor por defecto
            _Str_SQL = "select '0' as cfactura, '...' as cdescripcion UNION ";

            //Consutamos
            _Str_SQL += "select distinct convert(varchar, TFACTURAM.cfactura) as cfactura, ('Factura: ' + convert(varchar, TFACTURAM.cfactura) + ' - Bs F. ' + dbo.Fnc_Formatear(Abs(cmontosaldo))) as cdescripcion from TFACTURAM";
            _Str_SQL += " inner join TTRCDOCUMENTO on TFACTURAM.ccompany = TTRCDOCUMENTO.ccompany and TFACTURAM.cfactura = TTRCDOCUMENTO.cfactura";

            foreach (DataGridViewRow oFactura in _G_Obj_Facturas.Rows)
            {
                var _Bol_EsContribuyenteEspecial = Frm_RC_Pago._Mtd_ClienteEsContribuyenteEspecial(oFactura.Cells["colClienteFactura"].Value.ToString());

                if ((oFactura.Cells[0].Value != null) && ((bool)oFactura.Cells[0].Value) && _Bol_EsContribuyenteEspecial)
                {
                    _Str_WHERE += ((_Str_WHERE == "") ? " where (" : " or ") + "((TFACTURAM.cfactura=" + oFactura.Cells[2].Value.ToString() + "))";
                }
            }
            _Str_SQL += " AND (cmontodocumentoimpuesto > 0.00) ";

            //QUE NO EXISTA EN EL GRID NI EN LA BD
            _G_Obj_Retenciones.Rows.Cast<DataGridViewRow>().ToList().ForEach(_Row =>
                {
                    _Str_SQL += "AND (TFACTURAM.cfactura <> " + _Row.Cells["colRetencionFactura"].Value.ToString() + ") ";
                });

            //QUE NO EXISTAN  EN LA BD
            if (_G_Str_IdPago != "")
                _Str_SQL += "AND NOT EXISTS (SELECT TTRCRETENCION.cfactura FROM TTRCRETENCION WHERE ISNULL(TTRCRETENCION.cdelete,0)=0 AND TTRCRETENCION.cfactura=TFACTURAM.cfactura AND cidpago <> " + _G_Str_IdPago + ") ";
            else
                _Str_SQL += "AND NOT EXISTS (SELECT TTRCRETENCION.cfactura FROM TTRCRETENCION WHERE ISNULL(TTRCRETENCION.cdelete,0)=0 AND TTRCRETENCION.cfactura=TFACTURAM.cfactura) ";

            if (_Str_WHERE != "")
            {
                var _SQL = _Str_SQL + _Str_WHERE + " and (TFACTURAM.ccompany='" + _P_Str_Compañia.Trim() + "'));";

                DataSet oResultado = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_SQL);

                _P_Obj_Combo.DataSource = oResultado.Tables[0];
                _P_Obj_Combo.DisplayMember = "cdescripcion";
                _P_Obj_Combo.ValueMember = "cfactura";
                _P_Obj_Combo.SelectedIndex = 0; //Seleccionamos el valor por defecto
            }            
        }

        /// <summary>Este método permite cargar el detalle de la retención.</summary>
        /// <param name="_P_Obj_Combo">Combo donde se van a mostrar las facturas seleccionadas.</param>
        /// <param name="_P_Str_Compañia">Código de la compañía para efecutar el filtro.</param>
        /// <param name="_P_Str_Factura">Código de la factura para efecutar el filtro.</param>
        private void _Mtd_CargarDetalleRelacion(ComboBox _P_Obj_Combo, string _P_Str_Compañia, string _P_Str_Factura)
        {
            string _Str_SQL;

            _Str_SQL = "select distinct convert(varchar, TFACTURAM.cfactura) as cfactura, ('Factura: ' + convert(varchar, TFACTURAM.cfactura) + ' - Bs F. ' + dbo.Fnc_Formatear(cmontosaldo)) as cdescripcion from TFACTURAM";
            _Str_SQL += " inner join TTRCDOCUMENTO on TFACTURAM.ccompany = TTRCDOCUMENTO.ccompany and TFACTURAM.cfactura = TTRCDOCUMENTO.cfactura";
            _Str_SQL += " where ((TFACTURAM.ccompany='" + _P_Str_Compañia + "') and (TFACTURAM.cfactura=" + _P_Str_Factura + "));";

            DataSet oResultado = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_SQL);

            _P_Obj_Combo.DataSource = oResultado.Tables[0];
            _P_Obj_Combo.DisplayMember = "cdescripcion";
            _P_Obj_Combo.ValueMember = "cfactura";
        }

        /// <summary>Este método permite cargar el número de control de la factura.</summary>
        /// <param name="_P_Str_Compañia">Código de la compañía para efecutar el filtro.</param>
        /// <param name="_P_Str_Factura">Código de la factura para efecutar el filtro.</param>
        private void _Mtd_CargarNumeroControl(string _P_Str_Compañia, string _P_Str_Factura)
        {
            string sSQL;

            sSQL = "select c_numerocontrol from TFACTURAM where ((cfactura=" + _P_Str_Factura + ") and (ccompany='" + _P_Str_Compañia + "'));";

            DataSet oResultado = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(sSQL);

            if (oResultado.Tables[0].Rows.Count > 0)
            {
                _G_Str_NumeroDeControl = oResultado.Tables[0].Rows[0]["c_numerocontrol"].ToString();
            }

            _Dtp_Fecha.Value = DateTime.Now;
            _Dtp_Fecha.Enabled = true;

            _Txt_NumeroRetencion_Derecha.Text = "";
            _Txt_NumeroRetencion_Derecha.Enabled = true;

            _Txt_Monto.Text = "";
            _Txt_Monto.Enabled = true;
        }

        /// <summary>Este método calcula el monto de la retención y lo asigna al control.</summary>
        /// <param name="_P_Str_Compañia">Código de la compañía para efecutar el filtro.</param>
        /// <param name="_P_Str_Factura">Código de la factura para efecutar el filtro.</param>
        private void _Mtd_CargarMontoRetencion(string _P_Str_Compañia, string _P_Str_Factura)
        {
            double _Dbl_MontoImpuesto = 0;
            double _Dbl_MontoPorcentaje = 0;
            double _Dbl_MontoMaximoImpuesto = 0;

            //Valores
            _Dbl_MontoImpuesto = Frm_RC_Pago._Mtd_ObtenerImpuesto(_G_Str_Compañia, _P_Str_Factura);
            _Dbl_MontoPorcentaje = Frm_RC_Pago._Mtd_ObtenerPorcentajeRetencionImpuesto(_G_Str_Compañia);
            _Dbl_MontoMaximoImpuesto = _Dbl_MontoImpuesto * (_Dbl_MontoPorcentaje /100);

            //redondeos
            _Dbl_MontoMaximoImpuesto = Math.Round(_Dbl_MontoMaximoImpuesto, 2);

            _Txt_Monto.Tag = _Dbl_MontoMaximoImpuesto;
            _Txt_Monto.Text = _Dbl_MontoMaximoImpuesto.ToString("c");

        }

        /// <summary>Este método permite validar el monto de la retención.</summary>
        /// <param name="_P_Str_Factura">Código de la factura para efectuar el filtro.</param>
        /// <returns>Verdadero si el monto de la retención no es mayor al monto de la factura.</returns>
        private bool _Mtd_VerificarMontoRentencion(string _P_Str_Factura)
        {
            bool _Bol_Valido = true;

            foreach (DataGridViewRow oFila in _G_Obj_Facturas.Rows)
            {
                if ((oFila.Cells[0].Value != null) && (oFila.Cells[2].Value.ToString() == _P_Str_Factura))
                {
                    if (Convert.ToDouble(_Txt_Monto.Tag.ToString()) > Convert.ToDouble(oFila.Cells[6].Value.ToString()))
                    {
                        _Bol_Valido = false;
                    }
                }
            }

            return _Bol_Valido;
        }

        /// <summary>Este método permite cargar los datos de la retención cuando se están editando.</summary>
        /// <param name="_P_Str_Factura">Código de la factura.</param>
        /// <param name="_P_Str_Retencion">Código de la retención.</param>
        /// <param name="_P_Dat_Fecha">Fecha de emisión.</param>
        /// <param name="_P_Str_Control">Número de control de la factura.</param>
        /// <param name="_P_Dbl_Monto">Monto de la factura.</param>
        private void _Mtd_CargarRetencion(string _P_Str_Factura, string _P_Str_Retencion, DateTime _P_Dat_Fecha, string _P_Str_Control, double _P_Dbl_Monto)
        {
            DataTable oDatos = (DataTable)_G_Obj_Retenciones.DataSource;

            DataRow oFila = oDatos.NewRow();

            oFila[0] = _P_Str_Retencion;
            oFila[1] = _P_Str_Factura;
            oFila[2] = _P_Dbl_Monto;
            oFila[3] = _P_Dat_Fecha;
            oFila[4] = _P_Str_Control;

            oDatos.Rows.Add(oFila);

            Close();
        }

        /// <summary>Este método permite modificar los datos de la retenciçon en el grid del formulario de pago.</summary>
        /// <param name="_P_Str_Factura">Código de la factura.</param>
        /// <param name="_P_Str_Retencion">Código de la retención.</param>
        /// <param name="_P_Dat_Fecha">Fecha de emisión.</param>
        /// <param name="_P_Dbl_Monto">Monto de la factura.</param>
        private void _Mtd_ModificarRetencion(string _P_Str_Factura, string _P_Str_Retencion, DateTime _P_Dat_Fecha, double _P_Dbl_Monto)
        {
            DataTable oDatos = (DataTable)_G_Obj_Retenciones.DataSource;
            
            foreach (DataGridViewRow oFila in _G_Obj_Retenciones.Rows)
            {
                if ((oFila.Cells[0].Value.ToString() == _P_Str_Retencion) && (oFila.Cells[1].Value.ToString() == _P_Str_Factura))
                {
                    oFila.Cells["colRetencionMonto"].Value = _P_Dbl_Monto;
                    oFila.Cells["colRetencionFecha"].Value = _P_Dat_Fecha;
                    oFila.Cells["colRetencion"].Value = _P_Str_Retencion;
                }
            }

            Close();
        }

        /// <summary>Este método permite modificar el saldo de la factura.</summary>
        /// <param name="_P_Str_Factura">Código de la factura.</param>
        /// <returns>Saldo de la factura.</returns>
        private double _Mtd_SaldoFactura(string _P_Str_Factura)
        {
            double _Dbl_TotalFactura = 0;
            double _Dbl_TotalAbono = 0;
            double _Dbl_TotalNotaCredito = 0;            

            foreach (DataGridViewRow oFactura in _G_Obj_Facturas.Rows)
            {
                if (oFactura.Cells[0].Value != null)
                {
                    if (((bool)oFactura.Cells[0].Value) && (oFactura.Cells[2].Value.ToString() == _P_Str_Factura))
                    {
                        _Dbl_TotalFactura = Convert.ToDouble(oFactura.Cells[6].Value.ToString());
                        _Dbl_TotalAbono = Convert.ToDouble(oFactura.Cells[7].Value.ToString());
                    }
                }
            }

            foreach (DataGridViewRow oNotaCredito in _G_Obj_NotasCredito.Rows)
            {
                if (oNotaCredito.Cells[0].Value != null)
                {
                    if (((bool)oNotaCredito.Cells[0].Value) && (oNotaCredito.Cells[1].Value.ToString() == _P_Str_Factura))
                    {
                        _Dbl_TotalNotaCredito += Convert.ToDouble(oNotaCredito.Cells[4].Value.ToString());
                    }
                }
            }

            return (_Dbl_TotalFactura - (Math.Abs(_Dbl_TotalAbono) + _Dbl_TotalNotaCredito + Convert.ToDouble(_Txt_Monto.Tag.ToString())));
        }

        /// <summary>Este método permite verificar si tiene retención la factura.</summary>
        /// <param name="_P_Str_Factura">Código de la factura.</param>
        /// <returns>Verdadero si la factura ya tiene retención asignada.</returns>
        private bool _Mtd_TieneRetencionEnGrid(string _P_Str_Factura)
        {
            bool _Bol_Valido = false;

            if (_G_Obj_Retenciones.Rows.Count > 0)
            {
                foreach (DataGridViewRow oRentencion in _G_Obj_Retenciones.Rows)
                {
                    if (_P_Str_Factura == oRentencion.Cells["colRetencionFactura"].Value.ToString())
                    {
                        _Bol_Valido = true;
                    }
                }
            }

            return _Bol_Valido;
        }
        #endregion

        #region Eventos

        private void Frm_RC_Retencion_Load(object sender, EventArgs e)
        {
            if (_G_Enum_EstadoRetencion == TiposEstadoRetencion.EstadoRetencionNuevo)
            {
                if (!_G_Bol_Mostrar)
                {
                    Close();
                }
                else
                {
                    _Mtd_CargarComboFacturas(_Cmb_Factura, _G_Str_Compañia);
                    _Mtd_CargarNumeroControl(_G_Str_Compañia, _Cmb_Factura.SelectedValue.ToString());
                    _Mtd_CargarMontoRetencion(_G_Str_Compañia, _Cmb_Factura.SelectedValue.ToString());
                }
            }
            _Txt_NumeroRetencion_Izquierda.Text = _Mtd_ObtenerMascara(_Dtp_Fecha.Value);
        }

        private void Frm_RC_Retencion_Resize(object sender, EventArgs e)
        {
            Width = 277;
            Height = 320;
        }

        private void _Cmb_Factura_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!(_Cmb_Factura.SelectedValue is string))
            {
                DataRowView oFila = (DataRowView)_Cmb_Factura.SelectedValue;
                _Mtd_CargarNumeroControl(_G_Str_Compañia, oFila[0].ToString());
                _Mtd_CargarMontoRetencion(_G_Str_Compañia, oFila[0].ToString());
            }
            else
            {
                _Mtd_CargarNumeroControl(_G_Str_Compañia, _Cmb_Factura.SelectedValue.ToString());
                _Mtd_CargarMontoRetencion(_G_Str_Compañia, _Cmb_Factura.SelectedValue.ToString());
            }
        }

        private void _Btn_Guardar_Click(object sender, EventArgs e)
        {
            double _Dbl_MontoImpuesto = 0;
            double _Dbl_MontoIntroducido = 0;
            double _Dbl_MontoPorcentaje = 0;
            double _Dbl_MontoMaximoImpuesto = 0;
            double _Dbl_MontoTolerancia = 0;

            if (_Cmb_Factura.SelectedIndex == 0)
            {
                MessageBox.Show
                    (
                        "Debe seleccionar una factura.",
                        "Advertencia",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );

                _Cmb_Factura.Focus();

                return;
            }

            if (_Txt_NumeroControl.Text.Trim() == "")
            {
                MessageBox.Show
                (
                    "Indica el número de control de la factura.",
                    "Advertencia",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );

                _Txt_NumeroControl.Focus();

                return;
            }
            if (_Txt_NumeroControl.Text.Trim() != _G_Str_NumeroDeControl)
            {
                MessageBox.Show
                (
                    "El número de control que introdujo no corresponde con el de la factura.",
                    "Advertencia",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );

                _Txt_NumeroControl.Focus();

                return;
            }

            var _Str_Numeroretencion = _Txt_NumeroRetencion_Izquierda.Text + _Txt_NumeroRetencion_Derecha.Text.Trim();
            if (_Str_Numeroretencion == "")
            {
                MessageBox.Show
                (
                    "Indica el número de retención de la factura.",
                    "Advertencia",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );

                _Txt_NumeroRetencion_Derecha.Focus();

                return;
            }

            if (_Str_Numeroretencion.Length != 14)
            {
                MessageBox.Show
                (
                    "El número de la retención debe tener 14 dígitos.",
                    "Advertencia",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );

                _Txt_NumeroRetencion_Derecha.Focus();

                return;
            }

            if (_Dtp_Fecha.Value.Date > DateTime.Now.Date)
            {
                MessageBox.Show
                (
                    "La fecha no puede ser posterior al día de hoy.",
                    "Advertencia",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );

                _Dtp_Fecha.Focus();

                return;
            }

            if ((_Txt_Monto.Tag.ToString() == "") || (_Txt_Monto.Tag.ToString() == "0"))
            {
                MessageBox.Show
                (
                    "El monto es incorrecto o no puede ser cero.",
                    "Advertencia",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );

                _Txt_Monto.Focus();

                return;
            }

            if ((_G_Enum_EstadoRetencion == TiposEstadoRetencion.EstadoRetencionNuevo) && (Frm_RC_Pago._Mtd_ExisteRetencionGuardada(_G_Str_Compañia, _G_Str_cguia, _Cmb_Factura.SelectedValue.ToString(), _G_Str_IdPago)))
            {
                MessageBox.Show
                (
                    "La factura ya tiene una retención aplicada.",
                    "Advertencia",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );

                _Cmb_Factura.Focus();

                return;
            }
            if ((_G_Enum_EstadoRetencion == TiposEstadoRetencion.EstadoRetencionNuevo) && (_Mtd_TieneRetencionEnGrid(_Cmb_Factura.SelectedValue.ToString())))
            {
                MessageBox.Show
                (
                    "La factura ya tiene una retención aplicada.",
                    "Advertencia",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );

                _Cmb_Factura.Focus();

                return;
            }

            //Valores
            _Dbl_MontoImpuesto = Frm_RC_Pago._Mtd_ObtenerImpuesto(_G_Str_Compañia, _Cmb_Factura.SelectedValue.ToString());
            _Dbl_MontoPorcentaje = Frm_RC_Pago._Mtd_ObtenerPorcentajeRetencionImpuesto(_G_Str_Compañia);
            _Dbl_MontoMaximoImpuesto = _Dbl_MontoImpuesto * (_Dbl_MontoPorcentaje / 100);
            _Dbl_MontoIntroducido = Convert.ToDouble(_Txt_Monto.Tag.ToString());
            _Dbl_MontoTolerancia = Frm_RC_DocumentosClientes._Mtd_ObtenerLimiteFaltante(Frm_Padre._Str_Comp);


            //redondeos
            _Dbl_MontoMaximoImpuesto = Math.Round(_Dbl_MontoMaximoImpuesto, 2);
            _Dbl_MontoTolerancia = Math.Round(_Dbl_MontoTolerancia, 2);


            if (_Dbl_MontoIntroducido > (_Dbl_MontoMaximoImpuesto+_Dbl_MontoTolerancia))
            {
                MessageBox.Show
                (
                    "El monto de la retención es mayor al monto máximo permitido de retención de impuesto de la factura.",
                    "Advertencia",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );

                _Txt_Monto.Focus();

                return;
            }
            //else if (_Dbl_MontoImpuesto == 0)
            //{
            //    MessageBox.Show
            //    (
            //        "La factura no tiene impuesto, no se puede agregar la retención.",
            //        "Advertencia",
            //        MessageBoxButtons.OK,
            //        MessageBoxIcon.Error
            //    );

            //    _Txt_Monto.Focus();

            //    return;
            //}

            if (_G_Enum_EstadoRetencion == TiposEstadoRetencion.EstadoRetencionNuevo)
            {
                _Mtd_CargarRetencion
                (
                    _Cmb_Factura.SelectedValue.ToString(),
                    _Str_Numeroretencion,
                    _Dtp_Fecha.Value,
                    _Txt_NumeroControl.Text,
                    Convert.ToDouble(_Txt_Monto.Tag.ToString())
                );
            }
            else if (_G_Enum_EstadoRetencion == TiposEstadoRetencion.EstadoRetencionEditar)
            {
                _Mtd_ModificarRetencion
                (
                    _Cmb_Factura.SelectedValue.ToString(),
                    _Str_Numeroretencion,
                    _Dtp_Fecha.Value,
                    Convert.ToDouble(_Txt_Monto.Tag.ToString())
                );
            }
        }

        private void _Btn_Cancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void _Txt_NumeroRetencion_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void _Txt_Monto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((!char.IsControl(e.KeyChar) && (!char.IsDigit(e.KeyChar)) && (e.KeyChar != ',')))
            {
                e.Handled = true;
            }

            if ((e.KeyChar == ',') && ((sender as TextBox).Text.IndexOf(',') > -1))
            {
                e.Handled = true;
            }
        }

        private void _Txt_Monto_Leave(object sender, EventArgs e)
        {
            if (_Txt_Monto.Text != "")
            {
                _Txt_Monto.Tag = Convert.ToDouble(_Txt_Monto.Text);
            }
            else
            {
                if (_Txt_Monto.Tag != null)
                {
                    _Txt_Monto.Text = _Txt_Monto.Tag.ToString();
                }
            }

            _Txt_Monto.Text = Convert.ToDouble(_Txt_Monto.Text).ToString("c");
        }

        private void _Txt_Monto_Enter(object sender, EventArgs e)
        {
            if (_Txt_Monto.Tag != null)
            {
                _Txt_Monto.Text = _Txt_Monto.Tag.ToString();
            }
        }

        private void _Dtp_Fecha_ValueChanged(object sender, EventArgs e)
        {
            //Mascara
            _Txt_NumeroRetencion_Izquierda.Text =  _Mtd_ObtenerMascara(_Dtp_Fecha.Value);

            if (_Dtp_Fecha.Value.Date > DateTime.Now.Date)
            {
                MessageBox.Show
                (
                    "La fecha no puede ser posterior al día de hoy.",
                    "Advertencia",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );

                _Dtp_Fecha.Focus();

                return;
            }
        }

        private string _Mtd_ObtenerMascara(DateTime _P_Dt_Fecha)
        {
            var _Str_Mascara = "";
            _Str_Mascara = _P_Dt_Fecha.Year.ToString() + _P_Dt_Fecha.Month.ToString("00");
            return _Str_Mascara;
        }

        #endregion
    }
}
