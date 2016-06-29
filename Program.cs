using System;
using System.Windows.Forms;
using System.Threading;

namespace T3
{
    static class Program
    {

        public static CLASES._Cls_Conexion _MyClsCnn;
        public static DataContext._Dat_CntxTablasDataContext _Dat_Tablas;
        public static DataContext._Dat_CntxVistasDataContext _Dat_Vistas;
        private static Mutex oMutex;
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]

        static void Main()
        {
            //Microsoft.Win32.RegistryKey _MyReg;
            //_MyReg = Microsoft.Win32.Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
            //_MyReg.SetValue("T3Regedit", "T3.exe");
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("es-VE");
            Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("es-VE");
            Thread.CurrentThread.CurrentCulture.NumberFormat.NumberDecimalSeparator = ",";
            Thread.CurrentThread.CurrentCulture.NumberFormat.NumberGroupSeparator = ".";
            Thread.CurrentThread.CurrentCulture.TextInfo.ListSeparator = ";";
            _MyClsCnn = new CLASES._Cls_Conexion();
            if (!CLASES._Cls_Conexion._Bol_UsuarioRemoto & CLASES._Cls_Conexion._Int_Sucursal == 0)
            {
                MessageBox.Show("No se obtuvo la sucursal", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); Application.Exit();
                Application.Exit();
            }
            else
            {
                bool _Bol_ProcesoAbierto;
                var objSingleInstance = new Mutex(false, "T3.exe", out _Bol_ProcesoAbierto);
                if (_Bol_ProcesoAbierto)
                    Application.Run(new Frm_Inicio());
                MessageBox.Show("La aplicación ya se encuentra abierta.", "Información", MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                return;
            }
        }
    }
}
