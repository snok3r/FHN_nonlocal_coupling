using System;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using FHN_nonlocal_coupling.Models;

namespace FHN_nonlocal_coupling.Controllers
{
    class PDEController : AbstractController<PDE>
    {
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
        public void plot(int tj, Chart chart)
        {
            for (int i = 0; i < fhn.Length; i++)
                plot(tj, (PDE)fhn[i], i, chart);
        }

        /// <summary>
        /// Plots layer tj with variable trackbar value
        /// </summary>
        public void plot(TrackBar trackBar, Chart chart)
        {
            if (trackBar.Value < trackBarMax()){
                trackBar.Value++;
                plot(trackBar.Value, chart);
            }
            else trackBar.Value = 0;
        }

        /// <summary>
        /// Plots full j segment
        /// </summary>
        private void plot(int j, PDE obj, int numEq, Chart chart)
        {
            for (int i = 0; i < obj.N; i++)
            {
                double x = obj.getX(i);

                chart.Series[2 * numEq].Points.AddXY(x, obj.getU(j, i));
                chart.Series[2 * numEq + 1].Points.AddXY(x, obj.getV(j, i));
            }
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
