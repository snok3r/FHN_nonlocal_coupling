using System;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

using FHN_nonlocal_coupling.Model;

namespace FHN_nonlocal_coupling.Controller
{
    class PDEController : AbstractController<PDE>
    {
        public PDEController(
            Chart chart,
            PropertyGrid pg1,
            PropertyGrid pg2,
            ProgressBar progressBar,
            TrackBar trackBar)
            : base(chart, pg1, pg2, progressBar, trackBar) 
        { }

        /// <summary>
        /// Returns chart's maximum X bound
        /// </summary>
        public override double chartXMax()
        { return fhn[0].L + 0.1; }

        /// <summary>
        /// Returns maximum value for trackBar
        /// </summary>
        public override int trackBarMax()
        { return ((PDE)fhn[0]).M - 1; }

        /// <summary>
        /// Plots layer 'tj'
        /// </summary>
        public override void plot(int tj)
        {
            clearPlot();

            for (int i = 0; i < fhn.Length; i++)
                plot(tj, (PDE)fhn[i], i);
        }

        /// <summary>
        /// Plots layer tj with variable trackbar value
        /// </summary>
        public override void plot()
        {
            if (trackBar.Value < trackBarMax()){
                trackBar.Value++;
                plot(trackBar.Value);
            }
            else trackBar.Value = 0;
        }

        /// <summary>
        /// Plots full j segment
        /// </summary>
        private void plot(int j, PDE obj, int numEq)
        {
            for (int i = 0; i < obj.N; i++)
            {
                double x = obj.getX(i);

                chart.Series[2 * numEq].Points.AddXY(x, obj.getU(j, i));
                chart.Series[2 * numEq + 1].Points.AddXY(x, obj.getV(j, i));
            }
        }

        /// <summary>
        /// Clears all the plot data
        /// </summary>
        public override void clearPlot()
        {
            for (int i = 0; i < chart.Series.Count(); i++)
                chart.Series[i].Points.Clear();
        }

        /// <summary>
        /// Returns velocity at trackBarValue point
        /// </summary>
        public double getVelocity(int trackBarValue)
        {
            return Math.Round(((PDE)fhn[0]).getVelocity(trackBarValue), 3);
        }

        /// <summary>
        /// Returns chart's minimum X bound
        /// </summary>
        public double chartXMin()
        { return -(fhn[0].L - 0.1); }
    }
}
