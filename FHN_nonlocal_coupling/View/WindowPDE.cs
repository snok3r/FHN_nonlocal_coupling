using FHN_nonlocal_coupling.Controller;
using FHN_nonlocal_coupling.View.Other;
using System;
using System.Reflection;

namespace FHN_nonlocal_coupling.View
{
    public partial class WindowPDE : WindowTemplate
    {
        public WindowPDE()
        {
            AppDomain.CurrentDomain.AssemblyResolve += (sender, args) =>
            {
                string resourceName = new AssemblyName(args.Name).Name + ".dll";
                string resource = Array.Find(this.GetType().Assembly.GetManifestResourceNames(), element => element.EndsWith(resourceName));

                using (var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(resource))
                {
                    Byte[] assemblyData = new Byte[stream.Length];
                    stream.Read(assemblyData, 0, assemblyData.Length);
                    return Assembly.Load(assemblyData);
                }
            };

            InitializeComponent();
            controller = new PDEController(ViewElements.PDEViewElements(chart, propertyGrid1, propertyGrid2, trBarT, txtBoxUX0, txtBoxVX0, checkBoxInitials));
        }

        protected override void btnPlot_Click(object sender, EventArgs e)
        {
            controller.plot(trBarT.Value);

            base.btnPlot_Click(sender, e);
        }

        private void parameterBtnsClick(bool measureContinuously)
        {
            if (measureContinuously)
            {
                btnGetVelocity.PerformClick();
                btnGetHeight.PerformClick();
            }
        }

        protected override void timerT_Tick(object sender, EventArgs e)
        {
            base.timerT_Tick(sender, e);

            parameterBtnsClick(checkBoxContiniousVelocity.Checked);
        }

        protected override void trBarT_Scroll(object sender, EventArgs e)
        {
            base.trBarT_Scroll(sender, e);

            parameterBtnsClick(checkBoxContiniousVelocity.Checked);
        }

        private void btnGetHeight_Click(object sender, EventArgs e)
        {
            double[] result = ((PDEController)controller).getHeight(trBarT.Value).ToArray();

            showParameters(lblHeight, result, 4);
        }

        private void btnGetVelocity_Click(object sender, EventArgs e)
        {
            double[] result = ((PDEController)controller).getVelocity(trBarT.Value).ToArray();

            showParameters(lblVelocity, result, 4);
        }

        private void showParameters(System.Windows.Forms.Label lbl, double[] data, int s)
        {
            String param = Math.Round(data[0], s).ToString();
            if (data.Length == 2)
                param += "  (" + Math.Round(data[1], s).ToString() + ")";

            lbl.Text = param;
        }

        protected override void disablePlotBtn()
        {
            base.disablePlotBtn();

            ((PDEController)controller).interruptThread();
            lblVelocity.Text = "---";
            lblHeight.Text = "---";
            btnGetVelocity.Enabled = false;
            btnGetHeight.Enabled = false;
        }

        protected override void enablePlotBtn()
        {
            base.enablePlotBtn();

            btnGetVelocity.Enabled = true;
            btnGetHeight.Enabled = true;
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
