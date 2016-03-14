using System;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace FHN_nonlocal_coupling
{
    class PDEModel : AbstractModel
    {
        public PDEModel() : base(typeof(PDE)) { }

        public override double chartXMax()
        { return fhn[0].L + 0.1; }

        public override int trackBarMax()
        { return ((PDE)fhn[0]).M - 1; }

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
        /// Plots layer 'j'
        /// </summary>
        public void plotLayer(int j, Chart chart)
        {
            for (int i = 0; i < fhn.Length; i++)
                plot(j, (PDE)fhn[i], i, chart);
        }

        public void plotTimerTick(TrackBar trackBar, Chart chart)
        {
            if (trackBar.Value < trackBarMax()){
                trackBar.Value++;
                plotLayer(trackBar.Value, chart);
            }
            else trackBar.Value = 0;
        }

        /// <summary>
        /// Returns formatted String with velocity
        /// at trackBarValue point
        /// </summary>
        public String getVelocity(int trackBarValue)
        {
            return Math.Round(((PDE)fhn[0]).getVelocity(trackBarValue), 3).ToString() + " x/t";
        }

        public double chartXMin()
        {
            return -(fhn[0].L - 0.1);
        }
    }
}
