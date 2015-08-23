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
        FHN_wo_diffussion ode;

        public Form1()
        {
            InitializeComponent();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //          1st tab functions         //////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void Plot(int j)
        {   // plots full given t segment of diffusion solution
            for (int i = 0; i < pde.N + 1; i++) 
            {   
                chartWDiff.Series[0].Points.AddXY(pde.GetX(i), pde.GetU(j, i));
                chartWDiff.Series[1].Points.AddXY(pde.GetX(i), pde.GetV(j, i));
            }
        }

        private void SetPlot()
        {
            chartWDiff.ChartAreas[0].AxisX.Minimum = - pde.L - 0.1;
            chartWDiff.ChartAreas[0].AxisX.Maximum = pde.L + 0.1;

            chartWDiff.ChartAreas[0].AxisY.Maximum = Convert.ToDouble(txtBoxMaxUV.Text);
            chartWDiff.ChartAreas[0].AxisY.Minimum = Convert.ToDouble(txtBoxMinUV.Text);

            chartWDiff.ChartAreas[0].AxisX.Interval = Convert.ToInt32((chartWDiff.ChartAreas[0].AxisX.Maximum + chartWDiff.ChartAreas[0].AxisX.Minimum) / 6.0);
            chartWDiff.ChartAreas[0].AxisY.Interval = Convert.ToInt32((chartWDiff.ChartAreas[0].AxisY.Maximum + chartWDiff.ChartAreas[0].AxisY.Minimum) / 6.0);
        }

        private void PlotClear()
        {
            chartWDiff.Series[0].Points.Clear();
            chartWDiff.Series[1].Points.Clear();
        }

        private void BtnReset()
        {
            // if tab with diffusion equation becomes active than recall this funciton
            btnLoad.Enabled = true;
            btnSolve.Enabled = false;
            btnPlot.Enabled = false;

            prBarSolve.Value = 0;
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

                trBarT.Enabled = false;
            }
        }

        private void BtnSolveBeh()
        {
            // Solve button behaviour
            // if we change eps, gamma, Kernel or f,
            // then disable Plot and call Solve again.
            if (btnPlot.Enabled)
            {
                btnLoad.Enabled = false;
                btnPlot.Enabled = false;
                btnSolve.Enabled = true;

                trBarT.Enabled = false;
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
            chartWDiff.Series[0].Points.Clear();
            chartWDiff.Series[1].Points.Clear();

            Plot(trBarT.Value);
        }

        private void timerT_Tick(object sender, EventArgs e)
        {   
            chartWDiff.Series[0].Points.Clear();
            chartWDiff.Series[1].Points.Clear();

            if (trBarT.Value == pde.M)
            {   // if it is the last t segment, plot it and reset trBar.Value
                Plot(trBarT.Value);
                trBarT.Value = 0;
            }
            else
            {
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
            chartWDiff.ChartAreas[0].AxisY.Maximum = Convert.ToDouble(txtBoxMaxUV.Text);
            chartWDiff.ChartAreas[0].AxisY.Minimum = Convert.ToDouble(txtBoxMinUV.Text);
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
        }

        private void rdBtnCplng_CheckedChanged(object sender, EventArgs e)
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

            trBarT.Maximum = pde.M;
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
            chartWDiff.Series[0].Points.Clear();
            chartWDiff.Series[1].Points.Clear();

            SetPlot();

            Plot(trBarT.Value);

            if (rdBtnTmr.Checked)
                timerT.Enabled = true;
            else
                timerT.Enabled = false;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //          2nd tab functions         //////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //       WOD - WithOut Diffusion      //////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void SetPlotWOD()
        {
            chartTWOD.ChartAreas[0].AxisX.Minimum = 0;
            chartTWOD.ChartAreas[0].AxisX.Maximum = ode.T + 1;

            chartTWOD.ChartAreas[0].AxisY.Maximum = Convert.ToDouble(txtBoxMaxUVTWOD.Text);
            chartTWOD.ChartAreas[0].AxisY.Minimum = Convert.ToDouble(txtBoxMinUVTWOD.Text);

            chartTWOD.ChartAreas[0].AxisX.Interval = Convert.ToInt32((chartTWOD.ChartAreas[0].AxisX.Maximum + chartTWOD.ChartAreas[0].AxisX.Minimum) / 5.0);
            chartTWOD.ChartAreas[0].AxisY.Interval = Convert.ToInt32((chartTWOD.ChartAreas[0].AxisY.Maximum + chartTWOD.ChartAreas[0].AxisY.Minimum) / 4.0);

            chartPhaseWOD.ChartAreas[0].AxisX.Minimum = -ode.L;
            chartPhaseWOD.ChartAreas[0].AxisX.Maximum = ode.L;

            chartPhaseWOD.ChartAreas[0].AxisY.Maximum = 1.5 + ode.I;
            chartPhaseWOD.ChartAreas[0].AxisY.Minimum = Convert.ToDouble(txtBoxMinUVPhaseWOD.Text);
        }

        private void PlotWOD(int j)
        {   // plots single point on t plot and phase plane
            chartTWOD.Series[0].Points.AddXY(ode.GetT(j), ode.GetU(j));
            chartTWOD.Series[1].Points.AddXY(ode.GetT(j), ode.GetV(j));

            chartPhaseWOD.Series[0].Points.AddXY(ode.GetU(j), ode.GetV(j));
        }

        private void PlotClearWOD()
        {
            chartTWOD.Series[0].Points.Clear();
            chartTWOD.Series[1].Points.Clear();

            chartPhaseWOD.Series[0].Points.Clear();
            chartPhaseWOD.Series[1].Points.Clear();
            chartPhaseWOD.Series[2].Points.Clear();
        }

        private void BtnResetWOD()
        {
            // if tab with non-diffusion eqaution becomes active than recall this funciton
            btnLoadWOD.Enabled = true;
            btnSolveWOD.Enabled = false;
            btnPlotWOD.Enabled = false;

            prBarSolveWOD.Value = 0;
        }

        private void BtnLoadBehWOD()
        {
            // Load button behaviour
            // if we change n, w_coupl (?), l, or TB
            if (btnPlotWOD.Enabled || btnSolveWOD.Enabled)
            {
                btnPlotWOD.Enabled = false;
                btnSolveWOD.Enabled = false;
                btnLoadWOD.Enabled = true;
            }
        }

        private void BtnSolveBehWOD()
        {
            // Solve button behaviour
            // if we change I, tau, a, b, Kernel (?), f or initials,
            // then disable Plot and call Solve again.
            if (btnPlotWOD.Enabled)
            {
                btnLoadWOD.Enabled = false;
                btnPlotWOD.Enabled = false;
                btnSolveWOD.Enabled = true;
            }
        }

        private void BtnPlotBehWOD()
        {
            // Plot button behaviour
            btnSolveWOD.Enabled = false;
            btnPlotWOD.Enabled = true;
        }

        private void btnLoadWOD_Click(object sender, EventArgs e)
        {
            ode.N = Convert.ToInt32(txtBoxNWOD.Text);
            ode.L = Convert.ToDouble(txtBoxLWOD.Text);
            ode.T = Convert.ToDouble(txtBoxTWOD.Text);

            ode.Eq = rdBtnWCplngWOD.Checked;

            ode.Load(ode.N, ode.L, ode.T, ode.Eq);

            btnLoadWOD.Enabled = false;
            btnSolveWOD.Enabled = true;

            trBarTWOD.Maximum = ode.N;
        }

        private void btnSolveWOD_Click(object sender, EventArgs e)
        {
            prBarSolveWOD.Value = 0;

            ode.U0 = Convert.ToDouble(txtBoxU0WOD.Text);
            ode.V0 = Convert.ToDouble(txtBoxV0WOD.Text);

            ode.I = Convert.ToDouble(txtBoxIWOD.Text);
            ode.Tau = Convert.ToDouble(txtBoxTauWOD.Text);
            ode.A = Convert.ToDouble(txtBoxAWOD.Text);
            ode.B = Convert.ToDouble(txtBoxBWOD.Text);

            ode.Initials(ode.U0, ode.V0);

            ode.Solve();

            BtnPlotBehWOD();
        }

        private void btnPlotWOD_Click(object sender, EventArgs e)
        {
            SetPlotWOD();
            
            if (rdBtnTmrWOD.Checked) PlotClearWOD();

            for (int j = 0; j < ode.N + 1; j++)
            {   // clean nullclines before drawing in case Iext changed
                chartPhaseWOD.Series[1].Points.Clear();
                chartPhaseWOD.Series[2].Points.Clear();
            }

            for (int j = 0; j < ode.N + 1; j++)
            {   // drawing nullclines
                chartPhaseWOD.Series[1].Points.AddXY(ode.GetUN(j), ode.GetV1(j));
                chartPhaseWOD.Series[2].Points.AddXY(ode.GetUN(j), ode.GetV2(j));
            }

            // if 'Plot all' checked then need to clear plot.
            if (rdBtnPlotAllWOD.Checked)
            {
                trBarTWOD.Enabled = false;
                trBarTWOD.Value = 0;

                chartTWOD.Series[0].Points.Clear();
                chartTWOD.Series[1].Points.Clear();

                chartPhaseWOD.Series[0].Points.Clear();

                for (int j = 0; j < ode.N+1; j++)
                {
                    PlotWOD(j);
                }
            }

            if (rdBtnTmrWOD.Checked)
            {
                trBarTWOD.Enabled = true; 
                timerTWOD.Enabled = true;
            }
            else
            {
                trBarTWOD.Enabled = false; 
                timerTWOD.Enabled = false;
            }
        }

        private void timerTWOD_Tick(object sender, EventArgs e)
        {
            if (trBarTWOD.Value == ode.N)
            {
                PlotWOD(trBarTWOD.Value);
                trBarTWOD.Value = 0;

                chartTWOD.Series[0].Points.Clear();
                chartTWOD.Series[1].Points.Clear();

                chartPhaseWOD.Series[0].Points.Clear();
            }
            else
            {
                trBarTWOD.Value += 1;
                PlotWOD(trBarTWOD.Value);
            }
        }

        private void btnStopTimerWOD_Click(object sender, EventArgs e)
        {
            if (timerTWOD.Enabled)
            {
                rdBtnTmrWOD.Checked = false;
                timerTWOD.Enabled = false;
                trBarTWOD.Enabled = false;

                rdBtnPlotAllWOD.Checked = true;
            }
        }

        private void trBarTWOD_Scroll(object sender, EventArgs e)
        {
            chartTWOD.Series[0].Points.Clear();
            chartTWOD.Series[1].Points.Clear();

            chartPhaseWOD.Series[0].Points.Clear();

            timerTWOD.Enabled = true;
        }

        private void txtBoxNWOD_TextChanged(object sender, EventArgs e)
        {
            BtnLoadBehWOD();
        }

        private void txtBoxLWOD_TextChanged(object sender, EventArgs e)
        {
            BtnLoadBehWOD();
        }

        private void txtBoxTWOD_TextChanged(object sender, EventArgs e)
        {
            BtnLoadBehWOD();
        }

        private void rdBtnWOCplngWOD_CheckedChanged(object sender, EventArgs e)
        {
            BtnLoadBehWOD();
        }

        private void rdBtnWCplngWOD_CheckedChanged(object sender, EventArgs e)
        {
            BtnLoadBehWOD();
        }

        private void txtBoxU0WOD_TextChanged(object sender, EventArgs e)
        {
            BtnSolveBehWOD();
        }

        private void txtBoxV0WOD_TextChanged(object sender, EventArgs e)
        {
            BtnSolveBehWOD();
        }

        private void txtBoxIWOD_TextChanged(object sender, EventArgs e)
        {
            BtnSolveBehWOD();
        }

        private void txtBoxTauWOD_TextChanged(object sender, EventArgs e)
        {
            BtnSolveBehWOD();
        }

        private void txtBoxAWOD_TextChanged(object sender, EventArgs e)
        {
            BtnSolveBehWOD();
        }

        private void txtBoxBWOD_TextChanged(object sender, EventArgs e)
        {
            BtnSolveBehWOD();
        }

        private void btnTuneTWOD_Click(object sender, EventArgs e)
        {
            chartTWOD.ChartAreas[0].AxisY.Maximum = Convert.ToDouble(txtBoxMaxUVTWOD.Text);
            chartTWOD.ChartAreas[0].AxisY.Minimum = Convert.ToDouble(txtBoxMinUVTWOD.Text);
        }

        private void btnTunePhaseWOD_Click(object sender, EventArgs e)
        {
            chartPhaseWOD.ChartAreas[0].AxisY.Maximum = Convert.ToDouble(txtBoxMaxUVPhaseWOD.Text);
            chartPhaseWOD.ChartAreas[0].AxisY.Minimum = Convert.ToDouble(txtBoxMinUVPhaseWOD.Text);
        }

        // Tabs behaviour

        private void tabPageWDiff_Enter(object sender, EventArgs e)
        {
            BtnReset();
            timerTWOD.Enabled = false;
            timerT.Enabled = false;
            PlotClearWOD();
            trBarT.Value = 0;
            ode = new FHN_wo_diffussion(); // destruct that

            double eps = Convert.ToDouble(txtBoxEps.Text), gamma = Convert.ToDouble(txtBoxGamma.Text);
            double a = Convert.ToDouble(txtBoxA.Text), l = Convert.ToDouble(txtBoxL.Text), TB = Convert.ToDouble(txtBoxT.Text);
            int m = Convert.ToInt32(txtBoxM.Text), n = Convert.ToInt32(txtBoxN.Text);
            bool w_coupl = rdBtnWCplng.Checked;

            pde = new FHN_w_diffusion(eps, gamma, a, l, TB, m, n, w_coupl, this);

            SetPlot();

            if (pde.T / m < 1)
                timerT.Interval = 1;
            else
                timerT.Interval = Convert.ToInt32(pde.T / m * 750); // plot trace for T sec

            timerT.Tick += timerT_Tick;
        }

        private void tabPageWODiff_Enter(object sender, EventArgs e)
        {
            BtnResetWOD();
            timerT.Enabled = false;
            timerTWOD.Enabled = false;
            PlotClear();
            trBarTWOD.Value = 0;
            pde = new FHN_w_diffusion(); // destruct that

            int n = Convert.ToInt32(txtBoxNWOD.Text);
            double l = Convert.ToDouble(txtBoxLWOD.Text), TB = Convert.ToDouble(txtBoxTWOD.Text);
            double u0 = Convert.ToDouble(txtBoxU0WOD.Text), v0 = Convert.ToDouble(txtBoxV0WOD.Text);
            double Iext = Convert.ToDouble(txtBoxIWOD.Text), tau = Convert.ToDouble(txtBoxTauWOD.Text);
            double a = Convert.ToDouble(txtBoxAWOD.Text), b = Convert.ToDouble(txtBoxBWOD.Text);
            bool w_coupl = rdBtnWCplngWOD.Checked;

            ode = new FHN_wo_diffussion(n, l, TB, u0, v0, Iext, tau, a, b, w_coupl, this);

            SetPlotWOD();

            if (ode.T / n < 1)
                timerTWOD.Interval = 1;
            else
                timerTWOD.Interval = Convert.ToInt32(ode.T / n * 750); // plot trace for T sec

            timerTWOD.Tick += timerTWOD_Tick;
        }
    }
}
