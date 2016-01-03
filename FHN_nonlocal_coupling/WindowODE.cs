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
        FHN_wo_diffussion[] odes = new FHN_wo_diffussion[1];

        public WindowODE()
        {
            InitializeComponent();
        }

        private void WindowODE_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < odes.Length; i++)
                odes[i] = new FHN_wo_diffussion(this);

            propertyGrid1.SelectedObject = odes[0];
            //propertyGrid2.SelectedObject = odes[1];
        }

        private void plotWOD(int j)
        {   // plots single point on t plot and phase plane
            chartTWOD.Series[0].Points.AddXY(odes[0].getT(j), odes[0].getU(j));
            chartTWOD.Series[1].Points.AddXY(odes[0].getT(j), odes[0].getV(j));

            chartPhaseWOD.Series[0].Points.AddXY(odes[0].getU(j), odes[0].getV(j));
        }
        
        private void propertyGrid1_Validated(object sender, EventArgs e)
        {
            btnSolveBehWOD();
        }

        private void btnSolveBehWOD()
        {
            // Solve button behaviour
            // if we change I, tau, a, b, Kernel (?), f or initials,
            // then disable Plot and call Solve again.
            if (btnPlotWOD.Enabled)
            {
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

        private void btnSolveWOD_Click(object sender, EventArgs e)
        {
            prBarSolveWOD.Value = 0;
            prBarSolveWOD.Maximum = 3;
            trBarTWOD.Maximum = odes[0].N;

            for (int i = 0; i < odes.Length; i++)
                odes[i].load();
            prBarSolveWOD.Value++;

            for (int i = 0; i < odes.Length; i++)
                odes[i].initials();
            prBarSolveWOD.Value++;

            for (int i = 0; i < odes.Length; i++)
            {
                int err = odes[i].solve();
                if (err != 0)
                    lblErrorWOD.Visible = true;
            }
            prBarSolveWOD.Value++;

            btnPlotBehWOD();
        }

        private void btnPlotWOD_Click(object sender, EventArgs e)
        {
            setPlotWOD();

            if (rdBtnTmrWOD.Checked) clearPlotWOD();

            for (int j = 0; j < odes[0].N + 1; j++)
            {   // drawing nullclines
                chartPhaseWOD.Series[1].Points.AddXY(odes[0].getUN(j), odes[0].getV1(j));
                chartPhaseWOD.Series[2].Points.AddXY(odes[0].getUN(j), odes[0].getV2(j));
            }

            // if 'Plot all' checked then need to clear plot.
            if (rdBtnPlotAllWOD.Checked)
            {
                //trBarTWOD.Enabled = false;
                trBarTWOD.Value = 0;

                clearAllButPhasePlotWOD();

                for (int j = 0; j < odes[0].N + 1; j++)
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
            if (trBarTWOD.Value == odes[0].N)
            {
                plotWOD(trBarTWOD.Value);
                trBarTWOD.Value = 0;

                clearAllButPhasePlotWOD();
            }
            else
            {
                trBarTWOD.Value += 1;
                plotWOD(trBarTWOD.Value);
            }
        }

        private void trBarTWOD_Scroll(object sender, EventArgs e)
        {
            clearAllButPhasePlotWOD();
            timerTWOD.Enabled = false;

            // plot all 'till moment on the trackbar
            for (int j = 0; j < trBarTWOD.Value; j++)
                plotWOD(j);
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

        private void clearAllButPhasePlotWOD()
        {
            chartTWOD.Series[0].Points.Clear();
            chartTWOD.Series[1].Points.Clear();

            chartPhaseWOD.Series[0].Points.Clear();
        }

        private void clearPlotWOD()
        {
            for (int i = 0; i < chartTWOD.Series.Count(); i++)
                chartTWOD.Series[i].Points.Clear();

            for (int i = 0; i < chartPhaseWOD.Series.Count(); i++)
                chartPhaseWOD.Series[i].Points.Clear();
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

        private void setPlotWOD()
        {
            chartTWOD.ChartAreas[0].AxisX.Minimum = 0;
            chartTWOD.ChartAreas[0].AxisX.Maximum = odes[0].T + 1;

            chartTWOD.ChartAreas[0].AxisY.Maximum = Convert.ToDouble(txtBoxMaxUVTWOD.Text);
            chartTWOD.ChartAreas[0].AxisY.Minimum = Convert.ToDouble(txtBoxMinUVTWOD.Text);

            chartTWOD.ChartAreas[0].AxisX.Interval = Convert.ToInt32((chartTWOD.ChartAreas[0].AxisX.Maximum + chartTWOD.ChartAreas[0].AxisX.Minimum) / 5.0);
            chartTWOD.ChartAreas[0].AxisY.Interval = Convert.ToInt32((chartTWOD.ChartAreas[0].AxisY.Maximum + chartTWOD.ChartAreas[0].AxisY.Minimum) / 4.0);

            chartPhaseWOD.ChartAreas[0].AxisX.Minimum = -odes[0].L;
            chartPhaseWOD.ChartAreas[0].AxisX.Maximum = odes[0].L;

            chartPhaseWOD.ChartAreas[0].AxisY.Maximum = 1.5 + odes[0].I;
            chartPhaseWOD.ChartAreas[0].AxisY.Minimum = Convert.ToDouble(txtBoxMinUVPhaseWOD.Text);
        }
    }
}
