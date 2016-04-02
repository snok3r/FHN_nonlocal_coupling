using System;
using System.Drawing;
using System.Windows.Forms;
using FHN_nonlocal_coupling.View.Other;
using FHN_nonlocal_coupling.Controller;

namespace FHN_nonlocal_coupling.View
{
    partial class WindowPDE : Form
    {
        private PDEController controller;

        public WindowPDE()
        {
            InitializeComponent();
        }

        private void WindowPDE_Load(object sender, EventArgs e)
        {
            controller = new PDEController(new ViewElements(chart, propertyGrid1, propertyGrid2, prBarSolve, trBarT));
            controller.reallocate(checkBox2ndEq.Checked);
        }

        private void WindowPDE_FormClosing(object sender, FormClosingEventArgs e)
        {
            timerT.Enabled = false;
            chart.Series.Clear();
            controller.dispose();
            Dispose(true);
        }

        private void checkBox2ndEq_CheckedChanged(object sender, EventArgs e)
        {
            controller.reallocate(checkBox2ndEq.Checked);
            disablePlotBtn();
        }

        private void btnSolve_Click(object sender, EventArgs e)
        {
            if (controller.solve())
                enablePlotBtn();
            else
                lblError.Visible = true;
        }

        private void btnSolveFurther_Click(object sender, EventArgs e)
        {
            controller.toSolveFurther(true);

            btnSolve_Click(sender, e);
        }

        private void btnPlot_Click(object sender, EventArgs e)
        {
            setPlot();
            controller.plot(trBarT.Value);

            if (rdBtnTmr.Checked)
                timerT.Enabled = true;
            else
                timerT.Enabled = false;
        }

        private void timerT_Tick(object sender, EventArgs e)
        {
            controller.plot();

            if (checkBoxContiniousVelocity.Checked)
                btnGetVelocity_Click(sender, e);
        }

        private void trBarT_Scroll(object sender, EventArgs e)
        {
            controller.plot(trBarT.Value);

            if (checkBoxContiniousVelocity.Checked)
                btnGetVelocity_Click(sender, e);
        }

        private void btnGetVelocity_Click(object sender, EventArgs e)
        {
            lblVelocity.Text = controller.getVelocity(trBarT.Value).ToString() + " x/t";
        }

        private void disablePlotBtn()
        {
            lblVelocity.Text = "--- x/t";
            btnGetVelocity.Enabled = false;
            btnPlot.Enabled = false;
            btnSolve.Enabled = true;
            btnSolveFurther.Enabled = false;

            lblError.Visible = false;

            trBarT.Value = 0;
            trBarT.Enabled = false;
            timerT.Enabled = false;

            controller.toAllocate(true);
            controller.toSolveFurther(false);
        }

        private void enablePlotBtn()
        {
            btnGetVelocity.Enabled = true;
            btnSolve.Enabled = false;
            btnSolveFurther.Enabled = true;
            btnPlot.Enabled = true;

            trBarT.Value = 0;
            trBarT.Enabled = true;
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

        private void btnTune_Click(object sender, EventArgs e)
        {
            chart.ChartAreas[0].AxisY.Maximum = Convert.ToDouble(txtBoxMaxUV.Text);
            chart.ChartAreas[0].AxisY.Minimum = Convert.ToDouble(txtBoxMinUV.Text);
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

            chart.ChartAreas[0].AxisY.Maximum = Convert.ToDouble(txtBoxMaxUV.Text);
            chart.ChartAreas[0].AxisY.Minimum = Convert.ToDouble(txtBoxMinUV.Text);

            chart.ChartAreas[0].AxisX.Interval = Convert.ToInt32((controller.chartXMax() + controller.chartXMin()) / 6.0);
            chart.ChartAreas[0].AxisY.Interval = Convert.ToInt32((chart.ChartAreas[0].AxisY.Maximum + chart.ChartAreas[0].AxisY.Minimum) / 6.0);

            chart.Series[2].Color = Color.Blue;
            chart.Series[3].Color = Color.OrangeRed;
        }

        private void btnAbout_Click(object sender, EventArgs e)
        {
            AboutPDE o = new AboutPDE();
            o.Show();
        }
    }
}
