using System;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace FHN_nonlocal_coupling
{
    class ODEModel : AbstractModel
    {
        public ODEModel() : base(typeof(ODE)) { }

        public override double chartXMax()
        { return fhn[0].T + 1; }

        public override int trackBarMax()
        { return fhn[0].N - 1; }

        /// <summary>
        /// Plots single point on t plot and phase plane
        /// </summary>
        private void plot(int j, ODE obj, int numEq, Chart chart, Chart chartPhase)
        {
            double t = obj.getT(j);
            double u = obj.getU(j);
            double v = obj.getV(j);

            chart.Series[2 * numEq].Points.AddXY(t, u);
            chart.Series[2 * numEq + 1].Points.AddXY(t, v);

            chartPhase.Series[3 * numEq].Points.AddXY(u, v);
        }

        /// <summary>
        /// Plots all at once
        /// </summary>
        public void plot(Chart chart, Chart chartPhase)
        {
            for (int i = 0; i < fhn.Length; i++)
            {
                plotNullclines((ODE)fhn[i], i, chartPhase);

                for (int j = 0; j < fhn[i].N; j++)
                    plot(j, (ODE)fhn[i], i, chart, chartPhase);
            }
        }

        /// <summary>
        /// Plots nullclines
        /// </summary>
        private void plotNullclines(ODE obj, int numEq, Chart chartPhase)
        {
            for (int j = 0; j < obj.N; j++)
            {
                double un = obj.getUN(j);

                chartPhase.Series[3 * numEq + 1].Points.AddXY(un, obj.getV1(j));
                chartPhase.Series[3 * numEq + 2].Points.AddXY(un, obj.getV2(j));
            }
        }

        /// <summary>
        /// Plots all 'till the trackBarValue moment
        /// </summary>
        public void plotTrackBarScroll(int trackBarValue, Chart chart, Chart chartPhase)
        {
            for (int j = 0; j < trackBarValue; j++)
                for (int i = 0; i < fhn.Length; i++)
                    plot(j, (ODE)fhn[i], i, chart, chartPhase);
        }

        /// <summary>
        /// Plots single point according to trackBar
        /// </summary>
        public void plotTimerTick(TrackBar trackBar, Chart chart, Chart chartPhase)
        {
            if (trackBar.Value < trackBarMax())
            {
                trackBar.Value++;
                for (int i = 0; i < fhn.Length; i++)
                    plot(trackBar.Value, (ODE)fhn[i], i, chart, chartPhase);
            }
            else trackBar.Value = 0;
        }

        public double chartPhaseXMin()
        {
            return -fhn[0].L;
        }

        public double chartPhaseXMax()
        {
            return fhn[0].L;
        }

        public double chartPhaseYMax()
        {
            return 1.5 + fhn[0].I;
        }
    }
}
