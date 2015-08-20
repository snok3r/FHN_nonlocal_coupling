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
        FHN_w_diffusion pde;

        public Form1()
        {
            InitializeComponent();

            double eps = 0.08, gamma = 0.8, a = 0.1, l = 3.0, TB = 30.0;
            int n, m;
            bool w_coupl = true;

            if (w_coupl)
            {
                //n = 100;
                m = 5000; // comment if SolveBeta() is used
                n = 500; // comment if SolveBeta() is used
                //m = 2 * n * n + 1;
            }
            else
            {
                n = 499;
                m = 999;
            }

            pde = new FHN_w_diffusion(eps, gamma, a, l, TB, m, n, w_coupl, this);

            SetPlot();

            txtBoxN.Text = Convert.ToString(pde.N);
            txtBoxM.Text = Convert.ToString(pde.M);
            txtBoxL.Text = Convert.ToString(pde.L);
            txtBoxT.Text = Convert.ToString(pde.T);
            txtBoxEps.Text = Convert.ToString(pde.Eps);
            txtBoxGamma.Text = Convert.ToString(pde.Gamma);
            txtBoxA.Text = Convert.ToString(pde.A);

            if ((w_coupl) || (m > 30000))
                timerT.Interval = 1;
            else
                timerT.Interval = Convert.ToInt32(pde.T / (m + 1) * 1000); // plot trace for T sec

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

            chart1.ChartAreas[0].AxisY.Maximum = Convert.ToDouble(txtBoxMaxUV.Text);
            chart1.ChartAreas[0].AxisY.Minimum = Convert.ToDouble(txtBoxMinUV.Text);

            txtBoxMaxUV.Text = Convert.ToString(chart1.ChartAreas[0].AxisY.Maximum);
            txtBoxMinUV.Text = Convert.ToString(chart1.ChartAreas[0].AxisY.Minimum);

            chart1.ChartAreas[0].AxisX.Interval = Convert.ToInt32((chart1.ChartAreas[0].AxisX.Maximum + chart1.ChartAreas[0].AxisX.Minimum) / 6.0);
            chart1.ChartAreas[0].AxisY.Interval = Convert.ToInt32((chart1.ChartAreas[0].AxisY.Maximum + chart1.ChartAreas[0].AxisY.Minimum) / 6.0);
        }

        private void BtnLoadBeh()
        {
            // Load button behaviour
            // if we change n, m, w_coupl, l, or TB
            if (btnPlot.Enabled || btnSolve.Enabled)
            {
                btnPlot.Enabled = false;
                btnSolve.Enabled = false;
                btnLoad.Enabled = true;
            }
        }

        private void BtnSolveBeh()
        {
            // Solve button behaviour
            // if we change eps, gamma, Kernel, f or conditions,
            // then disable Plot and call Solve again.
            if (btnPlot.Enabled)
            {
                btnLoad.Enabled = false;
                btnPlot.Enabled = false;
                btnSolve.Enabled = true;
            }
        }

        private void BtnPlotBeh()
        {
            // Plot button behaviour
            btnSolve.Enabled = false;
            btnPlot.Enabled = true;
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
            if (timerT.Enabled)
            {
                rdBtnTmr.Checked = false;
                timerT.Enabled = false;
            }
        }

        private void btnTune_Click(object sender, EventArgs e)
        {
            chart1.ChartAreas[0].AxisY.Maximum = Convert.ToDouble(txtBoxMaxUV.Text);
            chart1.ChartAreas[0].AxisY.Minimum = Convert.ToDouble(txtBoxMinUV.Text);
        }

        private void txtBoxN_TextChanged(object sender, EventArgs e)
        {
            BtnLoadBeh();
        }

        private void txtBoxM_TextChanged(object sender, EventArgs e)
        {
            BtnLoadBeh();
        }

        private void txtBoxL_TextChanged(object sender, EventArgs e)
        {
            BtnLoadBeh();
        }

        private void txtBoxT_TextChanged(object sender, EventArgs e)
        {
            BtnLoadBeh();
        }

        private void rdBtnDiffsn_CheckedChanged(object sender, EventArgs e)
        {
            BtnLoadBeh();
            txtBoxM.Enabled = true; // comment it if SolveBeta() is used
        }

        private void rdBtnCplng_CheckedChanged(object sender, EventArgs e)
        {
            BtnLoadBeh();
            txtBoxM.Enabled = true;
        }

        private void txtBoxUx0_TextChanged(object sender, EventArgs e)
        {
            BtnLoadBeh();
        }

        //

        private void txtBoxEps_TextChanged(object sender, EventArgs e)
        {
            BtnSolveBeh();
        }

        private void txtBoxGamma_TextChanged(object sender, EventArgs e)
        {
            BtnSolveBeh();
        }

        private void txtBoxA_TextChanged(object sender, EventArgs e)
        {
            BtnSolveBeh();
        }
        //

        private void btnLoad_Click(object sender, EventArgs e)
        {
            pde.N = Convert.ToInt32(txtBoxN.Text);
            pde.Eq = rdBtnWOCplng.Checked;

            if (pde.Eq)
            {   // comment below if SolveBeta() is used

                //pde.M = 2 * pde.N * pde.N + 1;
                //txtBoxM.Text = Convert.ToString(pde.M);
            }

            pde.M = Convert.ToInt32(txtBoxM.Text);
            pde.L = Convert.ToDouble(txtBoxL.Text);
            pde.T = Convert.ToDouble(txtBoxT.Text);

            pde.Load(pde.M, pde.N, pde.Eq, pde.L, pde.T);
            pde.Initials(pde.N);

            btnLoad.Enabled = false;
            btnSolve.Enabled = true;
        }

        private void btnSolve_Click(object sender, EventArgs e)
        {
            prBarSolve.Value = 0;

            pde.Eps = Convert.ToDouble(txtBoxEps.Text);
            pde.Gamma = Convert.ToDouble(txtBoxGamma.Text);
            pde.A = Convert.ToDouble(txtBoxA.Text);

            pde.SolveBeta1();
            
            BtnPlotBeh();
        }

        private void btnPlot_Click(object sender, EventArgs e)
        {
            BtnPlotBeh();

            chart1.Series[0].Points.Clear();
            chart1.Series[1].Points.Clear();

            SetPlot();

            trBarT.Maximum = pde.M;
            Plot(trBarT.Value);

            if (rdBtnTmr.Checked)
                timerT.Enabled = true;
            else
                timerT.Enabled = false;
        }
    }
}
