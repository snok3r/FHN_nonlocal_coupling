using FHN_nonlocal_coupling.Controller;
using FHN_nonlocal_coupling.View.Other;
using System;
using System.Drawing;

namespace FHN_nonlocal_coupling.View
{
    public partial class WindowODE : WindowTemplate
    {
        public WindowODE()
        {
            InitializeComponent();
            controller = new ODEController(ViewElements.ODEViewElements(chart, chartPhase, propertyGrid1, propertyGrid2, trBarT));
        }

        protected override void btnPlot_Click(object sender, EventArgs e)
        {
            ((ODEController)controller).plot(rdBtnTmr.Checked);

            base.btnPlot_Click(sender, e);
        }

        private void btnTunePhase_Click(object sender, EventArgs e)
        {
            chartPhase.ChartAreas[0].AxisY.Maximum = Convert.ToDouble(txtBoxMaxUVPhase.Text);
            chartPhase.ChartAreas[0].AxisY.Minimum = Convert.ToDouble(txtBoxMinUVPhase.Text);

            chartPhase.ChartAreas[0].AxisY.Interval = (chartPhase.ChartAreas[0].AxisY.Maximum - chartPhase.ChartAreas[0].AxisY.Minimum) / 10.0;
        }

        protected override void setPlot()
        {
            base.setPlot();

            chartPhase.ChartAreas[0].AxisX.Minimum = ((ODEController)controller).chartPhaseXMin();
            chartPhase.ChartAreas[0].AxisX.Maximum = ((ODEController)controller).chartPhaseXMax();

            chartPhase.ChartAreas[0].AxisY.Minimum = Convert.ToDouble(txtBoxMinUVPhase.Text);
            chartPhase.ChartAreas[0].AxisY.Maximum = Convert.ToDouble(txtBoxMaxUVPhase.Text);

            chartPhase.ChartAreas[0].AxisX.Interval = (((ODEController)controller).chartPhaseXMax() - ((ODEController)controller).chartPhaseXMin()) / 10.0;
            chartPhase.ChartAreas[0].AxisY.Interval = (chartPhase.ChartAreas[0].AxisY.Maximum - chartPhase.ChartAreas[0].AxisY.Minimum) / 10.0;

            chartPhase.Series[3].Color = Color.Blue;
        }

        protected override void change2ndLegendVisibility(bool isSecondEqChecked)
        {
            base.change2ndLegendVisibility(isSecondEqChecked);

            for (int i = 0; i < 3; i++)
                chartPhase.Series[i + 3].IsVisibleInLegend = isSecondEqChecked;
        }

        protected override void btnAbout_Click(object sender, EventArgs e)
        {
            AboutODE o = new AboutODE();
            o.Show();
        }
    }
}
