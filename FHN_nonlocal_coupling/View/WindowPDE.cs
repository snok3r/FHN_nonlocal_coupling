using System;
using System.Drawing;
using System.Windows.Forms;
using FHN_nonlocal_coupling.View.Other;
using FHN_nonlocal_coupling.Controllers;

namespace FHN_nonlocal_coupling.View
{
    partial class WindowPDE : Form
    {
        private PDEController controller;

        public WindowPDE()
        {
            InitializeComponent();
            controller = new PDEController();
        }

        private void WindowPDE_Load(object sender, EventArgs e)
        {
            controller.load(checkBox2ndEq.Checked, propertyGrid1, propertyGrid2);
        }

        private void WindowPDE_FormClosing(object sender, FormClosingEventArgs e)
        {
            timerT.Enabled = false;
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
                lblVelocity.Text = "--- x/t";
                btnGetVelocity.Enabled = false;
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
                btnGetVelocity.Enabled = true;
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

            controller.plot(trBarT.Value, chart);

            if (rdBtnTmr.Checked)
                timerT.Enabled = true;
            else
                timerT.Enabled = false;
        }

        private void timerT_Tick(object sender, EventArgs e)
        {
            controller.plot(trBarT, chart);
        }

        private void trBarT_Scroll(object sender, EventArgs e)
        {
            controller.plot(trBarT.Value, chart);
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

        private void btnGetVelocity_Click(object sender, EventArgs e)
        {
            lblVelocity.Text = controller.getVelocity(trBarT.Value).ToString() + " x/t";
        }

        private void setPlot()
        {
            chart.ChartAreas[0].AxisX.Minimum = controller.chartXMin();
            chart.ChartAreas[0].AxisX.Maximum = controller.chartXMax();

            chart.ChartAreas[0].AxisY.Maximum = Convert.ToDouble(txtBoxMaxUV.Text);
            chart.ChartAreas[0].AxisY.Minimum = Convert.ToDouble(txtBoxMinUV.Text);

            chart.ChartAreas[0].AxisX.Interval = Convert.ToInt32((chart.ChartAreas[0].AxisX.Maximum + chart.ChartAreas[0].AxisX.Minimum) / 6.0);
            chart.ChartAreas[0].AxisY.Interval = Convert.ToInt32((chart.ChartAreas[0].AxisY.Maximum + chart.ChartAreas[0].AxisY.Minimum) / 6.0);

            chart.Series[2].Color = Color.Blue;
            chart.Series[3].Color = Color.OrangeRed;
        }

        private void checkBox2ndEq_CheckedChanged(object sender, EventArgs e)
        {
            controller.load(checkBox2ndEq.Checked, propertyGrid1, propertyGrid2);
        }

        private void btnAbout_Click(object sender, EventArgs e)
        {
            AboutPDE o = new AboutPDE();
            o.Show();
        }
    }
}
