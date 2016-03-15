using System;
using System.Windows.Forms;

namespace FHN_nonlocal_coupling.View.Other
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void btnLoadODE_Click(object sender, EventArgs e)
        {
            WindowODE o = new WindowODE();
            o.ShowDialog();
        }

        private void btnLoadPDE_Click(object sender, EventArgs e)
        {
            WindowPDE p = new WindowPDE();
            p.ShowDialog();
        }
    }
}
