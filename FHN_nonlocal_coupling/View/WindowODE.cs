using System;
using System.Drawing;
using System.Windows.Forms;
using FHN_nonlocal_coupling.View.Other;
using FHN_nonlocal_coupling.Controller;

namespace FHN_nonlocal_coupling.View
{
    partial class WindowODE : Form
    {
        private ODEController controller;

        public WindowODE()
        {
            InitializeComponent();
            controller = new ODEController(new ViewElements(chart, chartPhase, propertyGrid1, propertyGrid2, prBarSolve, trBarT));
        }

        private void WindowODE_Load(object sender, EventArgs e)
        {
            controller.reallocate(checkBox2ndEq.Checked);
        }
        
        private void WindowODE_FormClosing(object sender, FormClosingEventArgs e)
        {
            timerT.Enabled = false;
            chart.Series.Clear();
            controller.dispose();
        }

        private void checkBox2ndEq_CheckedChanged(object sender, EventArgs e)
        {
            controller.reallocate(checkBox2ndEq.Checked);
            disablePlotBtn();
        }

        private void btnSolve_Click(object sender, EventArgs e)
        {
            if (controller.solve() != 0)
                lblError.Visible = true;
            enablePlotBtn();
        }

        private void btnSolveFurther_Click(object sender, EventArgs e)
        {
            controller.toSolveFurther(true);

            btnSolve_Click(sender, e);
        }

        private void btnPlot_Click(object sender, EventArgs e)
        {
            setPlot();
            controller.plot(rdBtnTmr.Checked);

            if (rdBtnTmr.Checked)
                timerT.Enabled = true;
            else
                timerT.Enabled = false;
        }

        private void timerT_Tick(object sender, EventArgs e)
        {
            controller.plot();
        }

        private void trBarT_Scroll(object sender, EventArgs e)
        {
            controller.plot(trBarT.Value);
        }                

        private void disablePlotBtn()
        {
            if (btnPlot.Enabled)
            {
                btnPlot.Enabled = false;
                btnSolve.Enabled = true;
                btnSolveFurther.Enabled = false;
            }

            lblError.Visible = false;

            trBarT.Value = 0;
            trBarT.Enabled = false;
            timerT.Enabled = false;

            controller.toAllocate(true);
            controller.toSolveFurther(false);
        }

        private void enablePlotBtn()
        {
            if (!lblError.Visible)
            {
                btnSolve.Enabled = false;
                btnPlot.Enabled = true;
                btnSolveFurther.Enabled = true;

                trBarT.Value = 0;
                trBarT.Enabled = true;
            }
        }

        private void propertyGrid1_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
        {
            if (e.OldValue == e.ChangedItem.Value)
                return;

            disablePlotBtn();
            controller.checkToLoad(e.ChangedItem.Label);
        }

        private void propertyGrid2_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
        {
            if (e.OldValue == e.ChangedItem.Value)
                return;

            disablePlotBtn();
            controller.checkToLoad(e.ChangedItem.Label);
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
            }
        }

        private void setPlot()
        {
            chart.ChartAreas[0].AxisX.Minimum = controller.chartXMin();
            chart.ChartAreas[0].AxisX.Maximum = controller.chartXMax();

            chart.ChartAreas[0].AxisY.Minimum = Convert.ToDouble(txtBoxMinUVT.Text);
            chart.ChartAreas[0].AxisY.Maximum = Convert.ToDouble(txtBoxMaxUVT.Text);

            chart.ChartAreas[0].AxisX.Interval = Convert.ToInt32((controller.chartXMax() + controller.chartXMin()) / 5.0);
            chart.ChartAreas[0].AxisY.Interval = Convert.ToInt32((chart.ChartAreas[0].AxisY.Maximum + chart.ChartAreas[0].AxisY.Minimum) / 4.0);

            chartPhase.ChartAreas[0].AxisX.Minimum = controller.chartPhaseXMin();
            chartPhase.ChartAreas[0].AxisX.Maximum = controller.chartPhaseXMax();

            chartPhase.ChartAreas[0].AxisY.Minimum = Convert.ToDouble(txtBoxMinUVPhase.Text);
            chartPhase.ChartAreas[0].AxisY.Maximum = controller.chartPhaseYMax();

            chart.Series[2].Color = Color.Blue;
            chart.Series[3].Color = Color.OrangeRed;

            chartPhase.Series[3].Color = Color.Blue;
        }

        private void btnAbout_Click(object sender, EventArgs e)
        {
            AboutODE o = new AboutODE();
            o.Show();
        }
    }
}
