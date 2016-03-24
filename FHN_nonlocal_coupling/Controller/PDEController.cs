using System;
using System.Collections.Generic;
using FHN_nonlocal_coupling.Model;

namespace FHN_nonlocal_coupling.Controller
{
    class PDEController : AbstractController<PDE>
    {
        public PDEController(ViewElements viewElements)
            : base(viewElements) 
        {
            if (paramsNeedReload == null)
                paramsNeedReload = new HashSet<String>(new String[] { "N", "M", "T", "L" });
        }

        /// <summary>
        /// Returns chart's minimum X bound
        /// </summary>
        public override double chartXMin()
        { return -fhn[0].L; }

        /// <summary>
        /// Returns chart's maximum X bound
        /// </summary>
        public override double chartXMax()
        { return fhn[0].L; }

        /// <summary>
        /// Returns maximum value for trackBar
        /// </summary>
        public override int trackBarMax()
        { return fhn[0].M - 1; }

        /// <summary>
        /// Plots layer 'tj'
        /// </summary>
        public override void plot(int tj)
        {
            clearPlot();

            for (int i = 0; i < fhn.Length; i++)
                plot(tj, fhn[i], i);
        }

        /// <summary>
        /// Plots layer tj with variable trackbar value
        /// </summary>
        public override void plot()
        {
            if (viewElements.trackBar.Value < trackBarMax())
            {
                viewElements.trackBar.Value++;
                plot(viewElements.trackBar.Value);
            }
            else viewElements.trackBar.Value = 0;
        }

        /// <summary>
        /// Plots full j segment
        /// </summary>
        private void plot(int j, PDE obj, int numEq)
        {
            for (int i = 0; i < obj.N; i++)
            {
                double x = obj.getX(i);

                viewElements.chart.Series[2 * numEq].Points.AddXY(x, obj.getU(j, i));
                viewElements.chart.Series[2 * numEq + 1].Points.AddXY(x, obj.getV(j, i));
            }
        }

        /// <summary>
        /// Returns velocity at trackBarValue point
        /// </summary>
        public double getVelocity(int trackBarValue)
        {
            return Math.Round(fhn[0].getVelocity(trackBarValue), 3);
        }
    }
}
