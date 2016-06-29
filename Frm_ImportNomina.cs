using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Linq;
using T3.CLASES;

namespace T3
{
    public partial class Frm_ImportNomina : Form
    {
        CLASES._Cls_Varios_Metodos _Cls_Variosmetodos = new CLASES._Cls_Varios_Metodos(true);
        clslibraryconssa._Cls_Formato _Cls_Formato = new clslibraryconssa._Cls_Formato("es-VE");
        public static decimal debe;
        public static decimal haber;
        public static DateTime Datemin;
        public static DateTime Datemax;

        public Frm_ImportNomina()
        {
            InitializeComponent();
        }
        public Frm_ImportNomina(int _P_Int_Comprobante)
        {
            InitializeComponent();
        }

        private void Frm_ImportNomina_Load(object sender, EventArgs e)
        {
            DateMinPicker.MaxDate = DateTime.Today;
            DateMaxPicker.MinDate = DateMinPicker.Value;
            
            //string[] ListaUsuarios = new string[] {"36","1","18","19","27", "34", "30"};
            //if (!ListaUsuarios.Contains(Frm_Padre._Str_UserGroup))
            //{
            CLASES._Cls_Empleados_SPI _Cls_Empleados_SPI = new CLASES._Cls_Empleados_SPI();
            _Cls_Empleados_SPI._Mtd_ActualizarTablaEmpleadosSPI(false, false, true);
            //}
        }
                
        private void _Bt_Importar_Click_1(object sender, EventArgs e)
        {
            _Cls_Variosmetodos.Nomina_CSV();
            var tabla = CLASES._Cls_Varios_Metodos.dataset2.Tables[0];
            tabla.Rows[tabla.Rows.Count-1].Delete();
            foreach (DataRow _Row in tabla.Rows)
            {
                    debe += Convert.ToDecimal(_Row[7].ToString().Replace('.',','));
                    haber += Convert.ToDecimal(_Row[8].ToString().Replace('.', ','));
            }
            L_Debe.Text = debe.ToString("#,##0.00");
            L_Haber.Text = haber.ToString("#,##0.00");
            L_Saldo.Text = (debe - haber).ToString("#,##0.00");
            FCont.Text = "Fecha de Contabilización: " + tabla.Rows[0][4].ToString();
            ACont.Text = "Año de Contabilización: " + tabla.Rows[0][5].ToString();
            MCont.Text = "Mes de Contabilización: " + tabla.Rows[0][6].ToString();
            _Dg_Grid.DataSource = tabla;
            _Dg_Grid.ReadOnly = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //if (debe == haber){
                if (DateMinPicker.Value <= DateMaxPicker.Value){
                    Datemin = DateMinPicker.Value;
                    Datemax = DateMaxPicker.Value;
                    Frm_ComprobanteContable frm2 = new Frm_ComprobanteContable();
                    frm2.StartPosition = FormStartPosition.Manual;
                    frm2.Location = new Point(this.Location.X, this.Location.Y);
                    frm2.Width = this.Size.Width;
                    frm2.Height = this.Size.Height;
                    frm2.ShowDialog();
                }else {MessageBox.Show("Revise Las Fechad de Inicio y Culminacion");}
            //}else{MessageBox.Show("Verifique montos DEBE y HABER");}
        }

        private void Frm_ImportNomina_FormClosed(object sender, FormClosedEventArgs e)
        {
                CLASES._Cls_Varios_Metodos.dataset2.Clear();
                CLASES._Cls_Varios_Metodos.dataset2.Tables.Clear();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            DateMaxPicker.MinDate = DateMinPicker.Value;
        }

    }
}