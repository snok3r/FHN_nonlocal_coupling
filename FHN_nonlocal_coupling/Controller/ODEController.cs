using System;
using System.Linq;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using FHN_nonlocal_coupling.Model;

namespace FHN_nonlocal_coupling.Controller
{
    class ODEController : AbstractController<ODE>
    {
        private Chart chartPhase;

        public ODEController(
            Chart chart,
            Chart chartPhase, 
            PropertyGrid pg1, 
            PropertyGrid pg2, 
            ProgressBar progressBar, 
            TrackBar trackBar) 
            : base(chart, pg1, pg2, progressBar, trackBar)
        { this.chartPhase = chartPhase; }

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
        /// Checking whether arrays need to be
        /// reallocated, if yes returns true
        /// </summary>
        public override void toReload(String label)
        {
            HashSet<String> hs = new HashSet<String>(new String[] { "N", "T", "L" });

            if (hs.Contains(label))
                reload = true;
            else
                reload = false;
        }

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
                trackBar.Value = 0;

                clearPlot();

                for (int i = 0; i < fhn.Length; i++)
                    for (int j = 0; j < fhn[i].N; j++)
                        plot(j, (ODE)fhn[i], i);
            }

            for (int i = 0; i < fhn.Length; i++)
                plotNullclines((ODE)fhn[i], i);
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
                    plot(j, (ODE)fhn[i], i);
        }

        /// <summary>
        /// Plots single point according to trackBar,
        /// useful with TimerTick event
        /// </summary>
        public override void plot()
        {
            if (trackBar.Value == 0)
                clearAllButNullclines();

            if (trackBar.Value < trackBarMax())
            {
                trackBar.Value++;
                for (int i = 0; i < fhn.Length; i++)
                    plot(trackBar.Value, (ODE)fhn[i], i);
            }
            else
                trackBar.Value = 0;
        }

        /// <summary>
        /// Plots single point on t plot and phase plane
        /// </summary>
        private void plot(int j, ODE obj, int numEq)
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
        private void plotNullclines(ODE obj, int numEq)
        {
            for (int j = 0; j < obj.N; j++)
            {
                double un = obj.getUN(j);

                chartPhase.Series[3 * numEq + 1].Points.AddXY(un, obj.getV1(j));
                chartPhase.Series[3 * numEq + 2].Points.AddXY(un, obj.getV2(j));
            }
        }

        /// <summary>
        /// Clears all the plot data
        /// </summary>
        public override void clearPlot()
        {
            for (int i = 0; i < chart.Series.Count(); i++)
                chart.Series[i].Points.Clear();

            for (int i = 0; i < chartPhase.Series.Count(); i++)
                chartPhase.Series[i].Points.Clear();
        }

        /// <summary>
        /// Clears all the plot data except nullclines
        /// </summary>
        private void clearAllButNullclines()
        {
            for (int i = 0; i < chart.Series.Count(); i++)
                chart.Series[i].Points.Clear();

            for (int i = 0; i < 2; i++)
                chartPhase.Series[3 * i].Points.Clear();
        }

        /// <summary>
        /// Clears nullclines
        /// </summary>
        private void clearNullclines()
        {
            for (int i = 0; i < 2; i++)
            {
                chartPhase.Series[3 * i + 1].Points.Clear();
                chartPhase.Series[3 * i + 2].Points.Clear();
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
