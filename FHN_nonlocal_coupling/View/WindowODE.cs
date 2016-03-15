using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using FHN_nonlocal_coupling;

namespace FHN_nonlocal_coupling.View
{
    partial class WindowODE : Form
    {
        private Controllers.ODEController controller;

        public WindowODE()
        {
            InitializeComponent();
            controller = new Controllers.ODEController();
        }

        private void WindowODE_Load(object sender, EventArgs e)
        {
            controller.load(checkBox2ndEq.Checked, propertyGrid1, propertyGrid2);
        }

        private void WindowODE_FormClosing(object sender, FormClosingEventArgs e)
        {
            timerT.Enabled = false;
            trBarT.Enabled = false;
            chart.Series.Clear();

            controller.dispose();
        }

        private void propertyGrid1_SelectedGridItemChanged(object sender, SelectedGridItemChangedEventArgs e)
        {
            disablePlotBtn();
        }

        private void propertyGrid2_SelectedGridItemChanged(object sender, SelectedGridItemChangedEventArgs e)
        {
            disablePlotBtn();
        }

        private void disablePlotBtn()
        {
            if (btnPlot.Enabled)
            {
                btnPlot.Enabled = false;
                btnSolve.Enabled = true;
            }

            lblError.Visible = false;

            trBarT.Value = 0;
            trBarT.Enabled = false;
            timerT.Enabled = false;
        }

        private void enablePlotBtn()
        {
            if (!lblError.Visible)
            {
                btnSolve.Enabled = false;
                btnPlot.Enabled = true;

                trBarT.Value = 0;
                trBarT.Enabled = true;
            }
        }

        private void btnSolve_Click(object sender, EventArgs e)
        {
            prBarSolve.Value = 0;
            prBarSolve.Maximum = 3;
            trBarT.Maximum = controller.trackBarMax();

            if (controller.solve(prBarSolve) != 0)
                lblError.Visible = true;

            enablePlotBtn();
        }

        private void btnPlot_Click(object sender, EventArgs e)
        {
            setPlot();

            // if 'Plot all' checked then need to clear plot.
            if (rdBtnPlotAll.Checked)
            {
                //trBarT.Enabled = false;
                trBarT.Value = 0;

                clearPlot();

                controller.plot(chart, chartPhase);
            }

            if (rdBtnTmr.Checked)
            {
                clearAllButNullclinesPlot();

                trBarT.Enabled = true;
                timerT.Enabled = true;
            }
            else
            {
                //trBarT.Enabled = false; 
                timerT.Enabled = false;
            }
        }

        private void timerT_Tick(object sender, EventArgs e)
        {
            if (trBarT.Value == controller.trackBarMax())
                clearAllButNullclinesPlot();

            controller.plot(trBarT, chart, chartPhase);
        }

        private void trBarT_Scroll(object sender, EventArgs e)
        {
            clearAllButNullclinesPlot();
            timerT.Enabled = false;

            controller.plot(trBarT.Value, chart, chartPhase);
        }

        private void btnTuneT_Click(object sender, EventArgs e)
        {
            chart.ChartAreas[0].AxisY.Maximum = Convert.ToDouble(txtBoxMaxUVT.Text);
            chart.ChartAreas[0].AxisY.Minimum = Convert.ToDouble(txtBoxMinUVT.Text);
        }

        private void btnTunePhase_Click(object sender, EventArgs e)
        {
            chartPhase.ChartAreas[0].AxisY.Maximum = Convert.ToDouble(txtBoxMaxUVPhase.Text);
            chartPhase.ChartAreas[0].AxisY.Minimum = Convert.ToDouble(txtBoxMinUVPhase.Text);
        }

        private void btnStopTimer_Click(object sender, EventArgs e)
        {
            if (timerT.Enabled)
            {
                rdBtnTmr.Checked = false;
                timerT.Enabled = false;
                //trBarT.Enabled = false;

                rdBtnPlotAll.Checked = true;
            }
        }

        private void clearAllButNullclinesPlot()
        {
            for (int i = 0; i < chart.Series.Count(); i++)
                chart.Series[i].Points.Clear();

            for (int i = 0; i < 2; i++)
                chartPhase.Series[3 * i].Points.Clear();
        }

        private void clearPlot()
        {
            for (int i = 0; i < chart.Series.Count(); i++)
                chart.Series[i].Points.Clear();

            for (int i = 0; i < chartPhase.Series.Count(); i++)
                chartPhase.Series[i].Points.Clear();
        }

        private void setPlot()
        {
            chart.ChartAreas[0].AxisX.Minimum = 0;
            chart.ChartAreas[0].AxisX.Maximum = controller.chartXMax();

            chart.ChartAreas[0].AxisY.Minimum = Convert.ToDouble(txtBoxMinUVT.Text);
            chart.ChartAreas[0].AxisY.Maximum = Convert.ToDouble(txtBoxMaxUVT.Text);

            chart.ChartAreas[0].AxisX.Interval = Convert.ToInt32((chart.ChartAreas[0].AxisX.Maximum + chart.ChartAreas[0].AxisX.Minimum) / 5.0);
            chart.ChartAreas[0].AxisY.Interval = Convert.ToInt32((chart.ChartAreas[0].AxisY.Maximum + chart.ChartAreas[0].AxisY.Minimum) / 4.0);

            chartPhase.ChartAreas[0].AxisX.Minimum = controller.chartPhaseXMin();
            chartPhase.ChartAreas[0].AxisX.Maximum = controller.chartPhaseXMax();

            chartPhase.ChartAreas[0].AxisY.Minimum = Convert.ToDouble(txtBoxMinUVPhase.Text);
            chartPhase.ChartAreas[0].AxisY.Maximum = controller.chartPhaseYMax();

            chart.Series[2].Color = Color.Blue;
            chart.Series[3].Color = Color.OrangeRed;

            chartPhase.Series[3].Color = Color.Blue;
        }

        private void checkBox2ndEq_CheckedChanged(object sender, EventArgs e)
        {
            controller.load(checkBox2ndEq.Checked, propertyGrid1, propertyGrid2);
        }

        private void btnAbout_Click(object sender, EventArgs e)
        {
            View.Other.AboutODE o = new View.Other.AboutODE();
            o.Show();
        }
    }
}
