using FHN_nonlocal_coupling.Controller;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FHN_nonlocal_coupling.View.Other
{
    public partial class WindowTemplate : Form
    {
        protected IControllable controller;
        private Object monitor = new Object();

        protected WindowTemplate()
        {
            InitializeComponent();
            prBarSolve.Maximum = 100;
        }

        private void WindowTemplate_Load(object sender, EventArgs e)
        {
            if (controller != null) controller.reallocate(checkBox2ndEq.Checked);
            change2ndLegendVisibility(checkBox2ndEq.Checked);
        }

        private void WindowTemplate_FormClosing(object sender, FormClosingEventArgs e)
        {
            timerT.Enabled = false;
            controller.dispose();
            chart.Series.Clear();
            Dispose(true);
        }

        protected virtual void btnPlot_Click(object sender, EventArgs e)
        {
            setPlot();

            // start timer, if radio button is checked
            timerT.Enabled = rdBtnTmr.Checked;
        }

        protected virtual void timerT_Tick(object sender, EventArgs e)
        {
            controller.plot();
        }

        protected virtual void trBarT_Scroll(object sender, EventArgs e)
        {
            controller.plot(trBarT.Value);
        }

        protected virtual void disablePlotBtn()
        {
            btnPlot.Enabled = false;
            btnSolve.Enabled = true;
            btnSolveFurther.Enabled = false;

            lblError.Visible = false;

            trBarT.Value = 0;
            trBarT.Enabled = false;
            timerT.Enabled = false;

            prBarSolve.Value = 0;

            controller.toAllocate(true);
            controller.toSolveFurther(false);
        }

        protected virtual void enablePlotBtn()
        {
            btnSolve.Enabled = false;
            btnPlot.Enabled = true;
            btnSolveFurther.Enabled = true;

            trBarT.Maximum = controller.trackBarMax();
            trBarT.Value = 0;
            trBarT.Enabled = true;
        }

        protected virtual void setPlot()
        {
            chart.ChartAreas[0].AxisX.Minimum = controller.chartXMin();
            chart.ChartAreas[0].AxisX.Maximum = controller.chartXMax();

            chart.ChartAreas[0].AxisY.Minimum = Convert.ToDouble(txtBoxMinUV.Text);
            chart.ChartAreas[0].AxisY.Maximum = Convert.ToDouble(txtBoxMaxUV.Text);

            chart.ChartAreas[0].AxisX.Interval = Convert.ToInt32((controller.chartXMax() - controller.chartXMin()) / 10.0);
            chart.ChartAreas[0].AxisY.Interval = (chart.ChartAreas[0].AxisY.Maximum - chart.ChartAreas[0].AxisY.Minimum) / 10.0;

            chart.Series[2].Color = Color.DarkRed;
            chart.Series[3].Color = Color.LimeGreen;
        }

        protected virtual void change2ndLegendVisibility(bool isSecondEqChecked)
        {
            for (int i = 0; i < 2; i++)
                chart.Series[i + 2].IsVisibleInLegend = isSecondEqChecked;
        }

        private void checkBox2ndEq_CheckedChanged(object sender, EventArgs e)
        {
            controller.reallocate(checkBox2ndEq.Checked);
            disablePlotBtn();

            change2ndLegendVisibility(checkBox2ndEq.Checked);
        }

        private async void btnSolve_Click(object sender, EventArgs e)
        {
            if (!Monitor.IsEntered(monitor))
            {
                try
                {
                    Monitor.Enter(monitor);
                    btnStat.PerformClick();
                    bool result = false;
                    var progress = new Progress<int>(percent => prBarSolve.Value = percent);

                    result = await Task.Factory.StartNew(() => controller.solve(progress));

                    if (result)
                        enablePlotBtn();
                    else
                        lblError.Visible = true;
                }
                catch (NullReferenceException)
                {
                    Debug.WriteLine("Solution failed");
                }
                finally
                {
                    Monitor.Exit(monitor);
                }
            }
        }

        private void btnStat_Click(object sender, EventArgs e)
        {
            double[] result = controller.getStat().ToArray();
            lblUStat.Text = "u* = " + Math.Round(result[0], 5).ToString();
            lblVStat.Text = "v* = " + Math.Round(result[1], 5).ToString();

            if (result.Length == 4)
            {
                lblUStat.Text += "  (" + Math.Round(result[2], 5).ToString() + ")";
                lblVStat.Text += "  (" + Math.Round(result[3], 5).ToString() + ")";
            }
        }

        private void btnSolveFurther_Click(object sender, EventArgs e)
        {
            disablePlotBtn();
            controller.toSolveFurther(true);
            btnSolve_Click(sender, e);
        }

        private void propertyGrid_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
        {
            if (e.OldValue == e.ChangedItem.Value)
                return;

            disablePlotBtn();
            controller.checkToLoad(e.ChangedItem.Label);
        }

        private void btnTune_Click(object sender, EventArgs e)
        {
            chart.ChartAreas[0].AxisY.Minimum = Convert.ToDouble(txtBoxMinUV.Text);
            chart.ChartAreas[0].AxisY.Maximum = Convert.ToDouble(txtBoxMaxUV.Text);

            chart.ChartAreas[0].AxisY.Interval = (chart.ChartAreas[0].AxisY.Maximum - chart.ChartAreas[0].AxisY.Minimum) / 10.0;
        }

        private void btnStopTimer_Click(object sender, EventArgs e)
        {
            if (timerT.Enabled)
            {
                rdBtnTmr.Checked = false;
                timerT.Enabled = false;
            }
        }

        protected virtual void btnAbout_Click(object sender, EventArgs e) { }
    }
}
