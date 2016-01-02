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
    public partial class WindowPDE : Form
    {
        FHN_w_diffussion pde;
        FHN_w_diffussion pde2;

        public WindowPDE()
        {
            InitializeComponent();
        }

        private void plot(int j)
        {   // plots full given t segment of diffusion solution
            if (!chBoxPlotWB2.Checked)
            {
                for (int i = 0; i < pde.N + 1; i++)
                {
                    chartWDiff.Series[0].Points.AddXY(pde.getX(i), pde.getU(j, i));
                    chartWDiff.Series[1].Points.AddXY(pde.getX(i), pde.getV(j, i));
                }
            }
            else
            {
                for (int i = 0; i < pde.N + 1; i++)
                {
                    chartWDiff.Series[0].Points.AddXY(pde.getX(i), pde.getU(j, i));
                    chartWDiff.Series[1].Points.AddXY(pde.getX(i), pde.getV(j, i));

                    chartWDiff.Series[2].Points.AddXY(pde2.getX(i), pde2.getU(j, i));
                    chartWDiff.Series[3].Points.AddXY(pde2.getX(i), pde2.getV(j, i));
                }
            }
        }

        private void setPlot()
        {
            chartWDiff.ChartAreas[0].AxisX.Minimum = -Convert.ToDouble(txtBoxL.Text) - 0.1;
            chartWDiff.ChartAreas[0].AxisX.Maximum = Convert.ToDouble(txtBoxL.Text) + 0.1;

            chartWDiff.ChartAreas[0].AxisY.Maximum = Convert.ToDouble(txtBoxMaxUV.Text);
            chartWDiff.ChartAreas[0].AxisY.Minimum = Convert.ToDouble(txtBoxMinUV.Text);

            chartWDiff.ChartAreas[0].AxisX.Interval = Convert.ToInt32((chartWDiff.ChartAreas[0].AxisX.Maximum + chartWDiff.ChartAreas[0].AxisX.Minimum) / 6.0);
            chartWDiff.ChartAreas[0].AxisY.Interval = Convert.ToInt32((chartWDiff.ChartAreas[0].AxisY.Maximum + chartWDiff.ChartAreas[0].AxisY.Minimum) / 6.0);

            chartWDiff.Series[2].Color = Color.Blue;
            chartWDiff.Series[3].Color = Color.OrangeRed;
        }

        private void clearPlot()
        {
            for (int i = 0; i < 4; i++)
                chartWDiff.Series[i].Points.Clear();
        }

        private void btnReset()
        {
            // if tab with diffusion equation becomes active than recall this funciton
            btnLoad.Enabled = true;
            btnSolve.Enabled = false;
            btnPlot.Enabled = false;

            lblError.Visible = false;

            prBarSolve.Value = 0;
        }

        private void btnLoadBeh()
        {
            // Load button behaviour
            // if we change n, m, l, or TB
            if (btnPlot.Enabled || btnSolve.Enabled)
            {
                btnPlot.Enabled = false;
                btnSolve.Enabled = false;
                btnLoad.Enabled = true;
            }

            lblError.Visible = false;

            trBarT.Value = 0;
            trBarT.Enabled = false;
            timerT.Enabled = false;
        }

        private void btnSolveBeh()
        {
            // Solve button behaviour
            // if we change alpha, beta, gamma, Kernel or f,
            // then disable Plot and call Solve again.
            if (btnPlot.Enabled)
            {
                btnLoad.Enabled = false;
                btnPlot.Enabled = false;
                btnSolve.Enabled = true;
            }

            lblError.Visible = false;

            trBarT.Value = 0;
            trBarT.Enabled = false;
            timerT.Enabled = false;
        }

        private void btnPlotBeh()
        {
            // Plot button behaviour
            if (!lblError.Visible)
            {
                btnSolve.Enabled = false;
                btnPlot.Enabled = true;

                trBarT.Value = 0;
                trBarT.Enabled = true;
            }
        }

        private void trBarT_Scroll(object sender, EventArgs e)
        {
            clearPlot();

            plot(trBarT.Value);
        }

        private void timerT_Tick(object sender, EventArgs e)
        {
            clearPlot();

            if (trBarT.Value == pde.M)
            {   // if it is the last t segment, plot it and reset trBar.Value
                plot(trBarT.Value);
                trBarT.Value = 0;
            }
            else
            {
                trBarT.Value += 1;
                plot(trBarT.Value);
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
            chartWDiff.ChartAreas[0].AxisY.Maximum = Convert.ToDouble(txtBoxMaxUV.Text);
            chartWDiff.ChartAreas[0].AxisY.Minimum = Convert.ToDouble(txtBoxMinUV.Text);
        }

        private void txtBoxN_TextChanged(object sender, EventArgs e)
        {
            btnLoadBeh();
        }

        private void txtBoxM_TextChanged(object sender, EventArgs e)
        {
            btnLoadBeh();
        }

        private void txtBoxL_TextChanged(object sender, EventArgs e)
        {
            btnLoadBeh();
        }

        private void txtBoxT_TextChanged(object sender, EventArgs e)
        {
            btnLoadBeh();
        }

        //

        private void txtBoxAlpha_TextChanged(object sender, EventArgs e)
        {
            btnSolveBeh();
        }

        private void txtBoxBeta_TextChanged(object sender, EventArgs e)
        {
            btnSolveBeh();
        }

        private void txtBoxGamma_TextChanged(object sender, EventArgs e)
        {
            btnSolveBeh();
        }

        private void txtBoxA_TextChanged(object sender, EventArgs e)
        {
            btnSolveBeh();
        }

        private void txtBoxB_TextChanged(object sender, EventArgs e)
        {
            btnSolveBeh();
        }

        private void txtBoxD_TextChanged(object sender, EventArgs e)
        {
            btnSolveBeh();
        }

        private void txtBoxI_TextChanged(object sender, EventArgs e)
        {
            btnSolveBeh();
        }

        private void rdBtnDeltaCoupl_CheckedChanged(object sender, EventArgs e)
        {
            btnSolveBeh();

            lblD.Visible = true;
            txtBoxD.Visible = true;
        }

        private void rdBtnCoupl_CheckedChanged(object sender, EventArgs e)
        {
            btnSolveBeh();

            lblD.Visible = false;
            txtBoxD.Visible = false;
        }
        //

        private void btnLoad_Click(object sender, EventArgs e)
        {
            loadPDE(ref pde);

            if (chBoxPlotWB2.Checked)
                loadPDE(ref pde2);
        }

        private void loadPDE(ref FHN_w_diffussion obj)
        {
            obj.N = Convert.ToInt32(txtBoxN.Text);
            obj.M = Convert.ToInt32(txtBoxM.Text);
            obj.L = Convert.ToDouble(txtBoxL.Text);
            obj.T = Convert.ToDouble(txtBoxT.Text);

            obj.load(obj.M, obj.N, obj.L, obj.T);
            obj.initials(obj.N);

            btnLoad.Enabled = false;
            btnSolve.Enabled = true;

            trBarT.Maximum = obj.M;
        }

        private void btnSolve_Click(object sender, EventArgs e)
        {
            solvePDE(ref pde, 1);

            if (chBoxPlotWB2.Checked)
                solvePDE(ref pde2, 2);

            btnPlotBeh();
        }

        private void solvePDE(ref FHN_w_diffussion obj, int whichPDE)
        {
            prBarSolve.Value = 0;

            obj.Alpha = Convert.ToDouble(txtBoxAlpha.Text);
            obj.Beta = Convert.ToDouble(txtBoxBeta.Text);
            obj.Gamma = Convert.ToDouble(txtBoxGamma.Text);
            obj.A = Convert.ToDouble(txtBoxA.Text);

            if (whichPDE == 1)
                obj.B = Convert.ToDouble(txtBoxB.Text);
            else
                obj.B = Convert.ToDouble(txtBoxB2.Text);

            obj.D = Convert.ToDouble(txtBoxD.Text);
            obj.I = Convert.ToDouble(txtBoxI.Text);
            obj.Eq = rdBtnDeltaCoupl.Checked;

            obj.solve();
        }

        private void btnPlot_Click(object sender, EventArgs e)
        {
            clearPlot();

            setPlot();

            plot(trBarT.Value);

            if (rdBtnTmr.Checked)
                timerT.Enabled = true;
            else
                timerT.Enabled = false;
        }

        private void chBoxPlotWB2_CheckedChanged(object sender, EventArgs e)
        {
            btnSolveBeh();

            if (!lblB2.Visible)
            {
                lblB2.Visible = true;
                txtBoxB2.Visible = true;

                preparePDE(ref pde2, 2);
            }
            else
            {
                lblB2.Visible = false;
                txtBoxB2.Visible = false;

                pde2 = null;
            }
        }

        private void preparePDE(ref FHN_w_diffussion obj, int whichPDE)
        {
            btnReset();
            btnLoadBeh();
            timerT.Enabled = false;

            int n = Convert.ToInt32(txtBoxN.Text);
            int m = Convert.ToInt32(txtBoxM.Text);

            double alpha = Convert.ToDouble(txtBoxAlpha.Text);
            double beta = Convert.ToDouble(txtBoxBeta.Text);
            double gamma = Convert.ToDouble(txtBoxGamma.Text);

            double a = Convert.ToDouble(txtBoxA.Text);

            double l = Convert.ToDouble(txtBoxL.Text);
            double TB = Convert.ToDouble(txtBoxT.Text);

            double b;
            if (whichPDE == 1)
                b = Convert.ToDouble(txtBoxB.Text);
            else
                b = Convert.ToDouble(txtBoxB2.Text);

            double d = Convert.ToDouble(txtBoxD.Text);
            double Iext = Convert.ToDouble(txtBoxI.Text);

            bool deltaKer = rdBtnDeltaCoupl.Checked;

            obj = new FHN_w_diffussion(alpha, beta, gamma, a, b, d, l, TB, Iext, m, n, deltaKer, this);

            setPlot();

            if (obj.T / m * 500 < 1)
                timerT.Interval = 1;
            else
                timerT.Interval = Convert.ToInt32(obj.T / m * 500);

            timerT.Tick += timerT_Tick;
        }
    }
}
