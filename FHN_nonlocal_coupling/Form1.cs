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
        FHN pde;

        public Form1()
        {
            InitializeComponent();

            float eps = 0.08F, gamma = 0.8F, l = 3.0F, TB = 20.0F;
            int n, m;
            bool eq_diff = true;

            if (eq_diff)
            {
                n = 100;
                m = 2 * n * n + 1;
            }
            else
            {
                n = 499;
                m = 999;

                TB /= 2;
            }

            pde = new FHN(eps, gamma, l, TB, m, n, eq_diff);

            SetPlot();

            timerT.Interval = Convert.ToInt32(20.0/(m+1)*1000); // plot trace for 25 sec
            timerT.Tick += timerT_Tick;
            timerT.Enabled = false;
        }

        private void Plot(int j)
        {
            for (int i = 0; i < pde.N + 1; i++) 
            {   
                chart1.Series[0].Points.AddXY(pde.GetX(i), pde.GetU(j, i));
                chart1.Series[1].Points.AddXY(pde.GetX(i), pde.GetV(j, i));
            }
        }
        private void SetPlot()
        {
            chart1.ChartAreas[0].AxisX.Minimum = - pde.L - 0.1;
            chart1.ChartAreas[0].AxisX.Maximum = pde.L + 0.1;

            chart1.ChartAreas[0].AxisY.Maximum = 2;
            chart1.ChartAreas[0].AxisY.Minimum = - chart1.ChartAreas[0].AxisY.Maximum;

            chart1.ChartAreas[0].AxisX.Interval = 2;
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
            chart1.Series[0].Points.Clear();
            chart1.Series[1].Points.Clear();

            trBarT.Maximum = pde.M;
            Plot(trBarT.Value);

            if (rdBtnTmr.Checked)
                timerT.Enabled = true;
            else
                timerT.Enabled = false;
        }

        private void trBarT_Scroll(object sender, EventArgs e)
        {
            chart1.Series[0].Points.Clear();
            chart1.Series[1].Points.Clear();

            Plot(trBarT.Value);
        }

        private void timerT_Tick(object sender, EventArgs e)
        {
            if (trBarT.Value == pde.M)
            {
                chart1.Series[0].Points.Clear();
                chart1.Series[1].Points.Clear();

                Plot(trBarT.Value);
                trBarT.Value = 0;
            }
            else
            {
                chart1.Series[0].Points.Clear();
                chart1.Series[1].Points.Clear();

                trBarT.Value += 1;
                Plot(trBarT.Value);
            }
        }

        private void btnStopTimer_Click(object sender, EventArgs e)
        {
            rdBtnTmr.Checked = false;
            timerT.Enabled = false;
        }
    }
}
