using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace T3
{
    public partial class Frm_FactObs : Form
    {
        public Frm_FactObs()
        {
            InitializeComponent();
        }
        public Frm_FactObs(string _Pr_Str_Obs, string _Pr_Str_Titulo)
        {
            InitializeComponent();
            _Txt_Obs.Text = _Pr_Str_Obs;
            this.Text = _Pr_Str_Titulo;
        }
    }
}