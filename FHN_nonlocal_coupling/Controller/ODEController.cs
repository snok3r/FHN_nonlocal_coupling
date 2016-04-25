using FHN_nonlocal_coupling.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FHN_nonlocal_coupling.Controller
{
    public class ODEController : AbstractController<ODE>
    {
        public ODEController(ViewElements viewElements)
            : base(viewElements)
        { 
            if (paramsNeedReload == null)
                paramsNeedReload = new HashSet<String>(new String[] { "N", "T", "L" });
        }

        /// <summary>
        /// Returns chart's minimum X bound
        /// </summary>
        public override double chartXMin()
        { return 0; }

        /// <summary>
        /// Returns chart's maximum X bound
        /// </summary>
        public override double chartXMax()
        { return fhn[0].T; }

        /// <summary>
        /// Returns maximum value for trackBar
        /// </summary>
        public override int trackBarMax()
        { return fhn[0].N - 1; }

        /// <summary>
        /// Plots all at once if 'chckd' == false,
        /// otherwise plots only nullclines
        /// </summary>
        public void plot(bool chckd)
        {
            if (chckd)
                clearNullclines();
            else
            {
                viewElements.trackBar.Value = 0;

                clearPlot();

                for (int i = 0; i < fhn.Length; i++)
                    for (int j = 0; j < fhn[i].N; j++)
                        plot(j, fhn[i], i);
            }

            for (int i = 0; i < fhn.Length; i++)
                plotNullclines(fhn[i], i);
        }

        /// <summary>
        /// Plots all 'till the trackBarValue moment,
        /// useful with TrackBarScroll event
        /// </summary>
        public override void plot(int trackBarValue)
        {
            clearAllButNullclines();

            for (int j = 0; j < trackBarValue; j++)
                for (int i = 0; i < fhn.Length; i++)
                    plot(j, fhn[i], i);
        }

        /// <summary>
        /// Plots single point according to trackBar,
        /// useful with TimerTick event
        /// </summary>
        public override void plot()
        {
            if (viewElements.trackBar.Value == 0)
                clearAllButNullclines();

            if (viewElements.trackBar.Value < trackBarMax())
                for (int i = 0; i < fhn.Length; i++)
                    plot(viewElements.trackBar.Value++, fhn[i], i);
            else
                viewElements.trackBar.Value = 0;
        }

        /// <summary>
        /// Plots single point on t plot and phase plane
        /// </summary>
        private void plot(int j, ODE obj, int numEq)
        {
            double t = obj.getT(j);
            double u = obj.getU(j);
            double v = obj.getV(j);

            viewElements.chart.Series[2 * numEq].Points.AddXY(t, u);
            viewElements.chart.Series[2 * numEq + 1].Points.AddXY(t, v);

            viewElements.chartPhase.Series[3 * numEq].Points.AddXY(u, v);
        }

        /// <summary>
        /// Plots nullclines
        /// </summary>
        private void plotNullclines(ODE obj, int numEq)
        {
            for (int j = 0; j < obj.N; j++)
            {
                double un = obj.getUN(j);

                viewElements.chartPhase.Series[3 * numEq + 1].Points.AddXY(un, obj.getV1(j));
                viewElements.chartPhase.Series[3 * numEq + 2].Points.AddXY(un, obj.getV2(j));
            }
        }

        /// <summary>
        /// Clears all the plot data
        /// </summary>
        public override void clearPlot()
        {
            base.clearPlot();

            for (int i = 0; i < viewElements.chartPhase.Series.Count(); i++)
                viewElements.chartPhase.Series[i].Points.Clear();
        }

        /// <summary>
        /// Clears all the plot data except nullclines
        /// </summary>
        private void clearAllButNullclines()
        {
            base.clearPlot();

            for (int i = 0; i < 2; i++)
                viewElements.chartPhase.Series[3 * i].Points.Clear();
        }

        /// <summary>
        /// Clears nullclines
        /// </summary>
        private void clearNullclines()
        {
            for (int i = 0; i < 2; i++)
            {
                viewElements.chartPhase.Series[3 * i + 1].Points.Clear();
                viewElements.chartPhase.Series[3 * i + 2].Points.Clear();
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
    }
}
