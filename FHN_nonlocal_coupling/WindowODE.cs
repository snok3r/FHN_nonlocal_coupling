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
        FHN_wo_diffussion[] odes;

        public WindowODE()
        {
            InitializeComponent();
        }

        private void WindowODE_Load(object sender, EventArgs e)
        {
            loadEquations(1);
        }

        private void loadEquations(int num)
        {
            odes = new FHN_wo_diffussion[num];

            for (int i = 0; i < num; i++)
                odes[i] = new FHN_wo_diffussion(this);

            propertyGrid1.SelectedObject = odes[0];

            if (num == 2)
                propertyGrid2.SelectedObject = odes[1];
            else
                propertyGrid2.SelectedObject = null;
        }

        private void plotWOD(int j, FHN_wo_diffussion obj, int numEq)
        {   // plots single point on t plot and phase plane
            chartTWOD.Series[2 * numEq].Points.AddXY(obj.getT(j), obj.getU(j));
            chartTWOD.Series[2 * numEq + 1].Points.AddXY(obj.getT(j), obj.getV(j));

            chartPhaseWOD.Series[3 * numEq].Points.AddXY(obj.getU(j), obj.getV(j));
        }

        private void plotNullclines(FHN_wo_diffussion obj, int numEq)
        {
            for (int j = 0; j < obj.N + 1; j++)
            {   // drawing nullclines
                chartPhaseWOD.Series[3 * numEq + 1].Points.AddXY(obj.getUN(j), obj.getV1(j));
                chartPhaseWOD.Series[3 * numEq + 2].Points.AddXY(obj.getUN(j), obj.getV2(j));
            }
        }

        private void propertyGrid1_SelectedGridItemChanged(object sender, SelectedGridItemChangedEventArgs e)
        {
            btnSolveBehWOD();
        }

        private void propertyGrid2_SelectedGridItemChanged(object sender, SelectedGridItemChangedEventArgs e)
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
                int extCode = odes[i].solve();
                if (extCode != 0)
                    lblErrorWOD.Visible = true;
            }
            prBarSolveWOD.Value++;

            btnPlotBehWOD();
        }

        private void btnPlotWOD_Click(object sender, EventArgs e)
        {
            setPlotWOD();

            // if 'Plot all' checked then need to clear plot.
            if (rdBtnPlotAllWOD.Checked)
            {
                //trBarTWOD.Enabled = false;
                trBarTWOD.Value = 0;

                clearPlotWOD();

                for (int i = 0; i < odes.Length; i++)
                    plotNullclines(odes[i], i);

                for (int i = 0; i < odes.Length; i++)
                {
                    for (int j = 0; j < odes[i].N + 1; j++)
                    {
                        plotWOD(j, odes[i], i);
                    }
                }
            }

            if (rdBtnTmrWOD.Checked)
            {
                clearAllButNullclinesPlotWOD();

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
                for(int i =0 ; i < odes.Length; i++)
                    plotWOD(trBarTWOD.Value, odes[i], i);

                trBarTWOD.Value = 0;

                clearAllButNullclinesPlotWOD();
            }
            else
            {
                trBarTWOD.Value++;
                for (int i = 0; i < odes.Length; i++)
                    plotWOD(trBarTWOD.Value, odes[i], i);
            }
        }

        private void trBarTWOD_Scroll(object sender, EventArgs e)
        {
            clearAllButNullclinesPlotWOD();
            timerTWOD.Enabled = false;

            // plot all 'till moment on the trackbar
            for (int j = 0; j < trBarTWOD.Value; j++)
            {
                for (int i = 0; i < odes.Length; i++)
                    plotWOD(j, odes[i], i);
            }
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

        private void clearAllButNullclinesPlotWOD()
        {
            for (int i = 0; i < chartTWOD.Series.Count(); i++)
                chartTWOD.Series[i].Points.Clear();

            for (int i = 0; i < 2; i++)
                chartPhaseWOD.Series[3 * i].Points.Clear();
        }

        private void clearPlotWOD()
        {
            for (int i = 0; i < chartTWOD.Series.Count(); i++)
                chartTWOD.Series[i].Points.Clear();

            for (int i = 0; i < chartPhaseWOD.Series.Count(); i++)
                chartPhaseWOD.Series[i].Points.Clear();
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

            chartTWOD.Series[2].Color = Color.Blue;
            chartTWOD.Series[3].Color = Color.OrangeRed;

            chartPhaseWOD.Series[3].Color = Color.Blue;
        }

        private void checkBox2ndEq_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2ndEq.Checked)
                loadEquations(2);
            else
                loadEquations(1);
        }

        private void btnAbout_Click(object sender, EventArgs e)
        {
            AboutODE o = new AboutODE();
            o.Show();
        }

        private void btnTickSlower_Click(object sender, EventArgs e)
        {
            timerTWOD.Interval += odes[0].N / 5;
        }

        private void btnTickFaster_Click(object sender, EventArgs e)
        {
            if (timerTWOD.Interval - odes[0].N / 10 > 0)
                timerTWOD.Interval -= odes[0].N / 10;
            else
            {
                timerTWOD.Interval = 1;
            }
        }
    }
}
