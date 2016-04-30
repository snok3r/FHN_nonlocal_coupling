using FHN_nonlocal_coupling.Controller;
using FHN_nonlocal_coupling.View.Other;
using System;
using System.Windows.Forms;

namespace FHN_nonlocal_coupling.View
{
    public partial class WindowPDE : WindowTemplate
    {
        public WindowPDE()
        {
            InitializeComponent();
            controller = new PDEController(new ViewElements(chart, propertyGrid1, propertyGrid2, prBarSolve, trBarT, txtBoxUX0, txtBoxVX0, checkBoxInitials));
        }

        protected override void btnPlot_Click(object sender, EventArgs e)
        {
            controller.plot(trBarT.Value);

            base.btnPlot_Click(sender, e);
        }

        protected override void timerT_Tick(object sender, EventArgs e)
        {
            base.timerT_Tick(sender, e);

            if (checkBoxContiniousVelocity.Checked)
                btnGetVelocity_Click(sender, e);
        }

        protected override void trBarT_Scroll(object sender, EventArgs e)
        {
            base.trBarT_Scroll(sender, e);

            if (checkBoxContiniousVelocity.Checked)
                btnGetVelocity_Click(sender, e);
        }

        private void btnGetVelocity_Click(object sender, EventArgs e)
        {
            lblVelocity.Text = ((PDEController)controller).getVelocity(trBarT.Value).ToString() + " x/t";
        }

        protected override void disablePlotBtn()
        {
            base.disablePlotBtn();

            ((PDEController)controller).interruptThread();
            lblVelocity.Text = "--- x/t";
            btnGetVelocity.Enabled = false;
        }

        protected override void enablePlotBtn()
        {
            base.enablePlotBtn();

            btnGetVelocity.Enabled = true;
        }

        private void checkBoxInitials_CheckedChanged(object sender, EventArgs e)
        {
            disablePlotBtn();
            lblUX0.Enabled = checkBoxInitials.Checked;
            lblVX0.Enabled = checkBoxInitials.Checked;
            txtBoxUX0.Enabled = checkBoxInitials.Checked;
            txtBoxVX0.Enabled = checkBoxInitials.Checked;
        }

        protected override void btnAbout_Click(object sender, EventArgs e)
        {
            AboutPDE o = new AboutPDE();
            o.Show();
        }

        private void txtBoxInit_Validated(object sender, EventArgs e)
        {
            disablePlotBtn();
        }
    }
}
