using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;


namespace T3
{
    public partial class Frm_WaitForm : Form
    {
        public Frm_WaitForm()
        {
            InitializeComponent();
        }
        private Thread _Thr_Subproceso;

        public Frm_WaitForm(int _Int_Seg, Thread _Thr_Thread)
        {
            InitializeComponent();         
            _Tim_Timer.Interval = _Int_Seg;
            _Thr_Subproceso = _Thr_Thread;
            if (!_Tim_Timer.Enabled)
            {
                _Tim_Timer.Enabled = true;
            }
        }
        public Frm_WaitForm(int _Int_Seg, Thread _Thr_Thread,string _P_Str_Mensaje)
        {
            InitializeComponent();
            _Lbl_WaitMsg.Text = _P_Str_Mensaje;
            _Tim_Timer.Interval = _Int_Seg;
            _Thr_Subproceso = _Thr_Thread;
            if (!_Tim_Timer.Enabled)
            {
                _Tim_Timer.Enabled = true;
            }
        }

        private void _Tim_Timer_Tick(object sender, EventArgs e)
        {
            _Tim_Timer.Stop();     // Se para el timer.

            if (_Thr_Subproceso.IsAlive)
            {
                // Una vez transcurrido el tiempo inicialmente establecido
                // establezco un intervalo de un segundo para mirar si el proceso a terminado.

                if (_Tim_Timer.Interval != 1000)
                    _Tim_Timer.Interval = 1000;

                _Tim_Timer.Start();
            }
            else
            {
                this.Close();
            }
        }
    }
}
