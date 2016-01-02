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
    public partial class WindowODE : Form
    {
        FHN_wo_diffussion ode;

        public WindowODE()
        {
            InitializeComponent();
        }

        private void WindowODE_Load(object sender, EventArgs e)
        {
            ode = new FHN_wo_diffussion(this);

            propertyGrid1.SelectedObject = ode;
        }

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
            ode.load(ode.N, ode.L, ode.T);

            btnLoadWOD.Enabled = false;
            btnSolveWOD.Enabled = true;

            trBarTWOD.Maximum = ode.N;
        }

        private void btnSolveWOD_Click(object sender, EventArgs e)
        {
            prBarSolveWOD.Value = 0;

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

                for (int j = 0; j < ode.N + 1; j++)
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
            btnSolveBehWOD();
        }

        private void rdBtnClassicalNLWOD_CheckedChanged(object sender, EventArgs e)
        {
            btnSolveBehWOD();
        }

        private void rdBtnNLWOD_CheckedChanged(object sender, EventArgs e)
        {
            btnSolveBehWOD();
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
    }
}
