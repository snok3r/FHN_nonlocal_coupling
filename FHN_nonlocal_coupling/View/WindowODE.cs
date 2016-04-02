using FHN_nonlocal_coupling.Controller;
using FHN_nonlocal_coupling.View.Other;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace FHN_nonlocal_coupling.View
{
    public partial class WindowODE : WindowTemplate
    {
        public WindowODE()
        {
            InitializeComponent();
        }

        private void WindowODE_Load(object sender, EventArgs e)
        {
            controller = new ODEController(new ViewElements(chart, chartPhase, propertyGrid1, propertyGrid2, prBarSolve, trBarT));
            controller.reallocate(checkBox2ndEq.Checked);
        }

        private void WindowODE_FormClosing(object sender, FormClosingEventArgs e)
        {
            controller.dispose();
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
        }

        protected override void setPlot()
        {
            base.setPlot();

            chartPhase.ChartAreas[0].AxisX.Minimum = ((ODEController)controller).chartPhaseXMin();
            chartPhase.ChartAreas[0].AxisX.Maximum = ((ODEController)controller).chartPhaseXMax();

            chartPhase.ChartAreas[0].AxisY.Minimum = Convert.ToDouble(txtBoxMinUVPhase.Text);
            chartPhase.ChartAreas[0].AxisY.Maximum = Convert.ToDouble(txtBoxMaxUVPhase.Text);

            chartPhase.Series[3].Color = Color.Blue;
        }

        private void btnAbout_Click(object sender, EventArgs e)
        {
            AboutODE o = new AboutODE();
            o.Show();
        }
    }
}
