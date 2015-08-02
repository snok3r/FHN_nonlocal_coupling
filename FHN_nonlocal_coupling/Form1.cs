using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FHN_nonlocal_coupling
{
    public partial class Form1 : Form
    {
        FHN pde = new FHN();
        public Form1()
        {
            InitializeComponent();
            SetPlot();
        }

        private void Plot(int j)
        {
            for (int i = 0; i <= pde.N; i++) chart1.Series[0].Points.AddXY(pde.GetX(i), pde.GetU(j, i));
            for (int i = 0; i <= pde.N; i++) chart1.Series[1].Points.AddXY(pde.GetX(i), pde.GetV(j, i));
        }
        private void SetPlot()
        {
            chart1.ChartAreas[0].AxisX.Minimum = - pde.L - 0.1;
            chart1.ChartAreas[0].AxisX.Maximum = pde.L + 0.1;
            //chart1.ChartAreas[0].AxisY.Minimum = -0.1;
            //chart1.ChartAreas[0].AxisY.Maximum = 2.1;
            chart1.ChartAreas[0].AxisX.Interval = (pde.L / 20) % 10;
            chart1.ChartAreas[0].AxisY.Interval = 2;
        }

        private void btnSolve_Click(object sender, EventArgs e)
        {
            prBarSolve.Value = 0;
            pde.Solve();
            prBarSolve.Value = 1;
        }

        private void btnPlot_Click(object sender, EventArgs e)
        {
            trBarT.Maximum = pde.M - 1;
            Plot(trBarT.Value);
        }
    }
}
