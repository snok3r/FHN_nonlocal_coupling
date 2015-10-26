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
        FHN_w_diffusion pde2;
        FHN_wo_diffussion ode;

        public Form1()
        {
            InitializeComponent();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //          1st tab functions         //////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

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
            chartWDiff.ChartAreas[0].AxisX.Minimum = - Convert.ToDouble(txtBoxL.Text) - 0.1;
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

        private void loadPDE(ref FHN_w_diffusion obj)
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

        private void solvePDE(ref FHN_w_diffusion obj, int whichPDE)
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

        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //          2nd tab functions         //////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //       WOD - WithOut Diffusion      //////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void setPlotWOD()
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

        private void plotWOD(int j)
        {   // plots single point on t plot and phase plane
            chartTWOD.Series[0].Points.AddXY(ode.getT(j), ode.getU(j));
            chartTWOD.Series[1].Points.AddXY(ode.getT(j), ode.getV(j));

            chartPhaseWOD.Series[0].Points.AddXY(ode.getU(j), ode.getV(j));
        }

        private void clearPlotWOD()
        {
            chartTWOD.Series[0].Points.Clear();
            chartTWOD.Series[1].Points.Clear();

            chartPhaseWOD.Series[0].Points.Clear();
            chartPhaseWOD.Series[1].Points.Clear();
            chartPhaseWOD.Series[2].Points.Clear();
        }

        private void btnResetWOD()
        {
            // if tab with non-diffusion eqaution becomes active than recall this funciton
            btnLoadWOD.Enabled = true;
            btnSolveWOD.Enabled = false;
            btnPlotWOD.Enabled = false;

            lblErrorWOD.Visible = false;

            prBarSolveWOD.Value = 0;
        }

        private void btnLoadBehWOD()
        {
            // Load button behaviour
            // if we change n, w_coupl (?), l, or TB
            if (btnPlotWOD.Enabled || btnSolveWOD.Enabled)
            {
                btnPlotWOD.Enabled = false;
                btnSolveWOD.Enabled = false;
                btnLoadWOD.Enabled = true;
            }

            lblErrorWOD.Visible = false;

            trBarTWOD.Value = 0;
            trBarTWOD.Enabled = false;
            timerTWOD.Enabled = false;
        }

        private void btnSolveBehWOD()
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

            lblErrorWOD.Visible = false;

            trBarTWOD.Value = 0;
            trBarTWOD.Enabled = false;
            timerTWOD.Enabled = false;
        }

        private void btnPlotBehWOD()
        {
            // Plot button behaviour
            if (!lblErrorWOD.Visible)
            {
                btnSolveWOD.Enabled = false;
                btnPlotWOD.Enabled = true;

                trBarTWOD.Value = 0;
                trBarTWOD.Enabled = true;
            }
        }

        private void btnLoadWOD_Click(object sender, EventArgs e)
        {
            ode.N = Convert.ToInt32(txtBoxNWOD.Text);
            ode.L = Convert.ToDouble(txtBoxLWOD.Text);
            ode.T = Convert.ToDouble(txtBoxTWOD.Text);

            ode.load(ode.N, ode.L, ode.T);

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
            ode.Alpha = Convert.ToDouble(txtBoxAlphaWOD.Text);
            ode.Beta = Convert.ToDouble(txtBoxBetaWOD.Text);
            ode.A = Convert.ToDouble(txtBoxFAWOD.Text);

            ode.Eq = rdBtnClassicalNLWOD.Checked;

            ode.initials(ode.U0, ode.V0);

            ode.solve();

            btnPlotBehWOD();
        }

        private void btnPlotWOD_Click(object sender, EventArgs e)
        {
            setPlotWOD();
            
            if (rdBtnTmrWOD.Checked) clearPlotWOD();

            // clean nullclines before drawing in case Iext changed
            chartPhaseWOD.Series[1].Points.Clear();
            chartPhaseWOD.Series[2].Points.Clear();

            for (int j = 0; j < ode.N + 1; j++)
            {   // drawing nullclines
                chartPhaseWOD.Series[1].Points.AddXY(ode.getUN(j), ode.getV1(j));
                chartPhaseWOD.Series[2].Points.AddXY(ode.getUN(j), ode.getV2(j));
            }

            // if 'Plot all' checked then need to clear plot.
            if (rdBtnPlotAllWOD.Checked)
            {
                //trBarTWOD.Enabled = false;
                trBarTWOD.Value = 0;

                chartTWOD.Series[0].Points.Clear();
                chartTWOD.Series[1].Points.Clear();

                chartPhaseWOD.Series[0].Points.Clear();

                for (int j = 0; j < ode.N+1; j++)
                {
                    plotWOD(j);
                }
            }

            if (rdBtnTmrWOD.Checked)
            {
                trBarTWOD.Enabled = true; 
                timerTWOD.Enabled = true;
            }
            else
            {
                //trBarTWOD.Enabled = false; 
                timerTWOD.Enabled = false;
            }
        }

        private void timerTWOD_Tick(object sender, EventArgs e)
        {
            if (trBarTWOD.Value == ode.N)
            {
                plotWOD(trBarTWOD.Value);
                trBarTWOD.Value = 0;

                chartTWOD.Series[0].Points.Clear();
                chartTWOD.Series[1].Points.Clear();

                chartPhaseWOD.Series[0].Points.Clear();
            }
            else
            {
                trBarTWOD.Value += 1;
                plotWOD(trBarTWOD.Value);
            }
        }

        private void btnStopTimerWOD_Click(object sender, EventArgs e)
        {
            if (timerTWOD.Enabled)
            {
                rdBtnTmrWOD.Checked = false;
                timerTWOD.Enabled = false;
                //trBarTWOD.Enabled = false;

                rdBtnPlotAllWOD.Checked = true;
            }
        }

        private void trBarTWOD_Scroll(object sender, EventArgs e)
        {
            chartTWOD.Series[0].Points.Clear();
            chartTWOD.Series[1].Points.Clear();

            chartPhaseWOD.Series[0].Points.Clear();

            timerTWOD.Enabled = false;

            // plot all 'till moment on the trackbar
            for (int j = 0; j < trBarTWOD.Value; j++)
                plotWOD(j);
        }

        private void txtBoxNWOD_TextChanged(object sender, EventArgs e)
        {
            btnLoadBehWOD();
        }

        private void txtBoxLWOD_TextChanged(object sender, EventArgs e)
        {
            btnLoadBehWOD();
        }

        private void txtBoxTWOD_TextChanged(object sender, EventArgs e)
        {
            btnLoadBehWOD();
        }

        private void txtBoxU0WOD_TextChanged(object sender, EventArgs e)
        {
            btnSolveBehWOD();
        }

        private void txtBoxV0WOD_TextChanged(object sender, EventArgs e)
        {
            btnSolveBehWOD();
        }

        private void txtBoxIWOD_TextChanged(object sender, EventArgs e)
        {
            btnSolveBehWOD();
        }

        private void txtBoxTauWOD_TextChanged(object sender, EventArgs e)
        {
            btnSolveBehWOD();
        }

        private void txtBoxAlphaWOD_TextChanged(object sender, EventArgs e)
        {
            btnSolveBehWOD();
        }

        private void txtBoxBetaWOD_TextChanged(object sender, EventArgs e)
        {
            btnSolveBehWOD();
        }

        private void txtBoxFAWOD_TextChanged(object sender, EventArgs e)
        {
            btnSolveBehWOD();
        }

        private void txtBoxB2_TextChanged(object sender, EventArgs e)
        {
            btnSolveBeh();
        }

        private void rdBtnClassicalNLWOD_CheckedChanged(object sender, EventArgs e)
        {
            btnSolveBehWOD();

            lblFAWOD.Visible = false;
            txtBoxFAWOD.Visible = false;
        }

        private void rdBtnNLWOD_CheckedChanged(object sender, EventArgs e)
        {
            btnSolveBehWOD();

            lblFAWOD.Visible = true;
            txtBoxFAWOD.Visible = true;
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
            btnReset();
            btnLoadBeh();
            timerTWOD.Enabled = false;
            timerT.Enabled = false;
            clearPlotWOD();

            ode = null; // clear pointer reference
            pde = null;
            pde2 = null;

            preparePDE(ref pde, 1);
        }

        private void tabPageWODiff_Enter(object sender, EventArgs e)
        {
            btnResetWOD();
            btnLoadBehWOD();
            timerT.Enabled = false;
            timerTWOD.Enabled = false;
            clearPlot();

            ode = null;
            pde = null; // clear pointer reference
            pde2 = null; // clear pointer reference

            int n = Convert.ToInt32(txtBoxNWOD.Text);

            double l = Convert.ToDouble(txtBoxLWOD.Text);
            double TB = Convert.ToDouble(txtBoxTWOD.Text);

            double u0 = Convert.ToDouble(txtBoxU0WOD.Text);
            double v0 = Convert.ToDouble(txtBoxV0WOD.Text);

            double Iext = Convert.ToDouble(txtBoxIWOD.Text);

            double tau = Convert.ToDouble(txtBoxTauWOD.Text);
            double alpha = Convert.ToDouble(txtBoxAlphaWOD.Text);
            double beta = Convert.ToDouble(txtBoxBetaWOD.Text); 
            double a = Convert.ToDouble(txtBoxFAWOD.Text);
            bool classical = rdBtnClassicalNLWOD.Checked;

            ode = new FHN_wo_diffussion(n, l, TB, u0, v0, Iext, tau, alpha, beta, a, classical, this);

            setPlotWOD();

            if (ode.T / n * 500 < 1)
                timerTWOD.Interval = 1;
            else
                timerTWOD.Interval = Convert.ToInt32(ode.T / n * 500);

            timerTWOD.Tick += timerTWOD_Tick;
        }

        private void preparePDE(ref FHN_w_diffusion obj, int whichPDE)
        {
            btnReset();
            btnLoadBeh();
            timerTWOD.Enabled = false;
            timerT.Enabled = false;
            clearPlotWOD();

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

            obj = new FHN_w_diffusion(alpha, beta, gamma, a, b, d, l, TB, Iext, m, n, deltaKer, this);

            setPlot();

            if (obj.T / m * 500 < 1)
                timerT.Interval = 1;
            else
                timerT.Interval = Convert.ToInt32(obj.T / m * 500);

            timerT.Tick += timerT_Tick;
        }
    }
}
