using System;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace FHN_nonlocal_coupling
{
    class ODEController : AbstractController<ODE>
    {
        /// <summary>
        /// Returns chart's maximum X bound
        /// </summary>
        public override double chartXMax()
        { return fhn[0].T + 1; }

        /// <summary>
        /// Returns maximum value for trackBar
        /// </summary>
        public override int trackBarMax()
        { return fhn[0].N - 1; }

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
        /// Plots all 'till the trackBarValue moment,
        /// useful with TrackBarScroll event
        /// </summary>
        public void plot(int trackBarValue, Chart chart, Chart chartPhase)
        {
            for (int j = 0; j < trackBarValue; j++)
                for (int i = 0; i < fhn.Length; i++)
                    plot(j, (ODE)fhn[i], i, chart, chartPhase);
        }

        /// <summary>
        /// Plots single point according to trackBar,
        /// useful with TimerTick event
        /// </summary>
        public void plot(TrackBar trackBar, Chart chart, Chart chartPhase)
        {
            if (trackBar.Value < trackBarMax())
            {
                trackBar.Value++;
                for (int i = 0; i < fhn.Length; i++)
                    plot(trackBar.Value, (ODE)fhn[i], i, chart, chartPhase);
            }
            else trackBar.Value = 0;
        }

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
        /// Returns phase's chart minimum X bound
        /// </summary>
        public double chartPhaseXMin()
        { return -fhn[0].L; }

        /// <summary>
        /// Returns phase's chart maximum X bound
        /// </summary>
        public double chartPhaseXMax()
        { return fhn[0].L; }

        /// <summary>
        /// Returns phase's chart maximum Y bound
        /// </summary>
        public double chartPhaseYMax()
        { return 1.5 + fhn[0].I; }
    }
}
